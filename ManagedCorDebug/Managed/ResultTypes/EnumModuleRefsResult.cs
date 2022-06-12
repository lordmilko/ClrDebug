using System;

namespace ManagedCorDebug
{
    public struct EnumModuleRefsResult
    {
        public IntPtr PhEnum { get; }

        public mdModuleRef[] RModuleRefs { get; }

        public int PcModuleRefs { get; }

        public EnumModuleRefsResult(IntPtr phEnum, mdModuleRef[] rModuleRefs, int pcModuleRefs)
        {
            PhEnum = phEnum;
            RModuleRefs = rModuleRefs;
            PcModuleRefs = pcModuleRefs;
        }
    }
}