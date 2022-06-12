using System;

namespace ManagedCorDebug
{
    public struct EnumTypeRefsResult
    {
        public IntPtr PhEnum { get; }

        public mdTypeRef[] RTypeRefs { get; }

        public int PcTypeRefs { get; }

        public EnumTypeRefsResult(IntPtr phEnum, mdTypeRef[] rTypeRefs, int pcTypeRefs)
        {
            PhEnum = phEnum;
            RTypeRefs = rTypeRefs;
            PcTypeRefs = pcTypeRefs;
        }
    }
}