using System;
using System.Reflection;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

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
    /// it wants to receive notification by calling <see cref="CorProfilerInfo.EventMask"/>. This is usually done in
    /// the profiler's implementation of <see cref="Initialize"/>. The profiler is then able to receive notification from
    /// the runtime when an event is about to occur or has just occurred in an executing runtime process.
    /// </remarks>
#if GENERATED_MARSHALLING
    [GeneratedComClass]
#endif
    public abstract partial class CorProfilerCallback : ICorProfilerCallback11
    {
        #region ICorProfilerCallback

        /// <summary>
        /// Called to initialize the code profiler whenever a new common language runtime (CLR) application is started.
        /// </summary>
        /// <param name="pICorProfilerInfoUnk">[in] Pointer to an IUnknown interface that the profiler must query for an <see cref="ICorProfilerInfo"/> interface pointer.</param>
        /// <remarks>
        /// The Initialize call is the only opportunity to enable (or disable) callbacks that are immutable. Once a callback
        /// is enabled by the Initialize call, it cannot be disabled later using <see cref="ICorProfilerInfo.SetEventMask"/>.
        /// The COR_PRF_MONITOR_IMMUTABLE value of the <see cref="COR_PRF_MONITOR"/> enumeration indicates which events are immutable.
        /// </remarks>
        public virtual HRESULT Initialize(object pICorProfilerInfoUnk)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT Shutdown()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that an application domain is being created.
        /// </summary>
        /// <param name="appDomainId">[in] Identifies the domain which is being created.</param>
        /// <remarks>
        /// The ID is not valid for any information request until the <see cref="AppDomainCreationFinished"/> method is called.
        /// </remarks>
        public virtual HRESULT AppDomainCreationStarted(AppDomainID appDomainId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT AppDomainCreationFinished(AppDomainID appDomainId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that an application domain is being unloaded from a process.
        /// </summary>
        /// <param name="appDomainId">[in] Identifies the domain in which the application's assemblies are stored.</param>
        /// <remarks>
        /// The value of appDomainId is not valid for any information request after the AppDomainShutdownStarted method returns
        /// — this is the profiler's last chance to get information about this application domain.
        /// </remarks>
        public virtual HRESULT AppDomainShutdownStarted(AppDomainID appDomainId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT AppDomainShutdownFinished(AppDomainID appDomainId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that an assembly is being loaded.
        /// </summary>
        /// <param name="assemblyId">[in] Identifies the assembly that is being loaded.</param>
        /// <remarks>
        /// The value of assemblyId is not valid for an information request until the <see cref="AssemblyLoadFinished"/> method
        /// is called.
        /// </remarks>
        public virtual HRESULT AssemblyLoadStarted(AssemblyID assemblyId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT AssemblyLoadFinished(AssemblyID assemblyId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that an assembly is being unloaded.
        /// </summary>
        /// <param name="assemblyId">[in] Identifies the assembly that is being unloaded.</param>
        /// <remarks>
        /// The value of assemblyId is not valid for an information request after the AssemblyUnloadStarted method returns
        /// — this is the profiler's last chance to get information about this assembly.
        /// </remarks>
        public virtual HRESULT AssemblyUnloadStarted(AssemblyID assemblyId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT AssemblyUnloadFinished(AssemblyID assemblyId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a module is being loaded.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that is being loaded.</param>
        /// <remarks>
        /// The value of moduleId is not valid for an information request until the <see cref="ModuleLoadFinished"/> method
        /// is called.
        /// </remarks>
        public virtual HRESULT ModuleLoadStarted(ModuleID moduleId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ModuleLoadFinished(ModuleID moduleId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a module is being unloaded.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that is being unloaded.</param>
        /// <remarks>
        /// The value of moduleId is not valid for an information request after the ModuleUnloadStarted method returns — this
        /// is the profiler's last chance to get information about this module.
        /// </remarks>
        public virtual HRESULT ModuleUnloadStarted(ModuleID moduleId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ModuleUnloadFinished(ModuleID moduleId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ModuleAttachedToAssembly(ModuleID moduleId, AssemblyID assemblyId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a class is being loaded.
        /// </summary>
        /// <param name="classId">[in] Identifies the class that is being loaded.</param>
        /// <remarks>
        /// The value of classId is not valid for an information request until the <see cref="ClassLoadFinished"/> method is
        /// called.
        /// </remarks>
        public virtual HRESULT ClassLoadStarted(ClassID classId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ClassLoadFinished(ClassID classId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a class is being unloaded.
        /// </summary>
        /// <param name="classId">[in] Identifies the class that is being unloaded.</param>
        /// <remarks>
        /// The value of classId is not valid for an information request after the ClassUnloadStarted method returns — this
        /// is the profiler's last chance to obtain information about this class.
        /// </remarks>
        public virtual HRESULT ClassUnloadStarted(ClassID classId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ClassUnloadFinished(ClassID classId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the runtime has started to unload a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that is being unloaded.</param>
        /// <remarks>
        /// The value of the functionId parameter is no longer valid after this method returns to the caller.
        /// </remarks>
        public virtual HRESULT FunctionUnloadStarted(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT JITCompilationStarted(FunctionID functionId, bool fIsSafeToBlock)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler has finished compiling a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that was compiled.</param>
        /// <param name="hrStatus">[in] A value indicating whether compilation was successful.</param>
        /// <param name="fIsSafeToBlock">[in] A value indicating to the profiler whether blocking will affect the operation of the runtime. The value is true if blocking may cause the runtime to wait for the calling thread to return from this callback; otherwise, false.<para/>
        /// Although a value of true will not harm the runtime, it can skew the profiling results.</param>
        public virtual HRESULT JITCompilationFinished(FunctionID functionId, HRESULT hrStatus, bool fIsSafeToBlock)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT JITCachedFunctionSearchStarted(FunctionID functionId, out bool pbUseCachedFunction)
        {
            pbUseCachedFunction = default(bool);

            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT JITCachedFunctionSearchFinished(FunctionID functionId, COR_PRF_JIT_CACHE result)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT JITFunctionPitched(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler is about to insert a function in line with another function.
        /// </summary>
        /// <param name="callerId">[in] The ID of the function into which the calleeId function will be inserted.</param>
        /// <param name="calleeId">[in] The ID of the function to be inserted.</param>
        /// <param name="pfShouldInline">[out] true to allow the insertion to occur; otherwise, false.</param>
        /// <remarks>
        /// The profiler can set pfShouldInline to false to prevent the calleeId function from being inserted into the callerId
        /// function. Also, the profiler can globally disable inline insertion by using the COR_PRF_DISABLE_INLINING value
        /// of the <see cref="COR_PRF_MONITOR"/> enumeration. Functions inserted inline do not raise events for entering or leaving. Therefore,
        /// the profiler must set pfShouldInline to false in order to produce an accurate callgraph. Setting pfShouldInline
        /// to false will affect performance, because inline insertion typically increases speed and reduces the number of
        /// separate JIT compilation events for the inserted method.
        /// </remarks>
        public virtual HRESULT JITInlining(FunctionID callerId, FunctionID calleeId, out bool pfShouldInline)
        {
            pfShouldInline = default(bool);

            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a thread has been created.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread that has been created.</param>
        /// <remarks>
        /// The threadId value is immediately valid.
        /// </remarks>
        public virtual HRESULT ThreadCreated(ThreadID threadId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a thread has been destroyed.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread that has been destroyed.</param>
        /// <remarks>
        /// The threadId value is no longer valid at the time of this call.
        /// </remarks>
        public virtual HRESULT ThreadDestroyed(ThreadID threadId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a managed thread is being implemented using a particular operating system thread.
        /// </summary>
        /// <param name="managedThreadId">[in] The identifier of the managed thread.</param>
        /// <param name="osThreadId">[in] The identifier of the operating system thread.</param>
        /// <remarks>
        /// The ThreadAssignedToOSThread callback exists so that the profiler can maintain an accurate mapping across fibers
        /// of operating system threads to managed threads.
        /// </remarks>
        public virtual HRESULT ThreadAssignedToOSThread(ThreadID managedThreadId, int osThreadId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a remoting call has started.
        /// </summary>
        /// <remarks>
        /// This event is the same for synchronous and asynchronous calls. Each of the following pairs of callbacks will occur
        /// on the same thread: You should be aware of the following issues with the remoting callbacks:
        /// </remarks>
        public virtual HRESULT RemotingClientInvocationStarted()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the client is sending a request to the server.
        /// </summary>
        /// <param name="pCookie">[in] A value that corresponds with the value provided in <see cref="RemotingServerReceivingMessage"/> under these conditions: This allows easy pairing of remoting calls and the creation of a logical call stack.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        public virtual HRESULT RemotingClientSendingMessage(
#if GENERATED_MARSHALLING
            in
#endif
            Guid pCookie,
            bool fIsAsync)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the server-side portion of a remoting call has completed and the client is now receiving and about to process the reply.
        /// </summary>
        /// <param name="pCookie">[in] A value that will correspond with the value provided in <see cref="RemotingServerSendingReply"/> under these conditions: This allows easy pairing of remoting calls.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        public virtual HRESULT RemotingClientReceivingReply(
#if GENERATED_MARSHALLING
            in
#endif
            Guid pCookie,
            bool fIsAsync)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT RemotingClientInvocationFinished()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the process has received a remote method invocation or activation request.
        /// </summary>
        /// <param name="pCookie">[in] A value that will correspond with the value provided in <see cref="RemotingClientSendingMessage"/> under these conditions: This allows easy pairing of remoting calls and the creation of a logical call stack.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        /// <remarks>
        /// If the message request is asynchronous, the request can be serviced by any arbitrary thread.
        /// </remarks>
        public virtual HRESULT RemotingServerReceivingMessage(
#if GENERATED_MARSHALLING
            in
#endif
            Guid pCookie,
            bool fIsAsync)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the process is invoking a method in response to a remote method invocation request.
        /// </summary>
        public virtual HRESULT RemotingServerInvocationStarted()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the process has finished invoking a method in response to a remote method invocation request.
        /// </summary>
        public virtual HRESULT RemotingServerInvocationReturned()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the process has finished processing a remote method invocation request and is about to transmit the reply through a channel.
        /// </summary>
        /// <param name="pCookie">[in] A pointer to a GUID that will correspond with the value provided in <see cref="RemotingClientReceivingReply"/> under these conditions: This allows easy pairing of remoting calls and the creation of a logical call stack.</param>
        /// <param name="fIsAsync">[in] A value that is true if the call is asynchronous; otherwise, false.</param>
        public virtual HRESULT RemotingServerSendingReply(
#if GENERATED_MARSHALLING
            in
#endif
            Guid pCookie,
            bool fIsAsync)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT UnmanagedToManagedTransition(FunctionID functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ManagedToUnmanagedTransition(FunctionID functionId, COR_PRF_TRANSITION_REASON reason)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT RuntimeSuspendStarted(COR_PRF_SUSPEND_REASON suspendReason)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT RuntimeSuspendFinished()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the runtime has aborted the runtime suspension that was occurring.
        /// </summary>
        /// <remarks>
        /// The run-time suspension might be aborted if two threads simultaneously attempt to suspend the runtime. Either the
        /// <see cref="RuntimeSuspendFinished"/> callback or the RuntimeSuspendAborted callback will occur on a single thread
        /// following a <see cref="RuntimeSuspendStarted"/> callback. The RuntimeSuspendAborted callback is guaranteed to occur
        /// on the same thread as the RuntimeSuspendStarted callback.
        /// </remarks>
        public virtual HRESULT RuntimeSuspendAborted()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the runtime is resuming all run-time threads.
        /// </summary>
        public virtual HRESULT RuntimeResumeStarted()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the runtime has resumed all runtime threads and has returned to normal operation.
        /// </summary>
        /// <remarks>
        /// The RuntimeResumeFinished callback is not guaranteed to occur on the same thread as the <see cref="RuntimeSuspendStarted"/>
        /// callback. However, it is guaranteed to occur on the same thread as the <see cref="RuntimeResumeStarted"/> callback.
        /// </remarks>
        public virtual HRESULT RuntimeResumeFinished()
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT RuntimeThreadSuspended(ThreadID threadId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the specified thread has resumed after being suspended.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread that has been resumed.</param>
        public virtual HRESULT RuntimeThreadResumed(ThreadID threadId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT MovedReferences(int cMovedObjectIDRanges, ObjectID[] oldObjectIDRangeStart, ObjectID[] newObjectIDRangeStart, int[] cObjectIDRangeLength)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ObjectAllocated(ObjectID objectId, ClassID classId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ObjectsAllocatedByClass(int cClassCount, ClassID[] classIds, int[] cObjects)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ObjectReferences(ObjectID objectId, ClassID classId, int cObjectRefs, ObjectID[] objectRefIds)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT RootReferences(int cRootRefs, ObjectID[] rootRefIds)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ExceptionThrown(ObjectID thrownObjectId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has begun searching a function to find a handler for the current exception.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that has been entered.</param>
        public virtual HRESULT ExceptionSearchFunctionEnter(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has finished searching a function.
        /// </summary>
        public virtual HRESULT ExceptionSearchFunctionLeave()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has begun executing a user-defined exception filter.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the filter.</param>
        public virtual HRESULT ExceptionSearchFilterEnter(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that a user filter has just finished executing.
        /// </summary>
        public virtual HRESULT ExceptionSearchFilterLeave()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the search phase of exception handling has located a handler for the exception that was thrown.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the exception handler.</param>
        public virtual HRESULT ExceptionSearchCatcherFound(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Not implemented. A profiler that needs unmanaged exception information must obtain this information through other means.
        /// </summary>
        public virtual HRESULT ExceptionOSHandlerEnter(IntPtr __unused)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Not implemented. A profiler that needs unmanaged exception information must obtain this information through other means.
        /// </summary>
        public virtual HRESULT ExceptionOSHandlerLeave(IntPtr __unused)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ExceptionUnwindFunctionEnter(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ExceptionUnwindFunctionLeave()
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ExceptionUnwindFinallyEnter(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the unwind phase of exception handling has left a finally clause.
        /// </summary>
        /// <remarks>
        /// The profiler should not block during this call because the stack may not be in a state that allows garbage collection,
        /// and therefore preemptive garbage collection cannot be enabled. If the profiler blocks here and a garbage collection
        /// is attempted, the runtime will block until this callback returns. Also, during this call, the profiler must not
        /// call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        public virtual HRESULT ExceptionUnwindFinallyLeave()
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT ExceptionCatcherEnter(FunctionID functionId, ObjectID objectId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that control is being passed out of the appropriate catch block.
        /// </summary>
        /// <remarks>
        /// The profiler should not block in its implementation of this method because the stack may not be in a state that
        /// allows garbage collection, and therefore preemptive garbage collection cannot be enabled. If the profiler blocks
        /// here and garbage collection is attempted, the runtime will block until this callback returns. The profiler's implementation
        /// of this method should not call into managed code or in any way cause a managed-memory allocation.
        /// </remarks>
        public virtual HRESULT ExceptionCatcherLeave()
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT COMClassicVTableCreated(
            ClassID wrappedClassId,
#if GENERATED_MARSHALLING
            in
#endif
            Guid implementedIID,
            IntPtr pVTable,
            int cSlots)
        {
            return HRESULT.E_NOTIMPL;
        }

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
        public virtual HRESULT COMClassicVTableDestroyed(
            ClassID wrappedClassId,
#if GENERATED_MARSHALLING
            in
#endif
            Guid implementedIID,
            IntPtr pVTable)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Called when a catch block for an exception is found inside the common language runtime (CLR) itself. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        public virtual HRESULT ExceptionCLRCatcherFound()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Called when a catch block for an exception is executed inside the common language runtime (CLR) itself. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        public virtual HRESULT ExceptionCLRCatcherExecute()
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback2

        /// <summary>
        /// Notifies the code profiler that the name of a thread has changed.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread.</param>
        /// <param name="cchName">[in] The length of the new name of the thread.</param>
        /// <param name="name">[in] The new name of the thread. The name is not null-terminated.</param>
        public virtual HRESULT ThreadNameChanged(ThreadID threadId, int cchName, string name)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the code profiler that garbage collection has started.
        /// </summary>
        /// <param name="cGenerations">[in] The total number of entries in the generationCollected array.</param>
        /// <param name="generationCollected">[in] An array of Boolean values, which are true if the generation that corresponds to the array index is being collected by this garbage collection; otherwise, false.<para/>
        /// The array is indexed by a value of the <see cref="COR_PRF_GC_GENERATION"/> enumeration, which indicates the generation.</param>
        /// <param name="reason">[in] A value of the <see cref="COR_PRF_GC_REASON"/> enumeration that indicates the reason the garbage collection was induced.</param>
        /// <remarks>
        /// All callbacks that pertain to this garbage collection will occur between the GarbageCollectionStarted callback
        /// and the corresponding <see cref="GarbageCollectionFinished"/> callback. These callbacks need not occur on the same
        /// thread. It is safe for the profiler to inspect objects in their original locations during the GarbageCollectionStarted
        /// callback. The garbage collector will begin moving objects after the return from GarbageCollectionStarted. After
        /// the profiler has returned from this callback, the profiler should consider all object IDs to be invalid until it
        /// receives a ICorProfilerCallback2::GarbageCollectionFinished callback.
        /// </remarks>
        public virtual HRESULT GarbageCollectionStarted(int cGenerations, bool[] generationCollected, COR_PRF_GC_REASON reason)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Reports the layout of objects in the heap as a result of a non-compacting garbage collection.
        /// </summary>
        /// <param name="cSurvivingObjectIDRanges">[in] The number of blocks of contiguous objects that survived as the result of the non-compacting garbage collection.<para/>
        /// That is, the value of cSurvivingObjectIDRanges is the size of the objectIDRangeStart and cObjectIDRangeLength arrays, which store an ObjectID and a length, respectively, for each block of objects.<para/>
        /// The next two arguments of SurvivingReferences are parallel arrays. In other words, objectIDRangeStart and cObjectIDRangeLength concern the same block of contiguous objects.</param>
        /// <param name="objectIDRangeStart">[in] An array of ObjectID values, each of which is the starting address of a block of contiguous, live objects in memory.</param>
        /// <param name="cObjectIDRangeLength">[in] An array of integers, each of which is the size of a surviving block of contiguous objects in memory. A size is specified for each block that is referenced in the objectIDRangeStart array.</param>
        /// <remarks>
        /// The elements of the objectIDRangeStart and cObjectIDRangeLength arrays should be interpreted as follows to determine
        /// whether an object survived the garbage collection. Assume that an ObjectID value (ObjectID) lies within the following
        /// range: ObjectIDRangeStart[i] &lt;= ObjectID &lt; ObjectIDRangeStart[i] + cObjectIDRangeLength[i] For any value
        /// of i that is in the following range, the object has survived the garbage collection: 0 &lt;= i &lt; cSurvivingObjectIDRanges
        /// A non-compacting garbage collection reclaims the memory occupied by "dead" objects, but does not compact that freed
        /// space. As a result, memory is returned to the heap, but no "live" objects are moved. The common language runtime
        /// (CLR) calls SurvivingReferences for non-compacting garbage collections. For compacting garbage collections, <see
        /// cref="ICorProfilerCallback.MovedReferences"/> is called instead. A single garbage collection can be compacting
        /// for one generation and non-compacting for another. For a garbage collection on any particular generation, the profiler
        /// will receive either a SurvivingReferences callback or a MovedReferences callback, but not both. Multiple SurvivingReferences
        /// callbacks might be received during a particular garbage collection, due to limited internal buffering, multiple
        /// threads reporting in the case of server garbage collection, and other reasons. In the case of multiple callbacks
        /// during a garbage collection, the information is cumulative — all references that are reported in any SurvivingReferences
        /// callback survive the garbage collection.
        /// </remarks>
        public virtual HRESULT SurvivingReferences(int cSurvivingObjectIDRanges, ObjectID[] objectIDRangeStart, int[] cObjectIDRangeLength)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that garbage collection has completed and all garbage collection callbacks have been issued for it.
        /// </summary>
        /// <remarks>
        /// It is safe for the profiler to inspect objects in their final locations when the GarbageCollectionFinished method
        /// is called.
        /// </remarks>
        public virtual HRESULT GarbageCollectionFinished()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the code profiler that an object with a finalizer has been queued to the finalizer thread for execution of its Finalize method.
        /// </summary>
        /// <param name="finalizerFlags">[in] A value of the COR_PRF_FINALIZER_FLAGS enumeration that describes aspects of the finalizer.</param>
        /// <param name="objectID">[in] The ID of the object that has been queued.</param>
        public virtual HRESULT FinalizeableObjectQueued(COR_PRF_FINALIZER_FLAGS finalizerFlags, ObjectID objectID)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler about root references after a garbage collection has occurred. This method is an extension of the <see cref="ICorProfilerCallback.RootReferences"/> method.
        /// </summary>
        /// <param name="cRootRefs">[in] The number of elements in the rootRefIds, rootKinds, rootFlags, and rootIds arrays.</param>
        /// <param name="rootRefIds">[in] An array of object IDs, each of which references either a static object or an object on the stack. Elements in the rootKinds array provide information to classify corresponding elements in the rootRefIds array.</param>
        /// <param name="rootKinds">[in] An array of <see cref="COR_PRF_GC_ROOT_KIND"/> values that indicate the type of the garbage collection root.</param>
        /// <param name="rootFlags">[in] An array of <see cref="COR_PRF_GC_ROOT_FLAGS"/> values that describe the properties of a garbage collection root.</param>
        /// <param name="rootIds">[in] An array of UINT_PTR values that point to an integer that contains additional information about the garbage collection root, depending on the value of the rootKinds parameter.<para/>
        /// If the type of the root is a stack, the root ID is for the function that contains the variable. If that root ID is 0, the function is an unnamed function that is internal to the CLR.<para/>
        /// If the type of the root is a handle, the root ID is for the garbage collection handle. For the other root types, the ID is an opaque value and should be ignored.</param>
        /// <remarks>
        /// The rootRefIds, rootKinds, rootFlags, and rootIds arrays are parallel arrays. That is, rootRefIds[i], rootKinds[i],
        /// rootFlags[i], and rootIds[i] all concern the same root. Both RootReferences and RootReferences2 are called to notify
        /// the profiler. Profilers will normally implement one method or the other, but not both, because the information
        /// passed in RootReferences2 is a superset of that passed in RootReferences. It is possible for entries in rootRefIds
        /// to be zero, which implies that the corresponding root reference is null and does not refer to an object on the
        /// managed heap. The object IDs returned by RootReferences2 are not valid during the callback itself, because the
        /// garbage collection might be in the middle of moving objects from old addresses to new addresses. Therefore, profilers
        /// should not attempt to inspect objects during a RootReferences2 call. When <see cref="GarbageCollectionFinished"/>
        /// is called, all objects have been moved to their new locations and can be safely inspected.
        /// </remarks>
        public virtual HRESULT RootReferences2(int cRootRefs, ObjectID[] rootRefIds, COR_PRF_GC_ROOT_KIND[] rootKinds, COR_PRF_GC_ROOT_FLAGS[] rootFlags, IntPtr[] rootIds)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the code profiler that a garbage collection handle has been created.
        /// </summary>
        /// <param name="handleId">[in] The ID of the handle for the garbage collection.</param>
        /// <param name="initialObjectId">[in] The ID of the object for which the garbage collection handle was created.</param>
        public virtual HRESULT HandleCreated(GCHandleID handleId, ObjectID initialObjectId)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the code profiler that a garbage collection handle has been destroyed.
        /// </summary>
        /// <param name="handleId">[in] The ID of the handle for the garbage collection.</param>
        public virtual HRESULT HandleDestroyed(GCHandleID handleId)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback3

        /// <summary>
        /// Called by the common language runtime (CLR) to give the profiler an opportunity to initialize its state after an attach operation.
        /// </summary>
        /// <param name="pCorProfilerInfoUnk">[in] An interface pointer for the ICorProfilerInfo* interface.</param>
        /// <param name="pvClientData">[in] A pointer to the data passed to the <see cref="ICLRProfiling.AttachProfiler"/> method in its pvClientData parameter.<para/>
        /// If this parameter is null, cbClientData will be 0 (zero). The CLR frees this memory when it returns from InitializeForAttach.</param>
        /// <param name="cbClientData">[in] The size, in bytes, of the data that pvClientData points to.</param>
        /// <remarks>
        /// The CLR calls InitializeForAttach to give the profiler an opportunity to request callbacks.
        /// </remarks>
        public virtual HRESULT InitializeForAttach(object pCorProfilerInfoUnk, IntPtr pvClientData, int cbClientData)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Called by the common language runtime (CLR) to indicate that the profiler can now call the <see cref="ICorProfilerInfo3.EnumJITedFunctions"/> and <see cref="ICorProfilerInfo3.EnumModules"/> catch-up methods.
        /// </summary>
        /// <remarks>
        /// The ProfilerAttachComplete callback is issued after the <see cref="InitializeForAttach"/> method is called. It
        /// indicates the following: The CLR ignores the return value from this callback.
        /// </remarks>
        public virtual HRESULT ProfilerAttachComplete()
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the common language runtime (CLR) is about to unload the profiler DLL.
        /// </summary>
        /// <returns>The return value from this callback is ignored.</returns>
        /// <remarks>
        /// The ProfilerDetachSucceeded callback is issued after all threads have exited the profiler's code. When this method
        /// is called, the profiler should perform any last-minute tasks that are not appropriate for its destructor, such
        /// as notifying its UI or logging component. However, the profiler must not call functions on interfaces that are
        /// provided by the CLR during this callback (such as the <see cref="ICorProfilerInfo"/> or IMetaData* interfaces).
        /// The CLR creates an entry in the Windows Application event log to indicate that the detach operation is successful.
        /// After the profiler returns from this callback, the CLR releases the profiler object and unloads the profiler DLL.
        /// Therefore, the profiler must not perform any actions that would cause execution to occur inside the profiler DLL
        /// after it returns from this callback. For example, it must not create threads or register timer callbacks.
        /// </remarks>
        public virtual HRESULT ProfilerDetachSucceeded()
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback4

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler has started to recompile a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that the JIT compiler has started to recompile.</param>
        /// <param name="reJitId">[in] The recompilation ID of the new version of the function.</param>
        /// <param name="fIsSafeToBlock">[in] true to indicate that blocking may cause the runtime to wait for the calling thread to return from this callback; false to indicate that blocking will not affect the operation of the runtime.<para/>
        /// A value of true does not harm the runtime, but can affect the profiling results.</param>
        /// <remarks>
        /// It is possible to receive more than one pair of ReJITCompilationStarted and <see cref="ReJITCompilationFinished"/>
        /// method calls for each function because of the way the runtime handles class constructors. For example, the runtime
        /// starts to recompile method A, but the class constructor for class B needs to be run. Therefore, the runtime recompiles
        /// the constructor for class B and runs it. While the constructor is running, it makes a call to method A, which causes
        /// method A to be recompiled again. In this scenario, the first recompilation of method A is halted. However, both
        /// attempts to recompile method A are reported with JIT recompilation events. Profilers must support the sequence
        /// of JIT recompilation callbacks in cases where two threads are simultaneously making callbacks. For example, thread
        /// A calls ReJITCompilationStarted; however, before thread A calls <see cref="ReJITCompilationFinished"/>, thread
        /// B calls <see cref="ICorProfilerCallback.ExceptionSearchFunctionEnter"/> with the function ID from the ReJITCompilationStarted
        /// callback for thread A. It might appear that the function ID should not yet be valid because a call to <see cref="ReJITCompilationFinished"/>
        /// had not yet been received by the profiler. However, in this case, the function ID is valid.
        /// </remarks>
        public virtual HRESULT ReJITCompilationStarted(FunctionID functionId, ReJITID reJitId, bool fIsSafeToBlock)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Allows the code profiler to set alternate code generation flags for a new recompiled method body.
        /// </summary>
        /// <param name="moduleId">[in] The module that contains the method for which the CLR needs JIT recompilation parameters.</param>
        /// <param name="methodId">[in] The MethodDef of the method for which the CLR needs JIT recompilation parameters.</param>
        /// <param name="pFunctionControl">[in] A pointer to an <see cref="ICorProfilerFunctionControl"/> interface that the profiler can use to provide JIT recompilation information for the method being recompiled.</param>
        /// <remarks>
        /// The CLR issues a GetReJITParameters callback so that the profiler can specify the parameters for recompiling a
        /// given method. The GetReJITParameters callback is issued only once per function; the parameters supplied by the
        /// profiler apply to all instances of that function.
        /// </remarks>
        public virtual HRESULT GetReJITParameters(ModuleID moduleId, mdMethodDef methodId, ICorProfilerFunctionControl pFunctionControl)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler has finished recompiling a function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that was recompiled.</param>
        /// <param name="reJitId">[in] The identity of the JIT-recompiled function.</param>
        /// <param name="hrStatus">[in] A value that indicates whether the JIT recompilation was successful.</param>
        /// <param name="fIsSafeToBlock">[in] true to indicate that blocking may cause the runtime to wait for the calling thread to return from this callback; false to indicate that blocking will not affect the operation of the runtime.<para/>
        /// A value of true does not harm the runtime, but can affect the profiling results.</param>
        public virtual HRESULT ReJITCompilationFinished(FunctionID functionId, ReJITID reJitId, HRESULT hrStatus, bool fIsSafeToBlock)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler that the just-in-time (JIT) compiler encountered an error in the recompilation process.
        /// </summary>
        /// <param name="moduleId">[in] The ModuleID in which the failed recompilation attempt was made.</param>
        /// <param name="methodId">[in] The MethodDef of the method on which the failed recompilation attempt was made.</param>
        /// <param name="functionId">[in] The function instance that is being recompiled or marked for recompilation. This value may be NULL if the failure occurred on a per-method basis instead of a per-instantiation basis (for example, if the profiler specified an invalid metadata token for the method to be recompiled).</param>
        /// <param name="hrStatus">[in] An HRESULT that indicates the nature of the failure. See the Status HRESULTS section for a list of values.</param>
        /// <returns>Return values from this callback are ignored.</returns>
        public virtual HRESULT ReJITError(ModuleID moduleId, mdMethodDef methodId, FunctionID functionId, HRESULT hrStatus)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Called to report the new layout of objects in the heap as a result of a compacting garbage collection. This method is called if the profiler has implemented the <see cref="ICorProfilerCallback4"/> interface.<para/>
        /// This callback replaces the <see cref="ICorProfilerCallback.MovedReferences"/> method, because it can report larger ranges of objects whose lengths exceed what can be expressed in a ULONG.
        /// </summary>
        /// <param name="cMovedObjectIDRanges">[in] The number of blocks of contiguous objects that moved as the result of the compacting garbage collection. That is, the value of cMovedObjectIDRanges is the total size of the oldObjectIDRangeStart, newObjectIDRangeStart, and cObjectIDRangeLength arrays.<para/>
        /// The next three arguments of MovedReferences2 are parallel arrays. In other words, oldObjectIDRangeStart[i], newObjectIDRangeStart[i], and cObjectIDRangeLength[i] all concern a single block of contiguous objects.</param>
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
        /// by MovedReferences2 are valid during the callback itself, because the garbage collector might be in the middle
        /// of moving objects from old locations to new locations. Therefore, profilers should not attempt to inspect objects
        /// during a MovedReferences2 call. A <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/> callback indicates
        /// that all objects have been moved to their new locations and inspection can be performed. If the profiler implements
        /// both the <see cref="ICorProfilerCallback"/> and the <see cref="ICorProfilerCallback4"/> interfaces, the MovedReferences2
        /// method is called before the <see cref="ICorProfilerCallback.MovedReferences"/> method, but only if the MovedReferences2
        /// method returns successfully. Profilers can return an HRESULT that indicates failure from the MovedReferences2 method,
        /// to avoid calling the second method.
        /// </remarks>
        public virtual HRESULT MovedReferences2(int cMovedObjectIDRanges, ObjectID[] oldObjectIDRangeStart, ObjectID[] newObjectIDRangeStart, IntPtr[] cObjectIDRangeLength)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Reports the layout of objects in the heap as a result of a non-compacting garbage collection. This method is called if the profiler has implemented the <see cref="ICorProfilerCallback4"/> interface.<para/>
        /// This callback replaces the <see cref="ICorProfilerCallback2.SurvivingReferences"/> method, because it can report larger ranges of objects whose lengths exceed what can be expressed in a ULONG.
        /// </summary>
        /// <param name="cSurvivingObjectIDRanges">[in] The number of blocks of contiguous objects that survived as the result of the non-compacting garbage collection.<para/>
        /// That is, the value of cSurvivingObjectIDRanges is the size of the objectIDRangeStart and cObjectIDRangeLength arrays, which store an ObjectID and a length, respectively, for each block of objects.<para/>
        /// The next two arguments of SurvivingReferences2 are parallel arrays. In other words, objectIDRangeStart and cObjectIDRangeLength concern the same block of contiguous objects.</param>
        /// <param name="objectIDRangeStart">[in] An array of ObjectID values, each of which is the starting address of a block of contiguous, live objects in memory.</param>
        /// <param name="cObjectIDRangeLength">[in] An array of integers, each of which is the size of a surviving block of contiguous objects in memory. A size is specified for each block that is referenced in the objectIDRangeStart array.</param>
        /// <remarks>
        /// The elements of the objectIDRangeStart and cObjectIDRangeLength arrays should be interpreted as follows to determine
        /// whether an object survived the garbage collection. Assume that an ObjectID value (ObjectID) lies within the following
        /// range: ObjectIDRangeStart[i] &lt;= ObjectID &lt; ObjectIDRangeStart[i] + cObjectIDRangeLength[i] For any value
        /// of i that is in the following range, the object has survived the garbage collection: 0 &lt;= i &lt; cSurvivingObjectIDRanges
        /// A non-compacting garbage collection reclaims the memory occupied by "dead" objects, but does not compact that freed
        /// space. As a result, memory is returned to the heap, but no "live" objects are moved. The common language runtime
        /// (CLR) calls SurvivingReferences2 for non-compacting garbage collections. For compacting garbage collections, <see
        /// cref="MovedReferences2"/> is called instead. A single garbage collection can be compacting for one generation and
        /// non-compacting for another. For a garbage collection on any particular generation, the profiler will receive either
        /// a SurvivingReferences2 callback or a <see cref="MovedReferences2"/> callback, but not both. Multiple SurvivingReferences2
        /// callbacks might be received during a particular garbage collection, because of limited internal buffering, multiple
        /// callbacks during server garbage collection, and other reasons. In the case of multiple callbacks during a garbage
        /// collection, the information is cumulative; all references that are reported in any SurvivingReferences2 callback
        /// survive the garbage collection. If the profiler implements both the <see cref="ICorProfilerCallback"/> and the
        /// <see cref="ICorProfilerCallback4"/> interfaces, the SurvivingReferences2 method is called before the <see cref="ICorProfilerCallback2.SurvivingReferences"/>
        /// method, but only if SurvivingReferences2 returns successfully. Profilers can return an HRESULT that indicates failure
        /// from the SurvivingReferences2 method to avoid calling the second method.
        /// </remarks>
        public virtual HRESULT SurvivingReferences2(int cSurvivingObjectIDRanges, ObjectID[] objectIDRangeStart, IntPtr[] cObjectIDRangeLength)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback5

        /// <summary>
        /// Identifies the transitive closure of objects referenced by those roots through both direct member field references and through ConditionalWeakTable dependencies.
        /// </summary>
        /// <param name="cRootRefs">[in] The number of elements in the keyRefIds, valueRefIds, and rootIds arrays.</param>
        /// <param name="keyRefIds">[in] An array of object IDs, each of which contains the ObjectID for the primary element in the dependent handle pair.</param>
        /// <param name="valueRefIds">[in] An array of object IDs, each of which contains the ObjectID for the secondary element in the dependent handle pair.<para/>
        /// (keyRefIds[i] keeps valueRefIds[i] alive.)</param>
        /// <param name="rootIds">[in] An array of GCHandleID values that point to an integer that contains additional information about the garbage collection root.</param>
        /// <remarks>
        /// A profiler for the .NET Framework 4.5 or later versions implements the <see cref="ICorProfilerCallback5"/> interface
        /// and records the dependencies specified by the ConditionalWeakTableElementReferences method. ICorProfilerCallback5
        /// provides the complete set of dependencies among live objects represented by ConditionalWeakTable entries. These
        /// dependencies and the member field references specified by the <see cref="ICorProfilerCallback.ObjectReferences"/>
        /// method enable a managed profiler to generate the full object graph of live objects.
        /// </remarks>
        public virtual HRESULT ConditionalWeakTableElementReferences(int cRootRefs, ObjectID[] keyRefIds, ObjectID[] valueRefIds, GCHandleID[] rootIds)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback6

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Notifies the profiler that an assembly is in a very early loading stage, when the common language runtime performs an assembly reference closure walk.
        /// </summary>
        /// <param name="wszAssemblyPath">[in] The path and name of the assembly whose metadata will be modified.</param>
        /// <param name="pAsmRefProvider">[in] A pointer to the address of an <see cref="ICorProfilerAssemblyReferenceProvider"/> interface that specifies the assembly references to add.</param>
        /// <returns>Return values from this callback are ignored.</returns>
        /// <remarks>
        /// This callback is controlled by setting the COR_PRF_HIGH_MONITOR.COR_PRF_HIGH_ADD_ASSEMBLY_REFERENCES event mask
        /// flag when calling the <see cref="ICorProfilerInfo5.SetEventMask2"/> method. If the profiler registers for the <see
        /// cref="GetAssemblyReferences"/> callback method, the runtime passes the path and name of the assembly to be loaded,
        /// along with a pointer to an <see cref="ICorProfilerAssemblyReferenceProvider"/> interface object to that method.
        /// The profiler can then call the <see cref="ICorProfilerAssemblyReferenceProvider.AddAssemblyReference"/> method
        /// with a COR_PRF_ASSEMBLY_REFERENCE_INFO object for each target assembly it plans to reference from the assembly
        /// specified in the GetAssemblyReferences callback. Use the GetAssemblyReferences callback only if the profiler has
        /// to modify an assembly's metadata to add assembly references. (But note that the actual modification of an assembly's
        /// metadata is done in the <see cref="ICorProfilerCallback.ModuleLoadFinished"/>callback method.) The profiler should
        /// implement the GetAssemblyReferences callback method to inform the common language runtime (CLR) that assembly references
        /// will be added when the module has been loaded. This helps ensure that assembly sharing decisions made by the CLR
        /// during this early stage remain valid although the profiler plans to modify the metadata assembly references later.
        /// This can avoid some instances in which profiler metadata modifications cause an SECURITY_E_INCOMPATIBLE_SHARE error.
        /// The profiler uses the <see cref="ICorProfilerAssemblyReferenceProvider"/> object provided by this method to add
        /// assembly references to the CLR assembly reference closure walker. The <see cref="ICorProfilerAssemblyReferenceProvider"/>
        /// object should be used only from within this callback. Calls to the <see cref="ICorProfilerAssemblyReferenceProvider.AddAssemblyReference"/>
        /// method from this callback don't result in modified metadata, but only in a modified assembly reference closure
        /// walk. The profiler will still have to use an IMetaDataAssemblyEmit object to explicitly add assembly references
        /// from within the <see cref="ICorProfilerCallback.ModuleLoadFinished"/> callback for the referencing assembly, even
        /// if it implements the GetAssemblyReferences callback. The profiler should be prepared to receive duplicate calls
        /// to this callback for the same assembly, and should respond identically for each such duplicate call (by making
        /// the same set of <see cref="ICorProfilerAssemblyReferenceProvider.AddAssemblyReference"/> calls).
        /// </remarks>
        public virtual HRESULT GetAssemblyReferences(string wszAssemblyPath, ICorProfilerAssemblyReferenceProvider pAsmRefProvider)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback7

        /// <summary>
        /// [Supported in the .NET Framework 4.6.1 and later versions] Notifies the profiler whenever the symbol stream associated with an in-memory module is updated.
        /// </summary>
        /// <param name="moduleId">[in] The identifier of the in-memory module whose symbol stream is updated.</param>
        /// <remarks>
        /// This callback is controlled by setting the COR_PRF_HIGH_MONITOR.COR_PRF_HIGH_IN_MEMORY_SYMBOLS_UPDATED event mask
        /// flag when calling the <see cref="ICorProfilerInfo5.SetEventMask2"/> method. Even when symbols are provided up front
        /// in a call to one of the overloads of the managed <see cref="Assembly.Load(string)"/> methods that includes a rawSymbolStore
        /// argument to specify the symbols for the assembly, the runtime may not actually associate the symbolic data with
        /// the module until after the <see cref="ICorProfilerCallback.ModuleLoadFinished"/> callback has occurred. This event
        /// provides a later opportunity to collect symbols for such modules.
        /// </remarks>
        public virtual HRESULT ModuleInMemorySymbolsUpdated(ModuleID moduleId)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback8

        /// <summary>
        /// [Supported in the .NET Framework 4.7 and later versions] Notifies the profiler whenever JIT compilation of a dynamic method has started.
        /// </summary>
        /// <param name="functionId">[in] The identifier of the in-memory function for which JIT compilation is started.</param>
        /// <param name="fIsSafeToBlock">[in] true to indicate that blocking may cause the runtime to wait for the calling thread to return from this callback; false to indicate that blocking will not affect the operation of the runtime.</param>
        /// <param name="pILHeader">[in] A pointer to the first byte of the method's IL header.</param>
        /// <param name="cbILHeader">[in] The number of bytes in the IL header.</param>
        /// <remarks>
        /// This callback is triggered whenever a dynamic method is JIT-compiled. This includes various IL stubs and LCG methods.
        /// Its goal is to provide profiler writers with enough information to identify the compiled method to users. The pILHeader
        /// pointer is only valid during the callback.
        /// </remarks>
        public virtual HRESULT DynamicMethodJITCompilationStarted(FunctionID functionId, bool fIsSafeToBlock, IntPtr pILHeader, int cbILHeader)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.7 and later versions] Notifies the profiler whenever JIT compilation of a dynamic method has completed.
        /// </summary>
        /// <param name="functionId">[in] The identifier of the in-memory function for which JIT compilation is started.</param>
        /// <param name="hrStatus">[in] A value that indicates whether the JIT compilation was successful.</param>
        /// <param name="fIsSafeToBlock">[in] true to indicate that blocking may cause the runtime to wait for the calling thread to return from this callback; false to indicate that blocking will not affect the operation of the runtime.</param>
        /// <remarks>
        /// This callback is triggered whenever JIT compilation of a dynamic method has finished. This includes various IL
        /// stubs and LCG methods. Its goal is to provide profiler writers with enough information to identify the compiled
        /// method to users.
        /// </remarks>
        public virtual HRESULT DynamicMethodJITCompilationFinished(FunctionID functionId, HRESULT hrStatus, bool fIsSafeToBlock)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback9

        /// <summary>
        /// [Supported in the .NET Framework 4.7.2 and later versions] Notifies the profiler whenever a dynamic method is garbage collected and subsequently unloaded.
        /// </summary>
        /// <param name="functionId">[in] The identifier of the in-memory function that has been garbage collected and unloaded.</param>
        public virtual HRESULT DynamicMethodUnloaded(FunctionID functionId)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback10

        /// <summary>
        /// Notifies the profiler whenever an EventPipe event has been delivered to the profiler's currently active session.
        /// </summary>
        /// <param name="provider">[in] The provider that this event originated from.</param>
        /// <param name="eventId">[in] The ID of the event being delivered.</param>
        /// <param name="eventVersion">[in] The version of the event being delivered.</param>
        /// <param name="cbMetadataBlob">[in] The length, in bytes, of metadataBlob.</param>
        /// <param name="metadataBlob">[in] A pointer to the metadata blob for the event.</param>
        /// <param name="cbEventData">[in] The length, in bytes, of eventData.</param>
        /// <param name="eventData">[in] The payload for the event.</param>
        /// <param name="pActivityId">[in] A pointer to the GUID that represents the event's activity ID, or NULL.</param>
        /// <param name="pRelatedActivityId">[in] A pointer to the GUID that represents the event's related activity ID, or NULL.</param>
        /// <param name="eventThread">[in] The ID of the thread the event occurred on.</param>
        /// <param name="numStackFrames">[in] The number of elements in the stackFrames array.</param>
        /// <param name="stackFrames">[in] An array of code addresses representing the managed callstack of the event.</param>
        public virtual HRESULT EventPipeEventDelivered(
            EVENTPIPE_PROVIDER provider,
            int eventId,
            int eventVersion,
            int cbMetadataBlob,
            IntPtr metadataBlob,
            int cbEventData,
            IntPtr eventData,
#if GENERATED_MARSHALLING
            in
#endif
            Guid pActivityId,
#if GENERATED_MARSHALLING
            in
#endif
            Guid pRelatedActivityId,
            ThreadID eventThread,
            int numStackFrames,
            IntPtr[] stackFrames)
        {
            return HRESULT.E_NOTIMPL;
        }

        /// <summary>
        /// Notifies the profiler whenever an EventPipe provider is created.
        /// </summary>
        /// <param name="provider">[in] The provider that was created.</param>
        public virtual HRESULT EventPipeProviderCreated(EVENTPIPE_PROVIDER provider)
        {
            return HRESULT.E_NOTIMPL;
        }

        #endregion
        #region ICorProfilerCallback11

        public virtual HRESULT LoadAsNotficationOnly(out bool pbNotificationOnly)
        {
            pbNotificationOnly = default(bool);

            return HRESULT.E_NOTIMPL;
        }

        #endregion
    }
}
