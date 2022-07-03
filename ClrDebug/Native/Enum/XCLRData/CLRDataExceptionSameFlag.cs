using System;

namespace ClrDebug
{
    [Flags]
    public enum CLRDataExceptionSameFlag : uint
    {
        CLRDATA_EXSAME_SECOND_CHANCE = 0x00000000,
        CLRDATA_EXSAME_FIRST_CHANCE = 0x00000001,
    }
}
