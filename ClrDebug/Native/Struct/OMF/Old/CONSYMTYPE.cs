namespace ClrDebug.OMF
{
    //Probably S_CONST (not explicitly dumped in cvdump)
    public unsafe struct CONSYMTYPE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public byte reclen;

        /// <summary>
        /// Record type
        /// </summary>
        public byte rectyp;

        /// <summary>
        /// Type index
        /// </summary>
        public short typind;

        /// <summary>
        /// Variable-length value
        /// </summary>
        public fixed byte value[1];

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
