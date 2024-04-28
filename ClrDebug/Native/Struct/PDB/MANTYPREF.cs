using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, typind = {typind.ToString(),nq}")]
    public struct MANTYPREF
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_MANTYPREF
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ_t typind;
    }
}
