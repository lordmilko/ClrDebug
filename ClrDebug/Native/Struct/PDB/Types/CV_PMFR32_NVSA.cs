using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 32 bit pointer to member function for a class with no virtual bases and a single address point
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}")]
    public struct CV_PMFR32_NVSA
    {
        /// <summary>
        /// near address of function (NULL = 0L)
        /// </summary>
        public CV_uoff32_t off;
    }
}
