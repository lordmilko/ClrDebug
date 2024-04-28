using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for modifications to members
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfMemberModify
    {
        /// <summary>
        /// LF_MEMBERMODIFY
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// the new attributes
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// index of base class type definition
        /// </summary>
        public CV_typ_t index;

        /// <summary>
        /// length prefixed member name
        /// </summary>
        public fixed byte Name[1];
    }
}
