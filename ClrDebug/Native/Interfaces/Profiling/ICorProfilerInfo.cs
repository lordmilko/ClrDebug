using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    public delegate void FunctionEnter([In] FunctionID funcID);
    public delegate void FunctionLeave([In] FunctionID funcID);
    public delegate void FunctionTailcall([In] FunctionID funcID);

    public unsafe delegate void FunctionEnter2(
        [In] FunctionID funcId,
        [In] IntPtr clientData,
        [In] COR_PRF_FRAME_INFO func,
        [In] COR_PRF_FUNCTION_ARGUMENT_INFO* argumentInfo);

    public unsafe delegate void FunctionLeave2(
        [In] FunctionID funcId,
        [In] IntPtr clientData,
        [In] COR_PRF_FRAME_INFO func,
        [In] COR_PRF_FUNCTION_ARGUMENT_RANGE* retvalRange);

    public delegate void FunctionTailcall2(
        [In] FunctionID funcId,
        [In] IntPtr clientData,
        [In] COR_PRF_FRAME_INFO func);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate IntPtr FunctionIDMapper(
        [In] FunctionID funcId,
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pbHookFunction);

    /// <summary>
    /// Provides methods for use by code profilers to communicate with the common language runtime (CLR) to control event monitoring and request information.
    /// </summary>
    /// <remarks>
    /// A profiler calls a method in the ICorProfilerInfo interface to communicate with the CLR to control event monitoring
    /// and request information. The methods of the ICorProfilerInfo interface are implemented by the CLR using the free-threaded
    /// model. Each method returns an HRESULT to indicate success or failure. See CorError.h for a list of possible return
    /// codes. The CLR passes, via the profiler's implementation of <see cref="ICorProfilerCallback.Initialize"/>, an ICorProfilerInfo
    /// interface to each code profiler during initialization. A code profiler can then call methods of the ICorProfilerInfo
    /// interface to get information about managed code being executed under the control of the CLR.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComConversionLoss]
    [Guid("28B5557D-3F3F-48B4-90B2-5F9EEA2F6C48")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorProfilerInfo
    {
        /// <summary>
        /// Gets the ClassID of an object, given its ObjectID.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object for which to get the ClassID.</param>
        /// <param name="pClassId">[out] A pointer to the returned ClassID.</param>
        /// <remarks>
        /// A null pClassId indicates that objectId has a type that is unloading.
        /// </remarks>
        [PreserveSig]
        HRESULT GetClassFromObject(
            [In] ObjectID objectId,
            [Out] out ClassID pClassId);

        /// <summary>
        /// Gets the ID of the class, given the metadata token. This method is obsolete in .NET Framework version 2.0. Use <see cref="ICorProfilerInfo2.GetClassFromTokenAndTypeArgs"/> instead.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that contains the class.</param>
        /// <param name="typeDef">[in] An mdTypeDef metadata token that references the class.</param>
        /// <param name="pClassId">[out] A pointer to the class ID.</param>
        /// <remarks>
        /// This method is obsolete; instead, use ICorProfilerInfo2::GetClassFromTokenAndTypeArgs for all types.
        /// </remarks>
        [PreserveSig]
        HRESULT GetClassFromToken(
            [In] ModuleID moduleId,
            [In] mdTypeDef typeDef,
            [Out] out ClassID pClassId);

        /// <summary>
        /// Gets the extent of native code associated with the specified function ID. This method is obsolete. Use the <see cref="ICorProfilerInfo2.GetCodeInfo2"/> method instead.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
        /// <param name="pStart">[out] A pointer to an array of bytes that compose the native code of the function.</param>
        /// <param name="pcSize">[out] A pointer to an integer that specifies the size, in bytes, of the native code.</param>
        /// <remarks>
        /// To optimize performance, the runtime in the .NET Framework version 2.0 splits the precompiled, native code of a
        /// function into multiple regions. Consequently, the GetCodeInfo method is obsolete in the .NET Framework 2.0 because
        /// it is unable to handle the extent of a function's native code. Profilers should switch to using the more general
        /// ICorProfilerInfo2::GetCodeInfo2 method instead. This function uses caller-allocated buffers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCodeInfo(
            [In] FunctionID functionId,
            [Out] out IntPtr pStart,
            [Out] out int pcSize);

        /// <summary>
        /// Gets the current event categories for which the profiler wants to receive event notifications from the common language runtime (CLR).
        /// </summary>
        /// <param name="pdwEvents">[out] A pointer to a 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.</param>
        [PreserveSig]
        HRESULT GetEventMask(
            [Out] out COR_PRF_MONITOR pdwEvents);

        /// <summary>
        /// Maps a managed code instruction pointer to a FunctionID.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <param name="pFunctionId">[out] The returned function ID.</param>
        [PreserveSig]
        HRESULT GetFunctionFromIP(
            [In] IntPtr ip,
            [Out] out FunctionID pFunctionId);

        /// <summary>
        /// Gets the ID of a function. This method is obsolete in .NET Framework version 2.0. Use the <see cref="ICorProfilerInfo2.GetFunctionFromTokenAndTypeArgs"/> method instead.
        /// </summary>
        /// <remarks>
        /// The GetFunctionFromToken method will not work for generic functions or functions in generic types; it is now obsolete.
        /// Use ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs for all functions.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFunctionFromToken(
            [In] ModuleID moduleId,
            [In] mdToken token,
            [Out] out FunctionID pFunctionId);

        /// <summary>
        /// Maps the ID of a thread to a Win32 thread handle.
        /// </summary>
        /// <param name="threadId">[in] The thread ID to be mapped.</param>
        /// <param name="phThread">[out] A pointer to a Win32 thread handle.</param>
        /// <remarks>
        /// The profiler must call the Win32 DuplicateHandle function on the handle before using it. The handle returned from
        /// this method is owned by the runtime and the profiler should never close it.
        /// </remarks>
        [PreserveSig]
        HRESULT GetHandleFromThread(
            [In] ThreadID threadId,
            [Out] out IntPtr phThread);

        /// <summary>
        /// Gets the size of a specified object.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object.</param>
        /// <param name="pcSize">[out] A pointer to the object's size, in bytes.</param>
        /// <remarks>
        /// Different objects of the same types often have the same size. However, some types, such as arrays or strings, may
        /// have a different size for each object. The size returned by the GetObjectSize method does not include any alignment
        /// padding that may appear after the object is on the garbage collection heap. If you use the GetObjectSize method
        /// to advance from object to object on the garbage collection heap, add alignment padding manually, as necessary.
        /// </remarks>
        [PreserveSig]
        HRESULT GetObjectSize(
            [In] ObjectID objectId,
            [Out] out int pcSize);

        /// <summary>
        /// Determines whether the specified class is an array class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class to be examined.</param>
        /// <param name="pBaseElemType">[out] A pointer to a value of the CorElementType enumeration that indicates the type of the array elements.</param>
        /// <param name="pBaseClassId">[out] A pointer to the class ID of the array elements, when available.</param>
        /// <param name="pcRank">[out] A pointer to an integer that indicates the rank (that is, number of dimensions) of the array.</param>
        /// <remarks>
        /// If the specified class is an array class, the IsArrayClass method returns an S_OK HRESULT and values for any non-null
        /// output parameters. Otherwise, it returns S_FALSE.
        /// </remarks>
        [PreserveSig]
        HRESULT IsArrayClass(
            [In] ClassID classId,
            [Out] out CorElementType pBaseElemType,
            [Out] out ClassID pBaseClassId,
            [Out] out int pcRank);

        /// <summary>
        /// Gets the current Win32 thread identity for the specified thread.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread for which to get the current Win32 ID.</param>
        /// <param name="pdwWin32ThreadId">[out] A pointer to the specified thread's current Win32 thread ID.</param>
        [PreserveSig]
        HRESULT GetThreadInfo(
            [In] ThreadID threadId,
            [Out] out int pdwWin32ThreadId);

        /// <summary>
        /// Gets the ID of the current thread, if it is a managed thread.
        /// </summary>
        /// <param name="pThreadId">[out] A pointer to the returned ID of the managed thread.</param>
        /// <remarks>
        /// If the current thread is an internal runtime thread or other unmanaged thread, GetCurrentThreadID returns CORPROF_E_NOT_MANAGED_THREAD
        /// as the HRESULT, and the returned value of the pThreadId parameter will be null.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentThreadID(
            [Out] out ThreadID pThreadId);

        /// <summary>
        /// Gets the parent module and the metadata token for the specified class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which to get the information.</param>
        /// <param name="pModuleId">[out] A pointer to the ID of the parent module of the class.</param>
        /// <param name="pTypeDefToken">[out] A pointer to the metadata token for the class.</param>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for a given module. The
        /// metadata token that is returned to the location referenced by pTypeDefToken can then be used to access the metadata
        /// for the class. To get more information for generic types, use <see cref="ICorProfilerInfo2.GetClassIDInfo2"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT GetClassIDInfo(
            [In] ClassID classId,
            [Out] out ModuleID pModuleId,
            [Out] out mdTypeDef pTypeDefToken);

        /// <summary>
        /// Gets the parent class and metadata token for the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to get the parent class and metadata token.</param>
        /// <param name="pClassId">[out] A pointer to the parent class of the function.</param>
        /// <param name="pModuleId">[out] A pointer to the module in which the function's parent class is defined.</param>
        /// <param name="pToken">[out] A pointer to the metadata token for the function.</param>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for a given module. The
        /// metadata token that is returned to the location referenced by pToken can then be used to access the metadata for
        /// the function. The ClassID of a function on a generic class might not be obtainable without more contextual information
        /// about the use of the function. In this case, pClassId will be 0. Profiler code should use <see cref="ICorProfilerInfo2.GetFunctionInfo2"/>
        /// with a COR_PRF_FRAME_INFO value to provide more context.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFunctionInfo(
            [In] FunctionID functionId,
            [Out] out ClassID pClassId,
            [Out] out ModuleID pModuleId,
            [Out] out mdToken pToken);

        /// <summary>
        /// Sets a value that specifies the types of events for which the profiler wants to receive notification from the common language runtime (CLR).
        /// </summary>
        /// <param name="dwEvents">[in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.</param>
        [PreserveSig]
        HRESULT SetEventMask(
            [In] COR_PRF_MONITOR dwEvents);

        /// <summary>
        /// Specifies profiler-implemented functions to be called on "enter", "leave", and "tailcall" hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter">[in] A pointer to the implementation to be used as the FunctionEnter callback.</param>
        /// <param name="pFuncLeave">[in] A pointer to the implementation to be used as the FunctionLeave callback.</param>
        /// <param name="pFuncTailcall">[in] A pointer to the implementation to be used as the FunctionTailcall callback.</param>
        /// <remarks>
        /// In .NET Framework version 1.0, each function pointer can be null to disable that corresponding callback. Only one
        /// set of callbacks can be active at a time. Thus, if a profiler calls both SetEnterLeaveFunctionHooks and <see cref="ICorProfilerInfo2.SetEnterLeaveFunctionHooks2"/>,
        /// then SetEnterLeaveFunctionHooks2 takes precedence. The SetEnterLeaveFunctionHooks method can be called only from
        /// the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        [PreserveSig]
        HRESULT SetEnterLeaveFunctionHooks(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter pFuncEnter,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave pFuncLeave,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall pFuncTailcall);

        /// <summary>
        /// Specifies the profiler-implemented function that will be called to map FunctionID values to alternative values, which are passed to the profiler's function entry/exit hooks.
        /// </summary>
        /// <param name="pFunc">[in] A pointer to the FunctionIDMapper implementation that will be called to map the FunctionID values to their alternative values.</param>
        /// <remarks>
        /// The alternatives for the FunctionID values will be passed to the profiler's function entry/exit hooks (FunctionEnter2,
        /// FunctionLeave2, and FunctionTailcall2) that are specified by the <see cref="ICorProfilerInfo2.SetEnterLeaveFunctionHooks2"/>
        /// method. The FunctionIDMapper can be set only once and it is recommended that you set it in the <see cref="ICorProfilerCallback.Initialize"/>
        /// callback.
        /// </remarks>
        [PreserveSig]
        HRESULT SetFunctionIDMapper(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionIDMapper pFunc);

        /// <summary>
        /// Gets the metadata token and a metadata interface instance that can be used against the token for the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to get the metadata token and metadata interface.</param>
        /// <param name="riid">[in] The reference ID of the metadata interface to get the instance of.</param>
        /// <param name="ppImport">[out] A pointer to the address of the metadata interface instance that can be used against the token for the specified function.</param>
        /// <param name="pToken">[out] A pointer to the metadata token for the specified function.</param>
        [PreserveSig]
        HRESULT GetTokenAndMetaDataFromFunction(
            [In] FunctionID functionId,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppImport,
            [Out] out mdToken pToken);

        /// <summary>
        /// Given a module ID, returns the file name of the module and the ID of the module's parent assembly.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module for which information will be retrieved.</param>
        /// <param name="ppBaseLoadAddress">[out] The base address at which the module is loaded.</param>
        /// <param name="cchName">[in] The length, in characters, of the szName return buffer.</param>
        /// <param name="pcchName">[out] A pointer to the total character length of the module's file name that is returned.</param>
        /// <param name="szName">[out] A caller-provided wide character buffer. When the method returns, this buffer contains the file name of the module.</param>
        /// <param name="pAssemblyId">[out] A pointer to the ID of the module's parent assembly.</param>
        /// <remarks>
        /// For dynamic modules, the szName parameter is an empty string, and the base address is 0 (zero). Although the GetModuleInfo
        /// method may be called as soon as the module's ID exists, the ID of the parent assembly will not be available until
        /// the profiler receives the <see cref="ICorProfilerCallback.ModuleAttachedToAssembly"/> callback. When GetModuleInfo
        /// returns, you must verify that the szName buffer was large enough to contain the full file name of the module. To
        /// do this, compare the value that pcchName points to with the value of the cchName parameter. If pcchName points
        /// to a value that is larger than cchName, allocate a larger szName buffer, update cchName with the new, larger size,
        /// and call GetModuleInfo again. Alternatively, you can first call GetModuleInfo with a zero-length szName buffer
        /// to obtain the correct buffer size. You can then set the buffer size to the value returned in pcchName and call
        /// GetModuleInfo again.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleInfo(
            [In] ModuleID moduleId,
            [Out] out IntPtr ppBaseLoadAddress,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] szName,
            [Out] out AssemblyID pAssemblyId);

        /// <summary>
        /// Gets a metadata interface instance that maps to the specified module.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module to which the interface instance will be mapped.</param>
        /// <param name="dwOpenFlags">[in] A value of the CorOpenFlags enumeration that specifies the mode for opening manifest files. Only the ofRead, ofWrite and ofNoTransform bits are valid.</param>
        /// <param name="riid">[in] The reference ID (GUID) of the metadata interface whose instance will be retrieved. See Metadata Interfaces for a list of the interfaces.</param>
        /// <param name="ppOut">[out] A pointer to the address of the metadata interface instance.</param>
        /// <remarks>
        /// You may ask for the metadata to be opened in read/write mode, but this will result in slower metadata execution
        /// of the program, because changes made to the metadata cannot be optimized as they were from the compiler. Some modules
        /// (such as resource modules) have no metadata. In those cases, GetModuleMetaData will return an HRESULT value of
        /// S_FALSE, and a null in *ppOut.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleMetaData(
            [In] ModuleID moduleId,
            [In] CorOpenFlags dwOpenFlags,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppOut);

        /// <summary>
        /// Gets a pointer to the body of a method in Microsoft intermediate language (MSIL) code, starting at its header.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the function resides.</param>
        /// <param name="methodId">[in] The metadata token for the method.</param>
        /// <param name="ppMethodHeader">[out] A pointer to the method's header.</param>
        /// <param name="pcbMethodSize">[out] An integer that specifies the size of the method.</param>
        /// <remarks>
        /// A method is scoped by the module in which it lives. Because the GetILFunctionBody method is designed to give a
        /// tool access to the MSIL code before it has been loaded by the common language runtime (CLR), it uses the metadata
        /// token of the method to find the desired instance. GetILFunctionBody can return a CORPROF_E_FUNCTION_NOT_IL HRESULT
        /// if the methodId points to a method without any MSIL code (such as an abstract method, or a platform invoke (PInvoke)
        /// method).
        /// </remarks>
        [PreserveSig]
        HRESULT GetILFunctionBody(
            [In] ModuleID moduleId,
            [In] mdMethodDef methodId,
            [Out] out IntPtr ppMethodHeader,
            [Out] out int pcbMethodSize);

        /// <summary>
        /// Gets an interface that provides a method to allocate memory to be used for swapping out the body of a method in Microsoft intermediate language (MSIL) code.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the method resides.</param>
        /// <param name="ppMalloc">[out] A pointer to an <see cref="IMethodMalloc"/> interface that provides a method to allocate the memory.</param>
        /// <remarks>
        /// A method body in MSIL code must be located as a relative virtual address (RVA), relative to the loaded module,
        /// which means that it follows the module within 4 GB. To make it easier for a tool to swap out the body of a method,
        /// the GetILFunctionBodyAllocator method ensures that memory is allocated within that range.
        /// </remarks>
        [PreserveSig]
        HRESULT GetILFunctionBodyAllocator(
            [In] ModuleID moduleId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMethodMalloc ppMalloc);

        /// <summary>
        /// Replaces the body of the specified function in the specified module.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the function resides.</param>
        /// <param name="methodId">[in] The token of the function for which to replace the body.</param>
        /// <param name="pbNewILMethodHeader">[in] The new header for the function.</param>
        /// <remarks>
        /// The SetILFunctionBody method replaces the relative virtual address of the function in the metadata so that it points
        /// to the new function body, and adjusts any internal data structures as required. The SetILFunctionBody method can
        /// be called on only those functions that have never been compiled by a just-in-time (JIT) compiler. Use the <see
        /// cref="GetILFunctionBodyAllocator"/> method to allocate space for the new method to ensure that the buffer is compatible.
        /// </remarks>
        [PreserveSig]
        HRESULT SetILFunctionBody(
            [In] ModuleID moduleId,
            [In] mdMethodDef methodId,
            [In] IntPtr pbNewILMethodHeader);

        /// <summary>
        /// Accepts an application domain ID. Returns an application domain name and the ID of the process that contains it.
        /// </summary>
        /// <param name="appDomainId">[in] The ID of the application domain.</param>
        /// <param name="cchName">[in] The length, in characters, of the szName return buffer.</param>
        /// <param name="pcchName">[out] A pointer to the total character length of the application domain name.</param>
        /// <param name="szName">[out] A caller-provided wide character buffer. When the method returns, szName will contain the full or partial application domain name.</param>
        /// <param name="pProcessId">[out] A pointer to the ID of the process that contains the application domain.</param>
        /// <remarks>
        /// After this method returns, you must verify that the szName buffer was large enough to contain the full name of
        /// the application domain. To do this, compare the value that pcchName points to with the value of the cchName parameter.
        /// If pcchName points to a value that is larger than cchName, allocate a larger szName buffer, update cchName with
        /// the new, larger size, and call GetAppDomainInfo again. Alternatively, you can first call GetAppDomainInfo with
        /// a zero-length szName buffer to obtain the correct buffer size. You can then set the buffer size to the value returned
        /// in pcchName and call GetAppDomainInfo again.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAppDomainInfo(
            [In] AppDomainID appDomainId,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName,
            [Out] out ProcessID pProcessId);

        /// <summary>
        /// Accepts an assembly ID, and returns the assembly's name and the ID of its manifest module.
        /// </summary>
        /// <param name="assemblyId">[in] The identifier of the assembly.</param>
        /// <param name="cchName">[in] The length, in characters, of szName.</param>
        /// <param name="pcchName">[out] A pointer to the total character length of the assembly's name.</param>
        /// <param name="szName">[out] A caller-provided wide character buffer. When the function returns, it will contain the assembly's name.</param>
        /// <param name="pAppDomainId">[out] A pointer to the ID of the application domain that contains the assembly.</param>
        /// <param name="pModuleId">[out] A pointer to the ID of the assembly's manifest module.</param>
        /// <remarks>
        /// After this method returns, you must verify that the szName buffer was large enough to contain the full name of
        /// the assembly. To do this, compare the value that pcchName points to with the value of the cchName parameter. If
        /// pcchName points to a value that is larger than cchName, allocate a larger szName buffer, update cchName with the
        /// new, larger size, and call GetAssemblyInfo again. Alternatively, you can first call GetAssemblyInfo with a zero-length
        /// szName buffer to obtain the correct buffer size. You can then adjust the buffer size based on the value returned
        /// in pcchName and call GetAssemblyInfo again.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAssemblyInfo(
            [In] AssemblyID assemblyId,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName,
            [Out] out AppDomainID pAppDomainId,
            [Out] out ModuleID pModuleId);

        /// <summary>
        /// Not implemented. Do not use.
        /// </summary>
        [PreserveSig]
        HRESULT SetFunctionReJIT(
            [In] FunctionID functionId);

        /// <summary>
        /// Forces garbage collection to occur within the common language runtime (CLR).
        /// </summary>
        /// <remarks>
        /// The ForceGC method must be called only from a thread that has never run managed code and does not have any profiler
        /// callbacks on its stack. The most convenient implementation is to create a separate thread within the profiler that
        /// calls ForceGC when signaled.
        /// </remarks>
        [PreserveSig]
        HRESULT ForceGC();

        /// <summary>
        /// Sets a code map for the specified function using the specified Microsoft intermediate language (MSIL) map entries.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to set the code map.</param>
        /// <param name="fStartJit">[in] A Boolean value that indicates whether the call to the SetILInstrumentedCodeMap method is the first for a particular FunctionID.<para/>
        /// Set fStartJit to true in the first call to SetILInstrumentedCodeMap for a given FunctionID, and to false thereafter.</param>
        /// <param name="cILMapEntries">[in] The number of elements in the cILMapEntries array.</param>
        /// <param name="rgILMapEntries">[in] An array of COR_IL_MAP structures, each of which specifies an MSIL offset.</param>
        /// <remarks>
        /// A profiler often inserts statements within the source code of a method in order to instrument that method (for
        /// example, to notify when a given source line is reached). SetILInstrumentedCodeMap enables a profiler to map the
        /// original MSIL instructions to their new locations. A profiler can use the <see cref="GetILToNativeMapping"/> method
        /// to get the original MSIL offset for a given native offset. The debugger will assume that each old offset refers
        /// to an MSIL offset within the original, unmodified MSIL code, and that each new offset refers to the MSIL offset
        /// within the new, instrumented code. The map should be sorted in increasing order. For stepping to work properly,
        /// follow these guidelines: In the .NET Framework 3.5 and previous versions, you allocate the rgILMapEntries array
        /// by calling the CoTaskMemAlloc method. Because the runtime takes ownership of this memory, the profiler should not
        /// attempt to free it.
        /// </remarks>
        [PreserveSig]
        HRESULT SetILInstrumentedCodeMap(
            [In] FunctionID functionId,
            [In, MarshalAs(UnmanagedType.Bool)] bool fStartJit,
            [In] int cILMapEntries,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_IL_MAP[] rgILMapEntries);

        /// <summary>
        /// Gets an object that can be queried for an "ICorDebugProcess" interface. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        /// <param name="ppicd">out object that can be queried for an ICorDebugProcess interface.</param>
        /// <remarks>
        /// The common language runtime (CLR) debugging API supported limited in-process debugging in .NET Framework version
        /// 1.0. In-process debugging enabled a profiler to use the inspection portions of the debugging API. As a result of
        /// customer feedback, in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with
        /// a set of functionality that is more in line with the profiling API.
        /// </remarks>
        [PreserveSig]
        HRESULT GetInprocInspectionInterface(
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppicd);

        /// <summary>
        /// Gets an object that can be queried for the ICorDebugThread interface. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        /// <param name="ppicd">out object that can be queried for the ICorDebugThread interface.</param>
        /// <remarks>
        /// The common language runtime (CLR) debugging services supported limited in-process debugging in .NET Framework version
        /// 1.0. In-process debugging enabled a profiler to use the inspection portions of the debugging API. As a result of
        /// customer feedback, in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with
        /// a set of functionality that is more in line with the profiling API.
        /// </remarks>
        [PreserveSig]
        HRESULT GetInprocInspectionIThisThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppicd);

        /// <summary>
        /// Gets the context identity currently associated with the specified thread.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread.</param>
        /// <param name="pContextId">[out] A pointer to the context ID currently associated with the specified thread. If the thread has no context currently associated with it, this function will return CORPROF_E_DATAINCOMPLETE.</param>
        [PreserveSig]
        HRESULT GetThreadContext(
            [In] ThreadID threadId,
            [Out] out ContextID pContextId);

        /// <summary>
        /// Initializes in-process debugging support. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        /// <param name="fThisThreadOnly">[in] Set this value to true to initialize debugging support for only the current thread; set it to false to initialize debugging support for all threads.</param>
        /// <param name="pdwProfilerContext">[out] The pointer to a returned value that identifies the debugging session.</param>
        /// <remarks>
        /// The CLR debugging services supported limited in-process debugging in the .NET Framework versions 1.0 and 1.1. In-process
        /// debugging enabled a profiler to use the inspection portions of the debugging API. However, due to customer feedback,
        /// in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with a set of functionality
        /// that is more in line with the profiling API.
        /// </remarks>
        [PreserveSig]
        HRESULT BeginInprocDebugging(
            [In, MarshalAs(UnmanagedType.Bool)] bool fThisThreadOnly,
            [Out] out int pdwProfilerContext);

        /// <summary>
        /// Shuts down an in-process debugging session. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        /// <param name="dwProfilerContext">[in] A value that identifies the debugging session. This value must be the same as that received in the <see cref="BeginInprocDebugging"/> method.</param>
        /// <remarks>
        /// You must call <see cref="BeginInprocDebugging"/> and EndInprocDebugging within the same callback method. The CLR
        /// debugging services supported limited in-process debugging in the .NET Framework versions 1.0 and 1.1. In-process
        /// debugging enabled a profiler to use the inspection portions of the debugging API. However, due to customer feedback,
        /// in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with a set of functionality
        /// that is more in line with the profiling API.
        /// </remarks>
        [PreserveSig]
        HRESULT EndInprocDebugging(
            [In] int dwProfilerContext);

        /// <summary>
        /// Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the code.</param>
        /// <param name="cMap">[in] The maximum size of the map array.</param>
        /// <param name="pcMap">[out] The total number of available COR_DEBUG_IL_TO_NATIVE_MAP structures.</param>
        /// <param name="map">[out] An array of COR_DEBUG_IL_TO_NATIVE_MAP structures, each of which specifies the offsets. After the GetILToNativeMapping method returns, map will contain some or all of the COR_DEBUG_IL_TO_NATIVE_MAP structures.</param>
        /// <remarks>
        /// The GetILToNativeMapping method returns an array of COR_DEBUG_IL_TO_NATIVE_MAP structures. To convey that certain
        /// ranges of native instructions correspond to special regions of code (for example, the prolog), an entry in the
        /// array can have its ilOffset field set to a value of the CorDebugIlToNativeMappingTypes enumeration. After GetILToNativeMapping
        /// returns, you must verify that the map buffer was large enough to contain all the COR_DEBUG_IL_TO_NATIVE_MAP structures.
        /// To do this, compare the value of cMap with the value of the pcMap parameter. If the pcMap value, when it is multiplied
        /// by the size of a COR_DEBUG_IL_TO_NATIVE_MAP structure, is larger than cMap, allocate a larger map buffer, update
        /// cMap with the new, larger size, and call GetILToNativeMapping again. Alternatively, you can first call GetILToNativeMapping
        /// with a zero-length map buffer to obtain the correct buffer size. You can then set the buffer size to the value
        /// returned in pcMap and call GetILToNativeMapping again.
        /// </remarks>
        [PreserveSig]
        HRESULT GetILToNativeMapping(
            [In] FunctionID functionId,
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] COR_DEBUG_IL_TO_NATIVE_MAP[] map);
    }
}
