using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct FILESTATICSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_FILESTATIC
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// index of mod filename in stringtable
        /// </summary>
        public CV_uoff32_t modOffset;

        /// <summary>
        /// local var flags
        /// </summary>
        public CV_LVARFLAGS flags;

        /// <summary>
        /// Name of this symbol, a null terminated array of UTF8 characters
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
