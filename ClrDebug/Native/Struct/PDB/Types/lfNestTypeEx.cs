using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for nested (scoped) type definition, with attributes new records for vC v5.0, no need to have 16-bit ti versions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
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

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = Name)
                return CreateString(ptr);
        }
    }
}
