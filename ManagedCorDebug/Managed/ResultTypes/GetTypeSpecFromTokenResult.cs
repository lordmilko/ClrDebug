using System;

namespace ManagedCorDebug
{
    public struct GetTypeSpecFromTokenResult
    {
        public IntPtr PpvSig { get; }

        public uint PcbSig { get; }

        public GetTypeSpecFromTokenResult(IntPtr ppvSig, uint pcbSig)
        {
            PpvSig = ppvSig;
            PcbSig = pcbSig;
        }
    }
}