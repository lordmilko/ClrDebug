namespace ClrDebug.DbgEng
{
    /// <summary>
    /// GetSourceFileInformation requests.
    /// </summary>
    public enum DEBUG_SRCFILE : uint
    {
        /// <summary>
        /// Returns a token representing the specified source file on a source server. This token can be passed to FindSourceFileAndToken to retrieve
        /// information about the file. The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the
        /// size of the SrcSrv token.
        /// <para/>
        /// Arg64 - Module base.
        /// Arg32 - Unused.
        /// </summary>
        SYMBOL_TOKEN = 0,

        /// <summary>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and
        /// its command-line parameters. The command is returned to the Buffer buffer as a Unicode string.
        /// <para/>
        /// Arg64 - Module base.
        /// Arg32 - Unused.
        /// </summary>
        SYMBOL_TOKEN_SOURCE_COMMAND_WIDE = 1,

        /// <summary>
        /// Arg64 - Module base.
        /// Arg32 - Unused
        /// </summary>
        SYMBOL_CHECKSUMINFO = 2
    }
}
