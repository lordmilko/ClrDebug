using System;

namespace ClrDebug
{
    [Flags]
    public enum COR_VTABLE : short
    {
        /// <summary>
        /// V-table slots are 32-bits in size.
        /// </summary>
        COR_VTABLE_32BIT = 0x01,

        /// <summary>
        /// V-table slots are 64-bits in size.
        /// </summary>
        COR_VTABLE_64BIT = 0x02,

        /// <summary>
        /// If set, transition from unmanaged.
        /// </summary>
        COR_VTABLE_FROM_UNMANAGED = 0x04,
        COR_VTABLE_FROM_UNMANAGED_RETAIN_APPDOMAIN = 0x08,    // NEW

        /// <summary>
        /// Call most derived method described by
        /// </summary>
        COR_VTABLE_CALL_MOST_DERIVED = 0x10
    }
}
