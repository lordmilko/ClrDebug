using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_CLASS, LF_STRUCTURE
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, field = {field.ToString(),nq}, property = {property.ToString(),nq}, derived = {derived.ToString(),nq}, vshape = {vshape.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfClass_16t
    {
        /// <summary>
        /// LF_CLASS_16t, LF_STRUCT_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// count of number of elements in class
        /// </summary>
        public short count;

        /// <summary>
        /// type index of LF_FIELD descriptor list
        /// </summary>
        public CV_typ16_t field;

        /// <summary>
        /// property attribute field (prop_t)
        /// </summary>
        public CV_prop_t property;

        /// <summary>
        /// type index of derived from list if not zero
        /// </summary>
        public CV_typ16_t derived;

        /// <summary>
        /// type index of vshape table for this class
        /// </summary>
        public CV_typ16_t vshape;

        /// <summary>
        /// data describing length of structure in bytes and name
        /// </summary>
        public fixed byte data[1];
    }
}
