using System;

namespace ManagedCorDebug
{
    public struct EnumUnresolvedMethodsResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] RMethods { get; }

        public uint PcTokens { get; }

        public EnumUnresolvedMethodsResult(IntPtr phEnum, mdToken[] rMethods, uint pcTokens)
        {
            PhEnum = phEnum;
            RMethods = rMethods;
            PcTokens = pcTokens;
        }
    }
}