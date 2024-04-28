using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// signed quad leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfQuad
    {
        /// <summary>
        /// LF_QUAD
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signed 64-bit value
        /// </summary>
        public fixed byte val[8];
    }
}
