using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageMemoryViewRegion.FileViewAssociation"/> property.
    /// </summary>
    [DebuggerDisplay("pFileViewOffset = {pFileViewOffset}, pFileViewSize = {pFileViewSize}, pExtraByteMapping = {pExtraByteMapping.ToString(),nq}")]
    public struct GetFileViewAssociationResult
    {
        public long pFileViewOffset { get; }

        public long pFileViewSize { get; }

        public ServiceImageByteMapping pExtraByteMapping { get; }

        public GetFileViewAssociationResult(long pFileViewOffset, long pFileViewSize, ServiceImageByteMapping pExtraByteMapping)
        {
            this.pFileViewOffset = pFileViewOffset;
            this.pFileViewSize = pFileViewSize;
            this.pExtraByteMapping = pExtraByteMapping;
        }
    }
}
