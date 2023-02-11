using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that are used by the common language runtime (CLR) to notify a code profiler when the events to which the profiler has subscribed occur.
    /// </summary>
    /// <remarks>
    /// The CLR calls a method in the ICorProfilerCallback (or <see cref="ICorProfilerCallback2"/>) interface to notify
    /// the profiler when an event, to which the profiler has subscribed, occurs. This is the primary callback interface
    /// through which the CLR communicates with the code profiler. A code profiler must implement the methods of the ICorProfilerCallback
    /// interface. For the .NET Framework version 2.0 or later, the profiler must also implement the ICorProfilerCallback2
    /// methods. Each method implementation must return an HRESULT that has a value of S_OK on success or E_FAIL on failure.
    /// Currently, the CLR ignores the HRESULT that is returned by each callback except <see cref="ObjectReferences"/>.
    /// In the Microsoft Windows registry, a code profiler must register its Component Object Model (COM) object that implements
    /// the ICorProfilerCallback and ICorProfilerCallback2 interfaces. A code profiler subscribes to the events for which
    /// it wants to receive notification by calling <see cref="ICorProfilerInfo.SetEventMask"/>. This is usually done in
    /// the profiler's implementation of <see cref="Initialize"/>. The profiler is then able to receive notification from
    /// the runtime when an event is about to occur or has just occurred in an executing runtime process.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("176FBED1-A55C-4796-98CA-A9DA0EF883E7")]
    [ComImport]
    public interface ICorProfilerCallback
    {
        /// <summary>
        /// Called to initialize the code profiler whenever a new common language runtime (CLR) application is started.
        /// </summary>
        /// <param name="pICorProfilerInfoUnk">[in] Pointer to an IUnknown interface that the profiler must query for an <see cref="ICorProfilerInfo"/> interface pointer.</param>
        /// <remarks>
        /// The Initialize call is the only opportunity to enable (or disable) callbacks that are immutable. Once a callback
        /// is enabled by the Initialize call, it cannot be disabled later using <see cref="ICorProfilerInfo.SetEventMask"/>.
        /// The COR_PRF_MONITOR_IMMUTABLE value of the COR_PRF_MONITOR enumeration indicates which events are immutable.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Initialize(
            [MarshalAs(UnmanagedType.IUnknown), In] object pICorProfilerInfoUnk);

        /// <summary>
        /// Notifies the profiler that the application is shutting down.
        /// </summary>
        /// <remarks>
        /// The profiler code cannot safely call methods of the <see cref="ICorProfilerInfo"/> interface after the Shutdown
        /// method is called. Any calls to ICorProfilerInfo methods result in undefined behavior after the Shutdown method
        /// returns. Certain immutable events may still occur after shutdown; the profiler should take care to return immediately
        /// when this occurs. The Shutdown method will be called only if the managed application that is being profiled started
        /// as managed code (that is, the initial frame on the process stack is managed). If the application started as unmanaged
        /// code but later jumped into managed code, thereby creating an instance of the common language runtime (CLR), then
        /// Shutdown will not be called. For these cases, the profiler should include in its library a DllMain routine that
        /// uses the DLL_PROCESS_DETACH value to free any resources and perform clean-up processing of its data, such as flushing
        /// traces to disk and so on. In general, the profiler must cope with unexpected shutdowns. For example, a process
        /// might be halted by Win32's TerminateProcess method (declared in Winbase.h). In other cases, the CLR will halt certain
        /// managed threads (background threads) without delivering orderly destruction messages for them.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Shutdown();

        /// <summary>
        /// Notifies the profiler that an application domain is being created.
        /// </summary>
        /// <param name="appDomainId">[in] Identifies the domain which is being created.</param>
        /// <remarks>
        /// The ID is not valid for any information request until the <see cref="AppDomainCreationFinished"/> method is called.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AppDomainCreationStarted(
            [In] AppDomainID appDomainId);

        /// <summary>
        /// Notifies the profiler that an application domain has been created.
        /// </summary>
        /// <param name="appDomainId">[in] Identifies the domain which has been created.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether creation of the application domain completed successfully.</param>
        /// <remarks>
        /// The application ID is not valid for any information request until the AppDomainCreationFinished method is called.
        /// Some parts of loading the application domain might continue after the AppDomainCreationFinished callback. A failure
        /// HRESULT in hrStatus indicates a failure. However, a success HRESULT in hrStatus indicates only that the first part
        /// of creating the application domain has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AppDomainCreationFinished(
            [In] AppDomainID appDomainId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that an application domain is being unloaded from a process.
        /// </summary>
        /// <param name="appDomainId">[in] Identifies the domain in which the application's assemblies are stored.</param>
        /// <remarks>
        /// The value of appDomainId is not valid for any information request after the AppDomainShutdownStarted method returns
        /// — this is the profiler's last chance to get information about this application domain.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AppDomainShutdownStarted(
            [In] AppDomainID appDomainId);

        /// <summary>
        /// Notifies the profiler that an application domain has been unloaded from a process.
        /// </summary>
        /// <param name="appDomainId">[in] Identifies the domain in which the application's assemblies are stored.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether the application domain was unloaded successfully.</param>
        /// <remarks>
        /// The value of appDomainId is not valid for an information request after the <see cref="AppDomainShutdownStarted"/>
        /// method returns. Some parts of unloading the application domain might continue after the AppDomainCreationFinished
        /// callback. A failure HRESULT in hrStatus indicates a failure. However, a success HRESULT in hrStatus indicates only
        /// that the first part of unloading the application domain has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AppDomainShutdownFinished(
            [In] AppDomainID appDomainId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that an assembly is being loaded.
        /// </summary>
        /// <param name="assemblyId">[in] Identifies the assembly that is being loaded.</param>
        /// <remarks>
        /// The value of assemblyId is not valid for an information request until the <see cref="AssemblyLoadFinished"/> method
        /// is called.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AssemblyLoadStarted(
            [In] AssemblyID assemblyId);

        /// <summary>
        /// Notifies the profiler that an assembly has finished loading.
        /// </summary>
        /// <param name="assemblyId">[in] Identifies the assembly that was loaded.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether the assembly finished loading successfully.</param>
        /// <remarks>
        /// The value of assemblyId is not valid for an information request until the AssemblyLoadFinished method is called.
        /// Some parts of loading the assembly might continue after the AssemblyLoadFinished callback. A failure HRESULT in
        /// hrStatus indicates a failure. However, a success HRESULT in hrStatus indicates only that the first part of loading
        /// the assembly has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AssemblyLoadFinished(
            [In] AssemblyID assemblyId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that an assembly is being unloaded.
        /// </summary>
        /// <param name="assemblyId">[in] Identifies the assembly that is being unloaded.</param>
        /// <remarks>
        /// The value of assemblyId is not valid for an information request after the AssemblyUnloadStarted method returns
        /// — this is the profiler's last chance to get information about this assembly.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AssemblyUnloadStarted(
            [In] AssemblyID assemblyId);

        /// <summary>
        /// Notifies the profiler that an assembly has been unloaded.
        /// </summary>
        /// <param name="assemblyId">[in] Identifies the assembly that is being unloaded.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether the assembly was unloaded successfully.</param>
        /// <remarks>
        /// The value of assemblyId is not valid for an information request after the <see cref="AssemblyUnloadStarted"/> method
        /// returns. Some parts of unloading the assembly might continue after the AssemblyUnloadFinished callback. A failure
        /// HRESULT in hrStatus indicates a failure. However, a success HRESULT in hrStatus indicates only that the first part
        /// of unloading the assembly has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AssemblyUnloadFinished(
            [In] AssemblyID assemblyId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that a module is being loaded.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that is being loaded.</param>
        /// <remarks>
        /// The value of moduleId is not valid for an information request until the <see cref="ModuleLoadFinished"/> method
        /// is called.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModuleLoadStarted(
            [In] ModuleID moduleId);

        /// <summary>
        /// Notifies the profiler that a module has finished loading.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that has finished loading.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether the module was loaded successfully.</param>
        /// <remarks>
        /// The value of moduleId is not valid for an information request until the ModuleLoadFinished method is called. Some
        /// parts of loading the module might continue after the ModuleLoadFinished callback. A failure HRESULT in hrStatus
        /// indicates a failure. However, a success HRESULT in hrStatus indicates only that the first part of loading the module
        /// has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModuleLoadFinished(
            [In] ModuleID moduleId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that a module is being unloaded.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that is being unloaded.</param>
        /// <remarks>
        /// The value of moduleId is not valid for an information request after the ModuleUnloadStarted method returns — this
        /// is the profiler's last chance to get information about this module.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModuleUnloadStarted(
            [In] ModuleID moduleId);

        /// <summary>
        /// Notifies the profiler that a module has finished unloading.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that was unloaded.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether the module was unloaded successfully.</param>
        /// <remarks>
        /// The value of moduleId is not valid for an information request after the <see cref="ModuleUnloadStarted"/> method
        /// returns. Some parts of unloading the class might continue after the ModuleUnloadFinished callback. A failure HRESULT
        /// in hrStatus indicates a failure. However, a success HRESULT in hrStatus indicates only that the first part of unloading
        /// the module has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModuleUnloadFinished(
            [In] ModuleID moduleId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that a module is being attached to its parent assembly.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that is being attached.</param>
        /// <param name="assemblyId">[in] The ID of the parent assembly to which the module is attached.</param>
        /// <remarks>
        /// A module can be loaded through an import address table (IAT), through a call to LoadLibrary, or through a metadata
        /// reference. As a result, the common language runtime (CLR) loader has multiple code paths for determining the assembly
        /// in which a module lives. Therefore, it is possible that after <see cref="ModuleLoadFinished"/> is called, the module
        /// does not know what assembly it is in and getting the parent assembly ID is not possible. The ModuleAttachedToAssembly
        /// method is called when the module is attached to its parent assembly and its parent assembly ID can be obtained.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModuleAttachedToAssembly(
            [In] ModuleID moduleId,
            [In] AssemblyID assemblyId);

        /// <summary>
        /// Notifies the profiler that a class is being loaded.
        /// </summary>
        /// <param name="classId">[in] Identifies the class that is being loaded.</param>
        /// <remarks>
        /// The value of classId is not valid for an information request until the <see cref="ClassLoadFinished"/> method is
        /// called.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ClassLoadStarted(
            [In] ClassID classId);

        /// <summary>
        /// Notifies the profiler that a class has finished loading.
        /// </summary>
        /// <param name="classId">[in] Identifies the class that was loaded.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether the class loaded successfully.</param>
        /// <remarks>
        /// The value of classId is not valid for an information request until the ClassLoadFinished method is called. Some
        /// parts of loading the class might continue after the ClassLoadFinished callback. A failure HRESULT in hrStatus indicates
        /// a failure. However, a success HRESULT in hrStatus indicates only that the first part of loading the class has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ClassLoadFinished(
            [In] ClassID classId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that a class is being unloaded.
        /// </summary>
        /// <param name="classId">[in] Identifies the class that is being unloaded.</param>
        /// <remarks>
        /// The value of classId is not valid for an information request after the ClassUnloadStarted method returns — this
        /// is the profiler's last chance to obtain information about this class.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ClassUnloadStarted(
            [In] ClassID classId);

        /// <summary>
        /// Notifies the profiler that a class has finished unloading.
        /// </summary>
        /// <param name="classId">[in] Identifies the class that was unloaded.</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates whether the class was unloaded successfully.</param>
        /// <remarks>
        /// Some parts of unloading the class might continue after the ClassUnloadFinished callback. A failure HRESULT in hrStatus
        /// indicates a failure. However, a success HRESULT in hrStatus indicates only that the first part of unloading the
        /// class has succeeded.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ClassUnloadFinished(
            [In] ClassID classId,
            [In] HRESULT hrStatus);

        /// <summary>
        /// Notifies the profiler that the runtime has started to unload a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that is being unloaded.</param>
        /// <remarks>
        /// The value of the functionId parameter is no longer valid after this method returns to the caller.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT FunctionUnloadStarted(
            [In] FunctionID functionId);

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler has started to compile a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which the compilation is starting.</param>
        /// <param name="fIsSafeToBlock">[in] A value indicating to the profiler whether blocking will affect the operation of the runtime. The value is true if blocking may cause the runtime to wait for the calling thread to return from this callback; otherwise, false.<para/>
        /// Although a value of true will not harm the runtime, it can skew the profiling results.</param>
        /// <remarks>
        /// It is possible to receive more than one pair of JITCompilationStarted and <see cref="JITCompilationFinished"/>
        /// calls for each function because of the way the runtime handles class constructors. For example, the runtime starts
        /// to JIT-compile method A, but the class constructor for class B needs to be run. Therefore, the runtime JIT-compiles
        /// the constructor for class B and runs it. While the constructor is running, it makes a call to method A, which causes
        /// method A to be JIT-compiled again. In this scenario, the first JIT compilation of method A is halted. However,
        /// both attempts to JIT-compile method A are reported with JIT-compilation events. If the profiler is going to replace
        /// Microsoft intermediate language (MSIL) code for method A by calling the <see cref="ICorProfilerInfo.SetILFunctionBody"/>
        /// method, it must do so for both JITCompilationStarted events, but it may use the same MSIL block for both. Profilers
        /// must support the sequence of JIT callbacks in cases where two threads are simultaneously making callbacks. For
        /// example, thread A calls JITCompilationStarted. However, before thread A calls JITCompilationFinished, thread B
        /// calls <see cref="ExceptionSearchFunctionEnter"/> with the function ID from thread A's JITCompilationStarted callback.
        /// It might appear that the function ID should not yet be valid because a call to JITCompilationFinished had not yet
        /// been received by the profiler. However, in a case like this one, the function ID is valid.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT JITCompilationStarted(
            [In] FunctionID functionId,
            [In] bool fIsSafeToBlock);

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler has finished compiling a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that was compiled.</param>
        /// <param name="hrStatus">[in] A value indicating whether compilation was successful.</param>
        /// <param name="fIsSafeToBlock">[in] A value indicating to the profiler whether blocking will affect the operation of the runtime. The value is true if blocking may cause the runtime to wait for the calling thread to return from this callback; otherwise, false.<para/>
        /// Although a value of true will not harm the runtime, it can skew the profiling results.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT JITCompilationFinished(
            [In] FunctionID functionId,
            [In] HRESULT hrStatus,
            [In] bool fIsSafeToBlock);

        /// <summary>
        /// Notifies the profiler that a search has started for a function that was compiled previously using the Native Image Generator (NGen.exe).
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which the search is being performed.</param>
        /// <param name="pbUseCachedFunction">[out] true if the execution engine should use the cached version of a function (if available); otherwise false.<para/>
        /// If the value is false, the execution engine JIT-compiles the function instead of using a version that is not JIT-compiled.</param>
        /// <remarks>
        /// In .NET Framework version 2.0, the JITCachedFunctionSearchStarted and <see cref="JITCachedFunctionSearchFinished"/>
        /// callbacks will not be made for all functions in regular NGen images. Only NGen images optimized for a profile will
        /// generate callbacks for all functions in the image. However, due to the additional overhead, a profiler should request
        /// profiler-optimized NGen images only if it intends to use these callbacks to force a function to be compiled just-in-time
        /// (JIT). Otherwise, the profiler should use a lazy strategy for gathering function information. Profilers must support
        /// cases where multiple threads of a profiled application are calling the same method simultaneously. For example,
        /// thread A calls JITCachedFunctionSearchStarted and the profiler responds by setting pbUseCachedFunctionto FALSE
        /// to force JIT compilation. Thread A then calls <see cref="JITCompilationStarted"/> and <see cref="JITCompilationFinished"/>.
        /// Now thread B calls JITCachedFunctionSearchStarted for the same function. Even though the profiler has stated its
        /// intention to JIT-compile the function, the profiler receives the second callback because thread B sends the callback
        /// before the profiler has responded to thread A's call to JITCachedFunctionSearchStarted. The order in which the
        /// threads make calls depends on how the threads are scheduled. When the profiler receives duplicate callbacks, it
        /// must set the value referenced by pbUseCachedFunction to the same value for all the duplicate callbacks. That is,
        /// when JITCachedFunctionSearchStarted is called multiple times with the same functionId value, the profiler must
        /// respond the same each time.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT JITCachedFunctionSearchStarted(
            [In] FunctionID functionId,
            [Out] out bool pbUseCachedFunction);

        /// <summary>
        /// Notifies the profiler that a search has finished for a function that was compiled previously using the Native Image Generator (NGen.exe).
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which the search was performed.</param>
        /// <param name="result">[in] A value of the <see cref="COR_PRF_JIT_CACHE"/> enumeration that indicates the result of the search.</param>
        /// <remarks>
        /// In .NET Framework version 2.0, the <see cref="JITCachedFunctionSearchStarted"/> and JITCachedFunctionSearchFinished
        /// callbacks will not be made for all functions in regular NGen images. Only NGen images optimized for a profiler
        /// will generate callbacks for all functions in the image. However, due to the additional overhead, a profiler should
        /// request profiler-optimized NGen images only if it intends to use these callbacks to force a function to be compiled
        /// just-in-time (JIT). Otherwise, the profiler should use a lazy strategy for gathering function information.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT JITCachedFunctionSearchFinished(
            [In] FunctionID functionId,
            [In] COR_PRF_JIT_CACHE result);

        /// <summary>
        /// Notifies the profiler that a function that has been just-in-time (JIT)-compiled has been removed from memory.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that was removed.</param>
        /// <remarks>
        /// If the removed function is called, the profiler will receive new JIT-compilation events when the function is recompiled.
        /// Currently, the common language runtime (CLR) JIT compiler does not remove functions from memory, so this callback
        /// is currently not used and will not be received by the profiler. The value of functionId is not valid until the
        /// function is recompiled. When the function is recompiled, the same functionId value will be used.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT JITFunctionPitched(
            [In] FunctionID functionId);

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler is about to insert a function in line with another function.
        /// </summary>
        /// <param name="callerId">[in] The ID of the function into which the calleeId function will be inserted.</param>
        /// <param name="calleeId">[in] The ID of the function to be inserted.</param>
        /// <param name="pfShouldInline">[out] true to allow the insertion to occur; otherwise, false.</param>
        /// <remarks>
        /// The profiler can set pfShouldInline to false to prevent the calleeId function from being inserted into the callerId
        /// function. Also, the profiler can globally disable inline insertion by using the COR_PRF_DISABLE_INLINING value
        /// of the COR_PRF_MONITOR enumeration. Functions inserted inline do not raise events for entering or leaving. Therefore,
        /// the profiler must set pfShouldInline to false in order to produce an accurate callgraph. Setting pfShouldInline
        /// to false will affect performance, because inline insertion typically increases speed and reduces the number of
        /// separate JIT compilation events for the inserted method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT JITInlining(
            [In] FunctionID callerId,
            [In] FunctionID calleeId,
            [Out] out bool pfShouldInline);

        /// <summary>
        /// Notifies the profiler that a thread has been created.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread that has been created.</param>
        /// <remarks>
        /// The threadId value is immediately valid.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ThreadCreated(
            [In] ThreadID threadId);

        /// <summary>
        /// Notifies the profiler that a thread has been destroyed.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread that has been destroyed.</param>
        /// <remarks>
        /// The threadId value is no longer valid at the time of this call.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ThreadDestroyed(
            [In] ThreadID threadId);

        /// <summary>
        /// Notifies the profiler that a managed thread is being implemented using a particular operating system thread.
        /// </summary>
        /// <param name="managedThreadId">[in] The identifier of the managed thread.</param>
        /// <param name="osThreadId">[in] The identifier of the operating system thread.</param>
        /// <remarks>
        /// The ThreadAssignedToOSThread callback exists so that the profiler can maintain an accurate mapping across fibers
        /// of operating system threads to managed threads.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ThreadAssignedToOSThread(
            [In] ThreadID managedThreadId,
            [In] int osThreadId);

        /// <summary>
        /// Notifies the profiler that a remoting call has started.
        /// </summary>
        /// <remarks>
        /// This event is the same for synchronous and asynchronous calls. Each of the following pairs of callbacks will occur
        /// on the same thread: You should be aware of the following issues with the remoting callbacks:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingClientInvocationStarted();

        /// <summary>
        /// Notifies the profiler that the client is sending a request to the server.
        /// </summary>
        /// <param name="pCookie">[in] A value that corresponds with the value provided in <see cref="RemotingServerReceivingMessage"/> under these conditions: This allows easy pairing of remoting calls and the creation of a logical call stack.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingClientSendingMessage(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pCookie,
            [In] bool fIsAsync);

        /// <summary>
        /// Notifies the profiler that the server-side portion of a remoting call has completed and the client is now receiving and about to process the reply.
        /// </summary>
        /// <param name="pCookie">[in] A value that will correspond with the value provided in <see cref="RemotingServerSendingReply"/> under these conditions: This allows easy pairing of remoting calls.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingClientReceivingReply(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pCookie,
            [In] bool fIsAsync);

        /// <summary>
        /// Notifies the profiler that a remoting call has run to completion on the client.
        /// </summary>
        /// <remarks>
        /// If the remoting call was synchronous, it has also run to completion on the server. If the remoting call was asynchronous,
        /// a reply might still be expected when the call is handled. If a reply is expected, it will occur as a call to <see
        /// cref="RemotingClientReceivingReply"/> and an additional call to RemotingClientInvocationFinished to indicate the
        /// required secondary processing of an asynchronous call. Each of the following pairs of callbacks will occur on the
        /// same thread: You should be aware of the following issues with the remoting callbacks:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingClientInvocationFinished();

        /// <summary>
        /// Notifies the profiler that the process has received a remote method invocation or activation request.
        /// </summary>
        /// <param name="pCookie">[in] A value that will correspond with the value provided in <see cref="RemotingClientSendingMessage"/> under these conditions: This allows easy pairing of remoting calls and the creation of a logical call stack.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        /// <remarks>
        /// If the message request is asynchronous, the request can be serviced by any arbitrary thread.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingServerReceivingMessage(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pCookie,
            [In] bool fIsAsync);

        /// <summary>
        /// Notifies the profiler that the process is invoking a method in response to a remote method invocation request.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingServerInvocationStarted();

        /// <summary>
        /// Notifies the profiler that the process has finished invoking a method in response to a remote method invocation request.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingServerInvocationReturned();

        /// <summary>
        /// Notifies the profiler that the process has finished processing a remote method invocation request and is about to transmit the reply through a channel.
        /// </summary>
        /// <param name="pCookie">[in] A pointer to a GUID that will correspond with the value provided in <see cref="RemotingClientReceivingReply"/> under these conditions: This allows easy pairing of remoting calls and the creation of a logical call stack.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemotingServerSendingReply(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pCookie,
            [In] bool fIsAsync);

        /// <summary>
        /// Notifies the profiler that a transition from unmanaged code to managed code has occurred.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that is being called.</param>
        /// <param name="reason">[in] A value of the <see cref="COR_PRF_TRANSITION_REASON"/> enumeration that indicates whether the transition occurred because of a call into managed code from unmanaged code, or because of a return from an unmanaged function called by a managed one.</param>
        /// <remarks>
        /// If the value of reason is COR_PRF_TRANSITION_RETURN and functionId is not null, the function ID is that of the
        /// unmanaged function, and will never have been compiled using the just-in-time (JIT) compiler. Unmanaged functions
        /// have some basic information associated with them, such as a name and some metadata. If the value of reason is COR_PRF_TRANSITION_CALL,
        /// it may be possible that the called function (that is, the managed function) has not yet been JIT-compiled.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnmanagedToManagedTransition(
            [In] FunctionID functionId,
            [In] COR_PRF_TRANSITION_REASON reason);

        /// <summary>
        /// Notifies the profiler that a transition from managed code to unmanaged code has occurred.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that is being called.</param>
        /// <param name="reason">[in] A value of the <see cref="COR_PRF_TRANSITION_REASON"/> enumeration that indicates whether the transition occurred because of a call into unmanaged code from managed code, or because of a return from a managed function called by an unmanaged one.</param>
        /// <remarks>
        /// If the value of reason is COR_PRF_TRANSITION_CALL, the function ID is that of the unmanaged function, which will
        /// never have been compiled using the just-in-time compiler. Unmanaged functions have basic information associated
        /// with them, such as a name and some metadata. If the unmanaged function was called by using implicit platform invoke
        /// (PInvoke), the runtime cannot determine the destination of the call and the value of functionId will be null. For
        /// more information on implicit PInvoke, see Using C.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ManagedToUnmanagedTransition(
            [In] FunctionID functionId,
            [In] COR_PRF_TRANSITION_REASON reason);

        /// <summary>
        /// Notifies the profiler that the runtime is about to suspend all runtime threads.
        /// </summary>
        /// <param name="suspendReason">[in] A value of the <see cref="COR_PRF_SUSPEND_REASON"/> enumeration that indicates the reason for the suspension.</param>
        /// <remarks>
        /// All runtime threads that are in unmanaged code are allowed to continue running until they try to re-enter the runtime.
        /// At that point they will also be suspended until the runtime resumes. This also applies to new threads that enter
        /// the runtime. All threads in the runtime are either suspended immediately if they are already in interruptible code,
        /// or they are asked to suspend when they reach interruptible code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RuntimeSuspendStarted(
            [In] COR_PRF_SUSPEND_REASON suspendReason);

        /// <summary>
        /// Notifies the profiler that the runtime has completed suspension of all runtime threads.
        /// </summary>
        /// <remarks>
        /// All runtime threads that are in unmanaged code are allowed to continue running until they try to re-enter the runtime.
        /// At that point they will also be suspended until the runtime resumes. This also applies to new threads that enter
        /// the runtime. All threads in the runtime are either suspended immediately if they are already in interruptible code,
        /// or they are asked to suspend when they reach interruptible code. The RuntimeSuspendFinished callback is guaranteed
        /// to occur on the same thread as the <see cref="RuntimeSuspendStarted"/> callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RuntimeSuspendFinished();

        /// <summary>
        /// Notifies the profiler that the runtime has aborted the runtime suspension that was occurring.
        /// </summary>
        /// <remarks>
        /// The run-time suspension might be aborted if two threads simultaneously attempt to suspend the runtime. Either the
        /// <see cref="RuntimeSuspendFinished"/> callback or the RuntimeSuspendAborted callback will occur on a single thread
        /// following a <see cref="RuntimeSuspendStarted"/> callback. The RuntimeSuspendAborted callback is guaranteed to occur
        /// on the same thread as the RuntimeSuspendStarted callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RuntimeSuspendAborted();

        /// <summary>
        /// Notifies the profiler that the runtime is resuming all run-time threads.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RuntimeResumeStarted();

        /// <summary>
        /// Notifies the profiler that the runtime has resumed all runtime threads and has returned to normal operation.
        /// </summary>
        /// <remarks>
        /// The RuntimeResumeFinished callback is not guaranteed to occur on the same thread as the <see cref="RuntimeSuspendStarted"/>
        /// callback. However, it is guaranteed to occur on the same thread as the <see cref="RuntimeResumeStarted"/> callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RuntimeResumeFinished();

        /// <summary>
        /// Notifies the profiler that the specified thread has been suspended or is about to be suspended.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread that has been suspended.</param>
        /// <remarks>
        /// The RuntimeThreadSuspended notification can occur any time between the <see cref="RuntimeSuspendStarted"/> and
        /// the associated <see cref="RuntimeResumeStarted"/> callbacks. Notifications that occur between <see cref="RuntimeSuspendFinished"/>
        /// and RuntimeResumeStarted are for threads that had been running in unmanaged code and were suspended upon entry
        /// to the runtime. Generally, this callback occurs just after a thread is suspended. However, if the currently executing
        /// thread (the thread that called this callback) is the one that is being suspended, this callback will occur just
        /// before the thread is suspended.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RuntimeThreadSuspended(
            [In] ThreadID threadId);

        /// <summary>
        /// Notifies the profiler that the specified thread has resumed after being suspended.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread that has been resumed.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RuntimeThreadResumed(
            [In] ThreadID threadId);

        /// <summary>
        /// Called to report the new layout of objects in the heap as a result of a compacting garbage collection.
        /// </summary>
        /// <param name="cMovedObjectIDRanges">[in] The number of blocks of contiguous objects that moved as the result of the compacting garbage collection. That is, the value of cMovedObjectIDRanges is the total size of the oldObjectIDRangeStart, newObjectIDRangeStart, and cObjectIDRangeLength arrays.<para/>
        /// The next three arguments of MovedReferences are parallel arrays. In other words, oldObjectIDRangeStart[i], newObjectIDRangeStart[i], and cObjectIDRangeLength[i] all concern a single block of contiguous objects.</param>
        /// <param name="oldObjectIDRangeStart">[in] An array of ObjectID values, each of which is the old (pre-garbage collection) starting address of a block of contiguous, live objects in memory.</param>
        /// <param name="newObjectIDRangeStart">[in] An array of ObjectID values, each of which is the new (post-garbage collection) starting address of a block of contiguous, live objects in memory.</param>
        /// <param name="cObjectIDRangeLength">[in] An array of integers, each of which is the size of a block of contiguous objects in memory. A size is specified for each block that is referenced in the oldObjectIDRangeStart and newObjectIDRangeStart arrays.</param>
        /// <remarks>
        /// A compacting garbage collector reclaims the memory occupied by dead objects and compacts that freed space. As a
        /// result, live objects might be moved within the heap, and ObjectID values distributed by previous notifications
        /// might change. Assume that an existing ObjectID value (oldObjectID) lies within the following range: oldObjectIDRangeStart[i]
        /// &lt;= oldObjectID &lt; oldObjectIDRangeStart[i] + cObjectIDRangeLength[i] In this case, the offset from the start
        /// of the range to the start of the object is as follows: oldObjectID - oldObjectRangeStart[i] For any value of i
        /// that is in the following range: 0 &lt;= i &lt; cMovedObjectIDRanges you can calculate the new ObjectID as follows:
        /// newObjectID = newObjectIDRangeStart[i] + (oldObjectID – oldObjectIDRangeStart[i]) None of the ObjectID values passed
        /// by MovedReferences are valid during the callback itself, because the garbage collection might be in the middle
        /// of moving objects from old locations to new locations. Therefore, profilers should not attempt to inspect objects
        /// during a MovedReferences call. A <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/> callback indicates
        /// that all objects have been moved to their new locations and inspection can be performed.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT MovedReferences(
            [In] int cMovedObjectIDRanges,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ObjectID[] oldObjectIDRangeStart,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ObjectID[] newObjectIDRangeStart,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] cObjectIDRangeLength);

        /// <summary>
        /// Notifies the profiler that memory within the heap has been allocated for an object.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object for which memory was allocated.</param>
        /// <param name="classId">[in] The ID of the class of which the object is an instance.</param>
        /// <remarks>
        /// The ObjectedAllocated method is not called for allocations from either the stack or unmanaged memory. The classId
        /// parameter can refer to a class in managed code that has not been loaded yet. The profiler will receive a class
        /// load callback for that class immediately after the ObjectAllocated callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ObjectAllocated(
            [In] ObjectID objectId,
            [In] ClassID classId);

        /// <summary>
        /// Notifies the profiler about the number of instances of each specified class that have been created since the most recent garbage collection.
        /// </summary>
        /// <param name="cClassCount">[in] The size of the classIds and cObjects arrays.</param>
        /// <param name="classIds">[in] An array of class IDs, where each ID specifies a class with one or more instances.</param>
        /// <param name="cObjects">[in] An array of integers, where each integer specifies the number of instances for the corresponding class in the classIds array.</param>
        /// <remarks>
        /// The classIds and cObjects arrays are parallel arrays. For example, classIds[i] and cObjects[i] reference the same
        /// class. If no instance of a class has been created since the previous garbage collection, the class is omitted.
        /// The ObjectsAllocatedByClass callback will not report objects allocated in the large object heap. The numbers reported
        /// by ObjectsAllocatedByClass are only estimates. For exact counts, use <see cref="ObjectAllocated"/>. The classIds
        /// array may contain one or more null entries if the corresponding cObjects array has types that are unloading.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ObjectsAllocatedByClass(
            [In] int cClassCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ClassID[] classIds,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] cObjects);

        /// <summary>
        /// Notifies the profiler about objects in memory that are being referenced by the specified object.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object that is referencing objects.</param>
        /// <param name="classId">[in] The ID of the class that the specified object is an instance of.</param>
        /// <param name="cObjectRefs">[in] The number of objects referenced by the specified object (that is, the number of elements in the objectRefIds array).</param>
        /// <param name="objectRefIds">[in] An array of IDs of objects that are being referenced by objectId.</param>
        /// <remarks>
        /// The ObjectReferences method is called for each object remaining in the heap after a garbage collection has completed.
        /// If the profiler returns an error from this callback, the profiling services will discontinue invoking this callback
        /// until the next garbage collection. The ObjectReferences callback can be used in conjunction with the <see cref="RootReferences"/>
        /// callback to create a complete object reference graph for the runtime. The common language runtime (CLR) ensures
        /// that each object reference is reported only once by the ObjectReferences method. The object IDs returned by ObjectReferences
        /// are not valid during the callback itself, because the garbage collection might be in the middle of moving objects.
        /// Therefore, profilers must not attempt to inspect objects during an ObjectReferences call. When <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/>
        /// is called, the garbage collection is complete and inspection can be safely done. A null ClassId indicates that
        /// objectId has a type that is unloading.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ObjectReferences(
            [In] ObjectID objectId,
            [In] ClassID classId,
            [In] int cObjectRefs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ObjectID[] objectRefIds);

        /// <summary>
        /// Notifies the profiler with information about root references after garbage collection.
        /// </summary>
        /// <param name="cRootRefs">[in] The number of references in the rootRefIds array.</param>
        /// <param name="rootRefIds">[in] An array of object IDs that reference either a static object or an object on the stack.</param>
        /// <remarks>
        /// Both RootReferences and <see cref="ICorProfilerCallback2.RootReferences2"/> are called to notify the profiler.
        /// Profilers will normally implement one or the other, but not both, because the information passed in RootReferences2
        /// is a superset of that passed in RootReferences. It is possible for the rootRefIds array to contain a null object.
        /// For example, all object references declared on the stack are treated as roots by the garbage collector and will
        /// always be reported. The object IDs returned by RootReferences are not valid during the callback itself, because
        /// the garbage collection might be in the middle of moving objects from old addresses to new addresses. Therefore,
        /// profilers must not attempt to inspect objects during a RootReferences call. When <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/>
        /// is called, all objects have been moved to their new locations and can be safely inspected.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RootReferences(
            [In] int cRootRefs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ObjectID[] rootRefIds);

        /// <summary>
        /// Notifies the profiler that an exception has been thrown.
        /// </summary>
        /// <param name="thrownObjectId">[in] The ID of the object that caused the exception to be thrown.</param>
        /// <remarks>
        /// The profiler should not block in its implementation of this method because the stack may not be in a state that
        /// allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks
        /// here and garbage collection is attempted, the runtime will block until this callback returns. The profiler's implementation
        /// of this method should not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionThrown(
            [In] ObjectID thrownObjectId);

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has begun searching a function to find a handler for the current exception.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that has been entered.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionSearchFunctionEnter(
            [In] FunctionID functionId);

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has finished searching a function.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionSearchFunctionLeave();

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has begun executing a user-defined exception filter.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the filter.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionSearchFilterEnter(
            [In] FunctionID functionId);

        /// <summary>
        /// Notifies the profiler that a user filter has just finished executing.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionSearchFilterLeave();

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has located a handler for the exception that was thrown.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the exception handler.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionSearchCatcherFound(
            [In] FunctionID functionId);

        /// <summary>
        /// Not implemented. A profiler that needs unmanaged exception information must obtain this information through other means.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionOSHandlerEnter(
            [In] IntPtr __unused);

        /// <summary>
        /// Not implemented. A profiler that needs unmanaged exception information must obtain this information through other means.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionOSHandlerLeave(
            [In] IntPtr __unused);

        /// <summary>
        /// Notifies the profiler that the unwind phase of exception handling has begun to unwind a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that is being unwound.</param>
        /// <remarks>
        /// The profiler should not block in its implementation of this method because the stack may not be in a state that
        /// allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks
        /// here and garbage collection is attempted, the runtime will block until this callback returns. The profiler's implementation
        /// of this method should not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionUnwindFunctionEnter(
            [In] FunctionID functionId);

        /// <summary>
        /// Notifies the profiler that the unwind phase of exception handling has finished unwinding a function.
        /// </summary>
        /// <remarks>
        /// When the ExceptionUnwindFunctionLeave method is called, the function instance and its stack data are removed from
        /// the stack. The profiler should not block during this call because the stack may not be in a state that allows garbage
        /// collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and a garbage
        /// collection is attempted, the runtime will block until this callback returns. Also, during this call, the profiler
        /// must not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionUnwindFunctionLeave();

        /// <summary>
        /// Notifies the profiler that the unwind phase of exception handling is entering a finally clause contained in the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the finally clause.</param>
        /// <remarks>
        /// The profiler should not block in its implementation of this method because the stack may not be in a state that
        /// allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks
        /// here and garbage collection is attempted, the runtime will block until this callback returns. The profiler's implementation
        /// of this method should not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionUnwindFinallyEnter(
            [In] FunctionID functionId);

        /// <summary>
        /// Notifies the profiler that the unwind phase of exception handling has left a finally clause.
        /// </summary>
        /// <remarks>
        /// The profiler should not block during this call because the stack may not be in a state that allows garbage collection,
        /// and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and a garbage collection
        /// is attempted, the runtime will block until this callback returns. Also, during this call, the profiler must not
        /// call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionUnwindFinallyLeave();

        /// <summary>
        /// Notifies the profiler that control is being passed to the appropriate catch block.
        /// </summary>
        /// <param name="functionId">[in] The identifier of the function containing the catch block.</param>
        /// <param name="objectId">[in] The identifier of the exception being handled.</param>
        /// <remarks>
        /// The ExceptionCatcherEnter method is called only if the catch point is in code compiled with the just-in-time (JIT)
        /// compiler. An exception that is caught in unmanaged code or in the internal code of the runtime will not call this
        /// notification. The objectId value is passed again since a garbage collection could have moved the object since the
        /// ExceptionThrown notification. The profiler should not block in its implementation of this method because the stack
        /// may not be in a state that allows garbage collection, and therefore preemptive garbage collection cannot be enabled.
        /// If the profiler blocks here and garbage collection is attempted, the runtime will block until this callback returns.
        /// The profiler's implementation of this method should not call into managed code or in any way cause a managed-memory
        /// allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionCatcherEnter(
            [In] FunctionID functionId,
            [In] ObjectID objectId);

        /// <summary>
        /// Notifies the profiler that control is being passed out of the appropriate catch block.
        /// </summary>
        /// <remarks>
        /// The profiler should not block in its implementation of this method because the stack may not be in a state that
        /// allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks
        /// here and garbage collection is attempted, the runtime will block until this callback returns. The profiler's implementation
        /// of this method should not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionCatcherLeave();

        /// <summary>
        /// Notifies the profiler that a COM interop vtable for the specified IID and class has been created.
        /// </summary>
        /// <param name="wrappedClassId">[in] The ID of the class for which the vtable has been created.</param>
        /// <param name="implementedIID">[in] The ID of the interface implemented by the class. This value may be NULL if the interface is internal only.</param>
        /// <param name="pVTable">[in] A pointer to the start of the vtable.</param>
        /// <param name="cSlots">[in] The number of slots that are in the vtable.</param>
        /// <remarks>
        /// The profiler should not block in its implementation of this method because the stack may not be in a state that
        /// allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks
        /// here and garbage collection is attempted, the runtime will block until this callback returns. The profiler's implementation
        /// of this method should not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT COMClassicVTableCreated(
            [In] ClassID wrappedClassId,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid implementedIID,
            [In] IntPtr pVTable,
            [In] int cSlots);

        /// <summary>
        /// Notifies the profiler that a COM interop vtable is being destroyed.
        /// </summary>
        /// <param name="wrappedClassId">[in] The ID of the class for which this vtable was created.</param>
        /// <param name="implementedIID">[in] The ID of the interface implemented by the class. This value may be NULL if the interface is internal only.</param>
        /// <param name="pVTable">[in] A pointer to the start of the vtable.</param>
        /// <remarks>
        /// The profiler should not block in its implementation of this method because the stack may not be in a state that
        /// allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks
        /// here and garbage collection is attempted, the runtime will block until this callback returns. The profiler's implementation
        /// of this method should not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT COMClassicVTableDestroyed(
            [In] ClassID wrappedClassId,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid implementedIID,
            [In] IntPtr pVTable);

        /// <summary>
        /// Called when a catch block for an exception is found inside the common language runtime (CLR) itself. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionCLRCatcherFound();

        /// <summary>
        /// Called when a catch block for an exception is executed inside the common language runtime (CLR) itself. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionCLRCatcherExecute();
    }
}
