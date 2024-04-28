using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, cb = {cb}, characteristics = {characteristics}, off = {off.ToString(),nq}, seg = {seg}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct COFFGROUPSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_COFFGROUP
        /// </summary>
        public SYM_ENUM_e rectyp;

        public int cb;
        public int characteristics;

        /// <summary>
        /// Symbol offset
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// Symbol segment
        /// </summary>
        public short seg;

        /// <summary>
        /// name
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
