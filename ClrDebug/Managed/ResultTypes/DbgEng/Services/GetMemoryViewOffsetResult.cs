using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageParser.GetMemoryViewOffset"/> method.
    /// </summary>
    [DebuggerDisplay("pMemoryViewOffset = {pMemoryViewOffset}, pMappedByteCount = {pMappedByteCount}")]
    public struct GetMemoryViewOffsetResult
    {
        public long pMemoryViewOffset { get; }

        public long pMappedByteCount { get; }

        public GetMemoryViewOffsetResult(long pMemoryViewOffset, long pMappedByteCount)
        {
            this.pMemoryViewOffset = pMemoryViewOffset;
            this.pMappedByteCount = pMappedByteCount;
        }
    }
}
