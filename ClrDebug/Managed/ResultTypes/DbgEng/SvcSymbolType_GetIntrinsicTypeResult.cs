using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolType.IntrinsicType"/> property.
    /// </summary>
    [DebuggerDisplay("kind = {kind.ToString(),nq}, packingSize = {packingSize}")]
    public struct SvcSymbolType_GetIntrinsicTypeResult
    {
        public SvcSymbolIntrinsicKind kind { get; }

        public int packingSize { get; }

        public SvcSymbolType_GetIntrinsicTypeResult(SvcSymbolIntrinsicKind kind, int packingSize)
        {
            this.kind = kind;
            this.packingSize = packingSize;
        }
    }
}
