namespace PEReader.PE
{
    /// <summary>
    /// Represents a data entry pointed to by an IMAGE_RESOURCE_DIRECTORY_ENTRY contained in an IMAGE_RESOURCE_DIRECTORY.
    /// </summary>
    public class ImageResourceDataEntry
    {
        public int OffsetToData;
        public uint Size;
        public uint CodePage;
        public uint Reserved;

        internal ImageResourceDataEntry(PEBinaryReader reader)
        {
            OffsetToData = reader.ReadInt32();
            Size = reader.ReadUInt32();
            CodePage = reader.ReadUInt32();
            Reserved = reader.ReadUInt32();
        }
    }
}