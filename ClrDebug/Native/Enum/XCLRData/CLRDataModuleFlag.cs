using System;

namespace ClrDebug
{
    [Flags]
    public enum CLRDataModuleFlag : uint
    {
        CLRDATA_MODULE_DEFAULT = 0x00000000,
        CLRDATA_MODULE_IS_DYNAMIC = 0x00000001,
        CLRDATA_MODULE_IS_MEMORY_STREAM = 0x00000002,
        CLRDATA_MODULE_IS_MAIN_MODULE = 0x00000004,
    }
}
