using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostType.TaggedUnionTag"/> property.
    /// </summary>
    [DebuggerDisplay("pTagType = {pTagType?.ToString(),nq}, pTagOffset = {pTagOffset}, pTagMask = {pTagMask}")]
    public struct GetTaggedUnionTagResult
    {
        public DebugHostType pTagType { get; }

        public int pTagOffset { get; }

        public object pTagMask { get; }

        public GetTaggedUnionTagResult(DebugHostType pTagType, int pTagOffset, object pTagMask)
        {
            this.pTagType = pTagType;
            this.pTagOffset = pTagOffset;
            this.pTagMask = pTagMask;
        }
    }
}
