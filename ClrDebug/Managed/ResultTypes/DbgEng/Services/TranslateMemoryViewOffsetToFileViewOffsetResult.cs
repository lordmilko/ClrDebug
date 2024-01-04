using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageParser.TranslateMemoryViewOffsetToFileViewOffset"/> method.
    /// </summary>
    [DebuggerDisplay("pFileViewOffset = {pFileViewOffset}, pMappedByteCount = {pMappedByteCount}")]
    public struct TranslateMemoryViewOffsetToFileViewOffsetResult
    {
        public long pFileViewOffset { get; }

        public long pMappedByteCount { get; }

        public TranslateMemoryViewOffsetToFileViewOffsetResult(long pFileViewOffset, long pMappedByteCount)
        {
            this.pFileViewOffset = pFileViewOffset;
            this.pMappedByteCount = pMappedByteCount;
        }
    }
}
