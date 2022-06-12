using System;

namespace ManagedCorDebug
{
    public struct EnumPropertiesResult
    {
        public IntPtr PhEnum { get; }

        public mdProperty[] RProperties { get; }

        public int PcProperties { get; }

        public EnumPropertiesResult(IntPtr phEnum, mdProperty[] rProperties, int pcProperties)
        {
            PhEnum = phEnum;
            RProperties = rProperties;
            PcProperties = pcProperties;
        }
    }
}