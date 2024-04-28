using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct SECTIONSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_SECTION
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Section number
        /// </summary>
        public short isec;

        /// <summary>
        /// Alignment of this section (power of 2)
        /// </summary>
        public byte align;

        /// <summary>
        /// Reserved.  Must be zero.
        /// </summary>
        public byte bReserved;

        public int rva;
        public int cb;
        public int characteristics;

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
