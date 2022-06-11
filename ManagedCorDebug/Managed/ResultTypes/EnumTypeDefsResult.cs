using System;

namespace ManagedCorDebug
{
    public struct EnumTypeDefsResult
    {
        public IntPtr PhEnum { get; }

        public mdTypeDef[] TypeDefs { get; }

        public uint PcTypeDefs { get; }

        public EnumTypeDefsResult(IntPtr phEnum, mdTypeDef[] typeDefs, uint pcTypeDefs)
        {
            PhEnum = phEnum;
            TypeDefs = typeDefs;
            PcTypeDefs = pcTypeDefs;
        }
    }
}