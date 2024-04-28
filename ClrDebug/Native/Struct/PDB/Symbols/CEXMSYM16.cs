using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}, model = {model}, pcdtable = {pcdtable.ToString(),nq}, pcdspi = {pcdspi.ToString(),nq}, subtype = {subtype}, flag = {flag}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct CEXMSYM16
    {
        /// <summary>
        /// Record length
        /// </summary>
        [FieldOffset(0)]
        public short reclen;

        /// <summary>
        /// S_CEXMODEL16
        /// </summary>
        [FieldOffset(2)]
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of symbol
        /// </summary>
        [FieldOffset(4)]
        public CV_uoff16_t off;

        /// <summary>
        /// segment of symbol
        /// </summary>
        [FieldOffset(6)]
        public short seg;

        /// <summary>
        /// execution model
        /// </summary>
        [FieldOffset(8)]
        public short model;

        /// <summary>
        /// offset to pcode function table
        /// </summary>
        [FieldOffset(10)]
        public CV_uoff16_t pcdtable;

        /// <summary>
        /// offset to segment pcode information
        /// </summary>
        [FieldOffset(12)]
        public CV_uoff16_t pcdspi;

        /// <summary>
        /// see CV_COBOL_e above
        /// </summary>
        [FieldOffset(10)]
        public short subtype;
        [FieldOffset(12)]
        public short flag;
    }
}
