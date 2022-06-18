using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetMethodLocalSymbols"/> method.
    /// </summary>
    [DebuggerDisplay("pcFetchedSymbols = {pcFetchedSymbols}, pSymbols = {pSymbols}")]
    public struct GetMethodLocalSymbolsResult
    {
        /// <summary>
        /// A pointer to the number of symbols retrieved by the method.
        /// </summary>
        public int pcFetchedSymbols { get; }

        /// <summary>
        /// A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.
        /// </summary>
        public ICorDebugVariableSymbol[] pSymbols { get; }

        public GetMethodLocalSymbolsResult(int pcFetchedSymbols, ICorDebugVariableSymbol[] pSymbols)
        {
            this.pcFetchedSymbols = pcFetchedSymbols;
            this.pSymbols = pSymbols;
        }
    }
}