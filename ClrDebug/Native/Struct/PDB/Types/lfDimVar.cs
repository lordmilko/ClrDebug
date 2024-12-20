using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for dimensioned array with variable bounds
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, rank = {rank}, typ = {typ.ToString(),nq}, dim = {dim}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfDimVar
    {
        /// <summary>
        /// LF_DIMVARU or LF_DIMVARLU
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of dimensions
        /// </summary>
        public int rank;

        /// <summary>
        /// type of index
        /// </summary>
        public CV_typ_t typ;

        /// <summary>
        /// array of type indices for either variable upper bound or variable lower/upper bound.  The count of type
        /// indices is rank or rank*2 depending on whether it is LFDIMVARU or LF_DIMVARLU. The referenced types must be
        /// LF_REFSYM or T_VOID
        /// </summary>
        public fixed int dim[1]; //CV_typ_t
    }
}
