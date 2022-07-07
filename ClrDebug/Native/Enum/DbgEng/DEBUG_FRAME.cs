using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_FRAME : uint
    {
        DEFAULT = 0,
        IGNORE_INLINE = 1,
    }
}