using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageParser.GetFileViewOffset"/> method.
    /// </summary>
    [DebuggerDisplay("pFileViewOffset = {pFileViewOffset}, pMappedByteCount = {pMappedByteCount}")]
    public struct GetFileViewOffsetResult
    {
        public long pFileViewOffset { get; }

        public long pMappedByteCount { get; }

        public GetFileViewOffsetResult(long pFileViewOffset, long pMappedByteCount)
        {
            this.pFileViewOffset = pFileViewOffset;
            this.pMappedByteCount = pMappedByteCount;
        }
    }
}
