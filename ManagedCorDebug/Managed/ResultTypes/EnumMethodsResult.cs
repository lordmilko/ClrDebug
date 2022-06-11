using System;

namespace ManagedCorDebug
{
    public struct EnumMethodsResult
    {
        public IntPtr PhEnum { get; }

        public mdMethodDef[] RMethods { get; }

        public uint PcTokens { get; }

        public EnumMethodsResult(IntPtr phEnum, mdMethodDef[] rMethods, uint pcTokens)
        {
            PhEnum = phEnum;
            RMethods = rMethods;
            PcTokens = pcTokens;
        }
    }
}