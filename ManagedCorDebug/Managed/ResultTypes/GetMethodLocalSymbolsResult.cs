using System;

namespace ManagedCorDebug
{
    public struct GetMethodLocalSymbolsResult
    {
        public int PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetMethodLocalSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}