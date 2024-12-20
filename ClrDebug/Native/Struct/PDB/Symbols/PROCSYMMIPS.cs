using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PROCSYMMIPS
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_GPROCMIPS or S_LPROCMIPS
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
        /// pointer to next symbol
        /// </summary>
        public int pNext;

        /// <summary>
        /// Proc length
        /// </summary>
        public int len;

        /// <summary>
        /// Debug start offset
        /// </summary>
        public int DbgStart;

        /// <summary>
        /// Debug end offset
        /// </summary>
        public int DbgEnd;

        /// <summary>
        /// int register save mask
        /// </summary>
        public int regSave; //todo: enum?

        /// <summary>
        /// fp register save mask
        /// </summary>
        public int fpSave; //todo: enum?

        /// <summary>
        /// int register save offset
        /// </summary>
        public CV_uoff32_t intOff;

        /// <summary>
        /// fp register save offset
        /// </summary>
        public CV_uoff32_t fpOff;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// Symbol offset
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// Symbol segment
        /// </summary>
        public short seg;

        /// <summary>
        /// Register return value is in
        /// </summary>
        public byte retReg; //todo: enum?

        /// <summary>
        /// Frame pointer register
        /// </summary>
        public byte frameReg; //todo: enum?

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
