namespace ClrDebug
{
    /// <summary>
    /// Describes the finalizer for an object.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_FINALIZER_FLAGS enumeration is used by the <see cref="ICorProfilerCallback2.FinalizeableObjectQueued"/>
    /// method to describe the finalizer for an object.
    /// </remarks>
    public enum COR_PRF_FINALIZER_FLAGS
    {
        /// <summary>
        /// The finalizer is critical.
        /// </summary>
        COR_PRF_FINALIZER_CRITICAL = 0x1
    }
}
