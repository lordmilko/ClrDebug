using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Process creation flags specific to the debugger engine.
    /// </summary>
    [Flags]
    public enum DEBUG_ECREATE_PROCESS : uint
    {
        DEFAULT = 0,
        INHERIT_HANDLES = 1,
        USE_VERIFIER_FLAGS = 2,
        USE_IMPLICIT_COMMAND_LINE = 4,
    }
}
