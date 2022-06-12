using System;

namespace ManagedCorDebug
{
    public struct EnumFieldsResult
    {
        public IntPtr PhEnum { get; }

        public mdFieldDef[] RFields { get; }

        public int PcTokens { get; }

        public EnumFieldsResult(IntPtr phEnum, mdFieldDef[] rFields, int pcTokens)
        {
            PhEnum = phEnum;
            RFields = rFields;
            PcTokens = pcTokens;
        }
    }
}