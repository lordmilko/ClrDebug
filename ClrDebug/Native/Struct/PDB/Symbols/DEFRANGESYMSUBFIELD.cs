using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// A live range of sub field of variable. like locala.i
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, program = {program.ToString(),nq}, offParent = {offParent.ToString(),nq}, range = {range.ToString(),nq}, gaps = {gaps}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DEFRANGESYMSUBFIELD
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_DEFRANGE_SUBFIELD
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// DIA program to evaluate the value of the symbol
        /// </summary>
        public CV_uoff32_t program;

        /// <summary>
        /// Offset in parent variable.
        /// </summary>
        public CV_uoff32_t offParent;

        /// <summary>
        /// Range of addresses where this program is valid
        /// </summary>
        public CV_LVAR_ADDR_RANGE range;

        /// <summary>
        /// The value is not available in following gaps.
        /// </summary>
        public fixed byte gaps[1]; //CV_LVAR_ADDR_GAP[]
    }
}
