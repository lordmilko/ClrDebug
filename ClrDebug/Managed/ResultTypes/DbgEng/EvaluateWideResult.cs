using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.EvaluateWide"/> method.
    /// </summary>
    [DebuggerDisplay("Value = {Value.ToString(),nq}, RemainderIndex = {RemainderIndex}")]
    public struct EvaluateWideResult
    {
        /// <summary>
        /// Receives the value of the expression.
        /// </summary>
        public DEBUG_VALUE Value { get; }

        /// <summary>
        /// Receives the index of the first character of the expression not used in the evaluation. If RemainderIndex is NULL, this information isn't returned.
        /// </summary>
        public uint RemainderIndex { get; }

        public EvaluateWideResult(DEBUG_VALUE value, uint remainderIndex)
        {
            Value = value;
            RemainderIndex = remainderIndex;
        }
    }
}
