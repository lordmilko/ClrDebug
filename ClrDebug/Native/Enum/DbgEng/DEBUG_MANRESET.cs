using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_MANRESET : uint
    {
        DEFAULT = 0,
        LOAD_DLL = 1,
    }
}