using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing end of precompiled types that can be included by another file
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, signature = {signature}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfEndPreComp
    {
        /// <summary>
        /// LF_ENDPRECOMP
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signature
        /// </summary>
        public int signature;
    }
}
