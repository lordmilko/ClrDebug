using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for assembler labels
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, mode = {mode}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfLabel
    {
        /// <summary>
        /// LF_LABEL
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// addressing mode of label
        /// </summary>
        public short mode;
    }
}
