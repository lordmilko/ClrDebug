using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Offset mapping table<para/>
    /// This table provides a mapping from logical to physical offsets.
    /// This mapping is applied between the logical to physical mapping
    /// described by the seg map table.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFOffsetMap32
    {
        /// <summary>
        /// Count of physical sections
        /// </summary>
        public uint csection;

        // The next six items are repeated for each section

        /// <summary>
        /// Count of logical offset ranges
        /// </summary>
        public uint crangeLog;

        /// <summary>
        /// Array of logical offsets
        /// </summary>
        public fixed uint rgoffLog[1];

        /// <summary>
        /// Array of logical->physical bias
        /// </summary>
        public fixed int rgbiasLog[1];

        /// <summary>
        /// Count of physical offset ranges
        /// </summary>
        public uint crangePhys;

        /// <summary>
        /// Array of physical offsets
        /// </summary>
        public fixed uint rgoffPhys[1];

        /// <summary>
        /// Array of physical->logical bias
        /// </summary>
        public fixed int rgbiasPhys[1];
    }
}
