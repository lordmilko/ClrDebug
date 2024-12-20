using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 32 bit pointer to data for a class with virtual bases
    /// </summary>
    [DebuggerDisplay("mdisp = {mdisp.ToString(),nq}, pdisp = {pdisp.ToString(),nq}, vdisp = {vdisp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_PDMR32_VBASE
    {
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

        // NULL = (,,0xffffffff)
    }
}
