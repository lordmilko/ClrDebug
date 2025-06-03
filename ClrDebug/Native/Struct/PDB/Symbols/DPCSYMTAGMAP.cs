using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// A map for DPC pointer tag values to symbol records.
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, mapEntries = {mapEntries}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DPCSYMTAGMAP
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_DPC_SYM_TAG_MAP
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Array of mappings from DPC pointer tag values to symbol record offsets
        /// </summary>
        public fixed byte mapEntries[1]; //CV_DPC_SYM_TAG_MAP_ENTRY
    }
}
