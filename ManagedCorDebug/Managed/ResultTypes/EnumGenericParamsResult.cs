using System;

namespace ManagedCorDebug
{
    public struct EnumGenericParamsResult
    {
        public IntPtr PhEnum { get; }

        public mdGenericParam[] RGenericParams { get; }

        public uint PcGenericParams { get; }

        public EnumGenericParamsResult(IntPtr phEnum, mdGenericParam[] rGenericParams, uint pcGenericParams)
        {
            PhEnum = phEnum;
            RGenericParams = rGenericParams;
            PcGenericParams = pcGenericParams;
        }
    }
}