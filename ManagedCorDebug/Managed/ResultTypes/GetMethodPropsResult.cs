using System;

namespace ManagedCorDebug
{
    public struct GetMethodPropsResult
    {
        public uint PMethodToken { get; }

        public uint PcGenericParams { get; }

        public uint PcbSignature { get; }

        public byte[] Signature { get; }

        public GetMethodPropsResult(uint pMethodToken, uint pcGenericParams, uint pcbSignature, byte[] signature)
        {
            PMethodToken = pMethodToken;
            PcGenericParams = pcGenericParams;
            PcbSignature = pcbSignature;
            Signature = signature;
        }
    }
}