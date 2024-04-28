using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Type record for LF_PROCEDURE
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, rvtype = {rvtype.ToString(),nq}, calltype = {calltype}, funcattr = {funcattr.ToString(),nq}, parmcount = {parmcount}, arglist = {arglist.ToString(),nq}")]
    public struct lfProc_16t
    {
        /// <summary>
        /// LF_PROCEDURE_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of return value
        /// </summary>
        public CV_typ16_t rvtype;

        /// <summary>
        /// calling convention (CV_call_t)
        /// </summary>
        public byte calltype;

        /// <summary>
        /// attributes
        /// </summary>
        public CV_funcattr_t funcattr;

        /// <summary>
        /// number of parameters
        /// </summary>
        public short parmcount;

        /// <summary>
        /// type index of argument list
        /// </summary>
        public CV_typ16_t arglist;
    }
}
