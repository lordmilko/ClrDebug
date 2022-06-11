using System;

namespace ManagedCorDebug
{
    public struct GetMethodSpecPropsResult
    {
        public mdToken TkParent { get; }

        public IntPtr PpvSigBlob { get; }

        public uint PcbSigBlob { get; }

        public GetMethodSpecPropsResult(mdToken tkParent, IntPtr ppvSigBlob, uint pcbSigBlob)
        {
            TkParent = tkParent;
            PpvSigBlob = ppvSigBlob;
            PcbSigBlob = pcbSigBlob;
        }
    }
}