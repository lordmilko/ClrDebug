using System;

namespace ManagedCorDebug
{
    public struct GetTypeSpecFromTokenResult
    {
        public IntPtr PpvSig { get; }

        public int PcbSig { get; }

        public GetTypeSpecFromTokenResult(IntPtr ppvSig, int pcbSig)
        {
            PpvSig = ppvSig;
            PcbSig = pcbSig;
        }
    }
}