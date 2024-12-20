using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, sect = {sect}, cbInstr = {cbInstr}, typind = {typind.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct HEAPALLOCSITE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_HEAPALLOCSITE
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of call site
        /// </summary>
        public CV_off32_t off;

        /// <summary>
        /// section index of call site
        /// </summary>
        public short sect;

        /// <summary>
        /// length of heap allocation call instruction
        /// </summary>
        public short cbInstr;

        /// <summary>
        /// type index describing function signature
        /// </summary>
        public CV_typ_t typind;
    }
}
