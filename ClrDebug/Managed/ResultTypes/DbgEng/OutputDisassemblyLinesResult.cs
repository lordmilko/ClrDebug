using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.OutputDisassemblyLines"/> method.
    /// </summary>
    [DebuggerDisplay("OffsetLine = {OffsetLine}, StartOffset = {StartOffset}, EndOffset = {EndOffset}, LineOffsets = {LineOffsets}")]
    public struct OutputDisassemblyLinesResult
    {
        /// <summary>
        /// Receives the line number in the output that contains the instruction at Offset. If OffsetLine is NULL, this information is not returned.
        /// </summary>
        public uint OffsetLine { get; }

        /// <summary>
        /// Receives the location in the target's memory of the first instruction included in the output. If StartOffset is NULL, this information is not returned.
        /// </summary>
        public ulong StartOffset { get; }

        /// <summary>
        /// Receives the locaiton in the target's memory of the instruction that follows the last disassembled instruction.
        /// </summary>
        public ulong EndOffset { get; }

        /// <summary>
        /// Receives the locations in the target's memory of the instructions included in the output starting with the instruction at Offset.<para/>
        /// LineOffsets is an array that contains TotalLines elements. Offset is the value of first entry in this array unless there was an error disassembling the instructions before this instruction.<para/>
        /// In this case, the first entry will contain DEBUG_ANY_ID and Offset will be placed in the second entry in the array (index one).<para/>
        /// If the output for an instruction spans multiple lines, the element in the array that corresponds to the first line of the instruction will contain the address of the instruction.<para/>
        /// If LineOffsets is NULL, this information is not returned.
        /// </summary>
        public ulong[] LineOffsets { get; }

        public OutputDisassemblyLinesResult(uint offsetLine, ulong startOffset, ulong endOffset, ulong[] lineOffsets)
        {
            OffsetLine = offsetLine;
            StartOffset = startOffset;
            EndOffset = endOffset;
            LineOffsets = lineOffsets;
        }
    }
}
