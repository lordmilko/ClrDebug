using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for non-static data members
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, offset = {offset}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfMember
    {
        /// <summary>
        /// LF_MEMBER
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// attribute mask
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// index of type record for field
        /// </summary>
        public CV_typ_t index;

        /// <summary>
        /// variable length offset of field followed by length prefixed name of field
        /// </summary>
        public fixed byte offset[1];
    }
}
