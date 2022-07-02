using System.Linq;

namespace PEReader.PE
{
    /// <summary>
    /// Encapsulates the enture resource hierarchy descended from the root IMAGE_RESOURCE_DIRECTORY entry that may have been read from IMAGE_OPTIONAL_HEADER.DataDirectory[IMAGE_DIRECTORY_ENTRY_RESOURCE]<para/>
    /// and provides access to specified types of resources that may have been read out of specified IMAGE_RESOURCE_DATA_ENTRY structures contained within this hierarchy.
    /// </summary>
    public class ImageResourceDirectoryInfo
    {
        public ImageResourceDirectoryLevel Root { get; }

        public VS_VERSIONINFO Version { get; }

        internal ImageResourceDirectoryInfo(PEFile file)
        {
            Root = ImageResourceDirectoryLevel.New(file);

            Version = ReadVersionInfo(file);
        }

        private VS_VERSIONINFO ReadVersionInfo(PEFile file)
        {
            const int VS_FILE_INFO = 16;
            const int VS_VERSION_INFO = 1;

            var entry = Root[VS_FILE_INFO]?[VS_VERSION_INFO]?.Directory.Entries.FirstOrDefault();

            if (entry == null)
                return null;

            int offset;

            if (!file.TryGetOffset(entry.Data.OffsetToData, out offset))
                return null;

            file.Reader.Seek(offset);

            var version = new VS_VERSIONINFO(file.Reader);

            if (version.Value.Signature != VS_FIXEDFILEINFO.FixedFileInfoSignature)
                return null;

            return version;
        }
    }
}