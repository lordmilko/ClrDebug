using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetMethodLocalSymbols"/> method.
    /// </summary>
    public struct GetMethodLocalSymbolsResult
    {
        /// <summary>
        /// [out] A pointer to the number of symbols retrieved by the method.
        /// </summary>
        public int pcFetchedSymbols { get; }

        /// <summary>
        /// [out] A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.
        /// </summary>
        public IntPtr pSymbols { get; }

        public GetMethodLocalSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            this.pcFetchedSymbols = pcFetchedSymbols;
            this.pSymbols = pSymbols;
        }
    }
}