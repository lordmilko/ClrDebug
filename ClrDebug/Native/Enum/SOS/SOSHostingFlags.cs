using System;

namespace ClrDebug
{
    [Flags]
    public enum SOSHostingFlags : uint
    {
        CLRMEMORYHOSTED = 0x1,
        CLRTASKHOSTED = 0x2,
        CLRSYNCHOSTED = 0x4,
        CLRTHREADPOOLHOSTED = 0x8,
        CLRIOCOMPLETIONHOSTED = 0x10,
        CLRASSEMBLYHOSTED = 0x20,
        CLRGCHOSTED = 0x40,
        CLRSECURITYHOSTED = 0x80,
        CLRHOSTED = 0x80000000
    }
}
