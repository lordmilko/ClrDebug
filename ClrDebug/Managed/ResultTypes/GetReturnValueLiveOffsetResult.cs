using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugCode.GetReturnValueLiveOffset"/> method.
    /// </summary>
    [DebuggerDisplay("pFetched = {pFetched}, pOffsets = {pOffsets}")]
    public struct GetReturnValueLiveOffsetResult
    {
        /// <summary>
        /// A pointer to the number of offsets actually returned. Usually, its value is 1, but a single IL instruction can map to multiple CALL assembly instructions.
        /// </summary>
        public int pFetched { get; }

        /// <summary>
        /// An array of native offsets. Typically, pOffsets contains a single offset, although a single IL instruction can map to multiple map to multiple CALL assembly instructions.
        /// </summary>
        public int pOffsets { get; }

        public GetReturnValueLiveOffsetResult(int pFetched, int pOffsets)
        {
            this.pFetched = pFetched;
            this.pOffsets = pOffsets;
        }
    }
}