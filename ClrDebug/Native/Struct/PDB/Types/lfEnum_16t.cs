using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_ENUM
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, utype = {utype.ToString(),nq}, field = {field.ToString(),nq}, property = {property.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfEnum_16t
    {
        /// <summary>
        /// LF_ENUM_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// count of number of elements in class
        /// </summary>
        public short count;

        /// <summary>
        /// underlying type of the enum
        /// </summary>
        public CV_typ16_t utype;

        /// <summary>
        /// type index of LF_FIELD descriptor list
        /// </summary>
        public CV_typ16_t field;

        /// <summary>
        /// property attribute field
        /// </summary>
        public CV_prop_t property;

        /// <summary>
        /// length prefixed name of enum
        /// </summary>
        public fixed byte Name[1];
    }
}
