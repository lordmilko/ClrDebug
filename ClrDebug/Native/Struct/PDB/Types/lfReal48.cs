using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// real 48-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfReal48
    {
        /// <summary>
        /// LF_REAL48
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// 48-bit real value
        /// </summary>
        public fixed byte val[6];
    }
}
