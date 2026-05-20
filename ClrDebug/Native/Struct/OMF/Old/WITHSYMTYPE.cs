namespace ClrDebug.OMF
{
    //S_WITH
    public unsafe struct WITHSYMTYPE 
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
        /// Length of scope
        /// </summary>
        public short len;

        /// <summary>
        /// String to be evaluated
        /// </summary>
        public fixed byte name[1];
    }
}
