using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.FunctionRemapOpportunity"/> method.
    /// </summary>
    public class FunctionRemapOpportunityCorDebugManagedCallbackEventArgs : AppDomainThreadDebugCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.FunctionRemapOpportunity;

        #region OldFunction

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugFunction rawOldFunction;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugFunction oldFunction;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function that is currently running on the thread.
        /// </summary>
        public CorDebugFunction OldFunction
        {
            get
            {
                if (oldFunction == null && rawOldFunction != null)
                    oldFunction = new CorDebugFunction(rawOldFunction);

                return oldFunction;
            }
        }

        #endregion
        #region NewFunction

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugFunction rawNewFunction;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugFunction newFunction;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugFunction"/> object that represents the latest version of the function.
        /// </summary>
        public CorDebugFunction NewFunction
        {
            get
            {
                if (newFunction == null && rawNewFunction != null)
                    newFunction = new CorDebugFunction(rawNewFunction);

                return newFunction;
            }
        }

        #endregion
        
        /// <summary>
        /// The Microsoft intermediate language (MSIL) offset of the instruction pointer in the old version of the function.
        /// </summary>
        public int OldILOffset { get; }

        /// <summary>
        /// Notifies the debugger that code execution has reached a sequence point in an older version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pOldFunction">A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function that is currently running on the thread.</param>
        /// <param name="pNewFunction">A pointer to an <see cref="ICorDebugFunction"/> object that represents the latest version of the function.</param>
        /// <param name="oldILOffset">The Microsoft intermediate language (MSIL) offset of the instruction pointer in the old version of the function.</param>
        public FunctionRemapOpportunityCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pOldFunction, ICorDebugFunction pNewFunction, int oldILOffset) : base(pAppDomain, pThread)
        {
            rawOldFunction = pOldFunction;
            rawNewFunction = pNewFunction;
            OldILOffset = oldILOffset;
        }
    }
}