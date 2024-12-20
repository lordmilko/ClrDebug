using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for build information
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, count = {count}, arg = {arg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfBuildInfo
    {
        /// <summary>
        /// LF_BUILDINFO
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// number of arguments
        /// </summary>
        public short count;

        /// <summary>
        /// arguments as CodeItemId
        /// </summary>
        public fixed int arg[(int) CV_BuildInfo_e.CV_BUILDINFO_KNOWN]; //CV_ItemId
    }
}
