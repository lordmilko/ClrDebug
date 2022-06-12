using System;

namespace ManagedCorDebug
{
    public struct EnumGenericParamConstraintsResult
    {
        public IntPtr PhEnum { get; }

        public mdGenericParamConstraint[] RGenericParamConstraints { get; }

        public int PcGenericParamConstraints { get; }

        public EnumGenericParamConstraintsResult(IntPtr phEnum, mdGenericParamConstraint[] rGenericParamConstraints, int pcGenericParamConstraints)
        {
            PhEnum = phEnum;
            RGenericParamConstraints = rGenericParamConstraints;
            PcGenericParamConstraints = pcGenericParamConstraints;
        }
    }
}