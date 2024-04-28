using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16:16 pointer to data for a class with virtual functions
    /// </summary>
    [DebuggerDisplay("mdisp = {mdisp.ToString(),nq}")]
    public struct CV_PMDR16_VFCN
    {
        /// <summary>
        /// displacement to data ( NULL = 0)
        /// </summary>
        public CV_off16_t mdisp;
    }
}
