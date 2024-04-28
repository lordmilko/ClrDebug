using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for nested (scoped) type definition
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfNestType_16t
    {
        /// <summary>
        /// LF_NESTTYPE_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// index of nested type definition
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// length prefixed type name
        /// </summary>
        public fixed byte Name[1];
    }
}
