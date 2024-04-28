using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for friend function
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, pad0 = {pad0}, index = {index.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfFriendFcn
    {
        /// <summary>
        /// LF_FRIENDFCN
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// internal padding, must be 0
        /// </summary>
        public short pad0;

        /// <summary>
        /// index to type record of friend function
        /// </summary>
        public CV_typ_t index;

        /// <summary>
        /// name of friend function
        /// </summary>
        public fixed byte Name[1];
    }
}
