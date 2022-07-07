using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_GETFNENT : uint
    {
        DEFAULT = 0,
        RAW_ENTRY_ONLY = 1,
    }
}