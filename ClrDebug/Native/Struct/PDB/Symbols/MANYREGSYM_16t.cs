using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, typind = {typind.ToString(),nq}, count = {count}, reg = {reg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct MANYREGSYM_16t
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_MANYREG_16t
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ16_t typind;

        /// <summary>
        /// count of number of registers
        /// </summary>
        public byte count;

        /// <summary>
        /// count register enumerates followed by length-prefixed name.  Registers are most significant first.
        /// </summary>
        public fixed byte reg[1];
    }
}
