using System;

namespace ClrDebug
{
    [Flags]
    public enum CLRDataMethodCodeNotification : uint
    {
        CLRDATA_METHNOTIFY_NONE = 0x00000000,
        CLRDATA_METHNOTIFY_GENERATED = 0x00000001,
        CLRDATA_METHNOTIFY_DISCARDED = 0x00000002,
    }
}
