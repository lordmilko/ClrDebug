using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, root = {root.ToString(),nq}, path = {path.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
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
