using System;

namespace ManagedCorDebug
{
    public struct GetSigFromTokenResult
    {
        public IntPtr PpvSig { get; }

        public uint PcbSig { get; }

        public GetSigFromTokenResult(IntPtr ppvSig, uint pcbSig)
        {
            PpvSig = ppvSig;
            PcbSig = pcbSig;
        }
    }
}