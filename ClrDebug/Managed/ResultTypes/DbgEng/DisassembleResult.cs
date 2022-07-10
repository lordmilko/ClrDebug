using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.Disassemble"/> method.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, EndOffset = {EndOffset}")]
    public struct DisassembleResult
    {
        /// <summary>
        /// Receives the disassembled instruction. If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        /// <summary>
        /// Receives the location in the target's memory of the instruction following the disassembled instruction.
        /// </summary>
        public ulong EndOffset { get; }

        public DisassembleResult(string buffer, ulong endOffset)
        {
            Buffer = buffer;
            EndOffset = endOffset;
        }
    }
}
