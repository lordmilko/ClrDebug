using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelScriptDebugStackFrame.Transition"/> property.
    /// </summary>
    [DebuggerDisplay("transitionScript = {transitionScript?.ToString(),nq}, isTransitionContiguous = {isTransitionContiguous}")]
    public struct GetTransitionResult
    {
        /// <summary>
        /// The debugger returns the previous script here. The previous script is the one which called into the script represented by the stack segment containing this IDataModelStackDebugFrame.
        /// </summary>
        public DataModelScript transitionScript { get; }

        /// <summary>
        /// An indication of whether the transition is contiguous or not is returned here.
        /// </summary>
        public bool isTransitionContiguous { get; }

        public GetTransitionResult(DataModelScript transitionScript, bool isTransitionContiguous)
        {
            this.transitionScript = transitionScript;
            this.isTransitionContiguous = isTransitionContiguous;
        }
    }
}
