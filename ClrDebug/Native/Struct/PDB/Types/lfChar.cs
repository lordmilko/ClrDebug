using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// signed character leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    public struct lfChar
    {
        /// <summary>
        /// LF_CHAR
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signed 8-bit value
        /// </summary>
        public sbyte val;
    }
}
