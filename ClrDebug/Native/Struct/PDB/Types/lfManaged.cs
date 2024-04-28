using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_MANAGED
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfManaged
    {
        /// <summary>
        /// LF_MANAGED
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// utf8, zero terminated managed type name
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
