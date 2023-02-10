namespace ClrDebug
{
    /// <summary>
    /// Contains values that are used to specify behavior, capabilities, or events to which the profiler wishes to subscribe.
    /// </summary>
    /// <remarks>
    /// A COR_PRF_MONITOR value is used with the <see cref="ICorProfilerInfo.GetEventMask"/> and <see cref="ICorProfilerInfo.SetEventMask"/>
    /// methods to define the event notifications that the common language runtime makes to the profiler.
    /// </remarks>
    public enum COR_PRF_MONITOR : uint
    {
        /// <summary>
        /// No flags are set.
        /// </summary>
        COR_PRF_MONITOR_NONE = 0x00000000,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback.FunctionUnloadStarted"/> callback in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_FUNCTION_UNLOADS = 0x00000001,

        /// <summary>
        /// Controls the ClassLoad* and ClassUnload* callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_CLASS_LOADS = 0x00000002,

        /// <summary>
        /// Controls the ModuleLoad*, ModuleUnload*, and <see cref="ICorProfilerCallback.ModuleAttachedToAssembly"/> callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_MODULE_LOADS = 0x00000004,

        /// <summary>
        /// Controls the AssemblyLoad* and AssemblyUnload* callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_ASSEMBLY_LOADS = 0x00000008,

        /// <summary>
        /// Controls the AppDomainCreation* and AppDomainShutdown* callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_APPDOMAIN_LOADS = 0x00000010,

        /// <summary>
        /// Controls the JITCompilation*, <see cref="ICorProfilerCallback.JITFunctionPitched"/>, and <see cref="ICorProfilerCallback.JITInlining"/> callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_JIT_COMPILATION = 0x00000020,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback.ExceptionThrown"/> callback and the ExceptionSearch*, ExceptionOSHandler*, ExceptionUnwind*, and ExceptionCatcher* callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_EXCEPTIONS = 0x00000040,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback2.GarbageCollectionStarted"/>, <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/>, <see cref="ICorProfilerCallback.MovedReferences"/>, <see cref="ICorProfilerCallback4.MovedReferences2"/>, <see cref="ICorProfilerCallback2.SurvivingReferences"/>, <see cref="ICorProfilerCallback4.SurvivingReferences2"/>, <see cref="ICorProfilerCallback.ObjectReferences"/>, <see cref="ICorProfilerCallback.ObjectsAllocatedByClass"/>, <see cref="ICorProfilerCallback.RootReferences"/>, <see cref="ICorProfilerCallback2.RootReferences2"/>, <see cref="ICorProfilerCallback2.HandleCreated"/>, <see cref="ICorProfilerCallback2.HandleDestroyed"/>, and <see cref="ICorProfilerCallback2.FinalizeableObjectQueued"/> callbacks in the ICorProfilerCallback* interfaces.<para/>
        /// When COR_PRF_MONITOR_GC is allocated, concurrent garbage collection is turned off.
        /// </summary>
        COR_PRF_MONITOR_GC = 0x00000080,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback.ObjectAllocated"/> callback in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_OBJECT_ALLOCATED = 0x00000100,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback.ThreadCreated"/>, <see cref="ICorProfilerCallback.ThreadDestroyed"/>, <see cref="ICorProfilerCallback.ThreadAssignedToOSThread"/>, and <see cref="ICorProfilerCallback2.ThreadNameChanged"/> callbacks in the <see cref="ICorProfilerCallback"/> and <see cref="ICorProfilerCallback2"/> interfaces.
        /// </summary>
        COR_PRF_MONITOR_THREADS = 0x00000200,

        /// <summary>
        /// Controls the Remoting* callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_REMOTING = 0x00000400,

        /// <summary>
        /// Controls the <see cref="ICorProfilerCallback.UnmanagedToManagedTransition"/> and <see cref="ICorProfilerCallback.ManagedToUnmanagedTransition"/> callbacks in the <see cref="ICorProfilerCallback"/> interface
        /// </summary>
        COR_PRF_MONITOR_CODE_TRANSITIONS = 0x00000800,

        /// <summary>
        /// Controls the FunctionEnter*, FunctionLeave*, and FunctionTailCall*profiling global static functions.
        /// </summary>
        COR_PRF_MONITOR_ENTERLEAVE = 0x00001000,

        /// <summary>
        /// Controls the COMClassicVTable* callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_CCW = 0x00002000,

        /// <summary>
        /// Controls whether a cookie is passed to the Remoting* callbacks.
        /// </summary>
        COR_PRF_MONITOR_REMOTING_COOKIE = 0x00004000 | COR_PRF_MONITOR_REMOTING,

        /// <summary>
        /// Controls whether the Remoting* callbacks will monitor asynchronous events.
        /// </summary>
        COR_PRF_MONITOR_REMOTING_ASYNC = 0x00008000 | COR_PRF_MONITOR_REMOTING,

        /// <summary>
        /// Controls the RuntimeSuspend*, RuntimeResume*, <see cref="ICorProfilerCallback.RuntimeThreadSuspended"/>, and <see cref="ICorProfilerCallback.RuntimeThreadResumed"/> callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_SUSPENDS = 0x00010000,

        /// <summary>
        /// Controls the JITCachedFunctionSearch* callbacks in the <see cref="ICorProfilerCallback"/> interface. The behavior of this flag is changed in .NET Framework version 2.0.
        /// </summary>
        COR_PRF_MONITOR_CACHE_SEARCHES = 0x00020000,

        /// <summary>
        /// Enables calls to the <see cref="ICorProfilerInfo4.RequestReJIT"/> and <see cref="ICorProfilerInfo4.RequestRevert"/> methods.<para/>
        /// The profiler must set this flag on startup. If the profiler specifies this flag, it must also specify COR_PRF_DISABLE_ALL_NGEN_IMAGES.
        /// </summary>
        COR_PRF_ENABLE_REJIT = 0x00040000,

        /// <summary>
        /// Deprecated. In process debugging is not supported. This flag has no effect.
        /// </summary>
        COR_PRF_ENABLE_INPROC_DEBUGGING = 0x00080000,

        /// <summary>
        /// Deprecated. Allows the profiler to obtain IL-to-native maps by using <see cref="ICorProfilerInfo.GetILToNativeMapping"/>.<para/>
        /// Starting with .NET Framework 2.0, the runtime always tracks IL-to-native maps; therefore, this flag is always considered to be set.
        /// </summary>
        COR_PRF_ENABLE_JIT_MAPS = 0x00100000,

        /// <summary>
        /// Disables all inlining.
        /// </summary>
        COR_PRF_DISABLE_INLINING = 0x00200000,

        /// <summary>
        /// Disables all code optimizations.
        /// </summary>
        COR_PRF_DISABLE_OPTIMIZATIONS = 0x00400000,

        /// <summary>
        /// Informs the runtime that the profiler may want object allocation notifications. This flag must be set during initialization.<para/>
        /// It allows the profiler to subsequently use the COR_PRF_MONITOR_OBJECT_ALLOCATED flag to receive <see cref="ICorProfilerCallback.ObjectAllocated"/> callbacks.
        /// </summary>
        COR_PRF_ENABLE_OBJECT_ALLOCATED = 0x00800000,

        /// <summary>
        /// Controls the ExceptionCLRCatcher* callbacks in the <see cref="ICorProfilerCallback"/> interface.
        /// </summary>
        COR_PRF_MONITOR_CLR_EXCEPTIONS = 0x01000000,

        /// <summary>
        /// Enables all callback events.
        /// </summary>
        COR_PRF_MONITOR_ALL = 0x0107FFFF,

        /// <summary>
        /// Enables argument tracing using the FunctionEnter2 callback or the FunctionEnter3WithInfo callback and the <see cref="ICorProfilerInfo3.GetFunctionEnter3Info"/> method.
        /// </summary>
        COR_PRF_ENABLE_FUNCTION_ARGS = 0X02000000,

        /// <summary>
        /// Enables tracing of return values by using the FunctionLeave2 callback or the FunctionLeave3WithInfo callback and <see cref="ICorProfilerInfo3.GetFunctionLeave3Info"/> method.
        /// </summary>
        COR_PRF_ENABLE_FUNCTION_RETVAL = 0X04000000,

        /// <summary>
        /// Enables the retrieval of an exact ClassID for a generic function by calling the <see cref="ICorProfilerInfo2.GetFunctionInfo2"/> method with a COR_PRF_FRAME_INFO value returned by the FunctionEnter2 callback.
        /// </summary>
        COR_PRF_ENABLE_FRAME_INFO = 0X08000000,

        /// <summary>
        /// Enables calls to the <see cref="ICorProfilerInfo2.DoStackSnapshot"/> method.
        /// </summary>
        COR_PRF_ENABLE_STACK_SNAPSHOT = 0X10000000,

        /// <summary>
        /// Causes the native image search to look for profiler-enhanced images. If no profiler-enhanced image is found for a given assembly, the common language runtime falls back to JIT for that assembly.<para/>
        /// If this flag and the COR_PRF_DISABLE_ALL_NGEN_IMAGES flag are both specified, COR_PRF_DISABLE_ALL_NGEN_IMAGES is used.
        /// </summary>
        COR_PRF_USE_PROFILE_IMAGES = 0x20000000,

        /// <summary>
        /// Disables security transparency checks that are normally done during just-in-time (JIT) compilation and class loading for full-trust assemblies.<para/>
        /// This can make some instrumentation easier to perform.
        /// </summary>
        COR_PRF_DISABLE_TRANSPARENCY_CHECKS_UNDER_FULL_TRUST
            = 0x40000000,

        /// <summary>
        /// Prevents all native images (including profiler-enhanced images) from loading. If this flag and the COR_PRF_USE_PROFILE_IMAGES flag are both specified, COR_PRF_DISABLE_ALL_NGEN_IMAGES is used.
        /// </summary>
        COR_PRF_DISABLE_ALL_NGEN_IMAGES = 0x80000000,

        /// <summary>
        /// Represents all COR_PRF_MONITOR flag values.
        /// </summary>
        COR_PRF_ALL = 0x8FFFFFFF,

        /// <summary>
        /// Represents all COR_PRF_MONITOR flags that require profile-enhanced images.
        /// </summary>
        COR_PRF_REQUIRE_PROFILE_IMAGE = COR_PRF_USE_PROFILE_IMAGES |
                                        COR_PRF_MONITOR_CODE_TRANSITIONS |
                                        COR_PRF_MONITOR_ENTERLEAVE,

        /// <summary>
        /// Represents all COR_PRF_MONITOR flags that can be set after the profiler is attached to a running app. The syntax section indicates the individual flags that are present in this bitmask.
        /// </summary>
        COR_PRF_ALLOWABLE_AFTER_ATTACH = COR_PRF_MONITOR_THREADS |
                                         COR_PRF_MONITOR_MODULE_LOADS |
                                         COR_PRF_MONITOR_ASSEMBLY_LOADS |
                                         COR_PRF_MONITOR_APPDOMAIN_LOADS |
                                         COR_PRF_ENABLE_STACK_SNAPSHOT |
                                         COR_PRF_MONITOR_GC |
                                         COR_PRF_MONITOR_SUSPENDS |
                                         COR_PRF_MONITOR_CLASS_LOADS |
                                         COR_PRF_MONITOR_EXCEPTIONS |
                                         COR_PRF_MONITOR_JIT_COMPILATION |
                                         COR_PRF_ENABLE_REJIT,

        /// <summary>
        /// Represents all COR_PRF_MONITOR flag values.
        /// </summary>
        COR_PRF_ALLOWABLE_NOTIFICATION_PROFILER
            = COR_PRF_MONITOR_FUNCTION_UNLOADS |
              COR_PRF_MONITOR_CLASS_LOADS |
              COR_PRF_MONITOR_MODULE_LOADS |
              COR_PRF_MONITOR_ASSEMBLY_LOADS |
              COR_PRF_MONITOR_APPDOMAIN_LOADS |
              COR_PRF_MONITOR_JIT_COMPILATION |
              COR_PRF_MONITOR_EXCEPTIONS |
              COR_PRF_MONITOR_OBJECT_ALLOCATED |
              COR_PRF_MONITOR_THREADS |
              COR_PRF_MONITOR_CODE_TRANSITIONS |
              COR_PRF_MONITOR_CCW |
              COR_PRF_MONITOR_SUSPENDS |
              COR_PRF_MONITOR_CACHE_SEARCHES |
              COR_PRF_DISABLE_INLINING |
              COR_PRF_DISABLE_OPTIMIZATIONS |
              COR_PRF_ENABLE_OBJECT_ALLOCATED |
              COR_PRF_MONITOR_CLR_EXCEPTIONS |
              COR_PRF_ENABLE_STACK_SNAPSHOT |
              COR_PRF_USE_PROFILE_IMAGES |
              COR_PRF_DISABLE_ALL_NGEN_IMAGES,

        /// <summary>
        /// Represents all COR_PRF_MONITOR flags that can be set only during initialization. Trying to change any of these flags after initialization returns an HRESULT value that indicates failure.
        /// </summary>
        COR_PRF_MONITOR_IMMUTABLE = COR_PRF_MONITOR_CODE_TRANSITIONS |
                                    COR_PRF_MONITOR_REMOTING |
                                    COR_PRF_MONITOR_REMOTING_COOKIE |
                                    COR_PRF_MONITOR_REMOTING_ASYNC |
                                    COR_PRF_ENABLE_INPROC_DEBUGGING |
                                    COR_PRF_ENABLE_JIT_MAPS |
                                    COR_PRF_DISABLE_OPTIMIZATIONS |
                                    COR_PRF_DISABLE_INLINING |
                                    COR_PRF_ENABLE_OBJECT_ALLOCATED |
                                    COR_PRF_ENABLE_FUNCTION_ARGS |
                                    COR_PRF_ENABLE_FUNCTION_RETVAL |
                                    COR_PRF_ENABLE_FRAME_INFO |
                                    COR_PRF_USE_PROFILE_IMAGES |
                                    COR_PRF_DISABLE_TRANSPARENCY_CHECKS_UNDER_FULL_TRUST |
                                    COR_PRF_DISABLE_ALL_NGEN_IMAGES
    }
}
