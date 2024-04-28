using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Type record for LF_MODIFIER
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, type = {type.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfModifier_16t
    {
        /// <summary>
        /// LF_MODIFIER_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// modifier attribute modifier_t
        /// </summary>
        public CV_modifier_t attr;

        /// <summary>
        /// modified type
        /// </summary>
        public CV_typ16_t type;
    }
}
