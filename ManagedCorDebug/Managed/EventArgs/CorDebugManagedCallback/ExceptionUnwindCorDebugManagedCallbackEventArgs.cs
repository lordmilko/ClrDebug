using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.ExceptionUnwind"/> method.
    /// </summary>
    public class ExceptionUnwindCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.ExceptionUnwind;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.
        /// </summary>
        public CorDebugAppDomain AppDomain
        {
            get
            {
                if (appDomain == null && rawAppDomain != null)
                    appDomain = new CorDebugAppDomain(rawAppDomain);

                return appDomain;
            }
        }

        #endregion
        #region Thread

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugThread rawThread;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugThread thread;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.
        /// </summary>
        public CorDebugThread Thread
        {
            get
            {
                if (thread == null && rawThread != null)
                    thread = new CorDebugThread(rawThread);

                return thread;
            }
        }

        #endregion
        
        /// <summary>
        /// A value of the <see cref="CorDebugExceptionUnwindCallbackType"/> enumeration that specifies the event that is being signaled by the callback during the unwind phase.
        /// </summary>
        public CorDebugExceptionUnwindCallbackType EventType { get; }

        /// <summary>
        /// A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception.
        /// </summary>
        public int Flags { get; }

        /// <summary>
        /// Provides a status notification during the exception unwinding process.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="dwEventType">A value of the <see cref="CorDebugExceptionUnwindCallbackType"/> enumeration that specifies the event that is being signaled by the callback during the unwind phase.</param>
        /// <param name="dwFlags">A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception.</param>
        public ExceptionUnwindCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, CorDebugExceptionUnwindCallbackType dwEventType, int dwFlags)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            EventType = dwEventType;
            Flags = dwFlags;
        }
    }
}