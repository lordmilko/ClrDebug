using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Typed data output control flags.
    /// </summary>
    [Flags]
    public enum DEBUG_OUTTYPE
    {
        DEFAULT = 0,
        NO_INDENT = 1,
        NO_OFFSET = 2,
        VERBOSE = 4,
        COMPACT_OUTPUT = 8,
        ADDRESS_OF_FIELD = 0x10000,
        ADDRESS_ANT_END = 0x20000,
        BLOCK_RECURSE = 0x200000,
    }
}
