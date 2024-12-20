namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines common "abstractions" for a few select processor registers. Not every processor need actually have a mapping for such.<para/>
    /// For instance, the return address register is 'LR' in ARM architectures and does not exist in X86 architectures.
    /// </summary>
    public enum SvcAbstractRegister : uint
    {
        /// <summary>
        /// An abstract way to refer to the instruction pointer of any architecture.
        /// </summary>
        SvcAbstractRegisterInstructionPointer,

        /// <summary>
        /// An abstract way to refer to the stack pointer of any architecture.
        /// </summary>
        SvcAbstractRegisterStackPointer,

        /// <summary>
        /// An abstract way to refer to the frame pointer of any architecture.
        /// </summary>
        SvcAbstractRegisterFramePointer,

        /// <summary>
        /// An abstract way to refer to the return address register of any architecture.
        /// </summary>
        SvcAbstractRegisterReturnAddress
    }
}
