using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfMFuncId
    {
        /// <summary>
        /// LF_MFUNC_ID
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of parent
        /// </summary>
        public CV_typ_t parentType;

        /// <summary>
        /// function type
        /// </summary>
        public CV_typ_t type;

        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
