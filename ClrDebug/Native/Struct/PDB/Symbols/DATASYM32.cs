using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DATASYM32
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_LDATA32, S_GDATA32, S_LMANDATA, S_GMANDATA
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index, or Metadata token if a managed symbol
        /// </summary>
        public CV_typ_t typind;

        public CV_uoff32_t off;
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
