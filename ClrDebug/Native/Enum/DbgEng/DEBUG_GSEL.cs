using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetSourceEntriesByLine flags.
    /// </summary>
    [Flags]
    public enum DEBUG_GSEL : uint
    {
        DEFAULT = 0,

        /// <summary>
        /// Do not allow any extra symbols to load during the search.
        /// </summary>
        NO_SYMBOL_LOADS = 1,

        /// <summary>
        /// Allow source hits with lower line numbers.
        /// </summary>
        ALLOW_LOWER = 2,

        /// <summary>
        /// Allow source hits with higher line numbers.
        /// </summary>
        ALLOW_HIGHER = 4,

        /// <summary>
        /// Only return the nearest hits.
        /// </summary>
        NEAREST_ONLY = 8,

        /// <summary>
        /// Only return caller sites of the inline function.
        /// </summary>
        INLINE_CALLSITE = 0x10,
    }
}
