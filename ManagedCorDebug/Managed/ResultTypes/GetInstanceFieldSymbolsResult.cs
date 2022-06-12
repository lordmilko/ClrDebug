using System;

namespace ManagedCorDebug
{
    public struct GetInstanceFieldSymbolsResult
    {
        public int PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetInstanceFieldSymbolsResult(int pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}