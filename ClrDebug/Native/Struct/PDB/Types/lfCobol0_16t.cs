using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for cobol0
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfCobol0_16t
    {
        /// <summary>
        /// LF_COBOL0_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// parent type record index
        /// </summary>
        public CV_typ16_t type;

        public fixed byte data[1];
    }
}
