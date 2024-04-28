using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, invocations = {invocations}, dynCount = {dynCount}, numInstrs = {numInstrs}, staInstLive = {staInstLive}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct POGOINFO
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_POGODATA
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Number of times function was called
        /// </summary>
        public int invocations;

        /// <summary>
        /// Dynamic instruction count
        /// </summary>
        public long dynCount;

        /// <summary>
        /// Static instruction count
        /// </summary>
        public int numInstrs;

        /// <summary>
        /// Final static instruction count (post inlining)
        /// </summary>
        public int staInstLive;
    }
}
