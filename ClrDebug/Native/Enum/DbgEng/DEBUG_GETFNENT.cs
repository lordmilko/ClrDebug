using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetFunctionEntryByOffset flags.
    /// </summary>
    [Flags]
    public enum DEBUG_GETFNENT : uint
    {
        DEFAULT = 0,

        /// <summary>
        /// The engine provides artificial entries for well-known cases. This flag limits the entry
        /// search to only the raw entries and disables artificial entry lookup.
        /// </summary>
        RAW_ENTRY_ONLY = 1,
    }
}
