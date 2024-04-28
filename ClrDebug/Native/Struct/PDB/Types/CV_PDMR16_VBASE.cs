using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16:16 pointer to data for a class with virtual bases
    /// </summary>
    [DebuggerDisplay("mdisp = {mdisp.ToString(),nq}, pdisp = {pdisp.ToString(),nq}, vdisp = {vdisp.ToString(),nq}")]
    public struct CV_PDMR16_VBASE
    {
        /// <summary>
        /// displacement to data
        /// </summary>
        public CV_off16_t mdisp;

        /// <summary>
        /// this pointer displacement to vbptr
        /// </summary>
        public CV_off16_t pdisp;

        /// <summary>
        /// displacement within vbase table
        /// </summary>
        public CV_off16_t vdisp;

        // NULL = (,,0xffff)
    }
}
