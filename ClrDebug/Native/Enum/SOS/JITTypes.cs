using System;

namespace ClrDebug
{
    [Flags]
    public enum JITTypes : uint
    {
        TYPE_UNKNOWN,
        TYPE_JIT,
        TYPE_PJIT,
    }
}
