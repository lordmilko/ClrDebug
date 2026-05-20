namespace ClrDebug.OMF
{
    //Probably S_TYPEDEF (not explicitly dumped in cvdump)
    public unsafe struct TYPEDEFSYMTYPE
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
        /// Type index
        /// </summary>
        public short typind;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
