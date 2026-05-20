namespace ClrDebug.OMF
{
    //S_CV4CHGMODEL?
    public unsafe struct CV4CHANGESYMTYPE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public byte reclen;

        /// <summary>
        /// Record type
        /// </summary>
        public OLDSYM rectyp;

        /// <summary>
        /// Offset in code seg
        /// </summary>
        public int off;

        /// <summary>
        /// Segment of code
        /// </summary>
        public ushort seg;

        /// <summary>
        /// Execution model to change to
        /// </summary>
        public byte model;

        /// <summary>
        /// Variant info (unspecified)
        /// </summary>
        public fixed byte var[1];
    }
}
