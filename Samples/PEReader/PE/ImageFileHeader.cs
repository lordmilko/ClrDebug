using ClrDebug;

namespace PEReader.PE
{
    /// <summary>
    /// Represents a the IMAGE_FILE_HEADER structure that describes the COFF header format.
    /// </summary>
    public struct ImageFileHeader
    {
        /// <summary>
        /// The type of target machine.
        /// </summary>
        public IMAGE_FILE_MACHINE Machine { get; }

        /// <summary>
        /// The number of sections. This indicates the size of the section table, which immediately follows the headers.
        /// </summary>
        public short NumberOfSections { get; }

        /// <summary>
        /// The low 32 bits of the number of seconds since 00:00 January 1, 1970, that indicates when the file was created.
        /// </summary>
        public int TimeDateStamp { get; }

        /// <summary>
        /// The file pointer to the COFF symbol table, or zero if no COFF symbol table is present.
        /// This value should be zero for a PE image.
        /// </summary>
        public int PointerToSymbolTable { get; }

        /// <summary>
        /// The number of entries in the symbol table. This data can be used to locate the string table,
        /// which immediately follows the symbol table. This value should be zero for a PE image.
        /// </summary>
        public int NumberOfSymbols { get; }

        /// <summary>
        /// The size of the optional header, which is required for executable files but not for object files.
        /// This value should be zero for an object file.
        /// </summary>
        public short SizeOfOptionalHeader { get; }

        /// <summary>
        /// The flags that indicate the attributes of the file.
        /// </summary>
        public ImageFile Characteristics { get; }

        internal const int Size =
            sizeof(short) + // Machine
            sizeof(short) + // NumberOfSections
            sizeof(int) +   // TimeDateStamp:
            sizeof(int) +   // PointerToSymbolTable
            sizeof(int) +   // NumberOfSymbols
            sizeof(short) + // SizeOfOptionalHeader:
            sizeof(ushort); // Characteristics

        internal ImageFileHeader(PEBinaryReader reader)
        {
            Machine = (IMAGE_FILE_MACHINE) reader.ReadUInt16();
            NumberOfSections = reader.ReadInt16();
            TimeDateStamp = reader.ReadInt32();
            PointerToSymbolTable = reader.ReadInt32();
            NumberOfSymbols = reader.ReadInt32();
            SizeOfOptionalHeader = reader.ReadInt16();
            Characteristics = (ImageFile) reader.ReadUInt16();
        }
    }
}
