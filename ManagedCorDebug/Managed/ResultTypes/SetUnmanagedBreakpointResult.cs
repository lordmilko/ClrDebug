using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugProcess.SetUnmanagedBreakpoint"/> method.
    /// </summary>
    [DebuggerDisplay("buffer = {buffer}, bufLen = {bufLen}")]
    public struct SetUnmanagedBreakpointResult
    {
        /// <summary>
        /// An array that contains the opcode that is replaced by the breakpoint.
        /// </summary>
        public byte[] buffer { get; }

        /// <summary>
        /// A pointer to the number of bytes returned in the buffer array.
        /// </summary>
        public int bufLen { get; }

        public SetUnmanagedBreakpointResult(byte[] buffer, int bufLen)
        {
            this.buffer = buffer;
            this.bufLen = bufLen;
        }
    }
}