using System;

namespace ManagedCorDebug
{
    public struct GetTypePropsResult
    {
        public uint PcbSignature { get; }

        public byte[] Signature { get; }

        public GetTypePropsResult(uint pcbSignature, byte[] signature)
        {
            PcbSignature = pcbSignature;
            Signature = signature;
        }
    }
}