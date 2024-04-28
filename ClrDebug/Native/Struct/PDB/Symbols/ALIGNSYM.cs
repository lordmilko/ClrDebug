using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct ALIGNSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_ALIGN
        /// </summary>
        public SYM_ENUM_e rectyp;
    }
}
