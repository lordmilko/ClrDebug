namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Identifies an x86 processor.
    /// </summary>
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_X86
    {
        /// <summary>
        /// The family of the processor.
        /// </summary>
        public int Family;

        /// <summary>
        /// The model of the processor.
        /// </summary>
        public int Model;

        /// <summary>
        /// The stepping value of the processor.
        /// </summary>
        public int Stepping;

        /// <summary>
        /// A vendor specified string.
        /// </summary>
        public fixed byte VendorString[16];
    }
}