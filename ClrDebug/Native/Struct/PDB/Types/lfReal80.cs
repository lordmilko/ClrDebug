using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// real 80-bit leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfReal80
    {
        /// <summary>
        /// LF_REAL80
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// real 80-bit value
        /// </summary>
        public fixed byte val[10]; //FLOAT10
    }
}
