using System;
using System.Collections.Generic;
using System.IO;

namespace PEReader.PE
{
    /// <summary>
    /// Represents a Portable Executable (PE) file.
    /// </summary>
    public class PEFile
    {
        internal const ushort DosSignature = 0x5A4D;     //MZ
        internal const int PESignatureOffsetLocation = 0x3C;
        internal const uint PESignature = 0x00004550;    //PE00

        /// <summary>
        /// Gets whether the image exists within the memory a live process, or exists on disk. Offsets are slightly different in some areas when in memory vs on disk.
        /// </summary>
        public bool IsLoadedImage { get; }

        /// <summary>
        /// Gets the file header of the image. This value represents the IMAGE_NT_HEADERS.FileHeader field.
        /// </summary>
        public ImageFileHeader FileHeader { get; }

        /// <summary>
        /// Gets the optional header of the image. This value represents the IMAGE_NT_HEADERS.OptionalHeader field.
        /// </summary>
        public ImageOptionalHeader OptionalHeader { get; }

        /// <summary>
        /// Gets the section headers of the image. These values represent the IMAGE_SECTION_HEADER values (e.g. .text, .data) that immediately follow the <see cref="OptionalHeader"/>.<para/>
        /// Each section header points to a relative location within the image at which that section actually resides.
        /// </summary>
        public ImageSectionHeader[] SectionHeaders { get; }

        #region Directories

        //Items pointed to by directory entries in ImageOptionalHeader

        /// <summary>
        /// Gets the information about the export table in the image, and where the components of it can be found.<para/>
        /// This value is pointed to by <see cref="ImageOptionalHeader.ExportTableDirectory"/>.
        /// </summary>
        public ImageExportDirectory ExportDirectory { get; }

        public ImageCor20Header Cor20Header { get; }

        public ImageDebugDirectoryInfo DebugDirectoryInfo { get; }

        public ImageResourceDirectoryInfo ResourceDirectoryInfo { get; }

        #endregion

        /// <summary>
        /// Gets a reader capable of seeking to and reading from arbitrary locations within the image.
        /// </summary>
        public PEBinaryReader Reader { get; }

        public PEFile(Stream stream, bool isLoadedImage)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            if (!stream.CanRead || !stream.CanSeek)
                throw new InvalidOperationException("Stream must support read and seek operations.");

            IsLoadedImage = isLoadedImage;

            Reader = new PEBinaryReader(stream);

            //The PE file format extends the COFF format; if the file doesn't start with MZ,
            //it may be an old school COFF file (i.e. *.obj)
            var isCoffOnly = SkipDosHeader();

            FileHeader = new ImageFileHeader(Reader);

            if (!isCoffOnly)
                OptionalHeader = new ImageOptionalHeader(Reader);

            SectionHeaders = ReadSectionHeaders();

            //Try read various directories. Some entries are optional, while others are mandatory

            if (!isCoffOnly)
                Cor20Header = ReadCor20Header();

            ExportDirectory = ReadExportDirectory();
            DebugDirectoryInfo = new ImageDebugDirectoryInfo(this);
            ResourceDirectoryInfo = new ImageResourceDirectoryInfo(this);
        }

        private ImageSectionHeader[] ReadSectionHeaders()
        {
            if (FileHeader.NumberOfSections < 0)
                throw new BadImageFormatException("Invalid number of sections declared in PE header.");

            var list = new List<ImageSectionHeader>();

            for (var i = 0; i < FileHeader.NumberOfSections; i++)
                list.Add(new ImageSectionHeader(Reader));

            return list.ToArray();
        }

        private ImageCor20Header ReadCor20Header()
        {
            int offset;
            if (TryCalculateCor20HeaderOffset(out offset))
            {
                Reader.Seek(offset);
                return new ImageCor20Header(Reader);
            }

            return null;
        }

        private ImageExportDirectory ReadExportDirectory()
        {
            int offset;

            if (!TryGetDirectoryOffset(OptionalHeader.ExportTableDirectory, out offset, true))
                return null;

            Reader.Seek(offset);
            return new ImageExportDirectory(Reader);
        }

        #region Helpers

        private bool SkipDosHeader()
        {
            var dosSig = Reader.ReadUInt16();

            if (dosSig != DosSignature)
            {
                if (dosSig != 0 || Reader.ReadUInt16() != 0xffff)
                {
                    Reader.Seek(0);
                    return true;
                }

                throw new BadImageFormatException("Unknown file format.");
            }

            Reader.Seek(PESignatureOffsetLocation);

            int ntHeaderOffset = Reader.ReadInt32();
            Reader.Seek(ntHeaderOffset);

            var ntSignature = Reader.ReadUInt32();

            if (ntSignature != PESignature)
                throw new BadImageFormatException("Invalid PE signature.");

            return false;
        }

        private bool TryCalculateCor20HeaderOffset(out int startOffset)
        {
            if (!TryGetDirectoryOffset(OptionalHeader.CorHeaderTableDirectory, out startOffset, false))
            {
                startOffset = -1;
                return false;
            }

            var length = OptionalHeader.CorHeaderTableDirectory.Size;

            const int sizeOfCorHeader = 72;

            if (length < sizeOfCorHeader)
                throw new BadImageFormatException("Invalid COR header size.");

            return true;
        }

        /// <summary>
        /// Tries to get the offset within the image of the full directory pointed to by an <see cref="ImageDataDirectory"/>.
        /// </summary>
        /// <param name="entry">The <see cref="ImageDataDirectory"/> that may point to a full directory within the image.</param>
        /// <param name="offset">Offset from the start of the image to the given directory data.</param>
        /// <param name="canCrossSectionBoundary">Whether size of the entry is allowed to cross over the end of the section boundary.</param>
        /// <returns>True if the <see cref="ImageDataDirectory"/> points to a valid section, otherwise false.</returns>
        public bool TryGetDirectoryOffset(ImageDataDirectory entry, out int offset, bool canCrossSectionBoundary)
        {
            var sectionIndex = GetSectionContainingRVA(entry.RelativeVirtualAddress);

            if (sectionIndex < 0)
            {
                offset = -1;
                return false;
            }

            var section = SectionHeaders[sectionIndex];
            var relativeOffset = entry.RelativeVirtualAddress - section.VirtualAddress;

            if (!canCrossSectionBoundary && entry.Size > section.VirtualSize - relativeOffset)
                throw new BadImageFormatException("Section too small.");

            offset = IsLoadedImage
                ? entry.RelativeVirtualAddress
                : section.PointerToRawData + relativeOffset;

            return true;
        }

        public bool TryGetOffset(int rva, out int offset)
        {
            var sectionIndex = GetSectionContainingRVA(rva);

            if (sectionIndex < 0)
            {
                offset = -1;
                return false;
            }

            var section = SectionHeaders[sectionIndex];
            var relativeOffset = rva - section.VirtualAddress;

            offset = IsLoadedImage
                ? rva
                : section.PointerToRawData + relativeOffset;

            return true;
        }

        /// <summary>
        /// Gets the section that contains the specified Relative Virtual Address.
        /// </summary>
        /// <param name="rva">The RVA whose containing section should be found.</param>
        /// <returns>The index of section that contains the RVA, or -1 if none was found.</returns>
        public int GetSectionContainingRVA(int rva)
        {
            for (var i = 0; i < SectionHeaders.Length; i++)
            {
                var start = SectionHeaders[i].VirtualAddress;
                var end = SectionHeaders[i].VirtualAddress + SectionHeaders[i].VirtualSize;

                if (start <= rva && rva < end)
                    return i;
            }

            return -1;
        }

        internal int GetOffset(ImageDebugDirectory entry)
        {
            int dataOffset = IsLoadedImage
                ? entry.AddressOfRawData
                : entry.PointerToRawData;

            return dataOffset;
        }

        #endregion
    }
}
