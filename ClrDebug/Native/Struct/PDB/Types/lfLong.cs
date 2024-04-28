using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// signed long leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    public struct lfLong
    {
        /// <summary>
        /// LF_LONG
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signed 32-bit value
        /// </summary>
        public int val;
    }
}
