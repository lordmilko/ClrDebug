using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.FindSourceFileWide"/> method.
    /// </summary>
    [DebuggerDisplay("FoundElement = {FoundElement}, Buffer = {Buffer}")]
    public struct FindSourceFileWideResult
    {
        /// <summary>
        /// Receives the index of the element within the source path that contains the file. If the file was found directly on the filing system (not using the source path) then -1 is returned to FoundElement.<para/>
        /// If FoundElement is NULL, this information is not returned.
        /// </summary>
        public uint FoundElement { get; }

        /// <summary>
        /// Receives the path and name of the found file. If the flag DEBUG_FIND_SOURCE_FULL_PATH is set, this is the full canonical path name for the file.<para/>
        /// Otherwise, it is the concatenation of the directory in the source path with the tail of File that was used to find the file.<para/>
        /// If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        public FindSourceFileWideResult(uint foundElement, string buffer)
        {
            FoundElement = foundElement;
            Buffer = buffer;
        }
    }
}
