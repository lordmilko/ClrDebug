using System;

namespace ManagedCorDebug
{
    public struct GetInstanceFieldSymbolsResult
    {
        public uint PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetInstanceFieldSymbolsResult(uint pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}