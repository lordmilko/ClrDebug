using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugClient.GetDumpFile"/> method.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, Handle = {Handle}, Type = {Type}")]
    public struct GetDumpFileResult
    {
        /// <summary>
        /// Receives the file name. If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        /// <summary>
        /// Receives the file handle of the file. If Handle is NULL, this information is not returned.
        /// </summary>
        public ulong Handle { get; }

        /// <summary>
        /// Receives the type of the file.
        /// </summary>
        public uint Type { get; }

        public GetDumpFileResult(string buffer, ulong handle, uint type)
        {
            Buffer = buffer;
            Handle = handle;
            Type = type;
        }
    }
}
