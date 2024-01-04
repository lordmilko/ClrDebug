using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostModule.FindContainingSymbolByRVA"/> method.
    /// </summary>
    [DebuggerDisplay("symbol = {symbol?.ToString(),nq}, offset = {offset}")]
    public struct FindContainingSymbolByRVAResult
    {
        /// <summary>
        /// The found symbol will be returned here.
        /// </summary>
        public DebugHostSymbol symbol { get; }

        /// <summary>
        /// The offset value.
        /// </summary>
        public long offset { get; }

        public FindContainingSymbolByRVAResult(DebugHostSymbol symbol, long offset)
        {
            this.symbol = symbol;
            this.offset = offset;
        }
    }
}
