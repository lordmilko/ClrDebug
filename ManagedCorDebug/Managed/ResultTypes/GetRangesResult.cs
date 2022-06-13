using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedMethod.GetRanges"/> method.
    /// </summary>
    [DebuggerDisplay("pcRanges = {pcRanges}, ranges = {ranges}")]
    public struct GetRangesResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size of the buffer required to contain the ranges.
        /// </summary>
        public int pcRanges { get; }

        /// <summary>
        /// A pointer to the buffer that receives the ranges.
        /// </summary>
        public int[] ranges { get; }

        public GetRangesResult(int pcRanges, int[] ranges)
        {
            this.pcRanges = pcRanges;
            this.ranges = ranges;
        }
    }
}