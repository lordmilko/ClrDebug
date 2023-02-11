using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.StringLayout"/> property.
    /// </summary>
    [DebuggerDisplay("pBufferLengthOffset = {pBufferLengthOffset}, pStringLengthOffset = {pStringLengthOffset}, pBufferOffset = {pBufferOffset}")]
    public struct GetStringLayoutResult
    {
        /// <summary>
        /// A pointer to the offset of the location, relative to the ObjectID pointer, that stores the length of the string.<para/>
        /// The length is stored as a DWORD.
        /// </summary>
        public int pBufferLengthOffset { get; }

        /// <summary>
        /// A pointer to the offset of the location, relative to the ObjectID pointer, that stores the length of the string itself.<para/>
        /// The length is stored as a DWORD.
        /// </summary>
        public int pStringLengthOffset { get; }

        /// <summary>
        /// A pointer to the offset of the buffer, relative to the ObjectID pointer, that stores the string of wide characters.
        /// </summary>
        public int pBufferOffset { get; }

        public GetStringLayoutResult(int pBufferLengthOffset, int pStringLengthOffset, int pBufferOffset)
        {
            this.pBufferLengthOffset = pBufferLengthOffset;
            this.pStringLengthOffset = pStringLengthOffset;
            this.pBufferOffset = pBufferOffset;
        }
    }
}
