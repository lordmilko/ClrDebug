using System;

namespace ManagedCorDebug
{
    public struct GetSigFromTokenResult
    {
        public IntPtr PpvSig { get; }

        public int PcbSig { get; }

        public GetSigFromTokenResult(IntPtr ppvSig, int pcbSig)
        {
            PpvSig = ppvSig;
            PcbSig = pcbSig;
        }
    }
}