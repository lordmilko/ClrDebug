using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16:16 pointer to far member function for a class with no virtual bases and a single address point
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}, seg = {seg}")]
    public struct CV_PMFR16_FARNVSA
    {
        /// <summary>
        /// offset of function (NULL = 0:0)
        /// </summary>
        public CV_uoff16_t off;

        /// <summary>
        /// segment of function
        /// </summary>
        public short seg;
    }
}
