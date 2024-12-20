using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum MODEL_QUERY : uint
    {
        DEFAULT = 0,
        RAW_VIEW = 1,
        NODERIVED = 4,
        UNLIMITED = 8
    }
}
