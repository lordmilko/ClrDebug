using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// variable length numeric field
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, len = {len}, value = {value}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfVarString
    {
        /// <summary>
        /// LF_VARSTRING
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// length of value in bytes
        /// </summary>
        public short len;

        /// <summary>
        /// value
        /// </summary>
        public fixed byte value[1];
    }
}
