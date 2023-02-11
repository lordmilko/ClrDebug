using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.ExceptionUnwind"/> method.
    /// </summary>
    public class ExceptionUnwindCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.ExceptionUnwind;
        
        /// <summary>
        /// A value of the <see cref="CorDebugExceptionUnwindCallbackType"/> enumeration that specifies the event that is being signaled by the callback during the unwind phase.
        /// </summary>
        public CorDebugExceptionUnwindCallbackType EventType { get; }

        /// <summary>
        /// A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception.
        /// </summary>
        public CorDebugExceptionFlags Flags { get; }

        /// <summary>
        /// Provides a status notification during the exception unwinding process.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="dwEventType">A value of the <see cref="CorDebugExceptionUnwindCallbackType"/> enumeration that specifies the event that is being signaled by the callback during the unwind phase.</param>
        /// <param name="dwFlags">A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception.</param>
        public ExceptionUnwindCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, CorDebugExceptionUnwindCallbackType dwEventType, CorDebugExceptionFlags dwFlags) : base(pAppDomain, pThread)
        {
            EventType = dwEventType;
            Flags = dwFlags;
        }
    }
}
