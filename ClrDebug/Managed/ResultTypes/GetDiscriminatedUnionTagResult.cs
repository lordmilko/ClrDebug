using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSymbol.DiscriminatedUnionTag"/> property.
    /// </summary>
    [DebuggerDisplay("ppTagType = {ppTagType?.ToString(),nq}, pTagOffset = {pTagOffset}, pTagMask = {pTagMask.ToString(),nq}")]
    public struct GetDiscriminatedUnionTagResult
    {
        public DiaSymbol ppTagType { get; }

        public int pTagOffset { get; }

        public DiaTagValue pTagMask { get; }

        public GetDiscriminatedUnionTagResult(DiaSymbol ppTagType, int pTagOffset, DiaTagValue pTagMask)
        {
            this.ppTagType = ppTagType;
            this.pTagOffset = pTagOffset;
            this.pTagMask = pTagMask;
        }
    }
}
