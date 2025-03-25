using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_CLASS, LF_STRUCTURE
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, property = {property.ToString(),nq}, field = {field.ToString(),nq}, derived = {derived.ToString(),nq}, vshape = {vshape.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfClass
    {
        /// <summary>
        /// LF_CLASS, LF_STRUCTURE, LF_INTERFACE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// count of number of elements in class
        /// </summary>
        public short count;

        /// <summary>
        /// property attribute field (prop_t)
        /// </summary>
        public CV_prop_t property;

        /// <summary>
        /// type index of LF_FIELD descriptor list
        /// </summary>
        public CV_typ_t field;

        /// <summary>
        /// type index of derived from list if not zero
        /// </summary>
        public CV_typ_t derived;

        /// <summary>
        /// type index of vshape table for this class
        /// </summary>
        public CV_typ_t vshape;

        /// <summary>
        /// data describing length of structure in bytes and name
        /// </summary>
        public fixed byte data[1];

        //Can't have ToString() because that requires understanding the correct number of bytes to skip based on the LEAF_ENUM_e
        //value listed at the start of the "data" field. As this has some complexity to it, we leave this to the user so that
        //they can ensure it does what it's supposed to do
    }
}
