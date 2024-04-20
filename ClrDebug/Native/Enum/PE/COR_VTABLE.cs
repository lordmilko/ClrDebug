using System;

namespace ClrDebug
{
    [Flags]
    public enum COR_VTABLE : short
    {
        _32BIT = 0x01,          // V-table slots are 32-bits in size.
        _64BIT = 0x02,          // V-table slots are 64-bits in size.
        FROM_UNMANAGED = 0x04,          // If set, transition from unmanaged.
        FROM_UNMANAGED_RETAIN_APPDOMAIN = 0x08,    // NEW
        CALL_MOST_DERIVED = 0x10,          // Call most derived method described by
    }
}
