using System.Collections.Generic;
using System.Linq;

namespace PEReader.PE
{
    /// <summary>
    /// Encapsulates the IMAGE_DEBUG_DIRECTORY entries that have been read from IMAGE_OPTIONAL_HEADER.DataDirectory[IMAGE_DIRECTORY_ENTRY_DEBUG]
    /// and provides access to information that is pointed to by various different IMAGE_DEBUG_DIRECTORY types.
    /// </summary>
    public class ImageDebugDirectoryInfo
    {
        private PEFile file;

        public CodeViewInfo[] CodeViews { get; }

        public ImageDebugDirectory[] Entries { get; }

        internal ImageDebugDirectoryInfo(PEFile file)
        {
            this.file = file;

            Entries = ReadDebugDirectories();
            CodeViews = Entries
                .Where(v => v.Type == ImageDebugType.CodeView)
                .Select(v =>
                {
                    var offset = file.GetOffset(v);

                    file.Reader.Seek(offset);

                    return new CodeViewInfo(file.Reader);
                })
                .ToArray();
        }

        private ImageDebugDirectory[] ReadDebugDirectories()
        {
            var entryCount = file.OptionalHeader.DebugTableDirectory.Size / ImageDebugDirectory.Size;

            if (entryCount > 0)
            {
                int offset;

                if (!file.TryGetDirectoryOffset(file.OptionalHeader.DebugTableDirectory, out offset, true))
                    return new ImageDebugDirectory[0];

                file.Reader.Seek(offset);

                var list = new List<ImageDebugDirectory>();

                for (var i = 0; i < entryCount; i++)
                    list.Add(new ImageDebugDirectory(file.Reader));

                return list.ToArray();
            }

            return new ImageDebugDirectory[0];
        }
    }
}
