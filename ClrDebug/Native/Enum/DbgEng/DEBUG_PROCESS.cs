using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Process options.
    /// </summary>
    [Flags]
    public enum DEBUG_PROCESS : uint
    {
        DEFAULT = 0,

        /// <summary>
        /// Indicates that the debuggee process should be automatically detached when the debugger exits.
        /// A debugger can explicitly detach on exit or this flag can be set so that detach occurs
        /// regardless of how the debugger exits. This is only supported on some system versions.
        /// </summary>
        DETACH_ON_EXIT = 1,

        /// <summary>
        /// Indicates that processes created by the current process should not be debugged.
        /// Modifying this flag is only supported on some system versions.
        /// </summary>
        ONLY_THIS_PROCESS = 2
    }
}
