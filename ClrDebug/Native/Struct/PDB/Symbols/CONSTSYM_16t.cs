using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct CONSTSYM_16t
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_CONSTANT_16t
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index (containing enum if enumerate)
        /// </summary>
        public CV_typ16_t typind;

        /// <summary>
        /// numeric leaf containing value
        /// </summary>
        public short value;

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
