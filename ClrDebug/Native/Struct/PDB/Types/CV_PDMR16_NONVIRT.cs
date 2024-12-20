using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16:16 pointer to data for a class with no virtual functions or virtual bases
    /// </summary>
    [DebuggerDisplay("mdisp = {mdisp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_PDMR16_NONVIRT
    {
        /// <summary>
        /// displacement to data (NULL = -1)
        /// </summary>
        public CV_off16_t mdisp;
    }
}
