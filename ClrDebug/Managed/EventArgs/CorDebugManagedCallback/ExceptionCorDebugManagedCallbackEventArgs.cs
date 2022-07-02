using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.Exception"/> method.
    /// </summary>
    public class ExceptionCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.Exception;
        
        /// <summary>
        /// If this value is false, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.
        /// </summary>
        public int Unhandled { get; }

        /// <summary>
        /// Notifies the debugger that an exception has been thrown from managed code.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the exception was thrown.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the exception was thrown.</param>
        /// <param name="unhandled">If this value is false, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.</param>
        public ExceptionCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int unhandled) : base(pAppDomain, pThread)
        {
            Unhandled = unhandled;
        }
    }
}