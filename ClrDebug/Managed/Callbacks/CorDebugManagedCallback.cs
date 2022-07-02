using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to process debugger callbacks.
    /// </summary>
    /// <remarks>
    /// All callbacks are serialized, called in the same thread, and called with the process in the synchronized state.
    /// Each callback implementation must call <see cref="CorDebugController.Continue"/> to resume execution. If <see cref="CorDebugController.Continue"/>
    /// is not called before the callback returns, the process will remain stopped and no more event callbacks will occur
    /// until <see cref="CorDebugController.Continue"/> is called. A debugger must implement <see cref="ICorDebugManagedCallback2"/>
    /// if it is debugging .NET Framework version 2.0 applications. An instance of <see cref="ICorDebugManagedCallback"/> or <see cref="ICorDebugManagedCallback2"/>
    /// is passed as the callback object to <see cref="CorDebug.SetManagedHandler"/>.
    /// </remarks>
    public class CorDebugManagedCallback : ICorDebugManagedCallback, ICorDebugManagedCallback2, ICorDebugManagedCallback3
    {
        public EventHandler<CorDebugManagedCallbackEventArgs> OnAnyEvent;

        #region ICorDebugManagedCallback EventHandlers

        /// <summary>
        /// Notifies the debugger when a breakpoint is encountered.
        /// </summary>
        public EventHandler<BreakpointCorDebugManagedCallbackEventArgs> OnBreakpoint;

        /// <summary>
        /// Notifies the debugger that a step has completed.
        /// </summary>
        public EventHandler<StepCompleteCorDebugManagedCallbackEventArgs> OnStepComplete;

        /// <summary>
        /// Notifies the debugger when a <see cref="OpCodes.Break"/> instruction in the code stream is executed.
        /// </summary>
        public EventHandler<BreakCorDebugManagedCallbackEventArgs> OnBreak;

        /// <summary>
        /// Notifies the debugger that an exception has been thrown from managed code.
        /// </summary>
        public EventHandler<ExceptionCorDebugManagedCallbackEventArgs> OnException;

        /// <summary>
        /// Notifies the debugger that an evaluation has been completed.
        /// </summary>
        public EventHandler<EvalCompleteCorDebugManagedCallbackEventArgs> OnEvalComplete;

        /// <summary>
        /// Notifies the debugger that an evaluation has terminated with an unhandled exception.
        /// </summary>
        public EventHandler<EvalExceptionCorDebugManagedCallbackEventArgs> OnEvalException;

        /// <summary>
        /// Notifies the debugger when a process has been attached or started for the first time.
        /// </summary>
        public EventHandler<CreateProcessCorDebugManagedCallbackEventArgs> OnCreateProcess;

        /// <summary>
        /// Notifies the debugger that a process has exited.
        /// </summary>
        public EventHandler<ExitProcessCorDebugManagedCallbackEventArgs> OnExitProcess;

        /// <summary>
        /// Notifies the debugger that a thread has started executing managed code.
        /// </summary>
        public EventHandler<CreateThreadCorDebugManagedCallbackEventArgs> OnCreateThread;

        /// <summary>
        /// Notifies the debugger that a thread that was executing managed code has exited.
        /// </summary>
        public EventHandler<ExitThreadCorDebugManagedCallbackEventArgs> OnExitThread;

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) module has been successfully loaded.
        /// </summary>
        public EventHandler<LoadModuleCorDebugManagedCallbackEventArgs> OnLoadModule;

        /// <summary>
        /// Notifies the debugger that a common language runtime module (DLL) has been unloaded.
        /// </summary>
        public EventHandler<UnloadModuleCorDebugManagedCallbackEventArgs> OnUnloadModule;

        /// <summary>
        /// Notifies the debugger that a class has been loaded.
        /// </summary>
        public EventHandler<LoadClassCorDebugManagedCallbackEventArgs> OnLoadClass;

        /// <summary>
        /// Notifies the debugger that a class is being unloaded.
        /// </summary>
        public EventHandler<UnloadClassCorDebugManagedCallbackEventArgs> OnUnloadClass;

        /// <summary>
        /// Notifies the debugger that an error has occurred while attempting to handle an event from the common language runtime (CLR).
        /// </summary>
        public EventHandler<DebuggerErrorCorDebugManagedCallbackEventArgs> OnDebuggerError;

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="EventLog"/> class to log an event.
        /// </summary>
        public EventHandler<LogMessageCorDebugManagedCallbackEventArgs> OnLogMessage;

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="Switch"/> class to create, modify, or delete a debugging/tracing switch.
        /// </summary>
        public EventHandler<LogSwitchCorDebugManagedCallbackEventArgs> OnLogSwitch;

        /// <summary>
        /// Notifies the debugger that an application domain has been created.
        /// </summary>
        public EventHandler<CreateAppDomainCorDebugManagedCallbackEventArgs> OnCreateAppDomain;

        /// <summary>
        /// Notifies the debugger that an application domain has exited.
        /// </summary>
        public EventHandler<ExitAppDomainCorDebugManagedCallbackEventArgs> OnExitAppDomain;

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) assembly has been successfully loaded.
        /// </summary>
        public EventHandler<LoadAssemblyCorDebugManagedCallbackEventArgs> OnLoadAssembly;

        /// <summary>
        /// Notifies the debugger that a common language runtime assembly has been unloaded.
        /// </summary>
        public EventHandler<UnloadAssemblyCorDebugManagedCallbackEventArgs> OnUnloadAssembly;

        /// <summary>
        /// Notifies the debugger that a CTRL+C is trapped in the process that is being debugged.
        /// </summary>
        public EventHandler<ControlCTrapCorDebugManagedCallbackEventArgs> OnControlCTrap;

        /// <summary>
        /// Notifies the debugger that the name of either an application domain or a thread has changed.
        /// </summary>
        public EventHandler<NameChangeCorDebugManagedCallbackEventArgs> OnNameChange;

        /// <summary>
        /// Notifies the debugger that the symbols for a common language runtime module have changed.
        /// </summary>
        public EventHandler<UpdateModuleSymbolsCorDebugManagedCallbackEventArgs> OnUpdateModuleSymbols;

        /// <summary>
        /// This method has been deprecated. It notifies the debugger that a remap event has been sent to the integrated development environment (IDE).
        /// </summary>
        public EventHandler<EditAndContinueRemapCorDebugManagedCallbackEventArgs> OnEditAndContinueRemap;

        /// <summary>
        /// Notifies the debugger that the common language runtime was unable to accurately bind a breakpoint that was set before a function was just-in-time (JIT) compiled.
        /// </summary>
        public EventHandler<BreakpointSetErrorCorDebugManagedCallbackEventArgs> OnBreakpointSetError;

        #endregion
        #region ICorDebugManagedCallback2 EventHandlers

        /// <summary>
        /// Notifies the debugger that code execution has reached a sequence point in an older version of an edited function.
        /// </summary>
        public EventHandler<FunctionRemapOpportunityCorDebugManagedCallbackEventArgs> OnFunctionRemapOpportunity;

        /// <summary>
        /// Notifies the debugger that a new connection has been created.
        /// </summary>
        public EventHandler<CreateConnectionCorDebugManagedCallbackEventArgs> OnCreateConnection;

        /// <summary>
        /// Notifies the debugger that the set of tasks associated with the specified connection has changed.
        /// </summary>
        public EventHandler<ChangeConnectionCorDebugManagedCallbackEventArgs> OnChangeConnection;

        /// <summary>
        /// Notifies the debugger that the specified connection has been terminated.
        /// </summary>
        public EventHandler<DestroyConnectionCorDebugManagedCallbackEventArgs> OnDestroyConnection;

        /// <summary>
        /// Notifies the debugger that a search for an exception handler has started.
        /// </summary>
        public EventHandler<Exception2CorDebugManagedCallbackEventArgs> OnException2;

        /// <summary>
        /// Provides a status notification during the exception unwinding process.
        /// </summary>
        public EventHandler<ExceptionUnwindCorDebugManagedCallbackEventArgs> OnExceptionUnwind;

        /// <summary>
        /// Notifies the debugger that code execution has switched to a new version of an edited function.
        /// </summary>
        public EventHandler<FunctionRemapCompleteCorDebugManagedCallbackEventArgs> OnFunctionRemapComplete;

        /// <summary>
        /// Provides notification that code execution has encountered a managed debugging assistant (MDA) in the application that is being debugged.
        /// </summary>
        public EventHandler<MDANotificationCorDebugManagedCallbackEventArgs> OnMDANotification;

        #endregion
        #region ICorDebugManagedCallback3 EventHandlers

        /// <summary>
        /// Indicates that a custom debugger notification has been raised.
        /// </summary>
        public EventHandler<CustomNotificationCorDebugManagedCallbackEventArgs> OnCustomNotification;

        #endregion
        #region ICorDebugManagedCallback Methods

        HRESULT ICorDebugManagedCallback.Breakpoint(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint) => HandleEvent(OnBreakpoint, new BreakpointCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pBreakpoint));
        HRESULT ICorDebugManagedCallback.StepComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugStepper pStepper, CorDebugStepReason reason) => HandleEvent(OnStepComplete, new StepCompleteCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pStepper, reason));
        HRESULT ICorDebugManagedCallback.Break(ICorDebugAppDomain pAppDomain, ICorDebugThread thread) => HandleEvent(OnBreak, new BreakCorDebugManagedCallbackEventArgs(pAppDomain, thread));
        HRESULT ICorDebugManagedCallback.Exception(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int unhandled) => HandleEvent(OnException, new ExceptionCorDebugManagedCallbackEventArgs(pAppDomain, pThread, unhandled));
        HRESULT ICorDebugManagedCallback.EvalComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval) => HandleEvent(OnEvalComplete, new EvalCompleteCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pEval));
        HRESULT ICorDebugManagedCallback.EvalException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval) => HandleEvent(OnEvalException, new EvalExceptionCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pEval));
        HRESULT ICorDebugManagedCallback.CreateProcess(ICorDebugProcess pProcess) => HandleEvent(OnCreateProcess, new CreateProcessCorDebugManagedCallbackEventArgs(pProcess));
        HRESULT ICorDebugManagedCallback.ExitProcess(ICorDebugProcess pProcess) => HandleEvent(OnExitProcess, new ExitProcessCorDebugManagedCallbackEventArgs(pProcess));
        HRESULT ICorDebugManagedCallback.CreateThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread) => HandleEvent(OnCreateThread, new CreateThreadCorDebugManagedCallbackEventArgs(pAppDomain, thread));
        HRESULT ICorDebugManagedCallback.ExitThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread) => HandleEvent(OnExitThread, new ExitThreadCorDebugManagedCallbackEventArgs(pAppDomain, thread));
        HRESULT ICorDebugManagedCallback.LoadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule) => HandleEvent(OnLoadModule, new LoadModuleCorDebugManagedCallbackEventArgs(pAppDomain, pModule));
        HRESULT ICorDebugManagedCallback.UnloadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule) => HandleEvent(OnUnloadModule, new UnloadModuleCorDebugManagedCallbackEventArgs(pAppDomain, pModule));
        HRESULT ICorDebugManagedCallback.LoadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c) => HandleEvent(OnLoadClass, new LoadClassCorDebugManagedCallbackEventArgs(pAppDomain, c));
        HRESULT ICorDebugManagedCallback.UnloadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c) => HandleEvent(OnUnloadClass, new UnloadClassCorDebugManagedCallbackEventArgs(pAppDomain, c));
        HRESULT ICorDebugManagedCallback.DebuggerError(ICorDebugProcess pProcess, HRESULT errorHR, int errorCode) => HandleEvent(OnDebuggerError, new DebuggerErrorCorDebugManagedCallbackEventArgs(pProcess, errorHR, errorCode));
        HRESULT ICorDebugManagedCallback.LogMessage(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, LoggingLevelEnum lLevel, string pLogSwitchName, string pMessage) => HandleEvent(OnLogMessage, new LogMessageCorDebugManagedCallbackEventArgs(pAppDomain, pThread, lLevel, pLogSwitchName, pMessage));
        HRESULT ICorDebugManagedCallback.LogSwitch(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int lLevel, LogSwitchCallReason ulReason, string pLogSwitchName, string pParentName) => HandleEvent(OnLogSwitch, new LogSwitchCorDebugManagedCallbackEventArgs(pAppDomain, pThread, lLevel, ulReason, pLogSwitchName, pParentName));
        HRESULT ICorDebugManagedCallback.CreateAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain) => HandleEvent(OnCreateAppDomain, new CreateAppDomainCorDebugManagedCallbackEventArgs(pProcess, pAppDomain));
        HRESULT ICorDebugManagedCallback.ExitAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain) => HandleEvent(OnExitAppDomain, new ExitAppDomainCorDebugManagedCallbackEventArgs(pProcess, pAppDomain));
        HRESULT ICorDebugManagedCallback.LoadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly) => HandleEvent(OnLoadAssembly, new LoadAssemblyCorDebugManagedCallbackEventArgs(pAppDomain, pAssembly));
        HRESULT ICorDebugManagedCallback.UnloadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly) => HandleEvent(OnUnloadAssembly, new UnloadAssemblyCorDebugManagedCallbackEventArgs(pAppDomain, pAssembly));
        HRESULT ICorDebugManagedCallback.ControlCTrap(ICorDebugProcess pProcess) => HandleEvent(OnControlCTrap, new ControlCTrapCorDebugManagedCallbackEventArgs(pProcess));
        HRESULT ICorDebugManagedCallback.NameChange(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread) => HandleEvent(OnNameChange, new NameChangeCorDebugManagedCallbackEventArgs(pAppDomain, pThread));
        HRESULT ICorDebugManagedCallback.UpdateModuleSymbols(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule, IStream pSymbolStream) => HandleEvent(OnUpdateModuleSymbols, new UpdateModuleSymbolsCorDebugManagedCallbackEventArgs(pAppDomain, pModule, pSymbolStream));
        HRESULT ICorDebugManagedCallback.EditAndContinueRemap(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction, bool fAccurate) => HandleEvent(OnEditAndContinueRemap, new EditAndContinueRemapCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pFunction, fAccurate));
        HRESULT ICorDebugManagedCallback.BreakpointSetError(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint, int dwError) => HandleEvent(OnBreakpointSetError, new BreakpointSetErrorCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pBreakpoint, dwError));

        #endregion
        #region ICorDebugManagedCallback2 Methods

        HRESULT ICorDebugManagedCallback2.FunctionRemapOpportunity(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pOldFunction, ICorDebugFunction pNewFunction, int oldILOffset) => HandleEvent(OnFunctionRemapOpportunity, new FunctionRemapOpportunityCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pOldFunction, pNewFunction, oldILOffset));
        HRESULT ICorDebugManagedCallback2.CreateConnection(ICorDebugProcess pProcess, int dwConnectionId, string pConnName) => HandleEvent(OnCreateConnection, new CreateConnectionCorDebugManagedCallbackEventArgs(pProcess, dwConnectionId, pConnName));
        HRESULT ICorDebugManagedCallback2.ChangeConnection(ICorDebugProcess pProcess, int dwConnectionId) => HandleEvent(OnChangeConnection, new ChangeConnectionCorDebugManagedCallbackEventArgs(pProcess, dwConnectionId));
        HRESULT ICorDebugManagedCallback2.DestroyConnection(ICorDebugProcess pProcess, int dwConnectionId) => HandleEvent(OnDestroyConnection, new DestroyConnectionCorDebugManagedCallbackEventArgs(pProcess, dwConnectionId));
        HRESULT ICorDebugManagedCallback2.Exception(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFrame pFrame, int nOffset, CorDebugExceptionCallbackType dwEventType, int dwFlags) => HandleEvent(OnException2, new Exception2CorDebugManagedCallbackEventArgs(pAppDomain, pThread, pFrame, nOffset, dwEventType, dwFlags));
        HRESULT ICorDebugManagedCallback2.ExceptionUnwind(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, CorDebugExceptionUnwindCallbackType dwEventType, int dwFlags) => HandleEvent(OnExceptionUnwind, new ExceptionUnwindCorDebugManagedCallbackEventArgs(pAppDomain, pThread, dwEventType, dwFlags));
        HRESULT ICorDebugManagedCallback2.FunctionRemapComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction) => HandleEvent(OnFunctionRemapComplete, new FunctionRemapCompleteCorDebugManagedCallbackEventArgs(pAppDomain, pThread, pFunction));
        HRESULT ICorDebugManagedCallback2.MDANotification(ICorDebugController pController, ICorDebugThread pThread, ICorDebugMDA pMDA) => HandleEvent(OnMDANotification, new MDANotificationCorDebugManagedCallbackEventArgs(pController, pThread, pMDA));

        #endregion
        #region ICorDebugManagedCallback3 Methods

        HRESULT ICorDebugManagedCallback3.CustomNotification(ICorDebugThread pThread, ICorDebugAppDomain pAppDomain) => HandleEvent(OnCustomNotification, new CustomNotificationCorDebugManagedCallbackEventArgs(pThread, pAppDomain));

        #endregion
        
        protected virtual HRESULT HandleEvent<T>(EventHandler<T> handler, CorDebugManagedCallbackEventArgs args)
            where T : CorDebugManagedCallbackEventArgs
        {
            OnAnyEvent?.Invoke(this, args);
            handler?.Invoke(this, (T) args);

            return HRESULT.S_OK;
        }
    }
}