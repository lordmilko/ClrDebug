using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct SYMTYPE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// Record type
        /// </summary>
        public SYM_ENUM_e rectyp;

        public fixed byte data[1];

        public static SYMTYPE* NextSym(SYMTYPE* pSym)
        {
            return (SYMTYPE*) ((byte*) pSym + pSym->reclen + sizeof(short));
        }

        public override string ToString()
        {
            return rectyp.ToString();
        }
    }
}
