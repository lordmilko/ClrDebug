using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetInstanceFieldSymbols"/> method.
    /// </summary>
    [DebuggerDisplay("pcFetchedSymbols = {pcFetchedSymbols}, pSymbols = {pSymbols}")]
    public struct GetInstanceFieldSymbolsResult
    {
        /// <summary>
        /// A pointer to the number of symbols retrieved by the method.
        /// </summary>
        public int pcFetchedSymbols { get; }

        /// <summary>
        /// A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested instance field symbols.
        /// </summary>
        public ICorDebugInstanceFieldSymbol[] pSymbols { get; }

        public GetInstanceFieldSymbolsResult(int pcFetchedSymbols, ICorDebugInstanceFieldSymbol[] pSymbols)
        {
            this.pcFetchedSymbols = pcFetchedSymbols;
            this.pSymbols = pSymbols;
        }
    }
}