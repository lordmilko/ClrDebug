using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.BreakpointSetError"/> method.
    /// </summary>
    public class BreakpointSetErrorCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.BreakpointSetError;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the unbound breakpoint.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the unbound breakpoint.
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
        /// A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the unbound breakpoint.
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
        /// An integer that indicates the error.
        /// </summary>
        public int Error { get; }

        /// <summary>
        /// Notifies the debugger that the common language runtime was unable to accurately bind a breakpoint that was set before a function was just-in-time (JIT) compiled.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain that contains the unbound breakpoint.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread that contains the unbound breakpoint.</param>
        /// <param name="pBreakpoint">A pointer to an <see cref="ICorDebugBreakpoint"/> object that represents the unbound breakpoint.</param>
        /// <param name="dwError">An integer that indicates the error.</param>
        public BreakpointSetErrorCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint, int dwError)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            rawBreakpoint = pBreakpoint;
            Error = dwError;
        }
    }
}