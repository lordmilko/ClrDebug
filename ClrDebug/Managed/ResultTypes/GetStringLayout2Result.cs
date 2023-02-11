using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.StringLayout2"/> property.
    /// </summary>
    [DebuggerDisplay("pStringLengthOffset = {pStringLengthOffset}, pBufferOffset = {pBufferOffset}")]
    public struct GetStringLayout2Result
    {
        /// <summary>
        /// A pointer to the offset of the location, relative to the ObjectID pointer, that stores the length of the string itself.<para/>
        /// The length is stored as a DWORD.
        /// </summary>
        public int pStringLengthOffset { get; }

        /// <summary>
        /// A pointer to the offset of the buffer, relative to the ObjectID pointer, which stores the string of wide characters.
        /// </summary>
        public int pBufferOffset { get; }

        public GetStringLayout2Result(int pStringLengthOffset, int pBufferOffset)
        {
            this.pStringLengthOffset = pStringLengthOffset;
            this.pBufferOffset = pBufferOffset;
        }
    }
}
