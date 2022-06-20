using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugFrame.StackRange"/> property.
    /// </summary>
    [DebuggerDisplay("pStart = {pStart.ToString(),nq}, pEnd = {pEnd.ToString(),nq}")]
    public struct GetStackRangeResult
    {
        /// <summary>
        /// A pointer to a <see cref="CORDB_ADDRESS"/> that specifies the starting address of the stack frame represented by this <see cref="ICorDebugFrame"/> object.
        /// </summary>
        public CORDB_ADDRESS pStart { get; }

        /// <summary>
        /// A pointer to a <see cref="CORDB_ADDRESS"/> that specifies the ending address of the stack frame represented by this <see cref="ICorDebugFrame"/> object.
        /// </summary>
        public CORDB_ADDRESS pEnd { get; }

        public GetStackRangeResult(CORDB_ADDRESS pStart, CORDB_ADDRESS pEnd)
        {
            this.pStart = pStart;
            this.pEnd = pEnd;
        }
    }
}