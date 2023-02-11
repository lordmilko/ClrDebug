namespace ClrDebug
{
    /// <summary>
    /// Specifies how much data to pass back with a stack snapshot in each call to the profiler's StackSnapshotCallback function.
    /// </summary>
    /// <remarks>
    /// Values that are provided by the COR_PRF_SNAPSHOT_INFO enumeration are passed as parameters to the <see cref="ICorProfilerInfo2.DoStackSnapshot"/>
    /// method.
    /// </remarks>
    public enum COR_PRF_SNAPSHOT_INFO
    {
        /// <summary>
        /// Indicates that values must be passed for all StackSnapshotCallback parameters, except the context parameter.
        /// </summary>
        COR_PRF_SNAPSHOT_DEFAULT,

        /// <summary>
        /// Indicates that values must be passed for all StackSnapshotCallback parameters, including the context parameter.
        /// </summary>
        COR_PRF_SNAPSHOT_REGISTER_CONTEXT,

        /// <summary>
        /// Indicates that a simpler, alternative stack-walking algorithm will be used.
        /// </summary>
        COR_PRF_SNAPSHOT_X86_OPTIMIZED,
    }
}
