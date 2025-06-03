using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Type record for LF_PROCEDURE
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, rvtype = {rvtype.ToString(),nq}, calltype = {calltype}, funcattr = {funcattr.ToString(),nq}, parmcount = {parmcount}, arglist = {arglist.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfProc
    {
        /// <summary>
        /// LF_PROCEDURE
        /// </summary>
        public LEAF_ENUM_e leaf;

        //CV_typ_t. if its value is less than HDR.tiMin, its a primitive type

        /// <summary>
        /// type index of return value
        /// </summary>
        public CV_typ_t rvtype;

        /// <summary>
        /// calling convention (<see cref="CV_call_e"/>)
        /// </summary>
        public byte calltype; //microsoft-pdb erroneously says its CV_call_t, but its CV_call_e

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
        public CV_typ_t arglist;
    }
}
