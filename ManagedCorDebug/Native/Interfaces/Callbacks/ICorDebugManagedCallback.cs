using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to process debugger callbacks.
    /// </summary>
    /// <remarks>
    /// All callbacks are serialized, called in the same thread, and called with the process in the synchronized state.
    /// Each callback implementation must call <see cref="ICorDebugController.Continue"/> to resume execution. If <see cref="ICorDebugController.Continue"/>
    /// is not called before the callback returns, the process will remain stopped and no more event callbacks will occur
    /// until <see cref="ICorDebugController.Continue"/> is called. A debugger must implement <see cref="ICorDebugManagedCallback2"/>
    /// if it is debugging .NET Framework version 2.0 applications. An instance of <see cref="ICorDebugManagedCallback"/> or <see cref="ICorDebugManagedCallback2"/>
    /// is passed as the callback object to <see cref="ICorDebug.SetManagedHandler"/>.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3D6F5F60-7538-11D3-8D5B-00104B35E7EF")]
    [ComImport]
    public interface ICorDebugManagedCallback
    {
        /// <summary>
        /// Notifies the debugger when a breakpoint is encountered.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the breakpoint.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the breakpoint.</param>
        /// <param name="pBreakpoint">[in] A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the breakpoint.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Breakpoint(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint);

        /// <summary>
        /// Notifies the debugger that a step has completed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread in which the step has completed.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the step has completed.</param>
        /// <param name="pStepper">[in] A pointer to an <see cref="ICorDebugStepper"/> object that represents the step in code execution.</param>
        /// <param name="reason">[in] A value of the <see cref="CorDebugStepReason"/> enumeration that indicates the outcome of an individual step.</param>
        /// <remarks>
        /// The stepper may be used to continue stepping if desired, unless the debugging is terminated.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StepComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugStepper pStepper,
            [In] CorDebugStepReason reason);

        /// <summary>
        /// Notifies the debugger when a <see cref="OpCodes.Break"/> instruction in the code stream is executed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the break instruction.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the break instruction.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Break([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        /// <summary>
        /// Notifies the debugger that an exception has been thrown from managed code.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the exception was thrown.</param>
        /// <param name="unhandled">[in] If this value is false, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.</param>
        /// <remarks>
        /// The specific exception can be retrieved from the thread object.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Exception([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [In] int unhandled);

        /// <summary>
        /// Notifies the debugger that an evaluation has been completed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation was performed.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation was performed.</param>
        /// <param name="pEval">[in] A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EvalComplete([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);

        /// <summary>
        /// Notifies the debugger that an evaluation has terminated with an unhandled exception.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation terminated.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation terminated.</param>
        /// <param name="pEval">[in] A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EvalException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);

        /// <summary>
        /// Notifies the debugger when a process has been attached or started for the first time.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that has been attached or started.</param>
        /// <remarks>
        /// This method is not called until the common language runtime is initialized. Most of the <see cref="ICorDebug"/>
        /// methods will return CORDBG_E_NOTREADY before the CreateProcess callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        /// <summary>
        /// Notifies the debugger that a process has exited.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process.</param>
        /// <remarks>
        /// You cannot continue from an ExitProcess event. This event may fire asynchronously to other events while the process
        /// appears to be stopped. This can occur if the process terminates while stopped, usually due to some external force.
        /// If the common language runtime (CLR) is already dispatching a managed callback, this event will be delayed until
        /// after that callback has returned. The ExitProcess event is the only exit/unload event that is guaranteed to get
        /// called on shutdown.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExitProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        /// <summary>
        /// Notifies the debugger that a thread has started executing managed code.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the thread.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        /// <remarks>
        /// The thread will be positioned at the first managed code instruction to be executed.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        /// <summary>
        /// Notifies the debugger that a thread that was executing managed code has exited.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <remarks>
        /// Once the ExitThread callback is fired, the thread will no longer appear in thread enumerations.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExitThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) module has been successfully loaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the module has been loaded.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the CLR module.</param>
        /// <remarks>
        /// The LoadModule callback provides an appropriate time to examine metadata for the module, set just-in-time (JIT)
        /// compiler flags, or enable or disable class loading callbacks for the module.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);

        /// <summary>
        /// Notifies the debugger that a common language runtime module (DLL) has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the module.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the module.</param>
        /// <remarks>
        /// The module should not be used after this call.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnloadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);

        /// <summary>
        /// Notifies the debugger that a class has been loaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the class has been loaded.</param>
        /// <param name="c">[in] A pointer to an <see cref="ICorDebugClass"/> object that represents the class.</param>
        /// <remarks>
        /// This callback occurs only if class loading has been enabled for the module that contains the class. Class loading
        /// is always enabled for dynamic modules. The LoadClass callback provides an appropriate time to bind breakpoints
        /// to newly generated classes in dynamic modules.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);

        /// <summary>
        /// Notifies the debugger that a class is being unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the class.</param>
        /// <param name="c">[in] A pointer to an <see cref="ICorDebugClass"/> object that represents the class.</param>
        /// <remarks>
        /// The class should not be referenced after this call.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnloadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);

        /// <summary>
        /// Notifies the debugger that an error has occurred while attempting to handle an event from the common language runtime (CLR).
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process in which the event occurred.</param>
        /// <param name="errorHR">[in] The <see cref="HRESULT"/> value that was returned from the event handler.</param>
        /// <param name="errorCode">[in] An integer that specifies the CLR error.</param>
        /// <remarks>
        /// The process may be placed into pass-through mode, depending on the nature of the error. The DebugError callback
        /// indicates that debugging services have been disabled due to an error, so debuggers should make the error message
        /// available to the user. <see cref="ICorDebugProcess.GetID"/> will be safe to call, but all other methods, including
        /// <see cref="ICorDebug.Terminate"/>, should not be called. The debugger should use operating-system facilities for
        /// terminating processes.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DebuggerError([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Error), In] HRESULT errorHR, [In] int errorCode);

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="EventLog"/> class to log an event.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that logged the event.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">[in] A value of the <see cref="LoggingLevelEnum"/> enumeration that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="pLogSwitchName">[in] A pointer to the name of the tracing switch.</param>
        /// <param name="pMessage">[in] A pointer to the message that was written to the event log.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LogMessage(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] LoggingLevelEnum lLevel,
            [MarshalAs(UnmanagedType.LPWStr), In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pMessage);

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="Switch"/> class to create, modify, or delete a debugging/tracing switch.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that created, modified, or deleted a debugging/tracing switch.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">[in] A value that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="ulReason">[in] A value of the <see cref="LogSwitchCallReason"/> enumeration that indicates the operation performed on the debugging/tracing switch.</param>
        /// <param name="pLogSwitchName">[in] A pointer to the name of the debugging/tracing switch.</param>
        /// <param name="pParentName">[in] A pointer to the name of the parent of the debugging/tracing switch.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LogSwitch(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] int lLevel,
            [In] LogSwitchCallReason ulReason,
            [MarshalAs(UnmanagedType.LPWStr)]  [In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pParentName);

        /// <summary>
        /// Notifies the debugger that an application domain has been created.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the application domain was created.</param>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has been created.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);

        /// <summary>
        /// Notifies the debugger that an application domain has exited.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that contains the given application domain.</param>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has exited.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExitAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) assembly has been successfully loaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the assembly has been loaded.</param>
        /// <param name="pAssembly">[in] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);

        /// <summary>
        /// Notifies the debugger that a common language runtime assembly has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the assembly.</param>
        /// <param name="pAssembly">[in] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        /// <remarks>
        /// The assembly should not be used after this callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnloadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);

        /// <summary>
        /// Notifies the debugger that a CTRL+C is trapped in the process that is being debugged.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the CTRL+C is trapped.</param>
        /// <returns>
        /// | HRESULT | Description                                   |
        /// | ------- | --------------------------------------------- |
        /// | S_OK    | The debugger will handle the CTRL+C trap.     |
        /// | S_FALSE | The debugger will not handle the CTRL+C trap. |
        /// </returns>
        /// <remarks>
        /// All application domains within the process are stopped for this callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ControlCTrap([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        /// <summary>
        /// Notifies the debugger that the name of either an application domain or a thread has changed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that either had a name change or that contains the thread that had a name change.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that had a name change.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NameChange([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread);

        /// <summary>
        /// Notifies the debugger that the symbols for a common language runtime module have changed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the module in which the symbols have changed.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the module in which the symbols have changed.</param>
        /// <param name="pSymbolStream">[in] A pointer to a Win32 COM <see cref="IStream"/> object that contains the modified symbols.</param>
        /// <remarks>
        /// This method provides an opportunity to update the debugger's view of a module's symbols by calling <see cref="ISymUnmanagedReader.UpdateSymbolStore"/>
        /// or <see cref="ISymUnmanagedReader.ReplaceSymbolStore"/>. This callback can occur multiple times for the same module.
        /// A debugger should try to bind unbound source-level breakpoints.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UpdateModuleSymbols(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pSymbolStream);

        /// <summary>
        /// This method has been deprecated. It notifies the debugger that a remap event has been sent to the integrated development environment (IDE).
        /// </summary>
        /// <remarks>
        /// The EditAndContinueRemap method is called when the execution of the code in an old version of an updated function
        /// has been attempted. The common language runtime calls the EditAndContinueRemap method to send a remap event to
        /// the IDE.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EditAndContinueRemap(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] int fAccurate);

        /// <summary>
        /// Notifies the debugger that the common language runtime was unable to accurately bind a breakpoint that was set before a function was just-in-time (JIT) compiled.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the unbound breakpoint.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the unbound breakpoint.</param>
        /// <param name="pBreakpoint">[in] A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the unbound breakpoint.</param>
        /// <param name="dwError">[in] An integer that indicates the error.</param>
        /// <remarks>
        /// The given breakpoint will never be hit. The debugger should deactivate and rebind it.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT BreakpointSetError(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint,
            [In] int dwError);
    }
}