using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for referenced symbol
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, Sym = {Sym}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfRefSym
    {
        /// <summary>
        /// LF_REFSYM
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// copy of referenced symbol record (including length)
        /// </summary>
        public fixed byte Sym[1];
    }
}
