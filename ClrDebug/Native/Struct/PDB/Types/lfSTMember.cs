using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for static data members
    /// </summary>
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

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = Name)
                return CreateString(ptr);
        }
    }
}
