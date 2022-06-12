using System;

namespace ManagedCorDebug
{
    public struct GetLocalVariablesResult
    {
        public IntPtr RgLocals { get; }

        public int PceltFetched { get; }

        public GetLocalVariablesResult(IntPtr rgLocals, int pceltFetched)
        {
            RgLocals = rgLocals;
            PceltFetched = pceltFetched;
        }
    }
}