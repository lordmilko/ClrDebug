using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// directory structure<para/>
    /// The data in this structure is used to reference the data for each
    /// subsection of the CodeView Debug OMF information.  Tables that are
    /// not associated with a specific module will have a module index of
    /// oxffff.  These tables are the global types table, the global symbol
    /// table, the global public table and the library table.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OMFDirEntry
    {
        /// <summary>
        /// subsection type (sst...)
        /// </summary>
        public sstType SubSection;

        /// <summary>
        /// module index
        /// </summary>
        public ushort iMod;

        /// <summary>
        /// large file offset of subsection
        /// </summary>
        public int lfo;

        /// <summary>
        /// number of bytes in subsection
        /// </summary>
        public uint cb;
    }
}
