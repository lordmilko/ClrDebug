using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.Exception"/> method.
    /// </summary>
    public class ExceptionCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.Exception;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the exception was thrown.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the exception was thrown.
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
        /// If this value is false, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.
        /// </summary>
        public int Unhandled { get; }

        /// <summary>
        /// Notifies the debugger that an exception has been thrown from managed code.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the exception was thrown.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the exception was thrown.</param>
        /// <param name="unhandled">If this value is false, the exception has not yet been processed by the application; otherwise, the exception is unhandled and will terminate the process.</param>
        public ExceptionCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int unhandled)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            Unhandled = unhandled;
        }
    }
}