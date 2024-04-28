using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing inclusion of precompiled types
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, start = {start}, count = {count}, signature = {signature}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfPreComp
    {
        /// <summary>
        /// LF_PRECOMP
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// starting type index included
        /// </summary>
        public int start;

        /// <summary>
        /// number of types in inclusion
        /// </summary>
        public int count;

        /// <summary>
        /// signature
        /// </summary>
        public int signature;

        /// <summary>
        /// length prefixed name of included type file
        /// </summary>
        public fixed byte name[1];
    }
}
