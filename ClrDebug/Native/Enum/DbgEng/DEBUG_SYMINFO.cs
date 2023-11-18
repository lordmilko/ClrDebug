namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetSymbolInformation requests.
    /// </summary>
    public enum DEBUG_SYMINFO : uint
    {
        /// <summary>
        /// Arg64 - Unused.
        /// Arg32 - Breakpoint ID.
        /// Buffer - ULONG line number.
        /// String - File name.
        /// </summary>
        BREAKPOINT_SOURCE_LINE = 0,

        /// <summary>
        /// Arg64 - Module base.
        /// Arg32 - Unused.
        /// Buffer - IMAGEHLP_MODULEW64.
        /// String - Unused.
        /// </summary>
        IMAGEHLP_MODULEW64 = 1,

        /// <summary>
        /// Arg64 - Offset.
        /// Arg32 - Symbol tag.
        /// Buffer - Unicode symbol name strings. Could have multiple strings.
        /// String - Unused, strings are returned in Buffer as there may be more than one.
        /// </summary>
        GET_SYMBOL_NAME_BY_OFFSET_AND_TAG_WIDE = 2,

        /// <summary>
        /// Arg64 - Module base.
        /// Arg32 - Symbol tag.
        /// Buffer - Array of symbol addresses.
        /// String - Concatenated symbol strings. Individual symbol strings are zero-terminated
        ///          and the final string in a symbol is double-zero-terminated.
        /// </summary>
        GET_MODULE_SYMBOL_NAMES_AND_OFFSETS = 3,
    }
}
