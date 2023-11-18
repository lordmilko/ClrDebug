using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Log file flags.
    /// </summary>
    [Flags]
    public enum DEBUG_LOG : uint
    {
        DEFAULT = 0,
        APPEND = 1,
        UNICODE = 2,
        DML = 4,
    }
}
