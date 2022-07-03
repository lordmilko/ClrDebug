using System;

namespace ClrDebug
{
    [Flags]
    public enum CLRDataMethodFlag : uint
    {
        CLRDATA_METHOD_DEFAULT = 0x00000000,
        CLRDATA_METHOD_HAS_THIS = 0x00000001,
    }
}
