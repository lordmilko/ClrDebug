using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugAdvanced.FindSourceFileAndTokenWide"/> method.
    /// </summary>
    [DebuggerDisplay("FoundElement = {FoundElement}, Buffer = {Buffer}")]
    public struct FindSourceFileAndTokenWideResult
    {
        /// <summary>
        /// Receives the index of the element within the source path that contained the file. If the file was found directly on the filing system (not using the source path), -1 is returned to FoundElement.<para/>
        /// If FoundElement is NULL or Flags contain DEBUG_SRCFILE_SYMBOL_TOKEN, this information is not returned.
        /// </summary>
        public int FoundElement { get; }

        /// <summary>
        /// Receives the name of the file that was found. If the file is not on a source server, this is the name of the file in the local source cache.<para/>
        /// If the flag DEBUG_FIND_SOURCE_FULL_PATH is set, this is the full canonical path name for the file. Otherwise, it is the concatenation of the directory in the source path with the tail of File that was used to find the file.<para/>
        /// If the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, Buffer receives the value of the variable named File associated with the file token FileToken.<para/>
        /// If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        public FindSourceFileAndTokenWideResult(int foundElement, string buffer)
        {
            FoundElement = foundElement;
            Buffer = buffer;
        }
    }
}
