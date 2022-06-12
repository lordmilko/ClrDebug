using System;

namespace ManagedCorDebug
{
    public struct GetStaticFieldSymbolsResult
    {
        public int PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetStaticFieldSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}