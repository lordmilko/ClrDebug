using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct LABELSYM16
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_LABEL16
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of symbol
        /// </summary>
        public CV_uoff16_t off;

        /// <summary>
        /// segment of symbol
        /// </summary>
        public short seg;

        /// <summary>
        /// flags
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
