namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Identifies an ARM processor.
    /// </summary>
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_ARM
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