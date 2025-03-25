using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// information decribing each segment in a module
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OMFSegDesc
    {
        /// <summary>
        /// segment index
        /// </summary>
        public ushort Seg;

        /// <summary>
        /// pad to maintain alignment
        /// </summary>
        public ushort pad;

        /// <summary>
        /// offset of code in segment
        /// </summary>
        public uint Off;

        /// <summary>
        /// number of bytes in segment
        /// </summary>
        public uint cbSeg;
    }
}
