using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// A live range of en-registed variable
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, reg = {reg}, attr = {attr.ToString(),nq}, range = {range.ToString(),nq}, gaps = {gaps}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct DEFRANGESYMREGISTER
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_DEFRANGE_REGISTER
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Register to hold the value of the symbol
        /// </summary>
        public short reg;

        /// <summary>
        /// Attribute of the register range.
        /// </summary>
        public CV_RANGEATTR attr;

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
