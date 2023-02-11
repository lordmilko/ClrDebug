namespace ClrDebug
{
    public enum STARTUP_FLAGS
    {
        /// <summary>
        /// Specifies that concurrent garbage collection should be used.<para/>
        /// If the caller asks for the server build and concurrent garbage collection on a single-processor machine,
        /// the workstation build and non-concurrent garbage collection are run instead.<para/>Note: Concurrent garbage collection
        /// is not supported in applications that are running the WOW64 x86 emulator on 64-bit systems that implement
        /// the Intel Itanium architecture (formerly called IA-64). For more information about using WOW64 on
        /// 64-bit Windows systems, see Running 32-bit Applications.
        /// </summary>
        STARTUP_CONCURRENT_GC = 0x1,

        /// <summary>
        /// Specifies that loader optimization shall occur.
        /// </summary>
        STARTUP_LOADER_OPTIMIZATION_MASK = 0x3 << 1,

        /// <summary>
        /// Specifies that no assemblies are loaded as domain-neutral.
        /// </summary>
        STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN = 0x1 << 1,

        /// <summary>
        /// Specifies that all assemblies are loaded as domain-neutral.
        /// </summary>
        STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN = 0x2 << 1,

        /// <summary>
        /// Specifies that all strong-named assemblies are loaded as domain-neutral.
        /// </summary>
        STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN_HOST = 0x3 << 1,

        /// <summary>
        /// Specifies that CLR version policy will not be applied to the version passed in.<para/>
        /// The exact version specified of the CLR will be loaded. The shim does not evaluate policy to determine the latest compatible version.
        /// </summary>
        STARTUP_LOADER_SAFEMODE = 0x10,

        /// <summary>
        /// Specifies that the preferred runtime will be set, but not actually started.
        /// </summary>
        STARTUP_LOADER_SETPREFERENCE = 0x100,

        /// <summary>
        /// Specifies that the server garbage collection will be used.
        /// </summary>
        STARTUP_SERVER_GC = 0x1000,

        /// <summary>
        /// Specifies that garbage collection will keep the virtual address used.
        /// </summary>
        STARTUP_HOARD_GC_VM = 0x2000,

        /// <summary>
        /// Specifies that mixing a hosting interface will not be allowed.
        /// </summary>
        STARTUP_SINGLE_VERSION_HOSTING_INTERFACE = 0x4000,

        /// <summary>
        /// Specifies that impersonation should not flow across asynchronous points by default.
        /// </summary>
        STARTUP_LEGACY_IMPERSONATION = 0x10000,

        /// <summary>
        /// Specifies that the full thread stack should not be committed when the thread starts running.
        /// </summary>
        STARTUP_DISABLE_COMMITTHREADSTACK = 0x20000,

        /// <summary>
        /// Specifies that managed impersonations and impersonations achieved through platform invoke will flow across asynchronous points.<para/>
        /// By default, only managed impersonations will flow across asynchronous points.
        /// </summary>
        STARTUP_ALWAYSFLOW_IMPERSONATION = 0x40000,

        /// <summary>
        /// Specifies that garbage collection will use less committed space when system memory is low. See gcTrimCommitOnLowMemory in Optimization for Shared Web Hosting.
        /// </summary>
        STARTUP_TRIM_GC_COMMIT = 0x80000,

        /// <summary>
        /// Specifies that event tracing for Windows (ETW) is enabled for common language runtime events.<para/>
        /// Beginning with Windows Vista, event tracing is always enabled, so this flag has no effect. See Controlling .NET Framework Logging.
        /// </summary>
        STARTUP_ETW = 0x100000,

        /// <summary>
        /// Specifies that application domain resource monitoring is enabled. See the AppDomain.MonitoringIsEnabled property and &lt;appDomainResourceMonitoring&gt; Element.
        /// </summary>
        STARTUP_ARM = 0x400000
    }
}
