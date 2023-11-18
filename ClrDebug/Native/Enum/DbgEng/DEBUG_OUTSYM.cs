using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// OutputSymbolByOffset flags.
    /// </summary>
    [Flags]
    public enum DEBUG_OUTSYM : uint
    {
        /// <summary>
        /// Use the current debugger settings for symbol output.
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// Always display the offset in addition to any symbol hit.
        /// </summary>
        FORCE_OFFSET = 1,

        /// <summary>
        /// Display source line information if found.
        /// </summary>
        SOURCE_LINE = 2,

        /// <summary>
        /// Output symbol hits that don't exactly match.
        /// </summary>
        ALLOW_DISPLACEMENT = 4,
    }
}
