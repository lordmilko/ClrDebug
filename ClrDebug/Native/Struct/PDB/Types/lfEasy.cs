using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}")]
    public struct lfEasy
    {
        /// <summary>
        /// LF_...
        /// </summary>
        public LEAF_ENUM_e leaf;

        public override string ToString()
        {
            return leaf.ToString();
        }
    }
}
