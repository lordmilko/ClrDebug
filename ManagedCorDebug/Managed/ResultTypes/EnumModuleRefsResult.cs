using System;

namespace ManagedCorDebug
{
    public struct EnumModuleRefsResult
    {
        public IntPtr PhEnum { get; }

        public mdModuleRef[] RModuleRefs { get; }

        public uint PcModuleRefs { get; }

        public EnumModuleRefsResult(IntPtr phEnum, mdModuleRef[] rModuleRefs, uint pcModuleRefs)
        {
            PhEnum = phEnum;
            RModuleRefs = rModuleRefs;
            PcModuleRefs = pcModuleRefs;
        }
    }
}