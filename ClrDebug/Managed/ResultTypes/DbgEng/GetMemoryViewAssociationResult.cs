using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageFileViewRegion.MemoryViewAssociation"/> property.
    /// </summary>
    [DebuggerDisplay("pMemoryViewOffset = {pMemoryViewOffset}, pMemoryViewSize = {pMemoryViewSize}, pExtraByteMapping = {pExtraByteMapping.ToString(),nq}")]
    public struct GetMemoryViewAssociationResult
    {
        public long pMemoryViewOffset { get; }

        public long pMemoryViewSize { get; }

        public ServiceImageByteMapping pExtraByteMapping { get; }

        public GetMemoryViewAssociationResult(long pMemoryViewOffset, long pMemoryViewSize, ServiceImageByteMapping pExtraByteMapping)
        {
            this.pMemoryViewOffset = pMemoryViewOffset;
            this.pMemoryViewSize = pMemoryViewSize;
            this.pExtraByteMapping = pExtraByteMapping;
        }
    }
}
