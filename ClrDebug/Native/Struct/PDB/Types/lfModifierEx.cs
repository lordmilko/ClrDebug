using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for a generalized built-in type modifier
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, count = {count}, mods = {mods}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfModifierEx
    {
        /// <summary>
        /// LF_MODIFIER_EX
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type being modified
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// count of modifier values
        /// </summary>
        public short count;

        /// <summary>
        /// modifiers from CV_modifier_e
        /// </summary>
        public fixed short mods[1];
    }
}
