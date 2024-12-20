namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Flags that define types of registers (including categories that a given context might contain).
    /// </summary>
    public enum SvcContextFlags : uint
    {
        SvcContextCategorizationMask = 0x0000ffff,

        /// <summary>
        /// Indicates integer &amp; general purpose registers.
        /// </summary>
        SvcContextIntegerGPR = 0x00000001,

        /// <summary>
        /// Floating point registers.
        /// </summary>
        SvcContextFloatingPoint = 0x00000002,

        /// <summary>
        /// Extended (AVX/SSE).
        /// </summary>
        SvcContextExtended = 0x00000004,

        /// <summary>
        /// Control registers.
        /// </summary>
        SvcContextControl = 0x00000008,

        /// <summary>
        /// Debug registers.
        /// </summary>
        SvcContextDebug = 0x00000010,

        /// <summary>
        /// Special context (not retrievable or settable via a standard GetContext/SetContext).
        /// </summary>
        SvcContextSpecial = 0x00000020,
        SvcContextInformationMask = 0xffff0000,

        /// <summary>
        /// Register is a part of another register (e.g.: eax of rax, ah/al of ax, etc...).
        /// </summary>
        SvcContextSubRegister = 0x00010000,

        /// <summary>
        /// Register is a flags register. This may indicate that the entire register is a flags register (every bit) or that part of the register is a flags register (e.g.: some bits are control flags and others are data).<para/>
        /// If this flag is set, queries about flags can be made via ISvcRegisterInformation.
        /// </summary>
        SvcContextFlagsRegister = 0x00020000
    }
}
