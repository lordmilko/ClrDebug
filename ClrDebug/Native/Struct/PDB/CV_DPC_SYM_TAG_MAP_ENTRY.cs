using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Represents a mapping from a DPC pointer tag value to the corresponding symbol record
    /// </summary>
    [DebuggerDisplay("tagValue = {tagValue}, symRecordOffset = {symRecordOffset.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CV_DPC_SYM_TAG_MAP_ENTRY
    {
        /// <summary>
        /// address taken symbol's pointer tag value.
        /// </summary>
        public int tagValue;

        /// <summary>
        /// offset of the symbol record from the S_LPROC32_DPC record it is nested within
        /// </summary>
        public CV_off32_t symRecordOffset;
    }
}
