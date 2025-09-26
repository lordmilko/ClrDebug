namespace ClrDebug.PDB
{
    public enum SrcCompress : byte
    {
        srccompressNone,
        srccompressRLE,
        srccompressHuffman,
        srccompressLZ,

        //Name unknown, but used within DiaSymReader to indicate that the bytes of a SrcFormat
        //have a leading int32 that indicates whether the source is compressed or not (like in Portable PDBs)
        SrcFormat = 101
    }
}
