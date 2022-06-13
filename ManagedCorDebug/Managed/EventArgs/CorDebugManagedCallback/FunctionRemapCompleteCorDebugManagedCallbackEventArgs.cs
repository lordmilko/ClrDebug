using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.FunctionRemapComplete"/> method.
    /// </summary>
    public class FunctionRemapCompleteCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.FunctionRemapComplete;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.
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
        #region Function

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugFunction rawFunction;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugFunction function;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function currently running on the thread.
        /// </summary>
        public CorDebugFunction Function
        {
            get
            {
                if (function == null && rawFunction != null)
                    function = new CorDebugFunction(rawFunction);

                return function;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger that code execution has switched to a new version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pFunction">A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function currently running on the thread.</param>
        public FunctionRemapCompleteCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            rawFunction = pFunction;
        }
    }
}