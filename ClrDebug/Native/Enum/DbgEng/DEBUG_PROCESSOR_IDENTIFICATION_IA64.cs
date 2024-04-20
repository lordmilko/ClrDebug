namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Identifies an Intel Itanium architecture (IA64) processor.
    /// </summary>
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_IA64
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
        /// The family of the processor.
        /// </summary>
        public int Family;

        /// <summary>
        /// The architecture revision of the processor.
        /// </summary>
        public int ArchRev;

        /// <summary>
        /// A vendor specified string.
        /// </summary>
        public fixed byte VendorString[16];
    }
}