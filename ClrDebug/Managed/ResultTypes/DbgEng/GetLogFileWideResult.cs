using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.LogFileWide"/> property.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, Append = {Append}")]
    public struct GetLogFileWideResult
    {
        /// <summary>
        /// Receives the name of the currently open log file. If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        /// <summary>
        /// Receives TRUE if log messages are appended to the log file, or FALSE if the contents of the log file were discarded when the file was opened.
        /// </summary>
        public bool Append { get; }

        public GetLogFileWideResult(string buffer, bool append)
        {
            Buffer = buffer;
            Append = append;
        }
    }
}
