using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Trampoline thunk symbol
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, trampType = {trampType}, cbThunk = {cbThunk}, offThunk = {offThunk.ToString(),nq}, offTarget = {offTarget.ToString(),nq}, sectThunk = {sectThunk}, sectTarget = {sectTarget}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TRAMPOLINESYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_TRAMPOLINE
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// trampoline sym subtype
        /// </summary>
        public TRAMP_e trampType;

        /// <summary>
        /// size of the thunk
        /// </summary>
        public short cbThunk;

        /// <summary>
        /// offset of the thunk
        /// </summary>
        public CV_uoff32_t offThunk;

        /// <summary>
        /// offset of the target of the thunk
        /// </summary>
        public CV_uoff32_t offTarget;

        /// <summary>
        /// section index of the thunk
        /// </summary>
        public short sectThunk;

        /// <summary>
        /// section index of the target of the thunk
        /// </summary>
        public short sectTarget;
    }
}
