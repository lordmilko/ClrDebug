using System;

namespace ManagedCorDebug
{
    public struct EnumMethodsResult
    {
        public IntPtr PhEnum { get; }

        public mdMethodDef[] RMethods { get; }

        public int PcTokens { get; }

        public EnumMethodsResult(IntPtr phEnum, mdMethodDef[] rMethods, int pcTokens)
        {
            PhEnum = phEnum;
            RMethods = rMethods;
            PcTokens = pcTokens;
        }
    }
}