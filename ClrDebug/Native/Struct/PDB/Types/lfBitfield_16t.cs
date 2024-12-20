using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_BITFIELD
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, length = {length}, position = {position}, type = {type.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfBitfield_16t
    {
        /// <summary>
        /// LF_BITFIELD_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        public byte length;
        public byte position;

        /// <summary>
        /// type of bitfield
        /// </summary>
        public CV_typ16_t type;
    }
}
