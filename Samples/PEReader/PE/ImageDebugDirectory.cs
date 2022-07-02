using System;

namespace PEReader.PE
{
    /// <summary>
    /// Represents one of several IMAGE_DEBUG_DIRECTORY entries that may be pointed to by IMAGE_OPTIONAL_HEADER.DataDirectory[IMAGE_DIRECTORY_ENTRY_DEBUG].
    /// </summary>
    public struct ImageDebugDirectory
    {
        public int Characteristics { get; }

        /// <summary>
        /// The time and date that the debug data was created if the PE/COFF file is not deterministic,
        /// otherwise a value based on the hash of the content.
        /// </summary>
        /// <remarks>
        /// The algorithm used to calculate this value is an implementation
        /// detail of the tool that produced the file.
        /// </remarks>
        public uint TimeDateStamp { get; }

        /// <summary>
        /// The major version number of the debug data format.
        /// </summary>
        public ushort MajorVersion { get; }

        /// <summary>
        /// The minor version number of the debug data format.
        /// </summary>
        public ushort MinorVersion { get; }

        /// <summary>
        /// The format of debugging information.
        /// </summary>
        public ImageDebugType Type { get; }

        /// <summary>
        /// The size of the debug data (not including the debug directory itself).
        /// </summary>
        public int SizeOfData { get; }

        /// <summary>
        /// The address of the debug data when loaded, relative to the image base.
        /// </summary>
        public int AddressOfRawData { get; }

        /// <summary>
        /// The file pointer to the debug data.
        /// </summary>
        public int PointerToRawData { get; }

        internal const int Size =
            sizeof(uint) +   // Characteristics
            sizeof(uint) +   // TimeDataStamp
            sizeof(uint) +   // Version
            sizeof(uint) +   // Type
            sizeof(uint) +   // SizeOfData
            sizeof(uint) +   // AddressOfRawData
            sizeof(uint);    // PointerToRawData

        internal ImageDebugDirectory(PEBinaryReader reader)
        {
            Characteristics = reader.ReadInt32();

            if (Characteristics != 0)
                throw new BadImageFormatException($"The value of field {nameof(Characteristics)} in debug directory entry must be zero.");

            TimeDateStamp = reader.ReadUInt32();
            MajorVersion = reader.ReadUInt16();
            MinorVersion = reader.ReadUInt16();

            Type = (ImageDebugType) reader.ReadInt32();

            SizeOfData = reader.ReadInt32();
            AddressOfRawData = reader.ReadInt32();
            PointerToRawData = reader.ReadInt32();
        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
