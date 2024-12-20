using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// int leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfULong
    {
        /// <summary>
        /// LF_ULONG
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// unsigned 32-bit value
        /// </summary>
        public int val;
    }
}
