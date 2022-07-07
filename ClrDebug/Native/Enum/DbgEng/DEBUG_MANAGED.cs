using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_MANAGED : uint
    {
        DISABLED = 0,
        ALLOWED = 1,
        DLL_LOADED = 2,
    }
}