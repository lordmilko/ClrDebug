using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for base class field
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}, attr = {attr.ToString(),nq}, offset = {offset}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfBClass_16t
    {
        /// <summary>
        /// LF_BCLASS_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of base class
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// attribute
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// variable length offset of base within class
        /// </summary>
        public fixed byte offset[1];
    }
}
