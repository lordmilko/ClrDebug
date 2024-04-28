using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, pParent = {pParent}, pEnd = {pEnd}, length = {length}, scf = {scf.ToString(),nq}, off = {off.ToString(),nq}, offParent = {offParent.ToString(),nq}, sect = {sect}, sectParent = {sectParent}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct SEPCODESYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_SEPCODE
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// pointer to the parent
        /// </summary>
        public int pParent;

        /// <summary>
        /// pointer to this block's end
        /// </summary>
        public int pEnd;

        /// <summary>
        /// count of bytes of this block
        /// </summary>
        public int length;

        /// <summary>
        /// flags
        /// </summary>
        public CV_SEPCODEFLAGS scf;

        /// <summary>
        /// sect:off of the separated code
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// sectParent:offParent of the enclosing scope
        /// </summary>
        public CV_uoff32_t offParent;

        /// <summary>
        /// (proc, block, or sepcode)
        /// </summary>
        public short sect;
        public short sectParent;
    }
}
