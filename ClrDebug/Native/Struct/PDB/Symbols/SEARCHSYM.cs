using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, startsym = {startsym}, seg = {seg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct SEARCHSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_SSEARCH
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of the procedure
        /// </summary>
        public int startsym;

        /// <summary>
        /// segment of symbol
        /// </summary>
        public short seg;
    }
}
