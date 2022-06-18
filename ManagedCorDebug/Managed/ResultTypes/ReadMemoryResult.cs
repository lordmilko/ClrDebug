using System;
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
        /// A buffer that receives the contents of the memory.
        /// </summary>
        public IntPtr buffer { get; }

        /// <summary>
        /// A pointer to the number of bytes transferred into the specified buffer.
        /// </summary>
        public int read { get; }

        public ReadMemoryResult(IntPtr buffer, int read)
        {
            this.buffer = buffer;
            this.read = read;
        }
    }
}