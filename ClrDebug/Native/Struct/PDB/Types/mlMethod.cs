using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for non-static methods and friends in overloaded method list
    /// </summary>
    [DebuggerDisplay("attr = {attr.ToString(),nq}, pad0 = {pad0}, index = {index.ToString(),nq}, vbaseoff = {vbaseoff}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct mlMethod
    {
        /// <summary>
        /// method attribute
        /// </summary>
        public CV_fldattr_t attr;

        /// <summary>
        /// internal padding, must be 0
        /// </summary>
        public short pad0;

        /// <summary>
        /// index to type record for procedure
        /// </summary>
        public CV_typ_t index;

        /// <summary>
        /// offset in vfunctable if intro virtual
        /// </summary>
        public fixed int vbaseoff[1];
    }
}
