using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostSymbolSubstitutionEnumerator.NextWithSubstitutionText"/> property.
    /// </summary>
    [DebuggerDisplay("symbol = {symbol?.ToString(),nq}, symbolText = {symbolText}")]
    public struct GetNextWithSubstitutionTextResult
    {
        public DebugHostSymbol symbol { get; }

        public string symbolText { get; }

        public GetNextWithSubstitutionTextResult(DebugHostSymbol symbol, string symbolText)
        {
            this.symbol = symbol;
            this.symbolText = symbolText;
        }
    }
}
