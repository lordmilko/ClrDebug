using System;

namespace ClrDebug
{
    [Flags]
    public enum ClrDataValueLocationFlag : uint
    {
        CLRDATA_VLOC_MEMORY = 0x00000000,
        CLRDATA_VLOC_REGISTER = 0x00000001,
    }
}
