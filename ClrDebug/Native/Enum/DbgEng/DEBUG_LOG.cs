using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_LOG : uint
    {
        DEFAULT = 0,
        APPEND = 1,
        UNICODE = 2,
        DML = 4,
    }
}