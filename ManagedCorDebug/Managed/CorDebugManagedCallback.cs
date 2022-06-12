using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to process debugger callbacks.
    /// </summary>
    /// <remarks>
    /// All callbacks are serialized, called in the same thread, and called with the process in the synchronized state.
    /// Each callback implementation must call <see cref="CorDebugController.Continue"/> to resume execution. If ICorDebugController::Continue
    /// is not called before the callback returns, the process will remain stopped and no more event callbacks will occur
    /// until <see cref="CorDebugController.Continue"/> is called. A debugger must implement <see cref="ICorDebugManagedCallback2"/>
    /// if it is debugging .NET Framework version 2.0 applications. An instance of <see cref="ICorDebugManagedCallback"/> or <see cref="ICorDebugManagedCallback2"/>
    /// is passed as the callback object to <see cref="CorDebug.SetManagedHandler"/>.
    /// </remarks>
    public class CorDebugManagedCallback : ComObject<ICorDebugManagedCallback>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugManagedCallback"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugManagedCallback(ICorDebugManagedCallback raw) : base(raw)
        {
        }

        #region ICorDebugManagedCallback
        #region Breakpoint

        /// <summary>
        /// Notifies the debugger when a breakpoint is encountered.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the breakpoint.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the breakpoint.</param>
        /// <param name="pBreakpoint">[in] A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the breakpoint.</param>
        public void Breakpoint(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint)
        {
            HRESULT hr;

            if ((hr = TryBreakpoint(pAppDomain, pThread, pBreakpoint)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger when a breakpoint is encountered.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the breakpoint.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the breakpoint.</param>
        /// <param name="pBreakpoint">[in] A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the breakpoint.</param>
        public HRESULT TryBreakpoint(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint)
        {
            /*HRESULT Breakpoint(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint);*/
            return Raw.Breakpoint(pAppDomain, pThread, pBreakpoint);
        }

        #endregion
        #region StepComplete

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
        public void StepComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugStepper pStepper, CorDebugStepReason reason)
        {
            HRESULT hr;

            if ((hr = TryStepComplete(pAppDomain, pThread, pStepper, reason)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TryStepComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugStepper pStepper, CorDebugStepReason reason)
        {
            /*HRESULT StepComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugStepper pStepper,
            [In] CorDebugStepReason reason);*/
            return Raw.StepComplete(pAppDomain, pThread, pStepper, reason);
        }

        #endregion
        #region Break

        /// <summary>
        /// Notifies the debugger when a <see cref="OpCodes.Break"/> instruction in the code stream is executed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the break instruction.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the break instruction.</param>
        public void Break(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            HRESULT hr;

            if ((hr = TryBreak(pAppDomain, thread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger when a <see cref="OpCodes.Break"/> instruction in the code stream is executed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the break instruction.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the break instruction.</param>
        public HRESULT TryBreak(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            /*HRESULT Break([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);*/
            return Raw.Break(pAppDomain, thread);
        }

        #endregion
        #region Exception

        /// <summary>
        /// Notifies the debugger that an exception has been thrown from managed code.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the exception was thrown.</param>
        /// <param name="unhandled">[in] If this value is false, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.</param>
        /// <remarks>
        /// The specific exception can be retrieved from the thread object.
        /// </remarks>
        public void Exception(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int unhandled)
        {
            HRESULT hr;

            if ((hr = TryException(pAppDomain, pThread, unhandled)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that an exception has been thrown from managed code.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the exception was thrown.</param>
        /// <param name="unhandled">[in] If this value is false, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.</param>
        /// <remarks>
        /// The specific exception can be retrieved from the thread object.
        /// </remarks>
        public HRESULT TryException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int unhandled)
        {
            /*HRESULT Exception([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [In] int unhandled);*/
            return Raw.Exception(pAppDomain, pThread, unhandled);
        }

        #endregion
        #region EvalComplete

        /// <summary>
        /// Notifies the debugger that an evaluation has been completed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation was performed.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation was performed.</param>
        /// <param name="pEval">[in] A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.</param>
        public void EvalComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            HRESULT hr;

            if ((hr = TryEvalComplete(pAppDomain, pThread, pEval)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that an evaluation has been completed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation was performed.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation was performed.</param>
        /// <param name="pEval">[in] A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.</param>
        public HRESULT TryEvalComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            /*HRESULT EvalComplete([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);*/
            return Raw.EvalComplete(pAppDomain, pThread, pEval);
        }

        #endregion
        #region EvalException

        /// <summary>
        /// Notifies the debugger that an evaluation has terminated with an unhandled exception.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation terminated.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation terminated.</param>
        /// <param name="pEval">[in] A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.</param>
        public void EvalException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            HRESULT hr;

            if ((hr = TryEvalException(pAppDomain, pThread, pEval)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that an evaluation has terminated with an unhandled exception.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation terminated.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation terminated.</param>
        /// <param name="pEval">[in] A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.</param>
        public HRESULT TryEvalException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            /*HRESULT EvalException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);*/
            return Raw.EvalException(pAppDomain, pThread, pEval);
        }

        #endregion
        #region CreateProcess

        /// <summary>
        /// Notifies the debugger when a process has been attached or started for the first time.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that has been attached or started.</param>
        /// <remarks>
        /// This method is not called until the common language runtime is initialized. Most of the <see cref="ICorDebug"/>
        /// methods will return CORDBG_E_NOTREADY before the CreateProcess callback.
        /// </remarks>
        public void CreateProcess(ICorDebugProcess pProcess)
        {
            HRESULT hr;

            if ((hr = TryCreateProcess(pProcess)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger when a process has been attached or started for the first time.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that has been attached or started.</param>
        /// <remarks>
        /// This method is not called until the common language runtime is initialized. Most of the <see cref="ICorDebug"/>
        /// methods will return CORDBG_E_NOTREADY before the CreateProcess callback.
        /// </remarks>
        public HRESULT TryCreateProcess(ICorDebugProcess pProcess)
        {
            /*HRESULT CreateProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);*/
            return Raw.CreateProcess(pProcess);
        }

        #endregion
        #region ExitProcess

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
        public void ExitProcess(ICorDebugProcess pProcess)
        {
            HRESULT hr;

            if ((hr = TryExitProcess(pProcess)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TryExitProcess(ICorDebugProcess pProcess)
        {
            /*HRESULT ExitProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);*/
            return Raw.ExitProcess(pProcess);
        }

        #endregion
        #region CreateThread

        /// <summary>
        /// Notifies the debugger that a thread has started executing managed code.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the thread.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        /// <remarks>
        /// The thread will be positioned at the first managed code instruction to be executed.
        /// </remarks>
        public void CreateThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            HRESULT hr;

            if ((hr = TryCreateThread(pAppDomain, thread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a thread has started executing managed code.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the thread.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        /// <remarks>
        /// The thread will be positioned at the first managed code instruction to be executed.
        /// </remarks>
        public HRESULT TryCreateThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            /*HRESULT CreateThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);*/
            return Raw.CreateThread(pAppDomain, thread);
        }

        #endregion
        #region ExitThread

        /// <summary>
        /// Notifies the debugger that a thread that was executing managed code has exited.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <remarks>
        /// Once the ExitThread callback is fired, the thread will no longer appear in thread enumerations.
        /// </remarks>
        public void ExitThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            HRESULT hr;

            if ((hr = TryExitThread(pAppDomain, thread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a thread that was executing managed code has exited.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread.</param>
        /// <param name="thread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <remarks>
        /// Once the ExitThread callback is fired, the thread will no longer appear in thread enumerations.
        /// </remarks>
        public HRESULT TryExitThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            /*HRESULT ExitThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);*/
            return Raw.ExitThread(pAppDomain, thread);
        }

        #endregion
        #region LoadModule

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) module has been successfully loaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the module has been loaded.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the CLR module.</param>
        /// <remarks>
        /// The LoadModule callback provides an appropriate time to examine metadata for the module, set just-in-time (JIT)
        /// compiler flags, or enable or disable class loading callbacks for the module.
        /// </remarks>
        public void LoadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            HRESULT hr;

            if ((hr = TryLoadModule(pAppDomain, pModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) module has been successfully loaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the module has been loaded.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the CLR module.</param>
        /// <remarks>
        /// The LoadModule callback provides an appropriate time to examine metadata for the module, set just-in-time (JIT)
        /// compiler flags, or enable or disable class loading callbacks for the module.
        /// </remarks>
        public HRESULT TryLoadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            /*HRESULT LoadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);*/
            return Raw.LoadModule(pAppDomain, pModule);
        }

        #endregion
        #region UnloadModule

        /// <summary>
        /// Notifies the debugger that a common language runtime module (DLL) has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the module.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the module.</param>
        /// <remarks>
        /// The module should not be used after this call.
        /// </remarks>
        public void UnloadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            HRESULT hr;

            if ((hr = TryUnloadModule(pAppDomain, pModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a common language runtime module (DLL) has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the module.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the module.</param>
        /// <remarks>
        /// The module should not be used after this call.
        /// </remarks>
        public HRESULT TryUnloadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            /*HRESULT UnloadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);*/
            return Raw.UnloadModule(pAppDomain, pModule);
        }

        #endregion
        #region LoadClass

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
        public void LoadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            HRESULT hr;

            if ((hr = TryLoadClass(pAppDomain, c)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TryLoadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            /*HRESULT LoadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);*/
            return Raw.LoadClass(pAppDomain, c);
        }

        #endregion
        #region UnloadClass

        /// <summary>
        /// Notifies the debugger that a class is being unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the class.</param>
        /// <param name="c">[in] A pointer to an <see cref="ICorDebugClass"/> object that represents the class.</param>
        /// <remarks>
        /// The class should not be referenced after this call.
        /// </remarks>
        public void UnloadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            HRESULT hr;

            if ((hr = TryUnloadClass(pAppDomain, c)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a class is being unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the class.</param>
        /// <param name="c">[in] A pointer to an <see cref="ICorDebugClass"/> object that represents the class.</param>
        /// <remarks>
        /// The class should not be referenced after this call.
        /// </remarks>
        public HRESULT TryUnloadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            /*HRESULT UnloadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);*/
            return Raw.UnloadClass(pAppDomain, c);
        }

        #endregion
        #region DebuggerError

        /// <summary>
        /// Notifies the debugger that an error has occurred while attempting to handle an event from the common language runtime (CLR).
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process in which the event occurred.</param>
        /// <param name="errorHR">[in] The <see cref="HRESULT"/> value that was returned from the event handler.</param>
        /// <param name="errorCode">[in] An integer that specifies the CLR error.</param>
        /// <remarks>
        /// The process may be placed into pass-through mode, depending on the nature of the error. The DebugError callback
        /// indicates that debugging services have been disabled due to an error, so debuggers should make the error message
        /// available to the user. <see cref="CorDebugProcess.Id"/> will be safe to call, but all other methods, including
        /// <see cref="CorDebug.Terminate"/>, should not be called. The debugger should use operating-system facilities for
        /// terminating processes.
        /// </remarks>
        public void DebuggerError(ICorDebugProcess pProcess, HRESULT errorHR, int errorCode)
        {
            HRESULT hr;

            if ((hr = TryDebuggerError(pProcess, errorHR, errorCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that an error has occurred while attempting to handle an event from the common language runtime (CLR).
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process in which the event occurred.</param>
        /// <param name="errorHR">[in] The <see cref="HRESULT"/> value that was returned from the event handler.</param>
        /// <param name="errorCode">[in] An integer that specifies the CLR error.</param>
        /// <remarks>
        /// The process may be placed into pass-through mode, depending on the nature of the error. The DebugError callback
        /// indicates that debugging services have been disabled due to an error, so debuggers should make the error message
        /// available to the user. <see cref="CorDebugProcess.Id"/> will be safe to call, but all other methods, including
        /// <see cref="CorDebug.Terminate"/>, should not be called. The debugger should use operating-system facilities for
        /// terminating processes.
        /// </remarks>
        public HRESULT TryDebuggerError(ICorDebugProcess pProcess, HRESULT errorHR, int errorCode)
        {
            /*HRESULT DebuggerError([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Error), In] HRESULT errorHR, [In] int errorCode);*/
            return Raw.DebuggerError(pProcess, errorHR, errorCode);
        }

        #endregion
        #region LogMessage

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="EventLog"/> class to log an event.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that logged the event.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">[in] A value of the <see cref="LoggingLevelEnum"/> enumeration that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="pLogSwitchName">[in] A pointer to the name of the tracing switch.</param>
        /// <param name="pMessage">[in] A pointer to the message that was written to the event log.</param>
        public void LogMessage(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, LoggingLevelEnum lLevel, string pLogSwitchName, string pMessage)
        {
            HRESULT hr;

            if ((hr = TryLogMessage(pAppDomain, pThread, lLevel, pLogSwitchName, pMessage)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="EventLog"/> class to log an event.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that logged the event.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">[in] A value of the <see cref="LoggingLevelEnum"/> enumeration that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="pLogSwitchName">[in] A pointer to the name of the tracing switch.</param>
        /// <param name="pMessage">[in] A pointer to the message that was written to the event log.</param>
        public HRESULT TryLogMessage(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, LoggingLevelEnum lLevel, string pLogSwitchName, string pMessage)
        {
            /*HRESULT LogMessage(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] LoggingLevelEnum lLevel,
            [MarshalAs(UnmanagedType.LPWStr), In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pMessage);*/
            return Raw.LogMessage(pAppDomain, pThread, lLevel, pLogSwitchName, pMessage);
        }

        #endregion
        #region LogSwitch

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="Switch"/> class to create, modify, or delete a debugging/tracing switch.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that created, modified, or deleted a debugging/tracing switch.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">[in] A value that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="ulReason">[in] A value of the <see cref="LogSwitchCallReason"/> enumeration that indicates the operation performed on the debugging/tracing switch.</param>
        /// <param name="pLogSwitchName">[in] A pointer to the name of the debugging/tracing switch.</param>
        /// <param name="pParentName">[in] A pointer to the name of the parent of the debugging/tracing switch.</param>
        public void LogSwitch(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int lLevel, LogSwitchCallReason ulReason, string pLogSwitchName, string pParentName)
        {
            HRESULT hr;

            if ((hr = TryLogSwitch(pAppDomain, pThread, lLevel, ulReason, pLogSwitchName, pParentName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="Switch"/> class to create, modify, or delete a debugging/tracing switch.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that created, modified, or deleted a debugging/tracing switch.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">[in] A value that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="ulReason">[in] A value of the <see cref="LogSwitchCallReason"/> enumeration that indicates the operation performed on the debugging/tracing switch.</param>
        /// <param name="pLogSwitchName">[in] A pointer to the name of the debugging/tracing switch.</param>
        /// <param name="pParentName">[in] A pointer to the name of the parent of the debugging/tracing switch.</param>
        public HRESULT TryLogSwitch(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int lLevel, LogSwitchCallReason ulReason, string pLogSwitchName, string pParentName)
        {
            /*HRESULT LogSwitch(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] int lLevel,
            [In] LogSwitchCallReason ulReason,
            [MarshalAs(UnmanagedType.LPWStr)]  [In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pParentName);*/
            return Raw.LogSwitch(pAppDomain, pThread, lLevel, ulReason, pLogSwitchName, pParentName);
        }

        #endregion
        #region CreateAppDomain

        /// <summary>
        /// Notifies the debugger that an application domain has been created.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the application domain was created.</param>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has been created.</param>
        public void CreateAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryCreateAppDomain(pProcess, pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that an application domain has been created.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the application domain was created.</param>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has been created.</param>
        public HRESULT TryCreateAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            /*HRESULT CreateAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);*/
            return Raw.CreateAppDomain(pProcess, pAppDomain);
        }

        #endregion
        #region ExitAppDomain

        /// <summary>
        /// Notifies the debugger that an application domain has exited.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that contains the given application domain.</param>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has exited.</param>
        public void ExitAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryExitAppDomain(pProcess, pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that an application domain has exited.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process that contains the given application domain.</param>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that has exited.</param>
        public HRESULT TryExitAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            /*HRESULT ExitAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);*/
            return Raw.ExitAppDomain(pProcess, pAppDomain);
        }

        #endregion
        #region LoadAssembly

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) assembly has been successfully loaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the assembly has been loaded.</param>
        /// <param name="pAssembly">[in] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        public void LoadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            HRESULT hr;

            if ((hr = TryLoadAssembly(pAppDomain, pAssembly)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) assembly has been successfully loaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain into which the assembly has been loaded.</param>
        /// <param name="pAssembly">[in] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        public HRESULT TryLoadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            /*HRESULT LoadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);*/
            return Raw.LoadAssembly(pAppDomain, pAssembly);
        }

        #endregion
        #region UnloadAssembly

        /// <summary>
        /// Notifies the debugger that a common language runtime assembly has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the assembly.</param>
        /// <param name="pAssembly">[in] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        /// <remarks>
        /// The assembly should not be used after this callback.
        /// </remarks>
        public void UnloadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            HRESULT hr;

            if ((hr = TryUnloadAssembly(pAppDomain, pAssembly)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a common language runtime assembly has been unloaded.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contained the assembly.</param>
        /// <param name="pAssembly">[in] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        /// <remarks>
        /// The assembly should not be used after this callback.
        /// </remarks>
        public HRESULT TryUnloadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            /*HRESULT UnloadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);*/
            return Raw.UnloadAssembly(pAppDomain, pAssembly);
        }

        #endregion
        #region ControlCTrap

        /// <summary>
        /// Notifies the debugger that a CTRL+C is trapped in the process that is being debugged.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process in which the CTRL+C is trapped.</param>
        /// <remarks>
        /// All application domains within the process are stopped for this callback.
        /// </remarks>
        public void ControlCTrap(ICorDebugProcess pProcess)
        {
            HRESULT hr;

            if ((hr = TryControlCTrap(pProcess)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TryControlCTrap(ICorDebugProcess pProcess)
        {
            /*HRESULT ControlCTrap([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);*/
            return Raw.ControlCTrap(pProcess);
        }

        #endregion
        #region NameChange

        /// <summary>
        /// Notifies the debugger that the name of either an application domain or a thread has changed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that either had a name change or that contains the thread that had a name change.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that had a name change.</param>
        public void NameChange(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread)
        {
            HRESULT hr;

            if ((hr = TryNameChange(pAppDomain, pThread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that the name of either an application domain or a thread has changed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that either had a name change or that contains the thread that had a name change.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that had a name change.</param>
        public HRESULT TryNameChange(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread)
        {
            /*HRESULT NameChange([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread);*/
            return Raw.NameChange(pAppDomain, pThread);
        }

        #endregion
        #region UpdateModuleSymbols

        /// <summary>
        /// Notifies the debugger that the symbols for a common language runtime module have changed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the module in which the symbols have changed.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the module in which the symbols have changed.</param>
        /// <param name="pSymbolStream">[in] A pointer to a Win32 COM <see cref="IStream"/> object that contains the modified symbols.</param>
        /// <remarks>
        /// This method provides an opportunity to update the debugger's view of a module's symbols by calling <see cref="SymUnmanagedReader.UpdateSymbolStore"/>
        /// or <see cref="SymUnmanagedReader.ReplaceSymbolStore"/>. This callback can occur multiple times for the same module.
        /// A debugger should try to bind unbound source-level breakpoints.
        /// </remarks>
        public void UpdateModuleSymbols(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule, IStream pSymbolStream)
        {
            HRESULT hr;

            if ((hr = TryUpdateModuleSymbols(pAppDomain, pModule, pSymbolStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that the symbols for a common language runtime module have changed.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the module in which the symbols have changed.</param>
        /// <param name="pModule">[in] A pointer to an <see cref="ICorDebugModule"/> object that represents the module in which the symbols have changed.</param>
        /// <param name="pSymbolStream">[in] A pointer to a Win32 COM <see cref="IStream"/> object that contains the modified symbols.</param>
        /// <remarks>
        /// This method provides an opportunity to update the debugger's view of a module's symbols by calling <see cref="SymUnmanagedReader.UpdateSymbolStore"/>
        /// or <see cref="SymUnmanagedReader.ReplaceSymbolStore"/>. This callback can occur multiple times for the same module.
        /// A debugger should try to bind unbound source-level breakpoints.
        /// </remarks>
        public HRESULT TryUpdateModuleSymbols(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule, IStream pSymbolStream)
        {
            /*HRESULT UpdateModuleSymbols(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pSymbolStream);*/
            return Raw.UpdateModuleSymbols(pAppDomain, pModule, pSymbolStream);
        }

        #endregion
        #region EditAndContinueRemap

        /// <summary>
        /// This method has been deprecated. It notifies the debugger that a remap event has been sent to the integrated development environment (IDE).
        /// </summary>
        /// <remarks>
        /// The EditAndContinueRemap method is called when the execution of the code in an old version of an updated function
        /// has been attempted. The common language runtime calls the EditAndContinueRemap method to send a remap event to
        /// the IDE.
        /// </remarks>
        public void EditAndContinueRemap(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction, int fAccurate)
        {
            HRESULT hr;

            if ((hr = TryEditAndContinueRemap(pAppDomain, pThread, pFunction, fAccurate)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// This method has been deprecated. It notifies the debugger that a remap event has been sent to the integrated development environment (IDE).
        /// </summary>
        /// <remarks>
        /// The EditAndContinueRemap method is called when the execution of the code in an old version of an updated function
        /// has been attempted. The common language runtime calls the EditAndContinueRemap method to send a remap event to
        /// the IDE.
        /// </remarks>
        public HRESULT TryEditAndContinueRemap(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction, int fAccurate)
        {
            /*HRESULT EditAndContinueRemap(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] int fAccurate);*/
            return Raw.EditAndContinueRemap(pAppDomain, pThread, pFunction, fAccurate);
        }

        #endregion
        #region BreakpointSetError

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
        public void BreakpointSetError(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint, int dwError)
        {
            HRESULT hr;

            if ((hr = TryBreakpointSetError(pAppDomain, pThread, pBreakpoint, dwError)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TryBreakpointSetError(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint, int dwError)
        {
            /*HRESULT BreakpointSetError(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint,
            [In] int dwError);*/
            return Raw.BreakpointSetError(pAppDomain, pThread, pBreakpoint, dwError);
        }

        #endregion
        #endregion
        #region ICorDebugManagedCallback2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugManagedCallback2 Raw2 => (ICorDebugManagedCallback2) Raw;

        #region FunctionRemapOpportunity

        /// <summary>
        /// Notifies the debugger that code execution has reached a sequence point in an older version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pOldFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function that is currently running on the thread.</param>
        /// <param name="pNewFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the latest version of the function.</param>
        /// <param name="oldILOffset">[in] The Microsoft intermediate language (MSIL) offset of the instruction pointer in the old version of the function.</param>
        /// <remarks>
        /// This callback gives the debugger an opportunity to remap the instruction pointer to its proper place in the new
        /// version of the specified function by calling the <see cref="CorDebugILFrame.RemapFunction"/> method. If the debugger
        /// does not call RemapFunction before calling the <see cref="CorDebugController.Continue"/> method, the runtime will
        /// continue to execute the old code and will fire another FunctionRemapOpportunity callback at the next sequence point.
        /// This callback will be invoked for every frame that is executing an older version of the given function until the
        /// debugger returns S_OK.
        /// </remarks>
        public void FunctionRemapOpportunity(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pOldFunction, ICorDebugFunction pNewFunction, int oldILOffset)
        {
            HRESULT hr;

            if ((hr = TryFunctionRemapOpportunity(pAppDomain, pThread, pOldFunction, pNewFunction, oldILOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that code execution has reached a sequence point in an older version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pOldFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function that is currently running on the thread.</param>
        /// <param name="pNewFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the latest version of the function.</param>
        /// <param name="oldILOffset">[in] The Microsoft intermediate language (MSIL) offset of the instruction pointer in the old version of the function.</param>
        /// <remarks>
        /// This callback gives the debugger an opportunity to remap the instruction pointer to its proper place in the new
        /// version of the specified function by calling the <see cref="CorDebugILFrame.RemapFunction"/> method. If the debugger
        /// does not call RemapFunction before calling the <see cref="CorDebugController.Continue"/> method, the runtime will
        /// continue to execute the old code and will fire another FunctionRemapOpportunity callback at the next sequence point.
        /// This callback will be invoked for every frame that is executing an older version of the given function until the
        /// debugger returns S_OK.
        /// </remarks>
        public HRESULT TryFunctionRemapOpportunity(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pOldFunction, ICorDebugFunction pNewFunction, int oldILOffset)
        {
            /*HRESULT FunctionRemapOpportunity(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pOldFunction,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pNewFunction,
            [In] int oldILOffset);*/
            return Raw2.FunctionRemapOpportunity(pAppDomain, pThread, pOldFunction, pNewFunction, oldILOffset);
        }

        #endregion
        #region CreateConnection

        /// <summary>
        /// Notifies the debugger that a new connection has been created.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process in which the connection was created</param>
        /// <param name="dwConnectionId">[in] The ID of the new connection.</param>
        /// <param name="pConnName">[in] A pointer to the name of the new connection.</param>
        /// <remarks>
        /// A CreateConnection callback will be fired in either of the following cases:
        /// </remarks>
        public void CreateConnection(ICorDebugProcess pProcess, int dwConnectionId, string pConnName)
        {
            HRESULT hr;

            if ((hr = TryCreateConnection(pProcess, dwConnectionId, pConnName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a new connection has been created.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process in which the connection was created</param>
        /// <param name="dwConnectionId">[in] The ID of the new connection.</param>
        /// <param name="pConnName">[in] A pointer to the name of the new connection.</param>
        /// <remarks>
        /// A CreateConnection callback will be fired in either of the following cases:
        /// </remarks>
        public HRESULT TryCreateConnection(ICorDebugProcess pProcess, int dwConnectionId, string pConnName)
        {
            /*HRESULT CreateConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] int dwConnectionId, [MarshalAs(UnmanagedType.LPWStr), In] string pConnName);*/
            return Raw2.CreateConnection(pProcess, dwConnectionId, pConnName);
        }

        #endregion
        #region ChangeConnection

        /// <summary>
        /// Notifies the debugger that the set of tasks associated with the specified connection has changed.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process containing the connection that changed.</param>
        /// <param name="dwConnectionId">[in] The ID of the connection that changed.</param>
        /// <remarks>
        /// A ChangeConnection callback will be fired in either of the following cases: The debugger should scan all threads
        /// in the process to pick up the new changes.
        /// </remarks>
        public void ChangeConnection(ICorDebugProcess pProcess, int dwConnectionId)
        {
            HRESULT hr;

            if ((hr = TryChangeConnection(pProcess, dwConnectionId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that the set of tasks associated with the specified connection has changed.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process containing the connection that changed.</param>
        /// <param name="dwConnectionId">[in] The ID of the connection that changed.</param>
        /// <remarks>
        /// A ChangeConnection callback will be fired in either of the following cases: The debugger should scan all threads
        /// in the process to pick up the new changes.
        /// </remarks>
        public HRESULT TryChangeConnection(ICorDebugProcess pProcess, int dwConnectionId)
        {
            /*HRESULT ChangeConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] int dwConnectionId);*/
            return Raw2.ChangeConnection(pProcess, dwConnectionId);
        }

        #endregion
        #region DestroyConnection

        /// <summary>
        /// Notifies the debugger that the specified connection has been terminated.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process containing the connection that was destroyed.</param>
        /// <param name="dwConnectionId">[in] The ID of the connection that was destroyed.</param>
        /// <remarks>
        /// A DestroyConnection callback will be fired when a host calls <see cref="CLRDebugManager.EndConnection"/> in the
        /// Hosting API.
        /// </remarks>
        public void DestroyConnection(ICorDebugProcess pProcess, int dwConnectionId)
        {
            HRESULT hr;

            if ((hr = TryDestroyConnection(pProcess, dwConnectionId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that the specified connection has been terminated.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process containing the connection that was destroyed.</param>
        /// <param name="dwConnectionId">[in] The ID of the connection that was destroyed.</param>
        /// <remarks>
        /// A DestroyConnection callback will be fired when a host calls <see cref="CLRDebugManager.EndConnection"/> in the
        /// Hosting API.
        /// </remarks>
        public HRESULT TryDestroyConnection(ICorDebugProcess pProcess, int dwConnectionId)
        {
            /*HRESULT DestroyConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] int dwConnectionId);*/
            return Raw2.DestroyConnection(pProcess, dwConnectionId);
        }

        #endregion
        #region Exception

        /// <summary>
        /// Notifies the debugger that a search for an exception handler has started.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> object that represents a frame, as determined by the dwEventType parameter.<para/>
        /// For more information, see the table in the Remarks section.</param>
        /// <param name="nOffset">[in] An integer that specifies an offset, as determined by the dwEventType parameter. For more information, see the table in the Remarks section.</param>
        /// <param name="dwEventType">[in] A value of the <see cref="CorDebugExceptionCallbackType"/> enumeration that specifies the type of this exception callback.</param>
        /// <param name="dwFlags">[in] A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception</param>
        /// <remarks>
        /// The Exception callback is called at various points during the search phase of the exception-handling process. That
        /// is, it can be called more than once while unwinding an exception. The exception being processed can be retrieved
        /// from the <see cref="ICorDebugThread"/> object referenced by the pThread parameter. The particular frame and offset are determined
        /// by the dwEventType parameter as follows:
        /// </remarks>
        public void Exception(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFrame pFrame, int nOffset, CorDebugExceptionCallbackType dwEventType, int dwFlags)
        {
            HRESULT hr;

            if ((hr = TryException(pAppDomain, pThread, pFrame, nOffset, dwEventType, dwFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that a search for an exception handler has started.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> object that represents a frame, as determined by the dwEventType parameter.<para/>
        /// For more information, see the table in the Remarks section.</param>
        /// <param name="nOffset">[in] An integer that specifies an offset, as determined by the dwEventType parameter. For more information, see the table in the Remarks section.</param>
        /// <param name="dwEventType">[in] A value of the <see cref="CorDebugExceptionCallbackType"/> enumeration that specifies the type of this exception callback.</param>
        /// <param name="dwFlags">[in] A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception</param>
        /// <remarks>
        /// The Exception callback is called at various points during the search phase of the exception-handling process. That
        /// is, it can be called more than once while unwinding an exception. The exception being processed can be retrieved
        /// from the <see cref="ICorDebugThread"/> object referenced by the pThread parameter. The particular frame and offset are determined
        /// by the dwEventType parameter as follows:
        /// </remarks>
        public HRESULT TryException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFrame pFrame, int nOffset, CorDebugExceptionCallbackType dwEventType, int dwFlags)
        {
            /*HRESULT Exception(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame,
            [In] int nOffset,
            [In] CorDebugExceptionCallbackType dwEventType,
            [In] int dwFlags);*/
            return Raw2.Exception(pAppDomain, pThread, pFrame, nOffset, dwEventType, dwFlags);
        }

        #endregion
        #region ExceptionUnwind

        /// <summary>
        /// Provides a status notification during the exception unwinding process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="dwEventType">[in] A value of the <see cref="CorDebugExceptionUnwindCallbackType"/> enumeration that specifies the event that is being signaled by the callback during the unwind phase.</param>
        /// <param name="dwFlags">[in] A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception.</param>
        /// <remarks>
        /// ExceptionUnwind is called at various points during the unwind phase of the exception-handling process. ExceptionUnwind
        /// can be called more than once while unwinding a single exception. If dwEventType = DEBUG_EXCEPTION_INTERCEPTED,
        /// the instruction pointer will be in the leaf frame of the thread, at the sequence point before (this may be several
        /// instructions before) the instruction that led to the exception.
        /// </remarks>
        public void ExceptionUnwind(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, CorDebugExceptionUnwindCallbackType dwEventType, int dwFlags)
        {
            HRESULT hr;

            if ((hr = TryExceptionUnwind(pAppDomain, pThread, dwEventType, dwFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Provides a status notification during the exception unwinding process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="dwEventType">[in] A value of the <see cref="CorDebugExceptionUnwindCallbackType"/> enumeration that specifies the event that is being signaled by the callback during the unwind phase.</param>
        /// <param name="dwFlags">[in] A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception.</param>
        /// <remarks>
        /// ExceptionUnwind is called at various points during the unwind phase of the exception-handling process. ExceptionUnwind
        /// can be called more than once while unwinding a single exception. If dwEventType = DEBUG_EXCEPTION_INTERCEPTED,
        /// the instruction pointer will be in the leaf frame of the thread, at the sequence point before (this may be several
        /// instructions before) the instruction that led to the exception.
        /// </remarks>
        public HRESULT TryExceptionUnwind(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, CorDebugExceptionUnwindCallbackType dwEventType, int dwFlags)
        {
            /*HRESULT ExceptionUnwind(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] CorDebugExceptionUnwindCallbackType dwEventType,
            [In] int dwFlags);*/
            return Raw2.ExceptionUnwind(pAppDomain, pThread, dwEventType, dwFlags);
        }

        #endregion
        #region FunctionRemapComplete

        /// <summary>
        /// Notifies the debugger that code execution has switched to a new version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function currently running on the thread.</param>
        /// <remarks>
        /// This callback gives the debugger an opportunity to recreate any steppers that previously existed.
        /// </remarks>
        public void FunctionRemapComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction)
        {
            HRESULT hr;

            if ((hr = TryFunctionRemapComplete(pAppDomain, pThread, pFunction)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the debugger that code execution has switched to a new version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function currently running on the thread.</param>
        /// <remarks>
        /// This callback gives the debugger an opportunity to recreate any steppers that previously existed.
        /// </remarks>
        public HRESULT TryFunctionRemapComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction)
        {
            /*HRESULT FunctionRemapComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction);*/
            return Raw2.FunctionRemapComplete(pAppDomain, pThread, pFunction);
        }

        #endregion
        #region MDANotification

        /// <summary>
        /// Provides notification that code execution has encountered a managed debugging assistant (MDA) in the application that is being debugged.
        /// </summary>
        /// <param name="pController">[in] A pointer to an <see cref="ICorDebugController"/> interface that exposes the process or application domain in which the MDA occurred.<para/>
        /// A debugger should not make any assumptions about whether the controller is a process or an application domain, although it can always query the interface to make a determination.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> interface that exposes the managed thread on which the debug event occurred.<para/>
        /// If the MDA occurred on an unmanaged thread, the value of pThread will be null. You must get the operating system (OS) thread ID from the MDA object itself.</param>
        /// <param name="pMDA">[in] A pointer to an <see cref="ICorDebugMDA"/> interface that exposes the MDA information.</param>
        /// <remarks>
        /// An MDA is a heuristic warning and does not require any explicit debugger action except for calling <see cref="CorDebugController.Continue"/>
        /// to resume execution of the application that is being debugged. The common language runtime (CLR) can determine
        /// which MDAs are fired and which data is in any given MDA at any point. Therefore, debuggers should not build any
        /// functionality requiring specific MDA patterns. MDAs may be queued and fired shortly after the MDA is encountered.
        /// This could happen if the runtime needs to wait until it reaches a safe point for firing the MDA, instead of firing
        /// the MDA when it encounters it. It also means that the runtime may fire a number of MDAs in a single set of queued
        /// callbacks (similar to an "attach" event operation). A debugger should release the reference to an <see cref="ICorDebugMDA"/>
        /// instance immediately after returning from the MDANotification callback, to allow the CLR to recycle the memory
        /// consumed by an MDA. Releasing the instance may improve performance if many MDAs are firing.
        /// </remarks>
        public void MDANotification(ICorDebugController pController, ICorDebugThread pThread, ICorDebugMDA pMDA)
        {
            HRESULT hr;

            if ((hr = TryMDANotification(pController, pThread, pMDA)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Provides notification that code execution has encountered a managed debugging assistant (MDA) in the application that is being debugged.
        /// </summary>
        /// <param name="pController">[in] A pointer to an <see cref="ICorDebugController"/> interface that exposes the process or application domain in which the MDA occurred.<para/>
        /// A debugger should not make any assumptions about whether the controller is a process or an application domain, although it can always query the interface to make a determination.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> interface that exposes the managed thread on which the debug event occurred.<para/>
        /// If the MDA occurred on an unmanaged thread, the value of pThread will be null. You must get the operating system (OS) thread ID from the MDA object itself.</param>
        /// <param name="pMDA">[in] A pointer to an <see cref="ICorDebugMDA"/> interface that exposes the MDA information.</param>
        /// <remarks>
        /// An MDA is a heuristic warning and does not require any explicit debugger action except for calling <see cref="CorDebugController.Continue"/>
        /// to resume execution of the application that is being debugged. The common language runtime (CLR) can determine
        /// which MDAs are fired and which data is in any given MDA at any point. Therefore, debuggers should not build any
        /// functionality requiring specific MDA patterns. MDAs may be queued and fired shortly after the MDA is encountered.
        /// This could happen if the runtime needs to wait until it reaches a safe point for firing the MDA, instead of firing
        /// the MDA when it encounters it. It also means that the runtime may fire a number of MDAs in a single set of queued
        /// callbacks (similar to an "attach" event operation). A debugger should release the reference to an <see cref="ICorDebugMDA"/>
        /// instance immediately after returning from the MDANotification callback, to allow the CLR to recycle the memory
        /// consumed by an MDA. Releasing the instance may improve performance if many MDAs are firing.
        /// </remarks>
        public HRESULT TryMDANotification(ICorDebugController pController, ICorDebugThread pThread, ICorDebugMDA pMDA)
        {
            /*HRESULT MDANotification(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugController pController,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugMDA pMDA);*/
            return Raw2.MDANotification(pController, pThread, pMDA);
        }

        #endregion
        #endregion
        #region ICorDebugManagedCallback3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugManagedCallback3 Raw3 => (ICorDebugManagedCallback3) Raw;

        #region CustomNotification

        /// <summary>
        /// Indicates that a custom debugger notification has been raised.
        /// </summary>
        /// <param name="pThread">[in] A pointer to the thread that raised the notification.</param>
        /// <param name="pAppDomain">[in] A pointer to the application domain that contains the thread that raised the notification.</param>
        /// <remarks>
        /// A subsequent call to the <see cref="CorDebugThread.CurrentCustomDebuggerNotification"/> property retrieves the
        /// thread object that was passed to the <see cref="Debugger.NotifyOfCrossThreadDependency"/> method. The thread object's
        /// type must have been previously enabled by calling the <see cref="CorDebugProcess.SetEnableCustomNotification"/>
        /// method. The debugger can read type-specific parameters from the fields of the thread object, and can store responses
        /// into fields. The <see cref="ICorDebug"/> interface imposes no policy on the types of notifications or their contents,
        /// and the semantics of the notifications are strictly a contract between debuggers, applications, and the .NET Framework.
        /// </remarks>
        public void CustomNotification(ICorDebugThread pThread, ICorDebugAppDomain pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryCustomNotification(pThread, pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Indicates that a custom debugger notification has been raised.
        /// </summary>
        /// <param name="pThread">[in] A pointer to the thread that raised the notification.</param>
        /// <param name="pAppDomain">[in] A pointer to the application domain that contains the thread that raised the notification.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// A subsequent call to the <see cref="CorDebugThread.CurrentCustomDebuggerNotification"/> property retrieves the
        /// thread object that was passed to the <see cref="Debugger.NotifyOfCrossThreadDependency"/> method. The thread object's
        /// type must have been previously enabled by calling the <see cref="CorDebugProcess.SetEnableCustomNotification"/>
        /// method. The debugger can read type-specific parameters from the fields of the thread object, and can store responses
        /// into fields. The <see cref="ICorDebug"/> interface imposes no policy on the types of notifications or their contents,
        /// and the semantics of the notifications are strictly a contract between debuggers, applications, and the .NET Framework.
        /// </remarks>
        public HRESULT TryCustomNotification(ICorDebugThread pThread, ICorDebugAppDomain pAppDomain)
        {
            /*HRESULT CustomNotification([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);*/
            return Raw3.CustomNotification(pThread, pAppDomain);
        }

        #endregion
        #endregion
    }
}