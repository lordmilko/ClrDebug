using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for non-static methods and friends in overloaded method list
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, mList = {mList}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfMethodList
    {
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// really a mlMethod type
        /// </summary>
        public fixed byte mList[1];
    }
}
