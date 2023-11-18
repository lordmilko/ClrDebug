namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetSourceFileInformation requests.
    /// </summary>
    public enum DEBUG_SRCFILE : uint
    {
        /// <summary>
        /// Arg64 - Module base.
        /// Arg32 - Unused.
        /// </summary>
        SYMBOL_TOKEN = 0,

        /// <summary>
        /// Arg64 - Module base.
        /// Arg32 - Unused.
        /// </summary>
        SYMBOL_TOKEN_SOURCE_COMMAND_WIDE = 1,

        /// <summary>
        /// Arg64 - Module base.
        /// Arg32 - Unused
        /// </summary>
        SYMBOL_CHECKSUMINFO = 0
    }
}
