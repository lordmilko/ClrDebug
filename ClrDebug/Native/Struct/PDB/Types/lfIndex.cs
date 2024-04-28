using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// index leaf - contains type index of another leaf<para/>
    /// a major use of this leaf is to allow the compilers to emit a long complex list (LF_FIELD) in smaller pieces.
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, pad0 = {pad0}, index = {index.ToString(),nq}")]
    public struct lfIndex
    {
        /// <summary>
        /// LF_INDEX
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// internal padding, must be 0
        /// </summary>
        public short pad0;

        /// <summary>
        /// type index of referenced leaf
        /// </summary>
        public CV_typ_t index;
    }
}
