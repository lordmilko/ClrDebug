using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// leaf for default arguments
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, expr = {expr}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfDefArg
    {
        /// <summary>
        /// LF_DEFARG
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type of resulting expression
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// length prefixed expression string
        /// </summary>
        public fixed byte expr[1];
    }
}
