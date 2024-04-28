using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// real 128-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfReal128
    {
        /// <summary>
        /// LF_REAL128
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// real 128-bit value
        /// </summary>
        public fixed byte val[16];
    }
}
