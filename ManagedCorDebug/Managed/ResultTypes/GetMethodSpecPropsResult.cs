using System;

namespace ManagedCorDebug
{
    public struct GetMethodSpecPropsResult
    {
        public mdToken TkParent { get; }

        public IntPtr PpvSigBlob { get; }

        public int PcbSigBlob { get; }

        public GetMethodSpecPropsResult(mdToken tkParent, IntPtr ppvSigBlob, int pcbSigBlob)
        {
            TkParent = tkParent;
            PpvSigBlob = ppvSigBlob;
            PcbSigBlob = pcbSigBlob;
        }
    }
}