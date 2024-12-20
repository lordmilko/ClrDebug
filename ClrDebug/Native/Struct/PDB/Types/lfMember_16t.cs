using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for non-static data members
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}, attr = {attr.ToString(),nq}, offset = {offset}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfMember_16t
    {
        /// <summary>
        /// LF_MEMBER_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// index of type record for field
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// attribute mask
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// variable length offset of field followed by length prefixed name of field
        /// </summary>
        public fixed byte offset[1];
    }
}
