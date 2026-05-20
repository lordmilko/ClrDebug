namespace ClrDebug.OMF
{
    //Probably S_CV4WITH (not explicitly dumped in cvdump)
    public unsafe struct CV4WITHSYMTYPE
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
        /// Offset of sym of enclosing proc
        /// </summary>
        public int parentsym;

        /// <summary>
        /// matching end
        /// </summary>
        public int endsym;

        /// <summary>
        /// Offset in code seg
        /// </summary>
        public int off;

        /// <summary>
        /// Segment of code
        /// </summary>
        public ushort seg;

        /// <summary>
        /// Length of scope
        /// </summary>
        public int len;

        /// <summary>
        /// String to be evaluated
        /// </summary>
        public fixed byte name[1];
    }
}
