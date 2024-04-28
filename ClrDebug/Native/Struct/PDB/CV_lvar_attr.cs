using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// extended attributes common to all local variables
    /// </summary>
    [DebuggerDisplay("off = {off.ToString(),nq}, seg = {seg}, flags = {flags.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_lvar_attr
    {
        /// <summary>
        /// first code address where var is live
        /// </summary>
        public CV_uoff32_t off;

        public short seg;

        /// <summary>
        /// local var flags
        /// </summary>
        public CV_LVARFLAGS flags;
    }
}
