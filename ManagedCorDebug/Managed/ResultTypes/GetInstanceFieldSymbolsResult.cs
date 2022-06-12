using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetInstanceFieldSymbols"/> method.
    /// </summary>
    public struct GetInstanceFieldSymbolsResult
    {
        /// <summary>
        /// [out] A pointer to the number of symbols retrieved by the method.
        /// </summary>
        public int pcFetchedSymbols { get; }

        /// <summary>
        /// [out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested instance field symbols.
        /// </summary>
        public IntPtr pSymbols { get; }

        public GetInstanceFieldSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            this.pcFetchedSymbols = pcFetchedSymbols;
            this.pSymbols = pSymbols;
        }
    }
}