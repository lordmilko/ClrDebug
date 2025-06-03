using System.Runtime.InteropServices;

namespace ClrDebug.OMF
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
        /// Contains an array of <see cref="cFile"/> offsets. Each offset should be added to the address
        /// of the <see cref="OMFSourceModule"/> to get the address of an <see cref="OMFSourceFile"/> item.
        /// </summary>
        public fixed uint baseSrcFile[1];

        //baseSrcFile is followed by an array of segment start/end pairs
        //which is then followed by an array of linker indices of each segment in the module
    }
}
