namespace ClrDebug.OMF
{
    //S_PROC, S_ENTRY
    public unsafe struct PROCSYMTYPE
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
        /// Type index
        /// </summary>
        public short typind;

        /// <summary>
        /// Proc length
        /// </summary>
        public short len;

        /// <summary>
        /// Debug start offset
        /// </summary>
        public short startoff;

        /// <summary>
        /// Debug end offset
        /// </summary>
        public short endoff;

        /// <summary>
        /// Reserved
        /// </summary>
        public short res;

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
