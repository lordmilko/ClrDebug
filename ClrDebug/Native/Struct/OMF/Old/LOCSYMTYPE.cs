namespace ClrDebug.OMF
{
    //Probably S_LOCAL (not explicitly dumped in cvdump)
    public unsafe struct LOCSYMTYPE
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
        /// Offset in segment
        /// </summary>
        public int off;

        /// <summary>
        /// Segment address
        /// </summary>
        public ushort seg;

        /// <summary>
        /// Type index
        /// </summary>
        public short typind;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
