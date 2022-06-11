using System;

namespace ManagedCorDebug
{
    public struct EnumFieldsResult
    {
        public IntPtr PhEnum { get; }

        public mdFieldDef[] RFields { get; }

        public uint PcTokens { get; }

        public EnumFieldsResult(IntPtr phEnum, mdFieldDef[] rFields, uint pcTokens)
        {
            PhEnum = phEnum;
            RFields = rFields;
            PcTokens = pcTokens;
        }
    }
}