using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}, root = {root.ToString(),nq}, path = {path.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VPATHSYM32_16t
    {
        /// <summary>
        /// record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_VFTABLE32_16t
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// offset of virtual function table
        /// </summary>
        public CV_uoff32_t off;

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
