using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugProcess.ReadMemory"/> method.
    /// </summary>
    [DebuggerDisplay("buffer = {buffer}, read = {read}")]
    public struct ReadMemoryResult
    {
        /// <summary>
        /// [out] A buffer that receives the contents of the memory.
        /// </summary>
        public byte[] buffer { get; }

        /// <summary>
        /// [out] A pointer to the number of bytes transferred into the specified buffer.
        /// </summary>
        public long read { get; }

        public ReadMemoryResult(byte[] buffer, long read)
        {
            this.buffer = buffer;
            this.read = read;
        }
    }
}