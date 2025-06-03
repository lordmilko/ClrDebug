namespace ClrDebug.OMF
{
    //OMFDirEntry equivalent used by NB02. Principal difference is the size is a short
    //instead of an int
    public struct DirEntry
    {
        public SST SubSectionType;

        public ushort ModuleIndex;

        public int lfoStart;

        public short Size;
    }
}
