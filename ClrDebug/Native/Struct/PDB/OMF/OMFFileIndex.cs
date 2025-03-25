using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// sstFileIndex - An index of all of the files contributing to an executable.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFFileIndex
    {
        /// <summary>
        /// Number of modules
        /// </summary>
        public ushort cmodules;

        /// <summary>
        /// Number of file references
        /// </summary>
        public ushort cfilerefs;

        /// <summary>
        /// Index to beginning of list of files for module i. (0 for module w/o files)
        /// </summary>
        public fixed ushort modulelist[1];

        /// <summary>
        /// Number of file names associated with module i.
        /// </summary>
        public fixed ushort cfiles[1];

        /// <summary>
        /// Offsets from the beginning of this table to the file names
        /// </summary>
        public fixed uint ulNames[1];

        /// <summary>
        /// The length prefixed names of files
        /// </summary>
        public fixed byte Names[1];
    }
}
