using System;

namespace ClrDebug
{
    [Flags]
    public enum CLRDataSimpleFrameType : uint
    {
        CLRDATA_SIMPFRAME_UNRECOGNIZED = 0x1,
        CLRDATA_SIMPFRAME_MANAGED_METHOD = 0x2,
        CLRDATA_SIMPFRAME_RUNTIME_MANAGED_CODE = 0x4,
        CLRDATA_SIMPFRAME_RUNTIME_UNMANAGED_CODE = 0x8,
    }
}
