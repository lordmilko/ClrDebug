using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for virtual function table shape
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, desc = {desc}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfVTShape
    {
        /// <summary>
        /// LF_VTSHAPE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of entries in vfunctable
        /// </summary>
        public short count;

        /// <summary>
        /// 4 bit (CV_VTS_desc) descriptors
        /// </summary>
        public fixed byte desc[1];
    }
}
