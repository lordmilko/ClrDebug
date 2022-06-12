using System;

namespace ManagedCorDebug
{
    public struct EnumSignaturesResult
    {
        public IntPtr PhEnum { get; }

        public mdSignature[] RSignatures { get; }

        public int PcSignatures { get; }

        public EnumSignaturesResult(IntPtr phEnum, mdSignature[] rSignatures, int pcSignatures)
        {
            PhEnum = phEnum;
            RSignatures = rSignatures;
            PcSignatures = pcSignatures;
        }
    }
}