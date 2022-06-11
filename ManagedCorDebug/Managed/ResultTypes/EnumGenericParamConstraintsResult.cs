using System;

namespace ManagedCorDebug
{
    public struct EnumGenericParamConstraintsResult
    {
        public IntPtr PhEnum { get; }

        public mdGenericParamConstraint[] RGenericParamConstraints { get; }

        public uint PcGenericParamConstraints { get; }

        public EnumGenericParamConstraintsResult(IntPtr phEnum, mdGenericParamConstraint[] rGenericParamConstraints, uint pcGenericParamConstraints)
        {
            PhEnum = phEnum;
            RGenericParamConstraints = rGenericParamConstraints;
            PcGenericParamConstraints = pcGenericParamConstraints;
        }
    }
}