using System;

namespace ManagedCorDebug
{
    public struct EnumFieldsWithNameResult
    {
        public IntPtr PhEnum { get; }

        public mdFieldDef[] RFields { get; }

        public uint PcTokens { get; }

        public EnumFieldsWithNameResult(IntPtr phEnum, mdFieldDef[] rFields, uint pcTokens)
        {
            PhEnum = phEnum;
            RFields = rFields;
            PcTokens = pcTokens;
        }
    }
}