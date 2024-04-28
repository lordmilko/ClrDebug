using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, typind = {typind.ToString(),nq}, count = {count}, reg = {reg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct MANYREGSYM2
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_MANYREG2
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index or metadata token
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// count of number of registers
        /// </summary>
        public short count;

        /// <summary>
        /// count register enumerates followed by length-prefixed name.  Registers are most significant first.
        /// </summary>
        public fixed short reg[1];
    }
}
