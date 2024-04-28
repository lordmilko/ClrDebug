using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for direct and indirect virtual base class field
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, vbptr = {vbptr.ToString(),nq}, vbpoff = {vbpoff}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfVBClass
    {
        /// <summary>
        /// LF_VBCLASS | LF_IVBCLASS
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// attribute
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// type index of direct virtual base class
        /// </summary>
        public CV_typ_t index;

        /// <summary>
        /// type index of virtual base pointer
        /// </summary>
        public CV_typ_t vbptr;

        /// <summary>
        /// virtual base pointer offset from address point followed by virtual base offset from vbtable
        /// </summary>
        public fixed byte vbpoff[1];
    }
}
