using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_VECTOR
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, elemtype = {elemtype.ToString(),nq}, count = {count}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfVector
    {
        /// <summary>
        /// LF_VECTOR
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of element type
        /// </summary>
        public CV_typ_t elemtype;

        /// <summary>
        /// number of elements in the vector
        /// </summary>
        public int count;

        /// <summary>
        /// variable length data specifying size in bytes and name
        /// </summary>
        public fixed byte data[1];
    }
}
