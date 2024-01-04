using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageDataLocationParser.LocateDataBlob"/> method.
    /// </summary>
    [DebuggerDisplay("pFileOffset = {pFileOffset}, pMemoryOffset = {pMemoryOffset}, pBlobSize = {pBlobSize}")]
    public struct LocateDataBlobResult
    {
        public long pFileOffset { get; }

        public long pMemoryOffset { get; }

        public long pBlobSize { get; }

        public LocateDataBlobResult(long pFileOffset, long pMemoryOffset, long pBlobSize)
        {
            this.pFileOffset = pFileOffset;
            this.pMemoryOffset = pMemoryOffset;
            this.pBlobSize = pBlobSize;
        }
    }
}
