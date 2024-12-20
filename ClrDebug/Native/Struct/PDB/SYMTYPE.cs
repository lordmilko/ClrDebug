using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SYMTYPE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen; //reclen is the length of the record (excluding this field). You can have very big records with the signed bit set, so this should be ushort

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
