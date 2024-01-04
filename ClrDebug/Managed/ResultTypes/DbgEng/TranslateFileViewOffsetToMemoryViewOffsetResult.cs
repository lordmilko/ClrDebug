using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageParser.TranslateFileViewOffsetToMemoryViewOffset"/> method.
    /// </summary>
    [DebuggerDisplay("pMemoryViewOffset = {pMemoryViewOffset}, pMappedByteCount = {pMappedByteCount}")]
    public struct TranslateFileViewOffsetToMemoryViewOffsetResult
    {
        public long pMemoryViewOffset { get; }

        public long pMappedByteCount { get; }

        public TranslateFileViewOffsetToMemoryViewOffsetResult(long pMemoryViewOffset, long pMappedByteCount)
        {
            this.pMemoryViewOffset = pMemoryViewOffset;
            this.pMappedByteCount = pMappedByteCount;
        }
    }
}
