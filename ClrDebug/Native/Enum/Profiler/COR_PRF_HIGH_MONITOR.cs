namespace ClrDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Provides flags in addition to those found in the <see cref="COR_PRF_MONITOR"/> enumeration that the profiler can specify to the <see cref="ICorProfilerInfo5.SetEventMask2"/> method when it is loading.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_HIGH_MONITOR flags are used with the pdwEventsHigh parameter of the <see cref="ICorProfilerInfo5.GetEventMask2"/>
    /// and <see cref="ICorProfilerInfo5.SetEventMask2"/> methods. Starting with the .NET Framework 4.6.1, the value of
    /// the COR_PRF_HIGH_ALLOWABLE_AFTER_ATTACH changed from 0 to COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED (0x00000002).
    /// Starting with the .NET Framework 4.7.2, its value changed from COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED to COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED
    /// | COR_PRF_HIGH_MONITOR_DYNAMIC_FUNCTION_UNLOADS. COR_PRF_HIGH_MONITOR_IMMUTABLE is intended to be a bitmask that
    /// represents all flags that can only be set during initialization. Trying to change any of these flags elsewhere
    /// results in a failed HRESULT.
    /// </remarks>
    public enum COR_PRF_HIGH_MONITOR
    {
        /// <summary>
        /// No flags are set.
        /// </summary>
        COR_PRF_HIGH_MONITOR_NONE = 0x00000000,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback6.GetAssemblyReferences"/> callback for adding assembly references during the CLR assembly reference closure walk.
        /// </summary>
        COR_PRF_HIGH_ADD_ASSEMBLY_REFERENCES = 0x00000001,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback7.ModuleInMemorySymbolsUpdated"/> callback for updates to the symbol stream associated with an in-memory module.
        /// </summary>
        COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED = 0x00000002,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback9.DynamicMethodUnloaded"/> callback for indicating when a dynamic method has been garbage collected and unloaded.<para/>
        /// [!INCLUDEnet_current_v472plus]
        /// </summary>
        COR_PRF_HIGH_MONITOR_DYNAMIC_FUNCTION_UNLOADS = 0x00000004,

        /// <summary>
        /// .NET Core 3.0 and later versions only: Disables tiered compilation for profilers.
        /// </summary>
        COR_PRF_HIGH_DISABLE_TIERED_COMPILATION = 0x00000008,

        /// <summary>
        /// .NET Core 3.0 and later versions only: Provides a lightweight GC profiling option compared to <see cref="COR_PRF_MONITOR"/>.<para/>
        /// Controls only the <see cref="ICorProfilerCallback2.GarbageCollectionStarted"/>, <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/>, and <see cref="ICorProfilerInfo2.GetGenerationBounds"/> callbacks.<para/>
        /// Unlike the COR_PRF_MONITOR_GC flag, COR_PRF_HIGH_BASIC_GC does not disable concurrent garbage collection.
        /// </summary>
        COR_PRF_HIGH_BASIC_GC = 0x00000010,

        /// <summary>
        /// .NET Core 3.0 and later versions only: Enables the <see cref="ICorProfilerCallback.MovedReferences"/> and <see cref="ICorProfilerCallback4.MovedReferences2"/> callbacks for compacting GCs only.
        /// </summary>
        COR_PRF_HIGH_MONITOR_GC_MOVED_OBJECTS = 0x00000020,

        /// <summary>
        /// Represents all COR_PRF_HIGH_MONITOR flags that require profile-enhanced images. It corresponds to the COR_PRF_REQUIRE_PROFILE_IMAGE flag in the <see cref="COR_PRF_MONITOR"/> enumeration.
        /// </summary>
        COR_PRF_HIGH_REQUIRE_PROFILE_IMAGE = 0,

        /// <summary>
        /// .NET Core 3.0 and later versions only: Similar to <see cref="COR_PRF_MONITOR"/>, but provides information on object allocations for the large object heap (LOH) only.
        /// </summary>
        COR_PRF_HIGH_MONITOR_LARGEOBJECT_ALLOCATED = 0x00000040,
        COR_PRF_HIGH_MONITOR_EVENT_PIPE = 0x00000080,
        COR_PRF_HIGH_MONITOR_PINNEDOBJECT_ALLOCATED = 0x00000100,

        /// <summary>
        /// Represents all COR_PRF_HIGH_MONITOR flags that can be set after the profiler is attached to a running app.
        /// </summary>
        COR_PRF_HIGH_ALLOWABLE_AFTER_ATTACH = COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED |
                                              COR_PRF_HIGH_MONITOR_DYNAMIC_FUNCTION_UNLOADS |
                                              COR_PRF_HIGH_BASIC_GC |
                                              COR_PRF_HIGH_MONITOR_GC_MOVED_OBJECTS |
                                              COR_PRF_HIGH_MONITOR_LARGEOBJECT_ALLOCATED |
                                              COR_PRF_HIGH_MONITOR_EVENT_PIPE,

        COR_PRF_HIGH_ALLOWABLE_NOTIFICATION_PROFILER
            = COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED |
              COR_PRF_HIGH_MONITOR_DYNAMIC_FUNCTION_UNLOADS |
              COR_PRF_HIGH_DISABLE_TIERED_COMPILATION |
              COR_PRF_HIGH_BASIC_GC |
              COR_PRF_HIGH_MONITOR_GC_MOVED_OBJECTS |
              COR_PRF_HIGH_MONITOR_LARGEOBJECT_ALLOCATED |
              COR_PRF_HIGH_MONITOR_EVENT_PIPE,

        /// <summary>
        /// Represents all COR_PRF_HIGH_MONITOR flags that can be set only during initialization. Trying to change any of these flags elsewhere results in an HRESULT value that indicates failure.
        /// </summary>
        COR_PRF_HIGH_MONITOR_IMMUTABLE = COR_PRF_HIGH_DISABLE_TIERED_COMPILATION,

    }
    ;
}
