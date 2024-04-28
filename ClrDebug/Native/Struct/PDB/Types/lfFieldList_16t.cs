using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// field list leaf<para/>
    /// This is the header leaf for a complex list of class and structure subfields.
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfFieldList_16t
    {
        /// <summary>
        /// LF_FIELDLIST_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// field list sub lists
        /// </summary>
        public fixed byte data[1];
    }
}
