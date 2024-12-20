using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct WITHSYM32
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_WITH32
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
        /// Block length
        /// </summary>
        public int len;

        /// <summary>
        /// Offset in code segment
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// segment of label
        /// </summary>
        public short seg;

        /// <summary>
        /// Length-prefixed expression string
        /// </summary>
        public fixed byte expr[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = expr)
                return CreateString(ptr);
        }
    }
}
