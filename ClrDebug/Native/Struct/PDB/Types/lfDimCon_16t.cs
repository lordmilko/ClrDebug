using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for dimensioned array with constant bounds
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, rank = {rank}, typ = {typ.ToString(),nq}, dim = {dim}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfDimCon_16t
    {
        /// <summary>
        /// LF_DIMCONU_16t or LF_DIMCONLU_16t
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
        /// array of dimension information with either upper bounds or lower/upper bound
        /// </summary>
        public fixed byte dim[1];
    }
}
