using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugVariableHome.LiveRange"/> property.
    /// </summary>
    [DebuggerDisplay("pStartOffset = {pStartOffset}, pEndOffset = {pEndOffset}")]
    public struct GetLiveRangeResult
    {
        /// <summary>
        /// [out] The logical offset at which the variable is first live.
        /// </summary>
        public int pStartOffset { get; }

        /// <summary>
        /// [out] The logical offset immediately after the point at which the variable is last live.
        /// </summary>
        public int pEndOffset { get; }

        public GetLiveRangeResult(int pStartOffset, int pEndOffset)
        {
            this.pStartOffset = pStartOffset;
            this.pEndOffset = pEndOffset;
        }
    }
}