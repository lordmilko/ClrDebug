using System;

namespace ClrDebug
{
    [Flags]
    public enum CorILMethodSect : byte
    {
        //Values

        Reserved = 0,
        EHTable = 1,
        OptILTable = 2,

        //Flags

        KindMask = 0x3F,        // The mask for decoding the type code
        FatFormat = 0x40,        // fat format
        MoreSects = 0x80,        // there is another attribute after this one
    }
}
