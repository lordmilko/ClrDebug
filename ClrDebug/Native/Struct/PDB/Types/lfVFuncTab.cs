using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for virtual function table pointer
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, pad0 = {pad0}, type = {type.ToString(),nq}")]
    public struct lfVFuncTab
    {
        /// <summary>
        /// LF_VFUNCTAB
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// internal padding, must be 0
        /// </summary>
        public short pad0;

        /// <summary>
        /// type index of pointer
        /// </summary>
        public CV_typ_t type;
    }
}
