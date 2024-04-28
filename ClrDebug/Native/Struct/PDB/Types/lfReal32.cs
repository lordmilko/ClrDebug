using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// real 32-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfReal32
    {
        /// <summary>
        /// LF_REAL32
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// 32-bit real value
        /// </summary>
        public float val;
    }
}
