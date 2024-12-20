using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for basic array
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, utype = {utype.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct lfBArray_16t
    {
        /// <summary>
        /// LF_BARRAY_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of underlying type
        /// </summary>
        public CV_typ16_t utype;
    }
}
