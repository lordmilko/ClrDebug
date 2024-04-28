using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for overloaded method list
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, mList = {mList.ToString(),nq}, Name = {Name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfMethod_16t
    {
        /// <summary>
        /// LF_METHOD_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of occurrences of function
        /// </summary>
        public short count;

        /// <summary>
        /// index to LF_METHODLIST record
        /// </summary>
        public CV_typ16_t mList;

        /// <summary>
        /// length prefixed name of method
        /// </summary>
        public fixed byte Name[1];
    }
}
