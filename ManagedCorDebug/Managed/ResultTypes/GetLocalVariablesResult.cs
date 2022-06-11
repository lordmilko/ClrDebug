using System;

namespace ManagedCorDebug
{
    public struct GetLocalVariablesResult
    {
        public IntPtr RgLocals { get; }

        public uint PceltFetched { get; }

        public GetLocalVariablesResult(IntPtr rgLocals, uint pceltFetched)
        {
            RgLocals = rgLocals;
            PceltFetched = pceltFetched;
        }
    }
}