using System;

namespace ManagedCorDebug
{
    public struct EnumMethodSemanticsResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] REventProp { get; }

        public uint PcEventProp { get; }

        public EnumMethodSemanticsResult(IntPtr phEnum, mdToken[] rEventProp, uint pcEventProp)
        {
            PhEnum = phEnum;
            REventProp = rEventProp;
            PcEventProp = pcEventProp;
        }
    }
}