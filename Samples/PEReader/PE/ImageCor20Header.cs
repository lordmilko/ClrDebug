namespace PEReader.PE
{
    /// <summary>
    /// Represents the IMAGE_COR20_HEADER type that is pointed to by IMAGE_OPTIONAL_HEADER.DataDirectory[IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR] in managed assemblies.
    /// </summary>
    public class ImageCor20Header
    {
        public ushort MajorRuntimeVersion { get; }
        public ushort MinorRuntimeVersion { get; }
        public ImageDataDirectory Metadata { get; }
        public COMIMAGE_FLAGS Flags { get; }
        public int EntryPointTokenOrRelativeVirtualAddress { get; }
        public ImageDataDirectory Resources { get; }
        public ImageDataDirectory StrongNameSignature { get; }
        public ImageDataDirectory CodeManagerTable { get; }
        public ImageDataDirectory VtableFixups { get; }
        public ImageDataDirectory ExportAddressTableJumps { get; }
        public ImageDataDirectory ManagedNativeHeader { get; }

        internal ImageCor20Header(PEBinaryReader reader)
        {
            reader.ReadInt32(); //Skip byte count

            MajorRuntimeVersion = reader.ReadUInt16();
            MinorRuntimeVersion = reader.ReadUInt16();
            Metadata = new ImageDataDirectory(reader);
            Flags = (COMIMAGE_FLAGS) reader.ReadUInt32();
            EntryPointTokenOrRelativeVirtualAddress = reader.ReadInt32();
            Resources = new ImageDataDirectory(reader);
            StrongNameSignature = new ImageDataDirectory(reader);
            CodeManagerTable = new ImageDataDirectory(reader);
            VtableFixups = new ImageDataDirectory(reader);
            ExportAddressTableJumps = new ImageDataDirectory(reader);
            ManagedNativeHeader = new ImageDataDirectory(reader);
        }
    }
}
