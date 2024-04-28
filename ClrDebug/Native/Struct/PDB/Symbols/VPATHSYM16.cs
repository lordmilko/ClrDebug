using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}, root = {root.ToString(),nq}, path = {path.ToString(),nq}")]
    public struct VPATHSYM16
    {
        /// <summary>
        /// record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_VFTPATH16
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of virtual function table
        /// </summary>
        public CV_uoff16_t off;

        /// <summary>
        /// segment of virtual function table
        /// </summary>
        public short seg;

        /// <summary>
        /// type index of the root of path
        /// </summary>
        public CV_typ16_t root;

        /// <summary>
        /// type index of the path record
        /// </summary>
        public CV_typ16_t path;
    }
}
