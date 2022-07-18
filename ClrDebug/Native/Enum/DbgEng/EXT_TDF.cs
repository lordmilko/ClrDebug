using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum EXT_TDF : uint
    {
        PHYSICAL_DEFAULT = 0x00000002,
        PHYSICAL_CACHED = 0x00000004,
        PHYSICAL_UNCACHED = 0x00000006,
        PHYSICAL_WRITE_COMBINED = 0x00000008,
        PHYSICAL_MEMORY = 0x0000000e
    }
}