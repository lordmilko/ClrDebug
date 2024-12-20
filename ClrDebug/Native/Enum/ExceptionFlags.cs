using System;

namespace ClrDebug
{
    [Flags]
    public enum ExceptionFlags : uint
    {
        EXCEPTION_NONCONTINUABLE = 0x1,
        EXCEPTION_UNWINDING = 0x2,
        EXCEPTION_EXIT_UNWIND = 0x4,
        EXCEPTION_STACK_INVALID = 0x8,
        EXCEPTION_NESTED_CALL = 0x10,
        EXCEPTION_TARGET_UNWIND = 0x20,
        EXCEPTION_COLLIDED_UNWIND = 0x40,
    }
}
