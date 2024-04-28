using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16:16 pointer to near member function for a class with no virtual functions or bases and a single address point
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_PMFR16_NEARNVSA
    {
        /// <summary>
        /// near address of function (NULL = 0)
        /// </summary>
        public CV_uoff16_t off;
    }
}
