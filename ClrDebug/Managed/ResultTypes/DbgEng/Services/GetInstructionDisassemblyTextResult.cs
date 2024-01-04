using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcBasicDisassembly.GetInstructionDisassemblyText"/> method.
    /// </summary>
    [DebuggerDisplay("disassembledInstruction = {disassembledInstruction}, byteCount = {byteCount}, instructionCount = {instructionCount}, startAddress = {startAddress}")]
    public struct GetInstructionDisassemblyTextResult
    {
        public string disassembledInstruction { get; }

        public long byteCount { get; }

        public long instructionCount { get; }

        public long startAddress { get; }

        public GetInstructionDisassemblyTextResult(string disassembledInstruction, long byteCount, long instructionCount, long startAddress)
        {
            this.disassembledInstruction = disassembledInstruction;
            this.byteCount = byteCount;
            this.instructionCount = instructionCount;
            this.startAddress = startAddress;
        }
    }
}
