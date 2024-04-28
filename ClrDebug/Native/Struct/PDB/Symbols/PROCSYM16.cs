using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, pParent = {pParent}, pEnd = {pEnd}, pNext = {pNext}, len = {len}, DbgStart = {DbgStart}, DbgEnd = {DbgEnd}, off = {off.ToString(),nq}, seg = {seg}, typind = {typind.ToString(),nq}, flags = {flags.ToString(),nq}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct PROCSYM16
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_GPROC16 or S_LPROC16
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// pointer to the parent
        /// </summary>
        public int pParent;

        /// <summary>
        /// pointer to this blocks end
        /// </summary>
        public int pEnd;

        /// <summary>
        /// pointer to next symbol
        /// </summary>
        public int pNext;

        /// <summary>
        /// Proc length
        /// </summary>
        public short len;

        /// <summary>
        /// Debug start offset
        /// </summary>
        public short DbgStart;

        /// <summary>
        /// Debug end offset
        /// </summary>
        public short DbgEnd;

        /// <summary>
        /// offset of symbol
        /// </summary>
        public CV_uoff16_t off;

        /// <summary>
        /// segment of symbol
        /// </summary>
        public short seg;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ16_t typind;

        /// <summary>
        /// Proc flags
        /// </summary>
        public CV_PROCFLAGS flags;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
