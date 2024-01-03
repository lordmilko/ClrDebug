using System;
using System.Diagnostics;
using System.Linq;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that allow developers to debug applications in the common language runtime (CLR) environment.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebug"/> represents an event processing loop for a debugger process. The debugger must wait for the <see cref="ICorDebugManagedCallback.ExitProcess"/>
    /// callback from all processes being debugged before releasing this interface. The <see cref="ICorDebug"/> object is the initial
    /// object to control all further managed debugging. In the .NET Framework versions 1.0 and 1.1, this object was a
    /// CoClass object created from COM. In the .NET Framework version 2.0, this object is no longer a CoClass object.
    /// It must be created by the CreateDebuggingInterfaceFromVersion function, which is more version-aware. This new creation
    /// function enables clients to get a specific implementation of <see cref="ICorDebug"/>, which also emulates a specific version
    /// of the debugging API.
    /// </remarks>
    public partial class CorDebug : ComObject<ICorDebug>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebug"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebug(ICorDebug raw) : base(raw)
        {
        }

        #region ICorDebug
        #region Initialize

        /// <summary>
        /// Initializes the <see cref="ICorDebug"/> object.
        /// </summary>
        /// <remarks>
        /// The debugger must call Initialize at creation time to initialize the debugging services. This method must be called
        /// before any other method on <see cref="ICorDebug"/> is called.
        /// </remarks>
        public void Initialize()
        {
            TryInitialize().ThrowOnNotOK();
        }

        /// <summary>
        /// Initializes the <see cref="ICorDebug"/> object.
        /// </summary>
        /// <remarks>
        /// The debugger must call Initialize at creation time to initialize the debugging services. This method must be called
        /// before any other method on <see cref="ICorDebug"/> is called.
        /// </remarks>
        public HRESULT TryInitialize()
        {
            /*HRESULT Initialize();*/
            return Raw.Initialize();
        }

        #endregion
        #region Terminate

        /// <summary>
        /// Terminates the <see cref="ICorDebug"/> object.
        /// </summary>
        /// <remarks>
        /// Terminate must be called when the <see cref="ICorDebug"/> object is no longer needed.
        /// </remarks>
        public void Terminate()
        {
            TryTerminate().ThrowOnNotOK();
        }

        /// <summary>
        /// Terminates the <see cref="ICorDebug"/> object.
        /// </summary>
        /// <remarks>
        /// Terminate must be called when the <see cref="ICorDebug"/> object is no longer needed.
        /// </remarks>
        public HRESULT TryTerminate()
        {
            /*HRESULT Terminate();*/
            return Raw.Terminate();
        }

        #endregion
        #region SetManagedHandler

        /// <summary>
        /// Specifies the event handler object for managed events.
        /// </summary>
        /// <param name="pCallback">[in] A pointer to an <see cref="ICorDebugManagedCallback"/> object, which is the event handler object.</param>
        /// <remarks>
        /// SetManagedHandler must be called at creation time. If the <see cref="ICorDebugManagedCallback"/> implementation does not contain
        /// sufficient interfaces to handle debugging events for the application that is being debugged, SetManagedHandler
        /// returns an <see cref="HRESULT"/> of E_NOINTERFACE.
        /// </remarks>
        public void SetManagedHandler(ICorDebugManagedCallback pCallback)
        {
            TrySetManagedHandler(pCallback).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the event handler object for managed events.
        /// </summary>
        /// <param name="pCallback">[in] A pointer to an <see cref="ICorDebugManagedCallback"/> object, which is the event handler object.</param>
        /// <remarks>
        /// SetManagedHandler must be called at creation time. If the <see cref="ICorDebugManagedCallback"/> implementation does not contain
        /// sufficient interfaces to handle debugging events for the application that is being debugged, SetManagedHandler
        /// returns an <see cref="HRESULT"/> of E_NOINTERFACE.
        /// </remarks>
        public HRESULT TrySetManagedHandler(ICorDebugManagedCallback pCallback)
        {
            /*HRESULT SetManagedHandler(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugManagedCallback pCallback);*/
            return Raw.SetManagedHandler(pCallback);
        }

        #endregion
        #region SetUnmanagedHandler

        /// <summary>
        /// Specifies the event handler object for unmanaged events.
        /// </summary>
        /// <param name="pCallback">[in] A pointer to an <see cref="ICorDebugUnmanagedCallback"/> object that represents the event handler for unmanaged events.</param>
        /// <remarks>
        /// The event handler object for unmanaged events must be set after a call to <see cref="Initialize"/> and before any
        /// calls to <see cref="CreateProcess"/> or <see cref="DebugActiveProcess"/>. However, for legacy purposes, you are
        /// not required to set the event handler object for unmanaged events until the first native debug event is raised.
        /// Specifically, if <see cref="CreateProcess"/> has set the CREATE_SUSPENDED flag, native debug events cannot be dispatched
        /// until the main thread is resumed.
        /// </remarks>
        public void SetUnmanagedHandler(ICorDebugUnmanagedCallback pCallback)
        {
            TrySetUnmanagedHandler(pCallback).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the event handler object for unmanaged events.
        /// </summary>
        /// <param name="pCallback">[in] A pointer to an <see cref="ICorDebugUnmanagedCallback"/> object that represents the event handler for unmanaged events.</param>
        /// <remarks>
        /// The event handler object for unmanaged events must be set after a call to <see cref="Initialize"/> and before any
        /// calls to <see cref="CreateProcess"/> or <see cref="DebugActiveProcess"/>. However, for legacy purposes, you are
        /// not required to set the event handler object for unmanaged events until the first native debug event is raised.
        /// Specifically, if <see cref="CreateProcess"/> has set the CREATE_SUSPENDED flag, native debug events cannot be dispatched
        /// until the main thread is resumed.
        /// </remarks>
        public HRESULT TrySetUnmanagedHandler(ICorDebugUnmanagedCallback pCallback)
        {
            /*HRESULT SetUnmanagedHandler(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugUnmanagedCallback pCallback);*/
            return Raw.SetUnmanagedHandler(pCallback);
        }

        #endregion
        #region CreateProcess

        /// <summary>
        /// Launches a process and its primary thread under the control of the debugger.
        /// </summary>
        /// <param name="lpApplicationName">[in] Pointer to a null-terminated string that specifies the module to be executed by the launched process. The module is executed in the security context of the calling process.</param>
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
        /// <remarks>
        /// The parameters of this method are the same as those of the Win32 CreateProcess method. To enable unmanaged mixed-mode
        /// debugging, set dwCreationFlags to DEBUG_PROCESS DEBUG_ONLY_THIS_PROCESS. If you want to use only managed debugging,
        /// do not set these flags. If the debugger and the process to be debugged (the attached process) share a single console,
        /// and if interop debugging is used, it is possible for the attached process to hold console locks and stop at a debug
        /// event. The debugger will then block any attempt to use the console. To avoid this problem, set the CREATE_NEW_CONSOLE
        /// flag in the dwCreationFlags parameter. Interop debugging is not supported on Win9x and non-x86 platforms such as
        /// IA-64-based and AMD64-based platforms.
        /// </remarks>
        public CorDebugProcess CreateProcess(string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, CreateProcessFlags dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, STARTUPINFOW lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags)
        {
            CorDebugProcess ppProcessResult;
            TryCreateProcess(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, ref lpProcessInformation, debuggingFlags, out ppProcessResult).ThrowOnNotOK();

            return ppProcessResult;
        }

        /// <summary>
        /// Launches a process and its primary thread under the control of the debugger.
        /// </summary>
        /// <param name="lpApplicationName">[in] Pointer to a null-terminated string that specifies the module to be executed by the launched process. The module is executed in the security context of the calling process.</param>
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
        /// <param name="ppProcessResult">[out] A pointer to the address of a <see cref="ICorDebugProcess"/> object that represents the process.</param>
        /// <remarks>
        /// The parameters of this method are the same as those of the Win32 CreateProcess method. To enable unmanaged mixed-mode
        /// debugging, set dwCreationFlags to DEBUG_PROCESS DEBUG_ONLY_THIS_PROCESS. If you want to use only managed debugging,
        /// do not set these flags. If the debugger and the process to be debugged (the attached process) share a single console,
        /// and if interop debugging is used, it is possible for the attached process to hold console locks and stop at a debug
        /// event. The debugger will then block any attempt to use the console. To avoid this problem, set the CREATE_NEW_CONSOLE
        /// flag in the dwCreationFlags parameter. Interop debugging is not supported on Win9x and non-x86 platforms such as
        /// IA-64-based and AMD64-based platforms.
        /// </remarks>
        public HRESULT TryCreateProcess(string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, CreateProcessFlags dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, STARTUPINFOW lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT CreateProcess(
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref SECURITY_ATTRIBUTES lpThreadAttributes,
            [In, MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
            [In] CreateProcessFlags dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [In] ref STARTUPINFOW lpStartupInfo,
            [In, Out] ref PROCESS_INFORMATION lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.CreateProcess(lpApplicationName, lpCommandLine, ref lpProcessAttributes, ref lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, ref lpProcessInformation, debuggingFlags, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = ppProcess == null ? null : new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region DebugActiveProcess

        /// <summary>
        /// Attaches the debugger to an existing process.
        /// </summary>
        /// <param name="id">[in] The ID of the process to which the debugger is to be attached.</param>
        /// <param name="win32Attach">[in] Boolean value that is set to true if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, false.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.</returns>
        /// <remarks>
        /// Interop debugging is not supported on Win9x and non-x86 platforms, such as IA-64-based and AMD64-based platforms.
        /// </remarks>
        public CorDebugProcess DebugActiveProcess(int id, bool win32Attach)
        {
            CorDebugProcess ppProcessResult;
            TryDebugActiveProcess(id, win32Attach, out ppProcessResult).ThrowOnNotOK();

            return ppProcessResult;
        }

        /// <summary>
        /// Attaches the debugger to an existing process.
        /// </summary>
        /// <param name="id">[in] The ID of the process to which the debugger is to be attached.</param>
        /// <param name="win32Attach">[in] Boolean value that is set to true if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, false.</param>
        /// <param name="ppProcessResult">[out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.</param>
        /// <remarks>
        /// Interop debugging is not supported on Win9x and non-x86 platforms, such as IA-64-based and AMD64-based platforms.
        /// </remarks>
        public HRESULT TryDebugActiveProcess(int id, bool win32Attach, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT DebugActiveProcess(
            [In] int id,
            [In, MarshalAs(UnmanagedType.Bool)] bool win32Attach,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.DebugActiveProcess(id, win32Attach, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = ppProcess == null ? null : new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region EnumerateProcesses

        /// <summary>
        /// Gets an enumerator for the processes that are being debugged.
        /// </summary>
        public CorDebugProcess[] Processes => EnumerateProcesses().ToArray();

        /// <summary>
        /// Gets an enumerator for the processes that are being debugged.
        /// </summary>
        /// <returns>A pointer to the address of an <see cref="ICorDebugProcessEnum"/> object that is the enumerator for the processes being debugged.</returns>
        public CorDebugProcessEnum EnumerateProcesses()
        {
            CorDebugProcessEnum ppProcessResult;
            TryEnumerateProcesses(out ppProcessResult).ThrowOnNotOK();

            return ppProcessResult;
        }

        /// <summary>
        /// Gets an enumerator for the processes that are being debugged.
        /// </summary>
        /// <param name="ppProcessResult">A pointer to the address of an <see cref="ICorDebugProcessEnum"/> object that is the enumerator for the processes being debugged.</param>
        public HRESULT TryEnumerateProcesses(out CorDebugProcessEnum ppProcessResult)
        {
            /*HRESULT EnumerateProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcessEnum ppProcess);*/
            ICorDebugProcessEnum ppProcess;
            HRESULT hr = Raw.EnumerateProcesses(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = ppProcess == null ? null : new CorDebugProcessEnum(ppProcess);
            else
                ppProcessResult = default(CorDebugProcessEnum);

            return hr;
        }

        #endregion
        #region GetProcess

        /// <summary>
        /// Gets a pointer to the "ICorDebugProcess" instance for the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The ID of the process.</param>
        /// <returns>[out] A pointer to the address of a <see cref="ICorDebugProcess"/> instance for the specified process.</returns>
        public CorDebugProcess GetProcess(int dwProcessId)
        {
            CorDebugProcess ppProcessResult;
            TryGetProcess(dwProcessId, out ppProcessResult).ThrowOnNotOK();

            return ppProcessResult;
        }

        /// <summary>
        /// Gets a pointer to the "ICorDebugProcess" instance for the specified process.
        /// </summary>
        /// <param name="dwProcessId">[in] The ID of the process.</param>
        /// <param name="ppProcessResult">[out] A pointer to the address of a <see cref="ICorDebugProcess"/> instance for the specified process.</param>
        public HRESULT TryGetProcess(int dwProcessId, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess(
            [In] int dwProcessId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(dwProcessId, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = ppProcess == null ? null : new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region CanLaunchOrAttach

        /// <summary>
        /// Returns an <see cref="HRESULT"/> that indicates whether launching a new process or attaching to the specified existing process is possible within the context of the current machine and runtime configuration.
        /// </summary>
        /// <param name="dwProcessId">[in] The ID of an existing process.</param>
        /// <param name="win32DebuggingEnabled">[in] Pass in true if you plan to launch with Win32 debugging enabled, or to attach with Win32 debugging enabled; otherwise, pass false.</param>
        /// <remarks>
        /// This method is purely informational. The interface will not stop you from launching or attaching to a process,
        /// regardless of the value returned by CanLaunchOrAttach. If you plan to launch with Win32 debugging enabled or attach
        /// with Win32 debugging enabled, pass true for win32DebuggingEnabled. The <see cref="HRESULT"/> returned by CanLaunchOrAttach might
        /// differ if you use this option.
        /// </remarks>
        public void CanLaunchOrAttach(int dwProcessId, int win32DebuggingEnabled)
        {
            TryCanLaunchOrAttach(dwProcessId, win32DebuggingEnabled).ThrowOnNotOK();
        }

        /// <summary>
        /// Returns an <see cref="HRESULT"/> that indicates whether launching a new process or attaching to the specified existing process is possible within the context of the current machine and runtime configuration.
        /// </summary>
        /// <param name="dwProcessId">[in] The ID of an existing process.</param>
        /// <param name="win32DebuggingEnabled">[in] Pass in true if you plan to launch with Win32 debugging enabled, or to attach with Win32 debugging enabled; otherwise, pass false.</param>
        /// <returns>
        /// S_OK if the debugging services determine that launching a new process or attaching to the given process is possible, given the information about the current machine and runtime configuration.
        /// Possible <see cref="HRESULT"/> values are:
        /// * S_OK
        /// * CORDBG_E_DEBUGGING_NOT_POSSIBLE
        /// * CORDBG_E_KERNEL_DEBUGGER_PRESENT
        /// * CORDBG_E_KERNEL_DEBUGGER_ENABLED
        /// </returns>
        /// <remarks>
        /// This method is purely informational. The interface will not stop you from launching or attaching to a process,
        /// regardless of the value returned by CanLaunchOrAttach. If you plan to launch with Win32 debugging enabled or attach
        /// with Win32 debugging enabled, pass true for win32DebuggingEnabled. The <see cref="HRESULT"/> returned by CanLaunchOrAttach might
        /// differ if you use this option.
        /// </remarks>
        public HRESULT TryCanLaunchOrAttach(int dwProcessId, int win32DebuggingEnabled)
        {
            /*HRESULT CanLaunchOrAttach(
            [In] int dwProcessId,
            [In] int win32DebuggingEnabled);*/
            return Raw.CanLaunchOrAttach(dwProcessId, win32DebuggingEnabled);
        }

        #endregion
        #endregion
        #region ICorDebug2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebug2 Raw2 => (ICorDebug2) Raw;

        #endregion
    }
}
