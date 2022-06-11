using System;

namespace ManagedCorDebug
{
    public struct EnumTypeRefsResult
    {
        public IntPtr PhEnum { get; }

        public mdTypeRef[] RTypeRefs { get; }

        public uint PcTypeRefs { get; }

        public EnumTypeRefsResult(IntPtr phEnum, mdTypeRef[] rTypeRefs, uint pcTypeRefs)
        {
            PhEnum = phEnum;
            RTypeRefs = rTypeRefs;
            PcTypeRefs = pcTypeRefs;
        }
    }
}