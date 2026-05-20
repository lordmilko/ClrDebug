namespace ClrDebug.OMF
{
    //Probably S_CV4LABEL (not explicitly dumped in cvdump)
    public unsafe struct CV4LABSYMTYPE
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
        /// Return type (NEAR/FAR)
        /// </summary>
        public byte rtntyp;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
