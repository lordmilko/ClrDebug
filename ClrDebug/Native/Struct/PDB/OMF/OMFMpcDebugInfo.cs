using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Pcode support.  This subsection contains debug information generated
    /// by the MPC utility used to process Pcode executables.  Currently
    /// it contains a mapping table from segment index (zero based) to
    /// frame paragraph.  MPC converts segmented exe's to non-segmented
    /// exe's for DOS support.  To avoid backpatching all CV info, this
    /// table is provided for the mapping.  Additional info may be provided
    /// in the future for profiler support.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct OMFMpcDebugInfo
    {
        /// <summary>
        /// number of segments in module
        /// </summary>
        public ushort cSeg;

        /// <summary>
        /// map seg (zero based) to frame
        /// </summary>
        public fixed ushort mpSegFrame[1];
    }
}
