using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// signed int128 leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfOct
    {
        /// <summary>
        /// LF_OCT
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signed 128-bit value
        /// </summary>
        public fixed byte val[16];
    }
}
