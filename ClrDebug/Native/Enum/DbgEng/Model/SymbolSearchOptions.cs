namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Symbols search options.
    /// </summary>
    public enum SymbolSearchOptions : uint
    {
        /// <summary>
        /// No options set SymbolSearchNone = 0x00000000,
        /// </summary>
        SymbolSearchNone = 0x00000000,

        /// <summary>
        /// Search for symbols starting with the specified name rather than symbols of the exact specified name. SymbolSearchCompletion = 0x00000001
        /// </summary>
        SymbolSearchCompletion = 0x00000001,

        /// <summary>
        /// Search for symbols using case-insensitive rules. SymbolSearchCaseInsensitive = 0x00000002
        /// </summary>
        SymbolSearchCaseInsensitive = 0x00000002
    }
}
