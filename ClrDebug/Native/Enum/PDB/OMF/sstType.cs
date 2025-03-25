namespace ClrDebug.PDB
{
    public enum sstType : ushort //Name made up
    {
        sstModule = 0x120,
        sstTypes = 0x121,
        sstPublic = 0x122,
        sstPublicSym = 0x123,   // publics as symbol (waiting for link)
        sstSymbols = 0x124,
        sstAlignSym = 0x125,
        sstSrcLnSeg = 0x126,   // because link doesn't emit SrcModule
        sstSrcModule = 0x127,
        sstLibraries = 0x128,
        sstGlobalSym = 0x129,
        sstGlobalPub = 0x12a,
        sstGlobalTypes = 0x12b,
        sstMPC = 0x12c,
        sstSegMap = 0x12d,
        sstSegName = 0x12e,
        sstPreComp = 0x12f,   // precompiled types
        sstPreCompMap = 0x130,   // map precompiled types in global types
        sstOffsetMap16 = 0x131,
        sstOffsetMap32 = 0x132,
        sstFileIndex = 0x133,   // Index of file names
        sstStaticSym = 0x134
    }
}
