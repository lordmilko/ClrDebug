using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for dimensioned arrays
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfDimArray
    {
        /// <summary>
        /// LF_DIMARRAY
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// underlying type of the array
        /// </summary>
        public CV_typ_t utype;

        /// <summary>
        /// dimension information
        /// </summary>
        public CV_typ_t diminfo;

        /// <summary>
        /// length prefixed name
        /// </summary>
        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
