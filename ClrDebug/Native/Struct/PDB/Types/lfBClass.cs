using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for base class field
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, offset = {offset}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfBClass
    {
        /// <summary>
        /// LF_BCLASS, LF_BINTERFACE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// attribute
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// type index of base class
        /// </summary>
        public CV_typ_t index;

        /// <summary>
        /// variable length offset of base within class
        /// </summary>
        public fixed byte offset[1];
    }
}
