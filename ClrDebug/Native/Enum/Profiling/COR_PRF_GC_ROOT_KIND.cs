namespace ClrDebug
{
    /// <summary>
    /// Indicates the kind of garbage collection root that is exposed by the <see cref="ICorProfilerCallback2.RootReferences2"/> callback.
    /// </summary>
    public enum COR_PRF_GC_ROOT_KIND
    {
        /// <summary>
        /// The kind of root is unspecified.
        /// </summary>
        COR_PRF_GC_ROOT_OTHER,

        /// <summary>
        /// The root is a variable on the stack.
        /// </summary>
        COR_PRF_GC_ROOT_STACK,

        /// <summary>
        /// The root is an entry in the finalizer queue.
        /// </summary>
        COR_PRF_GC_ROOT_FINALIZER,

        /// <summary>
        /// The root is a garbage collection handle.
        /// </summary>
        COR_PRF_GC_ROOT_HANDLE,
    }
}
