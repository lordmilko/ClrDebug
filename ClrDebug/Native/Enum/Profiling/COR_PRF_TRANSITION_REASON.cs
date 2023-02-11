namespace ClrDebug
{
    /// <summary>
    /// Indicates the reason for a transition from managed to unmanaged code, or vice versa.
    /// </summary>
    /// <remarks>
    /// When a transition occurs, the profiler receives an ICorProfilerCallback.ManagedToUnmanagedTransition or ICorProfilerCallback.UnmanagedToManagedTransition
    /// callback, either of which provides a value of the COR_PRF_TRANSITION_REASON enumeration to indicate the reason
    /// for the transition.
    /// </remarks>
    public enum COR_PRF_TRANSITION_REASON
    {
        /// <summary>
        /// The transition is due to a call into a function.
        /// </summary>
        COR_PRF_TRANSITION_CALL,

        /// <summary>
        /// The transition is due to a return from a function.
        /// </summary>
        COR_PRF_TRANSITION_RETURN
    }
}
