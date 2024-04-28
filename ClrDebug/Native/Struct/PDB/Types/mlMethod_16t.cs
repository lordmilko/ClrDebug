using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for non-static methods and friends in overloaded method list
    /// </summary>
    [DebuggerDisplay("attr = {attr.ToString(),nq}, index = {index.ToString(),nq}, vbaseoff = {vbaseoff}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct mlMethod_16t
    {
        /// <summary>
        /// method attribute
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// index to type record for procedure
        /// </summary>
        public CV_typ16_t index;

        /// <summary>
        /// offset in vfunctable if intro virtual
        /// </summary>
        public fixed int vbaseoff[1];
    }
}
