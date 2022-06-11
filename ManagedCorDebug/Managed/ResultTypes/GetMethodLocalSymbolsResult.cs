using System;

namespace ManagedCorDebug
{
    public struct GetMethodLocalSymbolsResult
    {
        public uint PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetMethodLocalSymbolsResult(uint pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}