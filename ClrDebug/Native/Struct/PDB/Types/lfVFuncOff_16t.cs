using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for virtual function table pointer with offset
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, offset = {offset.ToString(),nq}")]
    public struct lfVFuncOff_16t
    {
        /// <summary>
        /// LF_VFUNCOFF_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of pointer
        /// </summary>
        public CV_typ16_t type;

        /// <summary>
        /// offset of virtual function table pointer
        /// </summary>
        public CV_off32_t offset;
    }
}
