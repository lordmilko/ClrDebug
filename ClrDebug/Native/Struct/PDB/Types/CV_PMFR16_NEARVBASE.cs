using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16 bit pointer to member function of a class with virtual bases
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}, mdisp = {mdisp.ToString(),nq}, pdisp = {pdisp.ToString(),nq}, vdisp = {vdisp.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_PMFR16_NEARVBASE
    {
        /// <summary>
        /// offset of function (NULL = 0,x,x,x)
        /// </summary>
        public CV_uoff16_t off;

        /// <summary>
        /// displacement to data
        /// </summary>
        public CV_off16_t mdisp;

        /// <summary>
        /// this pointer displacement
        /// </summary>
        public CV_off16_t pdisp;

        /// <summary>
        /// vbase table displacement
        /// </summary>
        public CV_off16_t vdisp;
    }
}
