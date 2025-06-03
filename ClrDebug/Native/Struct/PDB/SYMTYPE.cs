using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SYMTYPE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen; //reclen is the length of the record (excluding this field). The total size of the SYMTYPE is sizeof(ushort) + reclen. You can have very big records with the signed bit set, so this should be ushort

        /// <summary>
        /// Record type
        /// </summary>
        public SYM_ENUM_e rectyp;

        public fixed byte data[1];

        //Note: like the NextSym macro in microsoft-pdb, this does not handle the special logic required for S_DATAREF_ST, S_PROCREF_ST and S_LPROCREF_ST where there's
        //a hidden string after them not accounted for in their size. See DBI1::fReadSymRec for details
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
