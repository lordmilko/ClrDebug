using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for LF_ENUM
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfEnum
    {
        /// <summary>
        /// LF_ENUM
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// count of number of elements in class
        /// </summary>
        public short count;

        /// <summary>
        /// property attribute field
        /// </summary>
        public CV_prop_t property;

        /// <summary>
        /// underlying type of the enum
        /// </summary>
        public CV_typ_t utype;

        /// <summary>
        /// type index of LF_FIELD descriptor list
        /// </summary>
        public CV_typ_t field;

        /// <summary>
        /// length prefixed name of enum
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
