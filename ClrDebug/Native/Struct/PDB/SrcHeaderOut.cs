namespace ClrDebug.PDB
{
    public struct SrcHeaderOut
    {
        public int cb;         // record length
        public int ver;        // header version
        public uint sig;        // CRC of the data for uniqueness w/o full compare
        public int cbSource;   // count of bytes of the resulting source
        public int niFile;
        public int niObj;
        public int niVirt;
        public SrcCompress srccompress;// compression algorithm used

        //struct {
        //    unsigned char fVirtual : 1;   // file is a virtual file (injected)
        //    unsigned char pad : 7;        // must be zero
        //};
        public byte grFlags;

        public short sPad;

        //pvReserved1 is a void*, which is equal to or less than pv64Reserved2 which is always 64 bits
        public long pv64Reserved2;
    }
}
