namespace ClrDebug.OMF
{
    //S_BLOCK
    public unsafe struct BLKSYMTYPE
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
        /// Block length
        /// </summary>
        public short len;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
