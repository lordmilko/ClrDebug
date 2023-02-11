namespace ClrDebug
{
    /// <summary>
    /// Indicates the reason that the runtime is suspended.
    /// </summary>
    /// <remarks>
    /// All runtime threads that are in unmanaged code are permitted to continue running until they try to re-enter the
    /// runtime, at which point they will also be suspended until the runtime resumes. This also applies to new threads
    /// that enter the runtime. All threads within the runtime are either suspended immediately if they are in interruptible
    /// code, or asked to suspend when they do reach interruptible code.
    /// </remarks>
    public enum COR_PRF_SUSPEND_REASON
    {
        /// <summary>
        /// The runtime is suspended for an unspecified reason.
        /// </summary>
        COR_PRF_SUSPEND_OTHER = 0,

        /// <summary>
        /// The runtime is suspended to service a garbage collection request. The garbage collection-related callbacks occur between the <see cref="ICorProfilerCallback.RuntimeSuspendFinished"/> and <see cref="ICorProfilerCallback.RuntimeResumeStarted"/> callbacks.
        /// </summary>
        COR_PRF_SUSPEND_FOR_GC = 1,

        /// <summary>
        /// The runtime is suspended so that an AppDomain can be shut down. While the runtime is suspended, the runtime will determine which threads are in the AppDomain that is being shut down and set them to abort when they resume.<para/>
        /// There are no AppDomain-specific callbacks during this suspension.
        /// </summary>
        COR_PRF_SUSPEND_FOR_APPDOMAIN_SHUTDOWN = 2,

        /// <summary>
        /// The runtime is suspended so that code pitching can occur. Code pitching ensues only when the just-in-time (JIT) compiler is active with code pitching enabled.<para/>
        /// Code pitching callbacks occur between the ICorProfilerCallback::RuntimeSuspendFinished and ICorProfilerCallback::RuntimeResumeStarted callbacks.<para/>
        /// Note: The CLR JIT does not pitch functions in .NET Framework version 2.0, so this value is not used in 2.0.
        /// </summary>
        COR_PRF_SUSPEND_FOR_CODE_PITCHING = 3,

        /// <summary>
        /// The runtime is suspended so that it can shut down. It must suspend all threads to complete the operation.
        /// </summary>
        COR_PRF_SUSPEND_FOR_SHUTDOWN = 4,

        /// <summary>
        /// The runtime is suspended for in-process debugging.
        /// </summary>
        COR_PRF_SUSPEND_FOR_INPROC_DEBUGGER = 6,

        /// <summary>
        /// The runtime is suspended to prepare for a garbage collection.
        /// </summary>
        COR_PRF_SUSPEND_FOR_GC_PREP = 7,

        /// <summary>
        /// The runtime is suspended for JIT recompilation.
        /// </summary>
        COR_PRF_SUSPEND_FOR_REJIT = 8,
        COR_PRF_SUSPEND_FOR_PROFILER = 9,
    }
}
