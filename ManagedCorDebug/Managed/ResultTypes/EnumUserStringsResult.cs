using System;

namespace ManagedCorDebug
{
    public struct EnumUserStringsResult
    {
        public IntPtr PhEnum { get; }

        public mdString[] RStrings { get; }

        public int PcStrings { get; }

        public EnumUserStringsResult(IntPtr phEnum, mdString[] rStrings, int pcStrings)
        {
            PhEnum = phEnum;
            RStrings = rStrings;
            PcStrings = pcStrings;
        }
    }
}