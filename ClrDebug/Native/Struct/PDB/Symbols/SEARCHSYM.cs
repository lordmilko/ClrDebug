using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, startsym = {startsym}, seg = {seg}")]
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
