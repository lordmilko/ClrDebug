using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for dimensioned array with constant bounds
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, typ = {typ.ToString(),nq}, rank = {rank}, dim = {dim}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfDimCon
    {
        /// <summary>
        /// LF_DIMCONU or LF_DIMCONLU
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type of index
        /// </summary>
        public CV_typ_t typ;

        /// <summary>
        /// number of dimensions
        /// </summary>
        public short rank;

        /// <summary>
        /// array of dimension information with either upper bounds or lower/upper bound
        /// </summary>
        public fixed byte dim[1];
    }
}
