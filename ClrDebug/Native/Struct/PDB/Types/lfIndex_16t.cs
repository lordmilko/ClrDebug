using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// index leaf - contains type index of another leaf<para/>
    /// a major use of this leaf is to allow the compilers to emit a long complex list (LF_FIELD) in smaller pieces.
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}")]
    public struct lfIndex_16t
    {
        /// <summary>
        /// LF_INDEX_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of referenced leaf
        /// </summary>
        public CV_typ16_t index;
    }
}
