namespace ClrDebug.OMF
{
    //Unknown (there isn't a S_CV4PROC or S_CV4ENTRY type)
    public unsafe struct CV4PROCSYMTYPE
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
        /// Sym of closest following proc
        /// </summary>
        public int nextsym;

        /// <summary>
        /// Offset in code seg
        /// </summary>
        public int off;

        /// <summary>
        /// Seg of proc
        /// </summary>
        public ushort seg;

        /// <summary>
        /// Type index
        /// </summary>
        public short typind;

        /// <summary>
        /// Proc length
        /// </summary>
        public int len;

        /// <summary>
        /// Debug start offset
        /// </summary>
        public int startoff;

        /// <summary>
        /// Debug end offset
        /// </summary>
        public int endoff;

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
