using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugAdvanced.FindSourceFileAndToken"/> method.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, FoundSize = {FoundSize}")]
    public struct FindSourceFileAndTokenResult
    {
        /// <summary>
        /// Receives the name of the file that was found. If the file is not on a source server, this is the name of the file in the local source cache.<para/>
        /// If the flag DEBUG_FIND_SOURCE_FULL_PATH is set, this is the full canonical path name for the file. Otherwise, it is the concatenation of the directory in the source path with the tail of File that was used to find the file.<para/>
        /// If the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, Buffer receives the value of the variable named File associated with the file token FileToken.<para/>
        /// If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        /// <summary>
        /// Specifies the size in characters of the name of the file. This size includes the space for the '\0' terminating character.<para/>
        /// If foundSize is NULL, this information is not returned.
        /// </summary>
        public int FoundSize { get; }

        public FindSourceFileAndTokenResult(string buffer, int foundSize)
        {
            Buffer = buffer;
            FoundSize = foundSize;
        }
    }
}
