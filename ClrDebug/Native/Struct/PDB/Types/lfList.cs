using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// list leaf<para/>
    /// This list should no longer be used because the utilities cannot
    /// verify the contents of the list without knowing what type of list
    /// it is.  New specific leaf indices should be used instead.
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfList
    {
        /// <summary>
        /// LF_LIST
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// data format specified by indexing type
        /// </summary>
        public fixed byte data[1];
    }
}
