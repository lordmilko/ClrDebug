using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for enumerate
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, value = {value}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfEnumerate
    {
        /// <summary>
        /// LF_ENUMERATE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// access
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// variable length value field followed by length prefixed name
        /// </summary>
        public fixed byte value[1];
    }
}
