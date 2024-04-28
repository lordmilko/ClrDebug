using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// unsigned short leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, val = {val}")]
    public struct lfUShort
    {
        /// <summary>
        /// LF_USHORT
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// unsigned 16-bit value
        /// </summary>
        public short val;
    }
}
