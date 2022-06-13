using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetMethodParameterSymbols"/> method.
    /// </summary>
    [DebuggerDisplay("pcFetchedSymbols = {pcFetchedSymbols}, pSymbols = {pSymbols}")]
    public struct GetMethodParameterSymbolsResult
    {
        /// <summary>
        /// A pointer to the number of symbols retrieved by the method.
        /// </summary>
        public int pcFetchedSymbols { get; }

        /// <summary>
        /// A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.
        /// </summary>
        public IntPtr pSymbols { get; }

        public GetMethodParameterSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            this.pcFetchedSymbols = pcFetchedSymbols;
            this.pSymbols = pSymbols;
        }
    }
}