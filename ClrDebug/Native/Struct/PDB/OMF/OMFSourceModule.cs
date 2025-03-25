using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Source line to address mapping header structure<para/>
    /// This structure describes the number and location of the
    /// OMFAddrLine tables for a module.  The offSrcLine entries are
    /// relative to the beginning of this structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFSourceModule
    {
        /// <summary>
        /// number of OMFSourceTables
        /// </summary>
        public ushort cFile;

        /// <summary>
        /// number of segments in module
        /// </summary>
        public ushort cSeg;

        /// <summary>
        /// base of OMFSourceFile table<para/>
        /// this array is followed by array of segment start/end pairs followed
        /// by an array of linker indices for each segment in the module
        /// </summary>
        public fixed uint baseSrcFile[1];
    }
}
