namespace PEReader.PE
{
    /// <summary>
    /// Represents the IMAGE_EXPORT_DIRECTORY structure, that describes the locations and components of the export table within the image.
    /// </summary>
    public class ImageExportDirectory
    {
        public int Characteristics;
        public int TimeDateStamp;
        public ushort MajorVersion;
        public ushort MinorVersion;
        public int Name;
        public int Base;
        public int NumberOfFunctions;
        public int NumberOfNames;
        public int AddressOfFunctions;
        public int AddressOfNames;
        public int AddressOfNameOrdinals;

        public static int Size =
            sizeof(int) + //Characteristics
            sizeof(int) + //TimeDateStamp
            sizeof(ushort) + //MajorVersion
            sizeof(ushort) + //MinorVersion
            sizeof(int) + //Name
            sizeof(int) + //Base
            sizeof(int) + //NumberOfFunctions
            sizeof(int) + //NumberOfNames
            sizeof(int) + //AddressOfFunctions
            sizeof(int) + //AddressOfNames
            sizeof(int); //AddressOfNameOrdinals

        internal ImageExportDirectory(PEBinaryReader reader)
        {
            Characteristics = reader.ReadInt32();
            TimeDateStamp = reader.ReadInt32();
            MajorVersion = reader.ReadUInt16();
            MinorVersion = reader.ReadUInt16();
            Name = reader.ReadInt32();
            Base = reader.ReadInt32();
            NumberOfFunctions = reader.ReadInt32();
            NumberOfNames = reader.ReadInt32();
            AddressOfFunctions = reader.ReadInt32();
            AddressOfNames = reader.ReadInt32();
            AddressOfNameOrdinals = reader.ReadInt32();
        }
    }
}
