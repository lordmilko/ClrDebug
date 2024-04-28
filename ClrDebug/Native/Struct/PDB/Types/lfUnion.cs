using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_UNION
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, property = {property.ToString(),nq}, field = {field.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfUnion
    {
        /// <summary>
        /// LF_UNION
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// count of number of elements in class
        /// </summary>
        public short count;

        /// <summary>
        /// property attribute field
        /// </summary>
        public CV_prop_t property;

        /// <summary>
        /// type index of LF_FIELD descriptor list
        /// </summary>
        public CV_typ_t field;

        /// <summary>
        /// variable length data describing length of structure and name
        /// </summary>
        public fixed byte data[1];
    }
}
