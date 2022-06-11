using System;

namespace ManagedCorDebug
{
    public struct EnumPropertiesResult
    {
        public IntPtr PhEnum { get; }

        public mdProperty[] RProperties { get; }

        public uint PcProperties { get; }

        public EnumPropertiesResult(IntPtr phEnum, mdProperty[] rProperties, uint pcProperties)
        {
            PhEnum = phEnum;
            RProperties = rProperties;
            PcProperties = pcProperties;
        }
    }
}