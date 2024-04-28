using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
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
