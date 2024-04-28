using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, pParent = {pParent}, pEnd = {pEnd}, pNext = {pNext}, off = {off.ToString(),nq}, seg = {seg}, len = {len}, ord = {ord}, name = {name}, variant = {variant}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct THUNKSYM16
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_THUNK
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
        /// offset of symbol
        /// </summary>
        public CV_uoff16_t off;

        /// <summary>
        /// segment of symbol
        /// </summary>
        public short seg;

        /// <summary>
        /// length of thunk
        /// </summary>
        public short len;

        /// <summary>
        /// THUNK_ORDINAL specifying type of thunk
        /// </summary>
        public byte ord;

        /// <summary>
        /// name of thunk
        /// </summary>
        public fixed byte name[1];

        /// <summary>
        /// variant portion of thunk
        /// </summary>
        public fixed byte variant[1];
    }
}
