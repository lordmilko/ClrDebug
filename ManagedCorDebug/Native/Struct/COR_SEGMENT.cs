using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains information about a region of memory in the managed heap.
    /// </summary>
    /// <remarks>
    /// The COR_SEGMENTS structure represents a region of memory in the managed heap. COR_SEGMENTS objects are members
    /// of the <see cref="ICorDebugHeapSegmentEnum"/> collection object, which is populated by calling the <see cref="ICorDebugProcess5.EnumerateHeapRegions"/>
    /// method. The heap field is the processor number, which corresponds to the heap being reported. For workstation garbage
    /// collectors, its value is always zero, because workstations have only one garbage collection heap. For server garbage
    /// collectors, its value corresponds to the processor the heap is attached to. Note that there may be more or fewer
    /// garbage collection heaps than there are actual processors due to the implementation details of the garbage collector.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_SEGMENT
    {
        /// <summary>
        /// The starting address of the memory region.
        /// </summary>
        public CORDB_ADDRESS start;

        /// <summary>
        /// The ending address of the memory region.
        /// </summary>
        public CORDB_ADDRESS end;
        public CorDebugGenerationTypes type;

        /// <summary>
        /// The heap number in which the memory region resides. See the Remarks section for more information.
        /// </summary>
        public int heap;
    }
}