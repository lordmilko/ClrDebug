using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, root = {root.ToString(),nq}, path = {path.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}")]
    public struct VPATHSYM32
    {
        /// <summary>
        /// record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_VFTABLE32
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// type index of the root of path
        /// </summary>
        public CV_typ_t root;

        /// <summary>
        /// type index of the path record
        /// </summary>
        public CV_typ_t path;

        /// <summary>
        /// offset of virtual function table
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// segment of virtual function table
        /// </summary>
        public short seg;
    }
}
