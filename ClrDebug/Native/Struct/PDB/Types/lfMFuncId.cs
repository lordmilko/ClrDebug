using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, parentType = {parentType.ToString(),nq}, type = {type.ToString(),nq}, name = {name}")]
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
    }
}
