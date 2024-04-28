using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for nested (scoped) type definition, with attributes new records for vC v5.0, no need to have 16-bit ti versions.
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfNestTypeEx
    {
        /// <summary>
        /// LF_NESTTYPEEX
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// member access
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// index of nested type definition
        /// </summary>
        public CV_typ_t index;

        /// <summary>
        /// length prefixed type name
        /// </summary>
        public fixed byte Name[1];
    }
}
