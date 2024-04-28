using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct MANPROCSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_GMANPROC, S_LMANPROC, S_GMANPROCIA64 or S_LMANPROCIA64
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
        /// COM+ metadata token for method
        /// </summary>
        public mdToken token; //Modelled as CV_tkn_t by PDB1
        public CV_uoff32_t off;
        public short seg;

        /// <summary>
        /// Proc flags
        /// </summary>
        public CV_PROCFLAGS flags;

        /// <summary>
        /// Register return value is in (may not be used for all archs)
        /// </summary>
        public short retReg;

        /// <summary>
        /// optional name field
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
