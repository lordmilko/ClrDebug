using System;

namespace ManagedCorDebug
{
    public struct EnumTypeSpecsResult
    {
        public IntPtr PhEnum { get; }

        public mdTypeSpec[] RTypeSpecs { get; }

        public uint PcTypeSpecs { get; }

        public EnumTypeSpecsResult(IntPtr phEnum, mdTypeSpec[] rTypeSpecs, uint pcTypeSpecs)
        {
            PhEnum = phEnum;
            RTypeSpecs = rTypeSpecs;
            PcTypeSpecs = pcTypeSpecs;
        }
    }
}