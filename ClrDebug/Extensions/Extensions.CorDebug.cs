using System;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    public partial class CorDebug
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebug"/> class for the common language runtime version that is running in the current process, and automatically
        /// calls the <see cref="Initialize"/> method.<para/>
        /// This constructor simplifies the typical pattern of calling CLRCreateInstance, retrieving a target runtime, followed by retrieving and initializing an ICorDebug interface.<para/>
        /// For greater control over the initialization of the <see cref="CorDebug"/> class,
        /// please see the <see cref="CorDebug(ICorDebug)"/> constructor.
        /// </summary>
        public CorDebug() : base(Init())
        {
            Initialize();
        }

        private static ICorDebug Init()
        {
            var metaHost = CLRCreateInstance().CLRMetaHost;
            var runtime = metaHost.GetRuntime();

            return runtime.GetInterface<ICorDebug>(CLSID_CLRDebuggingLegacy);
        }
    }

    public static partial class Extensions
    {
        /// <summary>
        /// Launches a process and its primary thread under the control of the debugger.<para/>
        /// For simplicity, this method omits the lpApplicationName parameter. If you wish to specify this parameter, call the normal CorDebug.CreateProcess method directly.
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
        /// <param name="lpProcessInformation">[in] Pointer to a Win32 <see cref="PROCESS_INFORMATION"/> structure that specifies the identification information about the process to be launched.</param>
        /// <param name="debuggingFlags">[in] A value of the <see cref="CorDebugCreateProcessFlags"/> enumeration that specifies the debugging options.</param>
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
            STARTUPINFO? lpStartupInfo = null,
            PROCESS_INFORMATION? lpProcessInformation = null,
            CorDebugCreateProcessFlags debuggingFlags = CorDebugCreateProcessFlags.DEBUG_NO_SPECIAL_OPTIONS)
        {
            var processAttribs = lpProcessAttributes ?? new SECURITY_ATTRIBUTES();
            var threadAttribs = lpThreadAttributes ?? new SECURITY_ATTRIBUTES();
            var env = lpEnvironment ?? IntPtr.Zero;
            var pi = lpProcessInformation ?? new PROCESS_INFORMATION();

            STARTUPINFO si;

            if (lpStartupInfo == null)
            {
                si = new STARTUPINFO
                {
                    cb = Marshal.SizeOf<STARTUPINFO>()
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
                pi,
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
                if (pi.hProcess != IntPtr.Zero)
                    NativeMethods.CloseHandle(pi.hProcess);

                if (pi.hThread != IntPtr.Zero)
                    NativeMethods.CloseHandle(pi.hThread);
            }

            return process;
        }
    }
}
