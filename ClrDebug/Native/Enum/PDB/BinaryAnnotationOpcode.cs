namespace ClrDebug.PDB
{
    /// <summary>
    /// BinaryAnnotations ::= BinaryAnnotationInstruction+
    /// BinaryAnnotationInstruction ::= BinaryAnnotationOpcode Operand+<para/>
    ///
    /// The binary annotation mechanism supports recording a list of annotations
    /// in an instruction stream. The X64 unwind code and the DWARF standard have
    /// similar design.<para/>
    ///
    /// One annotation contains opcode and a number of 32bits operands.<para/>
    ///
    /// The initial set of annotation instructions are for line number table
    /// encoding only. These annotations append to S_INLINESITE record, and
    /// operands are unsigned except for BA_OP_ChangeLineOffset.
    /// </summary>
    public enum BinaryAnnotationOpcode
    {
        /// <summary>
        /// link time pdb contains PADDINGs
        /// </summary>
        BA_OP_Invalid,

        /// <summary>
        ///param : start offset 
        /// </summary>
        BA_OP_CodeOffset,

        /// <summary>
        /// param : nth separated code chunk (main code chunk == 0)
        /// </summary>
        BA_OP_ChangeCodeOffsetBase,

        /// <summary>
        /// param : delta of offset
        /// </summary>
        BA_OP_ChangeCodeOffset,

        /// <summary>
        /// param : length of code, default next start
        /// </summary>
        BA_OP_ChangeCodeLength,

        /// <summary>
        /// param : fileId 
        /// </summary>
        BA_OP_ChangeFile,

        /// <summary>
        /// param : line offset (signed)
        /// </summary>
        BA_OP_ChangeLineOffset,

        /// <summary>
        /// param : how many lines, default 1
        /// </summary>
        BA_OP_ChangeLineEndDelta,

        /// <summary>
        /// param : either 1 (default, for statement) or 0 (for expression)
        /// </summary>
        BA_OP_ChangeRangeKind,

        /// <summary>
        /// param : start column number, 0 means no column info
        /// </summary>
        BA_OP_ChangeColumnStart,

        /// <summary>
        /// param : end column number delta (signed)
        /// </summary>
        BA_OP_ChangeColumnEndDelta,

        // Combo opcodes for smaller encoding size.

        /// <summary>
        /// param : ((sourceDelta &lt;&lt; 4) | CodeDelta)
        /// </summary>
        BA_OP_ChangeCodeOffsetAndLineOffset,

        /// <summary>
        /// param : codeLength, codeOffset
        /// </summary>
        BA_OP_ChangeCodeLengthAndCodeOffset,

        /// <summary>
        /// param : end column number
        /// </summary>
        BA_OP_ChangeColumnEnd,
    }
}
