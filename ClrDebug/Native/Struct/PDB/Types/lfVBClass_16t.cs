using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// subfield record for direct and indirect virtual base class field
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, index = {index.ToString(),nq}, vbptr = {vbptr.ToString(),nq}, attr = {attr.ToString(),nq}, vbpoff = {vbpoff}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfVBClass_16t
    {
        /// <summary>
        /// LF_VBCLASS_16t | LF_IVBCLASS_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// type index of direct virtual base class
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// type index of virtual base pointer
        /// </summary>
        public CV_typ16_t vbptr;

        /// <summary>
        /// attribute
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// virtual base pointer offset from address point followed by virtual base offset from vbtable
        /// </summary>
        public fixed byte vbpoff[1];
    }
}
