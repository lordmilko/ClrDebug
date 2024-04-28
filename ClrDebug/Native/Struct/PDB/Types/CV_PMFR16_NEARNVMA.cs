using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// representation of a 16 bit pointer to member functions of a class with no virtual bases and multiple address points
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}, disp = {disp}")]
    public struct CV_PMFR16_NEARNVMA
    {
        /// <summary>
        /// offset of function (NULL = 0,x)
        /// </summary>
        public CV_uoff16_t off;

        public short disp;
    }
}
