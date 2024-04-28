using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, id = {id.ToString(),nq}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
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
    }
}
