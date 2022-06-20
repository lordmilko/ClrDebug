using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.EditAndContinueRemap"/> method.
    /// </summary>
    public class EditAndContinueRemapCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.EditAndContinueRemap;

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
        public EditAndContinueRemapCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction, int fAccurate) : base(pAppDomain, pThread)
        {
            rawFunction = pFunction;
            Accurate = fAccurate == 1;
        }
    }
}