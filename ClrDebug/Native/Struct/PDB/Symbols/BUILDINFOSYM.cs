using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, id = {id.ToString(),nq}")]
    public struct BUILDINFOSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_BUILDINFO
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// CV_ItemId of Build Info.
        /// </summary>
        public CV_ItemId id;
    }
}
