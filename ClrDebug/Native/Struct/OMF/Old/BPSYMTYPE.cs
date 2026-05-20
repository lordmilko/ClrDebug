namespace ClrDebug.OMF
{
    //S_BPREL
    public unsafe struct BPSYMTYPE
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
        /// BP-relative offset
        /// </summary>
        public int off;

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
