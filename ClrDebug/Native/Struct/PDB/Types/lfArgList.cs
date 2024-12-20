using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// argument list leaf
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, arg = {arg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfArgList
    {
        /// <summary>
        /// LF_ARGLIST, LF_SUBSTR_LIST
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of arguments
        /// </summary>
        public int count;

        /// <summary>
        /// number of arguments
        /// </summary>
        public fixed int arg[1]; //CV_typ_t
    }
}
