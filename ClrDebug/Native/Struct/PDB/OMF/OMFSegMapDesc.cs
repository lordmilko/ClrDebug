using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// OMFSegMap - This table contains the mapping between the logical segment indices
    /// used in the symbol table and the physical segments where the program is loaded
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OMFSegMapDesc
    {
        /// <summary>
        /// descriptor flags bit field.
        /// </summary>
        public ushort flags;

        /// <summary>
        /// the logical overlay number
        /// </summary>
        public ushort ovl;

        /// <summary>
        /// group index into the descriptor array
        /// </summary>
        public ushort group;

        /// <summary>
        /// logical segment index - interpreted via flags
        /// </summary>
        public ushort frame;

        /// <summary>
        /// segment or group name - index into sstSegName
        /// </summary>
        public ushort iSegName;

        /// <summary>
        /// class name - index into sstSegName
        /// </summary>
        public ushort iClassName;

        /// <summary>
        /// byte offset of the logical within the physical segment
        /// </summary>
        public uint offset;

        /// <summary>
        /// byte count of the logical segment or group
        /// </summary>
        public uint cbSeg;
    }
}
