using System;

namespace ManagedCorDebug
{
    public struct EnumUserStringsResult
    {
        public IntPtr PhEnum { get; }

        public mdString[] RStrings { get; }

        public uint PcStrings { get; }

        public EnumUserStringsResult(IntPtr phEnum, mdString[] rStrings, uint pcStrings)
        {
            PhEnum = phEnum;
            RStrings = rStrings;
            PcStrings = pcStrings;
        }
    }
}