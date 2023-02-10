namespace ClrDebug
{
    /// <summary>
    /// Indicates a property of a garbage collection root.
    /// </summary>
    /// <remarks>
    /// COR_PRF_GC_ROOT_FLAGS is a bitmask that provides additional information about special roots. However, not all roots
    /// are special. For example, some roots are not weak references, interior pointers, pinned, or reference-counted.
    /// For such roots, there are no flags to convey. Therefore, methods that use this enumeration, such as the <see cref="ICorProfilerCallback2.RootReferences2"/>
    /// method, send 0 for the flags bitmask, indicating that all flags are turned off.
    /// </remarks>
    public enum COR_PRF_GC_ROOT_FLAGS
    {
        /// <summary>
        /// The root prevents a garbage collection from moving the object.
        /// </summary>
        COR_PRF_GC_ROOT_PINNING = 1,

        /// <summary>
        /// The root does not prevent garbage collection.
        /// </summary>
        COR_PRF_GC_ROOT_WEAKREF = 2,

        /// <summary>
        /// The root refers to a field of the object rather than the object itself.
        /// </summary>
        COR_PRF_GC_ROOT_INTERIOR = 4,

        /// <summary>
        /// The root prevents garbage collection if the reference count of the object is a certain value.
        /// </summary>
        COR_PRF_GC_ROOT_REFCOUNTED = 8,
    }
}
