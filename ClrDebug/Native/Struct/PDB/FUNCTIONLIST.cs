using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, count = {count}, funcs = {funcs}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct FUNCTIONLIST
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_CALLERS or S_CALLEES
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Number of functions
        /// </summary>
        public int count;

        /// <summary>
        /// List of functions, dim == count
        /// </summary>
        public fixed int funcs[1]; //CV_typ_t

        // int   invocations[CV_ZEROLEN]; Followed by a parallel array of
        // invocation counts. Counts > reclen are assumed to be zero
    }
}
