using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for static data members
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}, attr = {attr.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfSTMember_16t
    {
        /// <summary>
        /// LF_STMEMBER_16t
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
        /// length prefixed name of field
        /// </summary>
        public fixed byte Name[1];
    }
}
