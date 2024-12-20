using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for dimensioned array with variable bounds
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, rank = {rank}, typ = {typ.ToString(),nq}, dim = {dim}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfDimVar_16t
    {
        /// <summary>
        /// LF_DIMVARU_16t or LF_DIMVARLU_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of dimensions
        /// </summary>
        public short rank;

        /// <summary>
        /// type of index
        /// </summary>
        public CV_typ16_t typ;

        /// <summary>
        /// array of type indices for either variable upper bound or variable lower/upper bound.  The referenced types must be LF_REFSYM or T_VOID
        /// </summary>
        public fixed short dim[1]; //CV_typ16_t
    }
}
