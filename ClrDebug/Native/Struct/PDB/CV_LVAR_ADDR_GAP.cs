using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Represents the holes in overall address range, all address is pre-bbt.
    /// It is for compress and reduce the amount of relocations need.
    /// </summary>
    [DebuggerDisplay("gapStartOffset = {gapStartOffset}, cbRange = {cbRange}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_LVAR_ADDR_GAP
    {
        /// <summary>
        /// relative offset from the beginning of the live range.
        /// </summary>
        public short gapStartOffset;

        /// <summary>
        /// length of this gap.
        /// </summary>
        public short cbRange;
    }
}
