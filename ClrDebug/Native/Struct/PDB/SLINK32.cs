using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, framesize = {framesize}, off = {off.ToString(),nq}, reg = {reg}")]
    public struct SLINK32
    {
        /// <summary>
        /// record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_SLINK32
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// frame size of parent procedure
        /// </summary>
        public int framesize;

        /// <summary>
        /// signed offset where the static link was saved relative to the value of reg
        /// </summary>
        public CV_off32_t off;

        public short reg;
    }
}
