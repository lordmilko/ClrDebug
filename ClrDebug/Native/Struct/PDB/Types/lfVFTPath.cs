using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing path to virtual function table
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, @base = {@base}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfVFTPath
    {
        /// <summary>
        /// LF_VFTPATH
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// count of number of bases in path
        /// </summary>
        public int count;

        /// <summary>
        /// bases from root to leaf
        /// </summary>
        public fixed int @base[1]; //CV_typ_t
    }
}
