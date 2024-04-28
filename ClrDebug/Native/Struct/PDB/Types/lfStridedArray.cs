using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, elemtype = {elemtype.ToString(),nq}, idxtype = {idxtype.ToString(),nq}, stride = {stride}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfStridedArray
    {
        /// <summary>
        /// LF_STRIDED_ARRAY
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of element type
        /// </summary>
        public CV_typ_t elemtype;

        /// <summary>
        /// type index of indexing type
        /// </summary>
        public CV_typ_t idxtype;

        public int stride;

        /// <summary>
        /// variable length data specifying size in bytes and name
        /// </summary>
        public fixed byte data[1];
    }
}
