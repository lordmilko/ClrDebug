using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for nested (scoped) type definition
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, pad0 = {pad0}, index = {index.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfNestType
    {
        /// <summary>
        /// LF_NESTTYPE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// internal padding, must be 0
        /// </summary>
        public short pad0;

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
