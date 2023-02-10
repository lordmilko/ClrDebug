using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Describes a range (that is, block) of memory that is undergoing garbage collection.
    /// </summary>
    /// <remarks>
    /// The rangeLength value is guaranteed to be accurate only if <see cref="ICorProfilerInfo2.GetGenerationBounds"/>
    /// or <see cref="ICorProfilerInfo2.GetObjectGeneration"/>, both of which use the COR_PRF_GC_GENERATION_RANGE structure,
    /// is called from the <see cref="ICorProfilerCallback2.GarbageCollectionStarted"/> or the <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/>
    /// method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_GC_GENERATION_RANGE
    {
        /// <summary>
        /// A value of the <see cref="COR_PRF_GC_GENERATION"/> enumeration that specifies the generation to which the block of memory belongs.
        /// </summary>
        public COR_PRF_GC_GENERATION generation;

        /// <summary>
        /// The ID of an object that specifies the starting location of the block of memory.
        /// </summary>
        public ObjectID rangeStart;

        /// <summary>
        /// A pointer to an integer that specifies the size of the used portion of the memory block (that is, the amount of memory used within the block).
        /// </summary>
        public IntPtr rangeLength;

        /// <summary>
        /// A pointer to an integer that specifies the size of the memory block (that is, the amount of memory reserved for the block).
        /// </summary>
        public IntPtr rangeLengthReserved;
    }
}
