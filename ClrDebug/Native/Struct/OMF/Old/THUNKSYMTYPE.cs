using System.Runtime.InteropServices;

namespace ClrDebug.OMF
{
    //Probably S_THUNK (not explicitly dumped in cvdump)
    public unsafe struct THUNKSYMTYPE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public byte reclen;

        /// <summary>
        /// Record type
        /// </summary>
        public byte rectyp;

        /// <summary>
        /// Offset of sym of enclosing proc
        /// </summary>
        public int parentsym;

        /// <summary>
        /// matching end
        /// </summary>
        public int endsym;

        /// <summary>
        /// Sym of closest following proc
        /// </summary>
        public int nextsym;

        /// <summary>
        /// Type of thunk
        /// </summary>
        public byte ord;

        /// <summary>
        /// Offset in code seg
        /// </summary>
        public int off;

        /// <summary>
        /// Seg of proc
        /// </summary>
        public ushort seg;

        /// <summary>
        /// Thunk length
        /// </summary>
        public short len;

        /// <summary>
        /// Thunk name
        /// </summary>
        public fixed byte name[1];

        public Variant variant;

        [StructLayout(LayoutKind.Explicit)]
        public struct Variant
        {
            [FieldOffset(0)]
            public Adjustor adjustor;

            /// <summary>
            /// Offset into the vtable
            /// </summary>
            [FieldOffset(0)]
            public short vtaboff;
        }

        public struct Adjustor
        {
            /// <summary>
            /// Size of adjustment
            /// </summary>
            public short delta;

            /// <summary>
            /// Name of target function
            /// </summary>
            public fixed byte name[1];
        }
    }
}
