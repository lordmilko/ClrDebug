using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, thissym = {thissym}")]
    public struct ENTRYTHISSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_ENTRYTHIS
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// symbol describing this pointer on entry
        /// </summary>
        public byte thissym;
    }
}
