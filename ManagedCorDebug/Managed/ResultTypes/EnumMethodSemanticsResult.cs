using System;

namespace ManagedCorDebug
{
    public struct EnumMethodSemanticsResult
    {
        public IntPtr PhEnum { get; }

        public mdToken[] REventProp { get; }

        public int PcEventProp { get; }

        public EnumMethodSemanticsResult(IntPtr phEnum, mdToken[] rEventProp, int pcEventProp)
        {
            PhEnum = phEnum;
            REventProp = rEventProp;
            PcEventProp = pcEventProp;
        }
    }
}