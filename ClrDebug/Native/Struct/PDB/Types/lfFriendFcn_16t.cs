using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for friend function
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}, Name = {Name}")]
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
    }
}
