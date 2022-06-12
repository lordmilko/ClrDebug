using System;

namespace ManagedCorDebug
{
    public struct EnumFieldsWithNameResult
    {
        public IntPtr PhEnum { get; }

        public mdFieldDef[] RFields { get; }

        public int PcTokens { get; }

        public EnumFieldsWithNameResult(IntPtr phEnum, mdFieldDef[] rFields, int pcTokens)
        {
            PhEnum = phEnum;
            RFields = rFields;
            PcTokens = pcTokens;
        }
    }
}