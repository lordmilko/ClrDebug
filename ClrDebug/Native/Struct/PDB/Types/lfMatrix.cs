using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_MATRIX
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, elemtype = {elemtype.ToString(),nq}, rows = {rows}, cols = {cols}, majorStride = {majorStride}, matattr = {matattr.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfMatrix
    {
        /// <summary>
        /// LF_MATRIX
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of element type
        /// </summary>
        public CV_typ_t elemtype;

        /// <summary>
        /// number of rows
        /// </summary>
        public int rows;

        /// <summary>
        /// number of columns
        /// </summary>
        public int cols;

        public int majorStride;

        /// <summary>
        /// attributes
        /// </summary>
        public CV_matrixattr_t matattr;

        /// <summary>
        /// variable length data specifying size in bytes and name
        /// </summary>
        public fixed byte data[1];
    }
}
