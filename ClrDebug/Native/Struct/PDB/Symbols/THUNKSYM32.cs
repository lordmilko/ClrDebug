using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct THUNKSYM32
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_THUNK32
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

        public CV_uoff32_t off;
        public short seg;

        /// <summary>
        /// length of thunk
        /// </summary>
        public short len;

        /// <summary>
        /// THUNK_ORDINAL specifying type of thunk
        /// </summary>
        public byte ord;

        /// <summary>
        /// Length-prefixed name
        /// </summary>
        public fixed byte name[1];

        /// <summary>
        /// variant portion of thunk
        /// </summary>
        public fixed byte variant[1];
    }
}
