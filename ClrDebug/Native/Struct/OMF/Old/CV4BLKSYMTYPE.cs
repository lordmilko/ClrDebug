namespace ClrDebug.OMF
{
    //Probably S_CV4BLOCK (not explicitly dumped in cvdump)
    public unsafe struct CV4BLKSYMTYPE
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
        /// Block length
        /// </summary>
        public int len;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
