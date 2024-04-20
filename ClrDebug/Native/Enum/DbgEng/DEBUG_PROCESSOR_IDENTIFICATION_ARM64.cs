namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Identifies an ARM64 processor.
    /// </summary>
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_ARM64
    {
        /// <summary>
        /// The model of the processor.
        /// </summary>
        public int Model;

        /// <summary>
        /// The revision of the processor.
        /// </summary>
        public int Revision;

        /// <summary>
        /// A vendor specified string.
        /// </summary>
        public fixed byte VendorString[16];
    }
}