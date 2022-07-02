namespace ClrDebug
{
    /// <summary>
    /// Indicates the type of memory address.
    /// </summary>
    public enum CorSymAddrKind
    {
        /// <summary>
        /// Indicates a Microsoft intermediate language (MSIL) local variable or parameter index.
        /// </summary>
        ADDR_IL_OFFSET = 1,

        /// <summary>
        /// Indicates a relative virtual address into a module.
        /// </summary>
        ADDR_NATIVE_RVA = 2,

        /// <summary>
        /// Indicates a CPU register.
        /// </summary>
        ADDR_NATIVE_REGISTER = 3,

        /// <summary>
        /// Indicates that the first address is a register and the second address is an offset.
        /// </summary>
        ADDR_NATIVE_REGREL = 4,

        /// <summary>
        /// Indicates an offset from a base address.
        /// </summary>
        ADDR_NATIVE_OFFSET = 5,

        /// <summary>
        /// Indicates that the first address is the low portion of a register, and the second address is the high portion.
        /// </summary>
        ADDR_NATIVE_REGREG = 6,

        /// <summary>
        /// Indicates that the first address is the low portion of a register, the second is the high portion, and the third is an offset.
        /// </summary>
        ADDR_NATIVE_REGSTK = 7,

        /// <summary>
        /// Indicates that the first address is a register, the second is an offset, and the third is the high portion of the register.
        /// </summary>
        ADDR_NATIVE_STKREG = 8,

        /// <summary>
        /// Indicates that the first address is the start of a field and the second address is the field length.
        /// </summary>
        ADDR_BITFIELD = 9,

        /// <summary>
        /// Indicates that the first address is the section and the second address is an offset.
        /// </summary>
        ADDR_NATIVE_ISECTOFFSET = 10,
    }
}