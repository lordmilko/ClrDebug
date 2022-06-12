using System;

namespace ManagedCorDebug
{
    public struct EnumTypeSpecsResult
    {
        public IntPtr PhEnum { get; }

        public mdTypeSpec[] RTypeSpecs { get; }

        public int PcTypeSpecs { get; }

        public EnumTypeSpecsResult(IntPtr phEnum, mdTypeSpec[] rTypeSpecs, int pcTypeSpecs)
        {
            PhEnum = phEnum;
            RTypeSpecs = rTypeSpecs;
            PcTypeSpecs = pcTypeSpecs;
        }
    }
}