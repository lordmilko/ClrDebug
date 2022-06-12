using System;

namespace ManagedCorDebug
{
    public struct EnumTypeDefsResult
    {
        public IntPtr PhEnum { get; }

        public mdTypeDef[] TypeDefs { get; }

        public int PcTypeDefs { get; }

        public EnumTypeDefsResult(IntPtr phEnum, mdTypeDef[] typeDefs, int pcTypeDefs)
        {
            PhEnum = phEnum;
            TypeDefs = typeDefs;
            PcTypeDefs = pcTypeDefs;
        }
    }
}