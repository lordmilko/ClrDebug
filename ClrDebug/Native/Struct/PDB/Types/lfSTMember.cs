using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for static data members
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfSTMember
    {
        /// <summary>
        /// LF_STMEMBER
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
        /// length prefixed name of field
        /// </summary>
        public fixed byte Name[1];
    }
}
