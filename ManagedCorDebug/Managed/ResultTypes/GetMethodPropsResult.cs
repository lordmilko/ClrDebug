using System;

namespace ManagedCorDebug
{
    public struct GetMethodPropsResult
    {
        public int PMethodToken { get; }

        public int PcGenericParams { get; }

        public int PcbSignature { get; }

        public byte[] Signature { get; }

        public GetMethodPropsResult(int pMethodToken, int pcGenericParams, int pcbSignature, byte[] signature)
        {
            PMethodToken = pMethodToken;
            PcGenericParams = pcGenericParams;
            PcbSignature = pcbSignature;
            Signature = signature;
        }
    }
}