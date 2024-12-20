using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// unsigned int128 leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfUOct
    {
        /// <summary>
        /// LF_UOCT
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// unsigned 128-bit value
        /// </summary>
        public fixed byte val[16];
    }
}
