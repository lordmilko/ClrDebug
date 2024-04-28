using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}, model = {model}, pcdtable = {pcdtable.ToString(),nq}, pcdspi = {pcdspi.ToString(),nq}, subtype = {subtype.ToString(),nq}, flag = {flag}, calltableOff = {calltableOff.ToString(),nq}, calltableSeg = {calltableSeg}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct CEXMSYM32
    {
        /// <summary>
        /// Record length
        /// </summary>
        [FieldOffset(0)]
        public short reclen;

        /// <summary>
        /// S_CEXMODEL32
        /// </summary>
        [FieldOffset(2)]
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of symbol
        /// </summary>
        [FieldOffset(4)]
        public CV_uoff32_t off;

        /// <summary>
        /// segment of symbol
        /// </summary>
        [FieldOffset(8)]
        public short seg;

        /// <summary>
        /// execution model
        /// </summary>
        [FieldOffset(10)]
        public short model;

        //Union

        //Struct 1

        /// <summary>
        /// offset to pcode function table
        /// </summary>
        [FieldOffset(12)]
        public CV_uoff32_t pcdtable;

        /// <summary>
        /// offset to segment pcode information
        /// </summary>
        [FieldOffset(16)]
        public CV_uoff32_t pcdspi;

        //Struct 2

        /// <summary>
        /// see CV_COBOL_e above
        /// </summary>
        [FieldOffset(12)]
        public CV_COBOL_e subtype;

        [FieldOffset(14)]
        public short flag;

        //Struct 3

        /// <summary>
        /// offset to function table
        /// </summary>
        [FieldOffset(12)]
        public CV_uoff32_t calltableOff;

        /// <summary>
        /// segment of function table
        /// </summary>
        [FieldOffset(16)]
        public short calltableSeg;
    }
}
