namespace PEReader.PE
{
    /// <summary>
    /// Represents the IMAGE_RESOURCE_DIRECTORY structure. Immediately following this structure
    /// are <see cref="NumberOfNamedEntries"/> + <see cref="NumberOfIdEntries"/> IMAGE_RESOURCE_DIRECTORY_ENTRY structures.
    /// </summary>
    public class ImageResourceDirectory
    {
        public uint Characteristics;
        public uint TimeDateStamp;
        public ushort MajorVersion;
        public ushort MinorVersion;
        public ushort NumberOfNamedEntries;
        public ushort NumberOfIdEntries;

        internal ImageResourceDirectory(PEBinaryReader reader)
        {
            Characteristics = reader.ReadUInt32();
            TimeDateStamp = reader.ReadUInt32();
            MajorVersion = reader.ReadUInt16();
            MinorVersion = reader.ReadUInt16();
            NumberOfNamedEntries = reader.ReadUInt16();
            NumberOfIdEntries = reader.ReadUInt16();
        }
    }
}