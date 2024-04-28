using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, flags = {flags.ToString(),nq}, style = {style}")]
    public struct RETURNSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_RETURN
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// flags
        /// </summary>
        public CV_GENERIC_FLAG flags;

        /// <summary>
        /// CV_GENERIC_STYLE_e return style followed by return method data
        /// </summary>
        public byte style;
    }
}
