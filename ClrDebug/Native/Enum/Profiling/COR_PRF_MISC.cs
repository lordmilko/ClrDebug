namespace ClrDebug
{
    /// <summary>
    /// Contains constant values that specify special identifiers.
    /// </summary>
    public enum COR_PRF_MISC : uint
    {
        /// <summary>
        /// The default identifier used by <see cref="ICorProfilerInfo.GetModuleInfo"/> for a module that has not yet been attached to an assembly.
        /// </summary>
        PROFILER_PARENT_UNKNOWN = 0xFFFFFFFD,

        /// <summary>
        /// The default class identifier for global constants that do not belong to a class.
        /// </summary>
        PROFILER_GLOBAL_CLASS = 0xFFFFFFFE,

        /// <summary>
        /// The default module identifier for global objects that do not belong to a module.
        /// </summary>
        PROFILER_GLOBAL_MODULE = 0xFFFFFFFF
    }
}
