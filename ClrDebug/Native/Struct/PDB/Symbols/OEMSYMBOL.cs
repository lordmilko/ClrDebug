using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, idOem = {idOem}, typind = {typind.ToString(),nq}, rgl = {rgl}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct OEMSYMBOL
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_OEM
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// an oem ID (GUID)
        /// </summary>
        public fixed byte idOem[16];

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// user data, force 4-byte alignment
        /// </summary>
        public fixed int rgl[1];
    }
}
