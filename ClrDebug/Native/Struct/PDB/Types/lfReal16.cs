using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// real 16-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfReal16
    {
        /// <summary>
        /// LF_REAL16
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// 16-bit real value
        /// </summary>
        public short val;
    }
}
