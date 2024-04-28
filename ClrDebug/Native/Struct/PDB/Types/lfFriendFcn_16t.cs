using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for friend function
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfFriendFcn_16t
    {
        /// <summary>
        /// LF_FRIENDFCN_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// index to type record of friend function
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// name of friend function
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
