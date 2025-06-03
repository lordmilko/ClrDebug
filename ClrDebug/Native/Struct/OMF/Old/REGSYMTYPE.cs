namespace ClrDebug.OMF
{
    //Probably S_REG (not explicitly dumped in cvdump)
    public unsafe struct REGSYMTYPE
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
        /// Which register
        /// </summary>
        public byte reg;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];
    }
}
