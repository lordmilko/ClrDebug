using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.EditAndContinueRemap"/> method.
    /// </summary>
    public class EditAndContinueRemapCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.EditAndContinueRemap;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

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
        
        public bool Accurate { get; }

        /// <summary>
        /// This method has been deprecated. It notifies the debugger that a remap event has been sent to the integrated development environment (IDE).
        /// </summary>
        public EditAndContinueRemapCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction, int fAccurate)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            rawFunction = pFunction;
            Accurate = fAccurate == 1;
        }
    }
}