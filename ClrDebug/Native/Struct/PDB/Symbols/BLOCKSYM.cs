using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, pParent = {pParent}, pEnd = {pEnd}")]
    public struct BLOCKSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_BLOCK16
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
    }
}
