using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.FindSymbolByRVAEx"/> method.
    /// </summary>
    [DebuggerDisplay("ppSymbol = {ppSymbol.ToString(),nq}, displacement = {displacement}")]
    public struct FindSymbolByRVAExResult
    {
        /// <summary>
        /// Returns an IDiaSymbol object that represents the symbol retrieved.
        /// </summary>
        public DiaSymbol ppSymbol { get; }

        /// <summary>
        /// Returns a value specifying an offset from the relative virtual address specified in rva.
        /// </summary>
        public int displacement { get; }

        public FindSymbolByRVAExResult(DiaSymbol ppSymbol, int displacement)
        {
            this.ppSymbol = ppSymbol;
            this.displacement = displacement;
        }
    }
}
