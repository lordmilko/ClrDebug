using System;

namespace ClrDebug
{
    [Flags]
    public enum CLRDataProcessFlag : uint
    {
        CLRDATA_PROCESS_DEFAULT = 0x00000000,
        CLRDATA_PROCESS_IN_GC = 0x00000001,
    }
}
