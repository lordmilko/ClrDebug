using System;

namespace ManagedCorDebug
{
    public struct GetTypePropsResult
    {
        public int PcbSignature { get; }

        public byte[] Signature { get; }

        public GetTypePropsResult(int pcbSignature, byte[] signature)
        {
            PcbSignature = pcbSignature;
            Signature = signature;
        }
    }
}