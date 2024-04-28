using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}, csz = {csz}, rgsz = {rgsz}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct ANNOTATIONSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_ANNOTATION
        /// </summary>
        public SYM_ENUM_e rectyp;

        public CV_uoff32_t off;
        public short seg;

        /// <summary>
        /// Count of zero terminated annotation strings
        /// </summary>
        public short csz;

        /// <summary>
        /// Sequence of zero terminated annotation strings
        /// </summary>
        public fixed byte rgsz[1];
    }
}
