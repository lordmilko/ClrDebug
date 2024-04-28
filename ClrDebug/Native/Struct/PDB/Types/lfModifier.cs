using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Type record for LF_MODIFIER
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, attr = {attr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct lfModifier
    {
        /// <summary>
        /// LF_MODIFIER
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// modified type
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// modifier attribute modifier_t
        /// </summary>
        public CV_modifier_t attr;
    }
}
