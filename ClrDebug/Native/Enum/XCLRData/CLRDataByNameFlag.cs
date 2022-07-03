using System;

namespace ClrDebug
{
    [Flags]
    public enum CLRDataByNameFlag : uint
    {
        CLRDATA_BYNAME_CASE_SENSITIVE = 0x00000000,
        CLRDATA_BYNAME_CASE_INSENSITIVE = 0x00000001,
    }
}
