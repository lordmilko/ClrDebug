namespace ClrDebug.PDB
{
    public unsafe struct SrcHeaderBlock
    {
        public int ver;
        public int cb;
        public FILETIME f;
        public int age;
        public fixed byte rgbPad[44];
    }
}
