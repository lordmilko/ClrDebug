using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback3.CustomNotification"/> method.
    /// </summary>
    public class CustomNotificationCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.CustomNotification;

        #region Thread

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugThread rawThread;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugThread thread;

        /// <summary>
        /// A pointer to the thread that raised the notification.
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
        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to the application domain that contains the thread that raised the notification.
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
        
        /// <summary>
        /// Indicates that a custom debugger notification has been raised.
        /// </summary>
        /// <param name="pThread">A pointer to the thread that raised the notification.</param>
        /// <param name="pAppDomain">A pointer to the application domain that contains the thread that raised the notification.</param>
        public CustomNotificationCorDebugManagedCallbackEventArgs(ICorDebugThread pThread, ICorDebugAppDomain pAppDomain)
        {
            rawThread = pThread;
            rawAppDomain = pAppDomain;
        }
    }
}