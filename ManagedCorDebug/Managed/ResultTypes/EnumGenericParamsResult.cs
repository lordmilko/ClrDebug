using System;

namespace ManagedCorDebug
{
    public struct EnumGenericParamsResult
    {
        public IntPtr PhEnum { get; }

        public mdGenericParam[] RGenericParams { get; }

        public int PcGenericParams { get; }

        public EnumGenericParamsResult(IntPtr phEnum, mdGenericParam[] rGenericParams, int pcGenericParams)
        {
            PhEnum = phEnum;
            RGenericParams = rGenericParams;
            PcGenericParams = pcGenericParams;
        }
    }
}