using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// sstLibraries
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFLibrary
    {
        /// <summary>
        /// count of library names
        /// </summary>
        public byte cbLibs;

        /// <summary>
        /// array of length prefixed lib names (first entry zero length)
        /// </summary>
        public fixed byte Libs[1];
    }
}
