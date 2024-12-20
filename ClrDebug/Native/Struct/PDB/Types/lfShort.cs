using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// signed short leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfShort
    {
        /// <summary>
        /// LF_SHORT
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signed 16-bit value
        /// </summary>
        public short val;
    }
}
