using System;

namespace ManagedCorDebug
{
    public struct GetStaticFieldSymbolsResult
    {
        public uint PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetStaticFieldSymbolsResult(uint pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}