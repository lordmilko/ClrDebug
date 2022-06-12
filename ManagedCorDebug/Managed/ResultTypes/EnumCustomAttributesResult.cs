using System;

namespace ManagedCorDebug
{
    public struct EnumCustomAttributesResult
    {
        public IntPtr PhEnum { get; }

        public mdCustomAttribute[] RCustomAttributes { get; }

        public int PcCustomAttributes { get; }

        public EnumCustomAttributesResult(IntPtr phEnum, mdCustomAttribute[] rCustomAttributes, int pcCustomAttributes)
        {
            PhEnum = phEnum;
            RCustomAttributes = rCustomAttributes;
            PcCustomAttributes = pcCustomAttributes;
        }
    }
}