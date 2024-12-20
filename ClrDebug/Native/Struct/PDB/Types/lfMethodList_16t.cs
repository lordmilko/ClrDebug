using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for non-static methods and friends in overloaded method list
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, mList = {mList}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfMethodList_16t
    {
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// really a mlMethod_16t type
        /// </summary>
        public fixed byte mList[1];
    }
}
