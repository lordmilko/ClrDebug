using System;

namespace ManagedCorDebug
{
    public struct EnumCustomAttributesResult
    {
        public IntPtr PhEnum { get; }

        public mdCustomAttribute[] RCustomAttributes { get; }

        public uint PcCustomAttributes { get; }

        public EnumCustomAttributesResult(IntPtr phEnum, mdCustomAttribute[] rCustomAttributes, uint pcCustomAttributes)
        {
            PhEnum = phEnum;
            RCustomAttributes = rCustomAttributes;
            PcCustomAttributes = pcCustomAttributes;
        }
    }
}