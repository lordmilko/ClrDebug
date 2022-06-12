using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetStaticFieldSymbols"/> method.
    /// </summary>
    [DebuggerDisplay("pcFetchedSymbols = {pcFetchedSymbols}, pSymbols = {pSymbols}")]
    public struct GetStaticFieldSymbolsResult
    {
        /// <summary>
        /// [out] A pointer to the number of symbols retrieved by the method.
        /// </summary>
        public int pcFetchedSymbols { get; }

        /// <summary>
        /// [out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested static field symbols.
        /// </summary>
        public IntPtr pSymbols { get; }

        public GetStaticFieldSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            this.pcFetchedSymbols = pcFetchedSymbols;
            this.pSymbols = pSymbols;
        }
    }
}