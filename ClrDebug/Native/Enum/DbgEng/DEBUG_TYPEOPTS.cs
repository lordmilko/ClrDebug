using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Type options, used with Get/SetTypeOptions.
    /// </summary>
    [Flags]
    public enum DEBUG_TYPEOPTS : uint
    {
        /// <summary>
        /// Display PUSHORT and USHORT arrays in Unicode.
        /// </summary>
        UNICODE_DISPLAY = 1,

        /// <summary>
        /// Display LONG types in default base instead of decimal.
        /// </summary>
        LONGSTATUS_DISPLAY = 2,

        /// <summary>
        /// Display integer types in default base instead of decimal.
        /// </summary>
        FORCERADIX_OUTPUT = 4,

        /// <summary>
        /// Search for the type/symbol with largest size when multiple type/symbol match for a given name.
        /// </summary>
        MATCH_MAXSIZE = 8,
    }
}
