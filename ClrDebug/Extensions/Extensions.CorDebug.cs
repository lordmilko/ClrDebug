﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    public partial class CorDebug
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebug"/> class from mscoree for the common language runtime version that is running in the current process, and automatically
        /// calls the <see cref="Initialize"/> method.<para/>
        /// This constructor is only supported on Windows, and simplifies the typical pattern of calling CLRCreateInstance, retrieving a target runtime, followed by retrieving and initializing an ICorDebug interface.<para/>
        /// If this method is called from an STA thread, an <see cref="InvalidOperationException"/> will be thrown, as the ICorDebug API does not support being used from STA threads.<para/>
        /// For greater control over the initialization of the <see cref="CorDebug"/> class,
        /// please see the <see cref="CorDebug(ICorDebug)"/> constructor.
        /// </summary>
        /// <exception cref="InvalidOperationException">The current thread is an STA thread.</exception>
        public CorDebug() : base(Init())
        {
            Initialize();
        }

        private static ICorDebug Init()
        {
            /* In C++, it doesn't technically matter what apartments a COM-style API implements when the objects themselves are implemented in C++: your COM object
             * is simply a vtable into a C++ object. VTables can be called from any thread without issue, nobody is going to enforce unnecessary marshalling upon you.
             * The real issue appears when consuming COM objects from C#: the CLR makes note of which apartment a given object is created on, and automatically "helpfully"
             * attempts to marshal cross-apartment calls for you. When using ComWrappers in .NET 8, potentially you may be able to bypass these restrictions, but when using built-in
             * COM marshalling, you're not going to be able to ignore the rules. And since the managed/unmanaged callback threads will occur on secondary threads, attempting to use
             * any COM objects you already have from within a callback thread (which may be necessary in order to Continue, etc) will cause the CLR to explode. Thus, we enforce
             * that these objects should simply be created from within an MTA thread */
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                throw new InvalidOperationException($"The ICorDebug API cannot be used from an STA thread. Please create a new thread and initialize ICorDebug from there. For more information, please see https://web.archive.org/web/20140422174916/http://blogs.msdn.com/b/jmstall/archive/2005/09/15/icordebug-mta-sta.aspx");

            var metaHost = CLRCreateInstance().CLRMetaHost;
            var runtime = metaHost.GetRuntime();

            return runtime.GetInterface<ICorDebug>(CLSID_CLRDebuggingLegacy);
        }
    }

    public static partial class Extensions
    {
        /// <summary>
        /// Launches a process and its primary thread under the control of the debugger.<para/>
        /// For simplicity, this method omits the lpApplicationName and lpProcessInformation parameters. If you wish to specify these parameters, call the normal CorDebug.CreateProcess method directly.
        /// </summary>
        /// <param name="corDebug">The <see cref="CorDebug"/> instance that should be used to create the process.</param>
        /// <param name="lpCommandLine">[in] Pointer to a null-terminated string that specifies the command line to be executed by the launched process.<para/>
        /// The application name (for example, "SomeApp.exe") must be the first argument.</param>
        /// <param name="lpProcessAttributes">[in] Pointer to a Win32 <see cref="SECURITY_ATTRIBUTES"/> structure that specifies the security descriptor for the process. If lpProcessAttributes is null, the process gets a default security descriptor.</param>
        /// <param name="lpThreadAttributes">[in] Pointer to a Win32 <see cref="SECURITY_ATTRIBUTES"/> structure that specifies the security descriptor for the primary thread of the process.<para/>
        /// If lpThreadAttributes is null, the thread gets a default security descriptor.</param>
        /// <param name="bInheritHandles">[in] Set to true to indicate that each inheritable handle in the calling process is inherited by the launched process, or false to indicate that the handles are not inherited.<para/>
        /// The inherited handles have the same value and access rights as the original handles.</param>
        /// <param name="dwCreationFlags">[in] A bitwise combination of the Win32 Process Creation Flags that control the priority class and the behavior of the launched process.</param>
        /// <param name="lpEnvironment">[in] Pointer to an environment block for the new process.</param>
        /// <param name="lpCurrentDirectory">[in] Pointer to a null-terminated string that specifies the full path to the current directory for the process.<para/>
        /// If this parameter is null, the new process will have the same current drive and directory as the calling process.</param>
        /// <param name="lpStartupInfo">[in] Pointer to a Win32 STARTUPINFOW structure that specifies the window station, desktop, standard handles, and appearance of the main window for the launched process.</param>
        /// <param name="debuggingFlags">[in] A value of the <see cref="CorDebugCreateProcessFlags"/> enumeration that specifies the debugging options.</param>
        /// <param name="closeHandle">A method capable of freeing the <see cref="PROCESS_INFORMATION.hProcess"/> and <see cref="PROCESS_INFORMATION.hThread"/> handles created for the process.<para/>
        /// On non-Windows platforms, this value must be provided. On Windows, if no value is provided, the Win32 function CloseHandle() will automatically be used.</param>
        /// <returns>[out] A pointer to the address of a <see cref="ICorDebugProcess"/> object that represents the process.</returns>
        public static CorDebugProcess CreateProcess(
            this CorDebug corDebug,
            string lpCommandLine,
            SECURITY_ATTRIBUTES? lpProcessAttributes = null,
            SECURITY_ATTRIBUTES? lpThreadAttributes = null,
            bool bInheritHandles = true,
            CreateProcessFlags dwCreationFlags = 0,
            IntPtr? lpEnvironment = null,
            string lpCurrentDirectory = null,
            STARTUPINFOW? lpStartupInfo = null,
            CorDebugCreateProcessFlags debuggingFlags = CorDebugCreateProcessFlags.DEBUG_NO_SPECIAL_OPTIONS,
            Action<IntPtr> closeHandle = null)
        {
            var processAttribs = lpProcessAttributes ?? new SECURITY_ATTRIBUTES();
            var threadAttribs = lpThreadAttributes ?? new SECURITY_ATTRIBUTES();
            var env = lpEnvironment ?? IntPtr.Zero;
            var pi = new PROCESS_INFORMATION();

            STARTUPINFOW si;

            if (lpStartupInfo == null)
            {
                si = new STARTUPINFOW
                {
                    cb = Marshal.SizeOf<STARTUPINFOW>()
                };
            }
            else
                si = lpStartupInfo.Value;

            CorDebugProcess process;

            var hr = corDebug.TryCreateProcess(
                null,
                lpCommandLine,
                processAttribs,
                threadAttribs,
                bInheritHandles,
                dwCreationFlags,
                env,
                lpCurrentDirectory,
                si,
                ref pi,
                debuggingFlags,
                out process
            );

            if (hr != HRESULT.S_OK)
            {
                if (hr == HRESULT.E_FAIL)
                    throw new InvalidOperationException($"Failed to create process: '{nameof(CorDebug)}.{nameof(CorDebug.Initialize)}' and '{nameof(CorDebug)}.{nameof(CorDebug.SetManagedHandler)}' must be called first.");

                hr.ThrowOnNotOK();
            }
            else
            {
#if GENERATED_MARSHALLING
                closeHandle = closeHandle ?? (h => NativeMethods.CloseHandle(h));
#else
                if (closeHandle == null)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        closeHandle = h => NativeMethods.CloseHandle(h);
                    else
                        throw new ArgumentException($"On non-Windows platforms, parameter '{nameof(closeHandle)}' must be specified.", nameof(closeHandle));
                }
#endif

                if (pi.hProcess != IntPtr.Zero)
                    closeHandle(pi.hProcess);

                if (pi.hThread != IntPtr.Zero)
                    closeHandle(pi.hThread);
            }

            return process;
        }
    }
}
