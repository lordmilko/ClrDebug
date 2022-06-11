using System;

namespace ManagedCorDebug
{
    public struct GetMethodParameterSymbolsResult
    {
        public uint PcFetchedSymbols { get; }

        public IntPtr PSymbols { get; }

        public GetMethodParameterSymbolsResult(uint pcFetchedSymbols, IntPtr pSymbols)
        {
            PcFetchedSymbols = pcFetchedSymbols;
            PSymbols = pSymbols;
        }
    }
}