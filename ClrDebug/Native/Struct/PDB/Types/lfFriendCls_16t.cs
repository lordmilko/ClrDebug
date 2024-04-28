using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for friend class
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfFriendCls_16t
    {
        /// <summary>
        /// LF_FRIENDCLS_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// index to type record of friend class
        /// </summary>
        public CV_typ16_t index;
    }
}
