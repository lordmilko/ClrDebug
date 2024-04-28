using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for modifications to members
    /// </summary>
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

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = Name)
                return CreateString(ptr);
        }
    }
}
