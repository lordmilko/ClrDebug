using System;

namespace ManagedCorDebug
{
    public struct GetMethodParameterSymbolsResult
    {
        public int PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetMethodParameterSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}