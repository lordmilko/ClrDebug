using System;

namespace ManagedCorDebug
{
    public struct EnumSignaturesResult
    {
        public IntPtr PhEnum { get; }

        public mdSignature[] RSignatures { get; }

        public uint PcSignatures { get; }

        public EnumSignaturesResult(IntPtr phEnum, mdSignature[] rSignatures, uint pcSignatures)
        {
            PhEnum = phEnum;
            RSignatures = rSignatures;
            PcSignatures = pcSignatures;
        }
    }
}