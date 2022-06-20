using System.Diagnostics;

namespace ManagedCorDebug
{
    public abstract class AppDomainThreadDebugCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the break instruction.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the break instruction.
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

        protected AppDomainThreadDebugCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread thread) : base(GetAppDomain(pAppDomain, thread))
        {
        }

        private static ICorDebugAppDomain GetAppDomain(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread)
        {
            //Sometimes the AppDomain is null; if so, try and get it from the thread. If we fail, an ArgumentNullException
            if (pAppDomain != null)
                return pAppDomain;

            if (pThread != null)
                pThread.GetAppDomain(out pAppDomain).ThrowOnNotOK();

            return pAppDomain;
        }
    }
}