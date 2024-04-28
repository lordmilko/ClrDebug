using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_ARRAY
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, elemtype = {elemtype.ToString(),nq}, idxtype = {idxtype.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfArray_16t
    {
        /// <summary>
        /// LF_ARRAY_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of element type
        /// </summary>
        public CV_typ16_t elemtype;

        /// <summary>
        /// type index of indexing type
        /// </summary>
        public CV_typ16_t idxtype;

        /// <summary>
        /// variable length data specifying size in bytes and name
        /// </summary>
        public fixed byte data[1];
    }
}
