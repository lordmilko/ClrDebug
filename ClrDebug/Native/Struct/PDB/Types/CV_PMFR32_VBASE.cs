using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 32 bit pointer to member function for a class with virtual bases
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}, mdisp = {mdisp.ToString(),nq}, pdisp = {pdisp.ToString(),nq}, vdisp = {vdisp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_PMFR32_VBASE
    {
        /// <summary>
        /// near address of function (NULL = 0L,x,x,x)
        /// </summary>
        public CV_uoff32_t off;

        /// <summary>
        /// displacement to data
        /// </summary>
        public CV_off32_t mdisp;

        /// <summary>
        /// this pointer displacement
        /// </summary>
        public CV_off32_t pdisp;

        /// <summary>
        /// vbase table displacement
        /// </summary>
        public CV_off32_t vdisp;
    }
}
