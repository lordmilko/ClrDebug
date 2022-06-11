using System;

namespace ManagedCorDebug
{
    public struct EnumMethodsWithNameResult
    {
        public IntPtr PhEnum { get; }

        public string SzName { get; }

        public mdMethodDef[] RMethods { get; }

        public uint PcTokens { get; }

        public EnumMethodsWithNameResult(IntPtr phEnum, string szName, mdMethodDef[] rMethods, uint pcTokens)
        {
            PhEnum = phEnum;
            SzName = szName;
            RMethods = rMethods;
            PcTokens = pcTokens;
        }
    }
}