using System;

namespace ManagedCorDebug
{
    public struct EnumUnresolvedMethodsResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] RMethods { get; }

        public int PcTokens { get; }

        public EnumUnresolvedMethodsResult(IntPtr phEnum, mdToken[] rMethods, int pcTokens)
        {
            PhEnum = phEnum;
            RMethods = rMethods;
            PcTokens = pcTokens;
        }
    }
}