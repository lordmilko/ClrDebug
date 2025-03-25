using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Global types subsection format<para/>
    /// This structure immediately preceeds the global types table.
    /// The offsets in the typeOffset array are relative to the address
    /// of ctypes.  Each type entry following the typeOffset array must
    /// begin on a int word boundary.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFGlobalTypes
    {
        public OMFTypeFlags flags;

        /// <summary>
        /// number of types
        /// </summary>
        public uint cTypes;

        /// <summary>
        /// array of offsets to types
        /// </summary>
        public fixed uint typeOffset[1];
    }
}
