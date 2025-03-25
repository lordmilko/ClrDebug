using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// directory information structure<para/>
    /// This structure contains the information describing the directory.
    /// It is pointed to by the signature at the base address or the directory
    /// link field of a preceeding directory.  The directory entries immediately
    /// follow this structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OMFDirHeader
    {
        /// <summary>
        /// length of this structure
        /// </summary>
        public ushort cbDirHeader;

        /// <summary>
        /// number of bytes in each directory entry
        /// </summary>
        public ushort cbDirEntry;

        /// <summary>
        /// number of directorie entries
        /// </summary>
        public uint cDir;

        /// <summary>
        /// offset from base of next directory
        /// </summary>
        public int lfoNextDir;

        /// <summary>
        /// status flags
        /// </summary>
        public uint flags;
    }
}
