using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for skip record
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfSkip
    {
        /// <summary>
        /// LF_SKIP
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// next valid index
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// pad data
        /// </summary>
        public fixed byte data[1];
    }
}
