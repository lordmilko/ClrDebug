using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.FindSymbolByVAEx"/> method.
    /// </summary>
    [DebuggerDisplay("ppSymbol = {ppSymbol.ToString(),nq}, displacement = {displacement}")]
    public struct FindSymbolByVAExResult
    {
        /// <summary>
        /// Returns an IDiaSymbol object that represents the symbol retrieved.
        /// </summary>
        public DiaSymbol ppSymbol { get; }

        /// <summary>
        /// Returns a value that specifies an offset from the virtual address given by va.
        /// </summary>
        public int displacement { get; }

        public FindSymbolByVAExResult(DiaSymbol ppSymbol, int displacement)
        {
            this.ppSymbol = ppSymbol;
            this.displacement = displacement;
        }
    }
}
