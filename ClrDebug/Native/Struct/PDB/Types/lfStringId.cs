using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfStringId
    {
        /// <summary>
        /// LF_STRING_ID
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// ID to list of sub string IDs
        /// </summary>
        public CV_ItemId id;

        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
