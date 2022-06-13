using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.NameChange"/> method.
    /// </summary>
    public class NameChangeCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.NameChange;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that either had a name change or that contains the thread that had a name change.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that had a name change.
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
        /// Notifies the debugger that the name of either an application domain or a thread has changed.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that either had a name change or that contains the thread that had a name change.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that had a name change.</param>
        public NameChangeCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
        }
    }
}