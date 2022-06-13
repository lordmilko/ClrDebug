using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.Breakpoint"/> method.
    /// </summary>
    public class BreakpointCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.Breakpoint;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the breakpoint.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the breakpoint.
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
        #region Breakpoint

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugBreakpoint rawBreakpoint;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugBreakpoint breakpoint;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the breakpoint.
        /// </summary>
        public CorDebugBreakpoint Breakpoint
        {
            get
            {
                if (breakpoint == null && rawBreakpoint != null)
                    breakpoint = CorDebugBreakpoint.New(rawBreakpoint);

                return breakpoint;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger when a breakpoint is encountered.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the breakpoint.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the breakpoint.</param>
        /// <param name="pBreakpoint">A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the breakpoint.</param>
        public BreakpointCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            rawBreakpoint = pBreakpoint;
        }
    }
}