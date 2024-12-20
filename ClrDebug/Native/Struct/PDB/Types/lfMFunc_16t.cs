using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Type record for member function
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, rvtype = {rvtype.ToString(),nq}, classtype = {classtype.ToString(),nq}, thistype = {thistype.ToString(),nq}, calltype = {calltype}, funcattr = {funcattr.ToString(),nq}, parmcount = {parmcount}, arglist = {arglist.ToString(),nq}, thisadjust = {thisadjust}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfMFunc_16t
    {
        /// <summary>
        /// LF_MFUNCTION_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of return value
        /// </summary>
        public CV_typ16_t rvtype;

        /// <summary>
        /// type index of containing class
        /// </summary>
        public CV_typ16_t classtype;

        /// <summary>
        /// type index of this pointer (model specific)
        /// </summary>
        public CV_typ16_t thistype;

        /// <summary>
        /// calling convention (call_t)
        /// </summary>
        public byte calltype; //todo: enum?

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

        /// <summary>
        /// this adjuster (long because pad required anyway)
        /// </summary>
        public int thisadjust;
    }
}
