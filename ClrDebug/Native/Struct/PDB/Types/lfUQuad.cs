using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// unsigned quad leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfUQuad
    {
        /// <summary>
        /// LF_UQUAD
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// unsigned 64-bit value
        /// </summary>
        public fixed byte val[8];
    }
}
