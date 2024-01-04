using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolSetSimpleNameResolution.FindSymbolByOffset"/> method.
    /// </summary>
    [DebuggerDisplay("symbol = {symbol?.ToString(),nq}, symbolOffset = {symbolOffset}")]
    public struct FindSymbolByOffsetResult
    {
        public SvcSymbol symbol { get; }

        public long symbolOffset { get; }

        public FindSymbolByOffsetResult(SvcSymbol symbol, long symbolOffset)
        {
            this.symbol = symbol;
            this.symbolOffset = symbolOffset;
        }
    }
}
