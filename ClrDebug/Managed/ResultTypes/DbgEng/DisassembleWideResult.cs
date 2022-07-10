using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.DisassembleWide"/> method.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, EndOffset = {EndOffset}")]
    public struct DisassembleWideResult
    {
        /// <summary>
        /// Receives the disassembled instruction. If Buffer is NULL, this information is not returned.
        /// </summary>
        public string Buffer { get; }

        /// <summary>
        /// Receives the location in the target's memory of the instruction following the disassembled instruction.
        /// </summary>
        public ulong EndOffset { get; }

        public DisassembleWideResult(string buffer, ulong endOffset)
        {
            Buffer = buffer;
            EndOffset = endOffset;
        }
    }
}
