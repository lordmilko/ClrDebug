using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_REGISTER : uint
    {
        SUB_REGISTER = 1,
    }
}