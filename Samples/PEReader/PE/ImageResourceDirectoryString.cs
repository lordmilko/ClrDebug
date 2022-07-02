namespace PEReader.PE
{
    /// <summary>
    /// Represents the name of an IMAGE_RESOURCE_DIRECTORY_ENTRY.
    /// </summary>
    public class ImageResourceDirectoryString
    {
        public int Length { get; }

        public string NameString { get; }

        internal ImageResourceDirectoryString(PEBinaryReader reader)
        {
            Length = reader.ReadUInt16();

            NameString = reader.ReadUnicodeString(Length);
        }

        public override string ToString()
        {
            return NameString;
        }
    }
}