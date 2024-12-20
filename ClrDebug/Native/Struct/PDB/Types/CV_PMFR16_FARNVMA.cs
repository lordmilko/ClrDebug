using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16:16 far pointer to member functions of a class with no virtual bases and multiple address points
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}, seg = {seg}, disp = {disp}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_PMFR16_FARNVMA
    {
        /// <summary>
        /// offset of function (NULL = 0:0,x)
        /// </summary>
        public CV_uoff16_t off;

        public short seg;
        public short disp;
    }
}
