using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 32 bit pointer to data for a class with or without virtual functions and no virtual bases
    /// </summary>
    [DebuggerDisplay("mdisp = {mdisp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_PDMR32_NVVFCN
    {
        /// <summary>
        /// displacement to data (NULL = 0x80000000)
        /// </summary>
        public CV_off32_t mdisp;
    }
}
