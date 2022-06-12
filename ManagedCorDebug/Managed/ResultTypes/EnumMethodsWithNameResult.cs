using System;

namespace ManagedCorDebug
{
    public struct EnumMethodsWithNameResult
    {
        public IntPtr PhEnum { get; }

        public string SzName { get; }

        public mdMethodDef[] RMethods { get; }

        public int PcTokens { get; }

        public EnumMethodsWithNameResult(IntPtr phEnum, string szName, mdMethodDef[] rMethods, int pcTokens)
        {
            PhEnum = phEnum;
            SzName = szName;
            RMethods = rMethods;
            PcTokens = pcTokens;
        }
    }
}