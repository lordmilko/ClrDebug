using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct THREADSYM32
    {
        /// <summary>
        /// record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_LTHREAD32 | S_GTHREAD32
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// offset into thread storage
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// segment of thread storage
        /// </summary>
        public short seg;

        /// <summary>
        /// length prefixed name
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
