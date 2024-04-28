using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct REFSYM2
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_PROCREF, S_DATAREF, or S_LPROCREF
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// SUC of the name
        /// </summary>
        public int sumName;

        /// <summary>
        /// Offset of actual symbol in $$Symbols
        /// </summary>
        public int ibSym;

        /// <summary>
        /// Module containing the actual symbol
        /// </summary>
        public short imod;

        /// <summary>
        /// hidden name made a first class member
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
