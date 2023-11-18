using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// DEBUG_SYMBOL_PARAMETERS flags.
    /// </summary>
    [Flags]
    public enum DEBUG_SYMBOL : uint
    {
        /// <summary>
        /// Cumulative expansion level, takes four bits.
        /// </summary>
        EXPANSION_LEVEL_MASK = 0xf,

        /// <summary>
        /// Symbols subelements follow.
        /// </summary>
        EXPANDED = 0x10,

        /// <summary>
        /// Symbols value is read-only.
        /// </summary>
        READ_ONLY = 0x20,

        /// <summary>
        /// Symbol subelements are array elements.
        /// </summary>
        IS_ARRAY = 0x40,

        /// <summary>
        /// Symbol is a float value.
        /// </summary>
        IS_FLOAT = 0x80,

        /// <summary>
        /// Symbol is a scope argument.
        /// </summary>
        IS_ARGUMENT = 0x100,

        /// <summary>
        /// Symbol is a scope argument.
        /// </summary>
        IS_LOCAL = 0x200,
    }
}
