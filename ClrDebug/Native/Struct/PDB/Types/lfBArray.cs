using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for basic array
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, utype = {utype.ToString(),nq}")]
    public struct lfBArray
    {
        /// <summary>
        /// LF_BARRAY
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of underlying type
        /// </summary>
        public CV_typ_t utype;
    }
}
