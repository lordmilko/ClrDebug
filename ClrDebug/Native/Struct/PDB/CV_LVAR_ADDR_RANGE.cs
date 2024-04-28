using System.Diagnostics;

namespace ClrDebug.PDB
{
    /// <summary>
    /// represents an address range, used for optimized code debug info.
    /// defines a range of addresses
    /// </summary>
    [DebuggerDisplay("offStart = {offStart.ToString(),nq}, isectStart = {isectStart}, cbRange = {cbRange}")]
    public struct CV_LVAR_ADDR_RANGE
    {
        public CV_uoff32_t offStart;
        public short isectStart;
        public short cbRange;
    }
}
