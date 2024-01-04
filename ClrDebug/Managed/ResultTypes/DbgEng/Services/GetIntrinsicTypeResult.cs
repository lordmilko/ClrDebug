using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolType.IntrinsicType"/> property.
    /// </summary>
    [DebuggerDisplay("kind = {kind.ToString(),nq}, packingSize = {packingSize}")]
    public struct GetIntrinsicTypeResult
    {
        public SvcSymbolIntrinsicKind kind { get; }

        public int packingSize { get; }

        public GetIntrinsicTypeResult(SvcSymbolIntrinsicKind kind, int packingSize)
        {
            this.kind = kind;
            this.packingSize = packingSize;
        }
    }
}
