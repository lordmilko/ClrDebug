using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 32 bit pointer to member function for a class with no virtual bases and multiple address points
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}, disp = {disp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_PMFR32_NVMA
    {
        /// <summary>
        /// near address of function (NULL = 0L,x)
        /// </summary>
        public CV_uoff32_t off;

        public CV_off32_t disp;
    }
}
