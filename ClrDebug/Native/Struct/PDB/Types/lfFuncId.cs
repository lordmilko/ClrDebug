using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, scopeId = {scopeId.ToString(),nq}, type = {type.ToString(),nq}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfFuncId
    {
        /// <summary>
        /// LF_FUNC_ID
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// parent scope of the ID, 0 if global
        /// </summary>
        public CV_ItemId scopeId;

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
