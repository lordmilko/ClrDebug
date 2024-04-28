using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, pParent = {pParent}, pEnd = {pEnd}, len = {len}, off = {off.ToString(),nq}, seg = {seg}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct BLOCKSYM16
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_BLOCK16
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
        /// Block length
        /// </summary>
        public short len;

        /// <summary>
        /// offset of symbol
        /// </summary>
        public CV_uoff16_t off;

        /// <summary>
        /// segment of symbol
        /// </summary>
        public short seg;

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
