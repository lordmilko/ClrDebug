namespace ClrDebug.PDB
{
    public unsafe struct SrcHeaderW
    {
        /// <summary>
        /// record length
        /// </summary>
        public int cb;

        /// <summary>
        ///header version
        /// </summary>
        public int ver;

        /// <summary>
        /// CRC of the data for uniqueness w/o full compare
        /// </summary>
        public uint sig;

        /// <summary>
        /// count of bytes of the resulting source
        /// </summary>
        public int cbSource;

        /// <summary>
        /// compression algorithm used
        /// </summary>
        public SrcCompress srccompress;

        //struct {
        //    unsigned char fVirtual : 1;   // file is a virtual file (injected)
        //    unsigned char pad : 7;        // must be zero
        //};
        public byte grFlags;

        /// <summary>
        /// file names (szFile "\0" szObj "\0" szVirtual, as in: "f.cpp" "\0" "f.obj" "\0" "*inj:1:f.obj")
        /// in the case of non-virtual files, szVirtual is the same as szFile.
        /// </summary>
        public fixed char szNames[1];
    }
}
