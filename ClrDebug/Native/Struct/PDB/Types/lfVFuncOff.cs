using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for virtual function table pointer with offset
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, pad0 = {pad0}, type = {type.ToString(),nq}, offset = {offset.ToString(),nq}")]
    public struct lfVFuncOff
    {
        /// <summary>
        /// LF_VFUNCOFF
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// internal padding, must be 0.
        /// </summary>
        public short pad0;

        /// <summary>
        /// type index of pointer
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// offset of virtual function table pointer
        /// </summary>
        public CV_off32_t offset;
    }
}
