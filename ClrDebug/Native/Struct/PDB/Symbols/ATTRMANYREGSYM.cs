using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct ATTRMANYREGSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_MANMANYREG
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index or metadata token
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// local var attributes
        /// </summary>
        public CV_lvar_attr attr;

        /// <summary>
        /// count of number of registers
        /// </summary>
        public byte count;

        /// <summary>
        /// count register enumerates followed by length-prefixed name.  Registers are most significant first.
        /// </summary>
        public fixed byte reg[1];

        /// <summary>
        /// utf-8 encoded zero terminate name
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
