using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for cobol1
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfCobol1
    {
        /// <summary>
        /// LF_COBOL1
        /// </summary>
        public LEAF_ENUM_e leaf;

        public fixed byte data[1];
    }
}
