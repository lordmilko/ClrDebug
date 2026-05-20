namespace ClrDebug.OMF
{
    //S_LABEL
    public unsafe struct LABSYMTYPE
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
        /// Return type (NEAR/FAR)
        /// </summary>
        public byte rtntyp;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
