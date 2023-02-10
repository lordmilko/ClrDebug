namespace ClrDebug
{
    /// <summary>
    /// Identifies a garbage-collection generation.
    /// </summary>
    /// <remarks>
    /// The garbage collector improves memory management performance by dividing objects into generations based on age.
    /// The garbage collector currently uses three generations, numbered 0, 1, and 2, and two special heap segments, one
    /// for large objects and one for pinned objects. Objects whose size is larger than a threshold value are stored in
    /// the large-object heap. Pinned objects can be allocated to the pinned-object heap to avoid the performance cost
    /// of allocating them on the normal heaps. Other allocated objects start out belonging to generation 0. All objects
    /// that exist after garbage collection occurs in generation 0 are promoted to generation 1. Objects that exist after
    /// garbage collection occurs in generation 1 move into generation 2. The use of generations means that the garbage
    /// collector has to work with only a subset of the allocated objects at any one time. The COR_PRF_GC_GENERATION enumeration
    /// is used by the <see cref="COR_PRF_GC_GENERATION_RANGE"/> structure.
    /// </remarks>
    public enum COR_PRF_GC_GENERATION
    {
        /// <summary>
        /// The object is stored as generation 0.
        /// </summary>
        COR_PRF_GC_GEN_0,

        /// <summary>
        /// The object is stored as generation 1.
        /// </summary>
        COR_PRF_GC_GEN_1,

        /// <summary>
        /// The object is stored as generation 2.
        /// </summary>
        COR_PRF_GC_GEN_2,

        /// <summary>
        /// The object is stored in the large-object heap.
        /// </summary>
        COR_PRF_GC_LARGE_OBJECT_HEAP,

        /// <summary>
        /// The object is stored in the pinned-object heap.
        /// </summary>
        COR_PRF_GC_PINNED_OBJECT_HEAP,
    }
}
