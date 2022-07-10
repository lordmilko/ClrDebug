using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.LogFile2"/> property.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, Flags = {Flags.ToString(),nq}")]
    public struct GetLogFile2Result
    {
        /// <summary>
        /// Receives the name of the currently open log file. If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        /// <summary>
        /// Receives the bit-flags that were used when opening the log file. See the Flags parameter of <see cref="DebugControl.OpenLogFile2"/> for a description of these flags.
        /// </summary>
        public DEBUG_LOG Flags { get; }

        public GetLogFile2Result(string buffer, DEBUG_LOG flags)
        {
            Buffer = buffer;
            Flags = flags;
        }
    }
}
