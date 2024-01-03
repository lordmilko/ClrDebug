using System;
using System.Reflection;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    public delegate void FunctionEnter3(
        [In] FunctionIDOrClientID functionIDOrClientID);

    public delegate void FunctionLeave3(
        [In] FunctionIDOrClientID functionIDOrClientID);

    public delegate void FunctionTailcall3(
        [In] FunctionIDOrClientID functionIDOrClientID);

    public delegate void FunctionEnter3WithInfo(
        [In] FunctionIDOrClientID functionIDOrClientID,
        [In] COR_PRF_ELT_INFO eltInfo);

    public delegate void FunctionLeave3WithInfo(
        [In] FunctionIDOrClientID functionIDOrClientID,
        [In] COR_PRF_ELT_INFO eltInfo);

    public delegate void FunctionTailcall3WithInfo(
        [In] FunctionIDOrClientID functionIDOrClientID,
        [In] COR_PRF_ELT_INFO eltInfo);

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate IntPtr FunctionIDMapper2(
        [In] FunctionID funcId,
        [In] IntPtr clientData,
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pbHookFunction);

    /// <summary>
    /// Provides methods that code profilers use to communicate with the common language runtime (CLR) to control event monitoring and to request information.<para/>
    /// The ICorProfilerInfo3 interface is an extension of the <see cref="ICorProfilerInfo2"/> interface. It provides new methods supported in the .NET Framework 4 and later versions.
    /// </summary>
    /// <remarks>
    /// The CLR implements the methods of the ICorProfilerInfo3 interface by using the free-threaded model. Each method
    /// returns an HRESULT to indicate success or failure. For a list of possible return codes, see the CorError.h file.
    /// The CLR passes an ICorProfilerInfo3 interface to each code profiler during initialization, using the profiler's
    /// implementation of the <see cref="ICorProfilerCallback.Initialize"/> or <see cref="ICorProfilerCallback3.InitializeForAttach"/>
    /// method. A code profiler can then call the ICorProfilerInfo3 methods to get information about managed code that
    /// is being executed under the control of the CLR.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B555ED4F-452A-4E54-8B39-B5360BAD32A0")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorProfilerInfo3 : ICorProfilerInfo2
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Gets the ClassID of an object, given its ObjectID.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object for which to get the ClassID.</param>
        /// <param name="pClassId">[out] A pointer to the returned ClassID.</param>
        /// <remarks>
        /// A null pClassId indicates that objectId has a type that is unloading.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetClassFromObject(
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
        new HRESULT GetClassFromToken(
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
        new HRESULT GetCodeInfo(
            [In] FunctionID functionId,
            [Out] out IntPtr pStart,
            [Out] out int pcSize);

        /// <summary>
        /// Gets the current event categories for which the profiler wants to receive event notifications from the common language runtime (CLR).
        /// </summary>
        /// <param name="pdwEvents">[out] A pointer to a 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.</param>
        [PreserveSig]
        new HRESULT GetEventMask(
            [Out] out COR_PRF_MONITOR pdwEvents);

        /// <summary>
        /// Maps a managed code instruction pointer to a FunctionID.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <param name="pFunctionId">[out] The returned function ID.</param>
        [PreserveSig]
        new HRESULT GetFunctionFromIP(
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
        new HRESULT GetFunctionFromToken(
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
        new HRESULT GetHandleFromThread(
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
        new HRESULT GetObjectSize(
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
        new HRESULT IsArrayClass(
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
        new HRESULT GetThreadInfo(
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
        new HRESULT GetCurrentThreadID(
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
        new HRESULT GetClassIDInfo(
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
        new HRESULT GetFunctionInfo(
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
        new HRESULT SetEventMask(
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
        new HRESULT SetEnterLeaveFunctionHooks(
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
        new HRESULT SetFunctionIDMapper(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionIDMapper pFunc);

        /// <summary>
        /// Gets the metadata token and a metadata interface instance that can be used against the token for the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to get the metadata token and metadata interface.</param>
        /// <param name="riid">[in] The reference ID of the metadata interface to get the instance of.</param>
        /// <param name="ppImport">[out] A pointer to the address of the metadata interface instance that can be used against the token for the specified function.</param>
        /// <param name="pToken">[out] A pointer to the metadata token for the specified function.</param>
        [PreserveSig]
        new HRESULT GetTokenAndMetaDataFromFunction(
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
        new HRESULT GetModuleInfo(
            [In] ModuleID moduleId,
            [Out] out IntPtr ppBaseLoadAddress,
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] szName,
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
        new HRESULT GetModuleMetaData(
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
        new HRESULT GetILFunctionBody(
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
        new HRESULT GetILFunctionBodyAllocator(
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
        new HRESULT SetILFunctionBody(
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
        new HRESULT GetAppDomainInfo(
            [In] AppDomainID appDomainId,
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName,
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
        new HRESULT GetAssemblyInfo(
            [In] AssemblyID assemblyId,
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName,
            [Out] out AppDomainID pAppDomainId,
            [Out] out ModuleID pModuleId);

        /// <summary>
        /// Not implemented. Do not use.
        /// </summary>
        [PreserveSig]
        new HRESULT SetFunctionReJIT(
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
        new HRESULT ForceGC();

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
        new HRESULT SetILInstrumentedCodeMap(
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
        new HRESULT GetInprocInspectionInterface(
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
        new HRESULT GetInprocInspectionIThisThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppicd);

        /// <summary>
        /// Gets the context identity currently associated with the specified thread.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread.</param>
        /// <param name="pContextId">[out] A pointer to the context ID currently associated with the specified thread. If the thread has no context currently associated with it, this function will return CORPROF_E_DATAINCOMPLETE.</param>
        [PreserveSig]
        new HRESULT GetThreadContext(
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
        new HRESULT BeginInprocDebugging(
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
        new HRESULT EndInprocDebugging(
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
        new HRESULT GetILToNativeMapping(
            [In] FunctionID functionId,
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] COR_DEBUG_IL_TO_NATIVE_MAP[] map);

        /// <summary>
        /// Walks the managed frames on the stack for the specified thread, and sends information to the profiler through a callback.
        /// </summary>
        /// <param name="thread">[in] The ID of the target thread. Passing null in thread yields a snapshot of the current thread. If a ThreadID of a different thread is passed, the common language runtime (CLR) suspends that thread, performs the snapshot, and resumes.</param>
        /// <param name="callback">[in] A pointer to the implementation of the StackSnapshotCallback method, which is called by the CLR to provide the profiler with information on each managed frame and each run of unmanaged frames.<para/>
        /// The StackSnapshotCallback method is implemented by the profiler writer.</param>
        /// <param name="infoFlags">[in] A value of the <see cref="COR_PRF_SNAPSHOT_INFO"/> enumeration, which specifies the amount of data to be passed back for each frame by StackSnapshotCallback.</param>
        /// <param name="clientData">[in] A pointer to the client data, which is passed straight through to the StackSnapshotCallback callback function.</param>
        /// <param name="context">[in] A pointer to a Win32 CONTEXT structure, which is used to seed the stack walk. The Win32 CONTEXT structure contains values of the CPU registers and represents the state of the CPU at a particular moment in time.<para/>
        /// The seed helps the CLR determine where to begin the stack walk, if the top of the stack is unmanaged helper code; otherwise, the seed is ignored.<para/>
        /// A seed must be supplied for an asynchronous walk. If you are doing a synchronous walk, no seed is necessary. The context parameter is valid only if the COR_PRF_SNAPSHOT_CONTEXT flag was passed in the infoFlags parameter.</param>
        /// <param name="contextSize">[in] The size of the CONTEXT structure, which is referenced by the context parameter.</param>
        /// <remarks>
        /// Passing null for thread yields a snapshot of the current thread. Snapshots can be taken of other threads only if
        /// the target thread is suspended at the time. When the profiler wants to walk the stack, it calls DoStackSnapshot.
        /// Before the CLR returns from that call, it calls your StackSnapshotCallback several times, once for each managed
        /// frame (or run of unmanaged frames) on the stack. When unmanaged frames are encountered, you must walk them yourself.
        /// The order in which the stack is walked is the reverse of how the frames were pushed onto the stack: leaf (last-pushed)
        /// frame first, main (first-pushed) frame last. For more information about how to program the profiler to walk managed
        /// stacks, see Profiler Stack Walking in the .NET Framework 2.0: Basics and Beyond. A stack walk can be synchronous
        /// or asynchronous, as explained in the following sections.
        /// </remarks>
        [PreserveSig]
        new HRESULT DoStackSnapshot(
            [In] ThreadID thread,
            [MarshalAs(UnmanagedType.FunctionPtr), In] StackSnapshotCallback callback,
            [In] COR_PRF_SNAPSHOT_INFO infoFlags,
            [In] IntPtr clientData,
            [In] IntPtr context,
            [In] int contextSize);

        /// <summary>
        /// Specifies profiler-implemented functions to be called on the updated versions of the "enter", "leave", and "tailcall" hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter">[in] A pointer to the implementation to be used as the FunctionEnter2 callback.</param>
        /// <param name="pFuncLeave">[in] A pointer to the implementation to be used as the FunctionLeave2 callback.</param>
        /// <param name="pFuncTailcall">[in] A pointer to the implementation to be used as the FunctionTailcall2 callback.</param>
        /// <remarks>
        /// The SetEnterLeaveFunctionHooks2 method is similar to the <see cref="ICorProfilerInfo.SetEnterLeaveFunctionHooks"/>
        /// method. Use the former to specify functions to be used as the newer versions of the enter/leave/tailcall callbacks,
        /// and the latter to specify functions to be used as the older versions of the enter/leave/tailcall callbacks. Only
        /// one set of callbacks may be active at a time. Thus, if a profiler calls both ICorProfilerInfo::SetEnterLeaveFunctionHooks
        /// and SetEnterLeaveFunctionHooks2, SetEnterLeaveFunctionHooks2 is used. The SetEnterLeaveFunctionHooks2 method may
        /// be called only from the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetEnterLeaveFunctionHooks2(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter2 pFuncEnter,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave2 pFuncLeave,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall2 pFuncTailcall);

        /// <summary>
        /// Gets the parent class, the metadata token, and the ClassID of each type argument, if present, of a function.
        /// </summary>
        /// <param name="funcID">[in] The ID of the function for which to get the parent class and other information.</param>
        /// <param name="frameInfo">[in] A COR_PRF_FRAME_INFO value that points to information about a stack frame.</param>
        /// <param name="pClassId">[out] A pointer to the parent class of the function.</param>
        /// <param name="pModuleId">[out] A pointer to the module in which the function's parent class is defined.</param>
        /// <param name="pToken">[out] A pointer to the metadata token for the function.</param>
        /// <param name="cTypeArgs">[in] The size of the typeArgs array.</param>
        /// <param name="pcTypeArgs">[out] A pointer to the total number of ClassID values.</param>
        /// <param name="typeArgs">[out] An array of ClassID values, each of which is the ID of a type argument of the function. When the method returns, typeArgs will contain some or all of the ClassID values.</param>
        /// <remarks>
        /// The profiler code can call <see cref="ICorProfilerInfo.GetModuleMetaData"/> to obtain a metadata interface for
        /// a given module. The metadata token that is returned to the location referenced by pToken can then be used to access
        /// the metadata for the function. The class ID and type arguments that are returned through the pClassId and typeArgs
        /// parameters depend on the value that is passed in the frameInfo parameter, as shown in the following table. After
        /// GetFunctionInfo2 returns, you must verify that the typeArgs buffer was large enough to contain all the ClassID
        /// values. To do this, compare the value that pcTypeArgs points to with the value of the cTypeArgs parameter. If pcTypeArgs
        /// points to a value that is larger than cTypeArgs divided by the size of a ClassID value, allocate a larger pcTypeArgs
        /// buffer, update cTypeArgs with the new, larger size, and call GetFunctionInfo2 again. Alternatively, you can first
        /// call GetFunctionInfo2 with a zero-length pcTypeArgs buffer to obtain the correct buffer size. You can then set
        /// the buffer size to the value returned in pcTypeArgs divided by the size of a ClassID value, and call GetFunctionInfo2
        /// again.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetFunctionInfo2(
            [In] FunctionID funcID,
            [In] COR_PRF_FRAME_INFO frameInfo,
            [Out] out ClassID pClassId,
            [Out] out ModuleID pModuleId,
            [Out] out mdToken pToken,
            [In] int cTypeArgs,
            [Out] out int pcTypeArgs,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ClassID[] typeArgs);

        /// <summary>
        /// Gets information about the layout of a string object. This method is deprecated in the .NET Framework 4, and is superseded by the <see cref="ICorProfilerInfo3.GetStringLayout2"/> method.
        /// </summary>
        /// <param name="pBufferLengthOffset">[out] A pointer to the offset of the location, relative to the ObjectID pointer, that stores the length of the string.<para/>
        /// The length is stored as a DWORD.</param>
        /// <param name="pStringLengthOffset">[out] A pointer to the offset of the location, relative to the ObjectID pointer, that stores the length of the string itself.<para/>
        /// The length is stored as a DWORD.</param>
        /// <param name="pBufferOffset">[out] A pointer to the offset of the buffer, relative to the ObjectID pointer, that stores the string of wide characters.</param>
        /// <remarks>
        /// The GetStringLayout method gets the offsets, relative to the ObjectID pointer, of the locations in which the following
        /// are stored: Strings may be null-terminated.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetStringLayout(
            [Out] out int pBufferLengthOffset,
            [Out] out int pStringLengthOffset,
            [Out] out int pBufferOffset);

        /// <summary>
        /// Gets information about the layout, in memory, of the fields defined by the specified class. That is, this method gets the offsets of the class's fields.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which the layout will be retrieved.</param>
        /// <param name="rFieldOffset">[in, out] An array of COR_FIELD_OFFSET structures, each of which contains the tokens and offsets of the class's fields.</param>
        /// <param name="cFieldOffset">[in] The size of the rFieldOffset array.</param>
        /// <param name="pcFieldOffset">[out] A pointer to the total number of available elements. If cFieldOffset is 0, this value indicates the number of elements needed.</param>
        /// <param name="pulClassSize">[out] A pointer to a location that contains the size, in bytes, of the class.</param>
        /// <remarks>
        /// The GetClassLayout method returns only the fields defined by the class itself. If the class's parent class has
        /// defined fields as well, the profiler must call GetClassLayout on the parent class to obtain those fields. If you
        /// use GetClassLayout with string classes, the method will fail with error code E_INVALIDARG. Use <see cref="GetStringLayout"/>
        /// to get information about the layout of a string. GetClassLayout will also fail when called with an array class.
        /// After GetClassLayout returns, you must verify that the rFieldOffset buffer was large enough to contain all the
        /// available COR_FIELD_OFFSET structures. To do this, compare the value that pcFieldOffset points to with the size
        /// of rFieldOffset divided by the size of a COR_FIELD_OFFSET structure. If rFieldOffset is not large enough, allocate
        /// a larger rFieldOffset buffer, update cFieldOffset with the new, larger size, and call GetClassLayout again. Alternatively,
        /// you can first call GetClassLayout with a zero-length rFieldOffset buffer to obtain the correct buffer size. You
        /// can then set the buffer size to the value returned in pcFieldOffset and call GetClassLayout again.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetClassLayout(
            [In] ClassID classId,
            [In, SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_FIELD_OFFSET[] rFieldOffset,
            [In] int cFieldOffset,
            [Out] out int pcFieldOffset,
            [Out] out int pulClassSize);

        /// <summary>
        /// Gets the parent module and metadata token for the open generic definition of the specified class, the ClassID of its parent class, and the ClassID for each type argument, if present, of the class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which information will be retrieved.</param>
        /// <param name="pModuleId">[out] Pointer to the ID of the parent module for the open generic definition of the specified class.</param>
        /// <param name="pTypeDefToken">[out] Pointer to the metadata token for the open generic definition of the specified class.</param>
        /// <param name="pParentClassId">[out] Pointer to the ID of the parent class.</param>
        /// <param name="cNumTypeArgs">[in] The size of the typeArgs array.</param>
        /// <param name="pcNumTypeArgs">[out] Pointer to the total number of available elements.</param>
        /// <param name="typeArgs">[out] An array of ClassID values, each of which represents the ID of a type argument of the class. When the method returns, typeArgs will contain some or all the available ClassID values.</param>
        /// <remarks>
        /// The GetClassIDInfo2 method is similar to the <see cref="ICorProfilerInfo.GetClassIDInfo"/> method, but GetClassIDInfo2
        /// obtains additional information about a generic type. The profiler code can call <see cref="ICorProfilerInfo.GetModuleMetaData"/>
        /// to obtain a metadata interface for a given module. The metadata token that is returned to the location referenced
        /// by pTypeDefToken can then be used to access the metadata for the class. After GetClassIDInfo2 returns, you must
        /// verify that the typeArgs buffer was large enough to contain all the ClassID values. To do this, compare the value
        /// that pcNumTypeArgs points to with the value of the cNumTypeArgs parameter. If pcNumTypeArgs points to a value that
        /// is larger than cNumTypeArgs, allocate a larger typeArgs buffer, update cNumTypeArgs with the new, larger size,
        /// and call GetClassIDInfo2 again. Alternatively, you can first call GetClassIDInfo2 with a zero-length typeArgs buffer
        /// to obtain the correct buffer size. You can then set the typeArgs buffer size to the value returned in pcNumTypeArgs
        /// and call GetClassIDInfo2 again.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetClassIDInfo2(
            [In] ClassID classId,
            [Out] out ModuleID pModuleId,
            [Out] out mdTypeDef pTypeDefToken,
            [Out] out ClassID pParentClassId,
            [In] int cNumTypeArgs,
            [Out] out int pcNumTypeArgs,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ClassID[] typeArgs);

        /// <summary>
        /// Gets the extents of native code associated with the specified FunctionID.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
        /// <param name="cCodeInfos">[in] The size of the codeInfos array.</param>
        /// <param name="pcCodeInfos">[out] A pointer to the total number of <see cref="COR_PRF_CODE_INFO"/> structures available.</param>
        /// <param name="codeInfos">[out] A caller-provided buffer. After the method returns, it contains an array of COR_PRF_CODE_INFO structures, each of which describes a block of native code.</param>
        /// <remarks>
        /// The extents are sorted in order of increasing Microsoft intermediate language (MSIL) offset. After GetCodeInfo2
        /// returns, you must verify that the codeInfos buffer was large enough to contain all the COR_PRF_CODE_INFO structures.
        /// To do this, compare the value of cCodeInfos with the value of the cchName parameter. If cCodeInfos divided by the
        /// size of a COR_PRF_CODE_INFO structure is smaller than pcCodeInfos, allocate a larger codeInfos buffer, update cCodeInfos
        /// with the new, larger size, and call GetCodeInfo2 again. Alternatively, you can first call GetCodeInfo2 with a zero-length
        /// codeInfos buffer to obtain the correct buffer size. You can then set the codeInfos buffer size to the value returned
        /// in pcCodeInfos, multiplied by the size of a COR_PRF_CODE_INFO structure, and call GetCodeInfo2 again.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetCodeInfo2(
            [In] FunctionID functionId,
            [In] int cCodeInfos,
            [Out] out int pcCodeInfos,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] COR_PRF_CODE_INFO[] codeInfos);

        /// <summary>
        /// Gets the ClassID of a type by using the specified metadata token and the ClassID values of any type arguments.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the type resides.</param>
        /// <param name="typeDef">[in] An mdTypeDef metadata token that references the type.</param>
        /// <param name="cTypeArgs">[in] The number of type parameters for the given type. This value must be zero for non-generic types.</param>
        /// <param name="typeArgs">[in] An array of ClassID values, each of which is an argument of the type. The value of typeArgs can be NULL if cTypeArgs is set to zero.</param>
        /// <param name="pClassId">[out] A pointer to the ClassID of the specified type.</param>
        /// <remarks>
        /// Calling the GetClassFromTokenAndTypeArgs method with an mdTypeRef instead of an mdTypeDef metadata token can have
        /// unpredictable results; callers should resolve the mdTypeRef to an mdTypeDef when passing it. If the type is not
        /// already loaded, calling GetClassFromTokenAndTypeArgs will trigger loading, which is a dangerous operation in many
        /// contexts. For example, calling this method during loading of modules or other types could lead to an infinite loop
        /// as the runtime attempts to circularly load things. In general, use of GetClassFromTokenAndTypeArgs is discouraged.
        /// If profilers are interested in events for a particular type, they should store the ModuleID and mdTypeDef of that
        /// type, and use <see cref="GetClassIDInfo2"/> to check whether a given ClassID is that of the desired type.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetClassFromTokenAndTypeArgs(
            [In] ModuleID moduleId,
            [In] mdTypeDef typeDef,
            [In] int cTypeArgs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ClassID[] typeArgs,
            [Out] out ClassID pClassId);

        /// <summary>
        /// Gets the FunctionID of a function by using the specified metadata token, containing class, and ClassID values of any type arguments.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the function resides.</param>
        /// <param name="funcDef">[in] An mdMethodDef metadata token that references the function.</param>
        /// <param name="classId">[in] The ID of the function's containing class.</param>
        /// <param name="cTypeArgs">[in] The number of type parameters for the given function. This value must be zero for non-generic functions.</param>
        /// <param name="typeArgs">[in] An array of ClassID values, each of which is an argument of the function. The value of typeArgs can be NULL if cTypeArgs is set to zero.</param>
        /// <param name="pFunctionId">[out] A pointer to the FunctionID of the specified function.</param>
        /// <remarks>
        /// Calling the GetFunctionFromTokenAndTypeArgs method with an mdMethodRef metadata instead of an mdMethodDef metadata
        /// token can have unpredictable results. Callers should resolve the mdMethodRef to an mdMethodDef when passing it.
        /// If the function is not already loaded, calling GetFunctionFromTokenAndTypeArgs will cause loading to occur, which
        /// is a dangerous operation in many contexts. For example, calling this method during loading of modules or types
        /// could lead to an infinite loop as the runtime attempts to circularly load things. In general, use of GetFunctionFromTokenAndTypeArgs
        /// is discouraged. If profilers are interested in events for a particular function, they should store the ModuleID
        /// and mdMethodDef of that function, and use <see cref="GetFunctionInfo2"/> to check whether a given FunctionID is
        /// that of the desired function.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetFunctionFromTokenAndTypeArgs(
            [In] ModuleID moduleId,
            [In] mdMethodDef funcDef,
            [In] ClassID classId,
            [In] int cTypeArgs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ClassID[] typeArgs,
            [Out] out FunctionID pFunctionId);

        /// <summary>
        /// Gets an enumerator that allows iteration over the frozen objects in the specified module.This method is obsolete.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that contains the frozen objects to be enumerated.</param>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorProfilerObjectEnum"/> interface, which enumerates the frozen objects.</param>
        [PreserveSig]
        new HRESULT EnumModuleFrozenObjects(
            [In] ModuleID moduleId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerObjectEnum ppEnum);

        /// <summary>
        /// Gets detailed information about an array object.
        /// </summary>
        /// <param name="objectId">[in] The ID of a valid array object.</param>
        /// <param name="cDimensions">[in] The rank (number of dimensions) of the array.</param>
        /// <param name="pDimensionSizes">[out] An array that contains integers, each representing the size of a dimension of the array.</param>
        /// <param name="pDimensionLowerBounds">[out] An array that contains integers, each representing the lower bound of a dimension of the array.</param>
        /// <param name="ppData">[out] A pointer to the address of the raw buffer for the array, which is laid out according to the C++ convention.</param>
        /// <remarks>
        /// The pDimensionSizes and pDimensionLowerBounds are parallel arrays, so the elements located at the same index in
        /// each array are characteristics of the same entity.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetArrayObjectInfo(
            [In] ObjectID objectId,
            [In] int cDimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] pDimensionSizes,
            [Out] out int pDimensionLowerBounds,
            [Out] out IntPtr ppData);

        /// <summary>
        /// Gets information about where the specified value type is located when it is boxed.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that describes the value type that is boxed.</param>
        /// <param name="pBufferOffset">[out] An integer that is the offset, relative to the boxed object ID pointer, of the value type.</param>
        /// <remarks>
        /// The pBufferOffset value is the location of the value type within a box. After pBufferOffset is applied to a boxed
        /// object, the value type's class layout can be used to interpret the object's value.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetBoxClassLayout(
            [In] ClassID classId,
            [Out] out int pBufferOffset);

        /// <summary>
        /// Gets the ID of the application domain in which the specified thread is currently executing code.
        /// </summary>
        /// <param name="threadId">[in] The ID specifying the thread.</param>
        /// <param name="pAppDomainId">[out] A pointer to the ID of the application domain.</param>
        [PreserveSig]
        new HRESULT GetThreadAppDomain(
            [In] ThreadID threadId,
            [Out] out AppDomainID pAppDomainId);

        /// <summary>
        /// Gets the address of the specified relative virtual address (RVA) static field.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested RVA-static field.</param>
        /// <param name="fieldToken">[in] Metadata token for the requested RVA-static field.</param>
        /// <param name="ppAddress">[out] A pointer to the address of the RVA-static field.</param>
        /// <remarks>
        /// The GetRVAStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetRVAStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and may be rooting garbage collection objects.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetRVAStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [Out] out IntPtr ppAddress);

        /// <summary>
        /// Gets the address of the specified application domain-static field that is in the scope of the specified application domain.
        /// </summary>
        /// <param name="classId">[in] The class ID of the class that contains the requested application domain-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested application domain-static field.</param>
        /// <param name="appDomainId">[in] The ID of the application domain that is the scope for the requested static field.</param>
        /// <param name="ppAddress">[out] A pointer to the address of the static field that is within the specified application domain.</param>
        /// <remarks>
        /// The GetAppDomainStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetAppDomainStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the
        /// static fields may already be initialized and rooting garbage collection objects.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetAppDomainStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] ThreadID appDomainId,
            [Out] out IntPtr ppAddress);

        /// <summary>
        /// Gets the address of the specified thread-static field that is in the scope of the specified thread.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested thread-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested thread-static field.</param>
        /// <param name="threadId">[in] The ID of the thread that is the scope for the requested static field.</param>
        /// <param name="ppAddress">[out] A pointer to the address of the static field that is within the specified thread.</param>
        /// <remarks>
        /// The GetThreadStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetThreadStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and rooting garbage collection objects.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetThreadStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] ContextID threadId,
            [Out] out IntPtr ppAddress);

        /// <summary>
        /// Gets the address for the specified context-static field that is in the scope of the specified context.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested context-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested context-static field.</param>
        /// <param name="contextId">[in] The ID of the context that is the scope for the requested context-static field.</param>
        /// <param name="ppAddress">[out] A pointer to the address of the static field that is within the specified context.</param>
        /// <remarks>
        /// The GetContextStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetContextStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and rooting garbage collection objects.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetContextStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] ContextID contextId,
            [Out] out IntPtr ppAddress);

        /// <summary>
        /// Gets a value that indicates the kind of static that applies to the specified field.
        /// </summary>
        /// <param name="classId">[in] The ID of the class in which the static field is defined.</param>
        /// <param name="fieldToken">[in] The metadata token for the static field.</param>
        /// <param name="pFieldInfo">[out] A pointer to a value of the <see cref="COR_PRF_STATIC_TYPE"/> enumeration that indicates whether the specified field is static, and if so, the kind of static that applies to the field.</param>
        /// <remarks>
        /// This information can be used to determine which function to call to get the address of the static field. The profiler
        /// code should still check the metadata for a static field to ensure that it actually has an address. Static literals
        /// (that is, constants) exist only in the metadata and do not have an address.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetStaticFieldInfo(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [Out] out COR_PRF_STATIC_TYPE pFieldInfo);

        /// <summary>
        /// Gets the memory regions, which are segments of the heap, that make up the various garbage collection generations.
        /// </summary>
        /// <param name="cObjectRanges">[in] The number of elements allocated by the caller for the ranges array.</param>
        /// <param name="pcObjectRanges">[out] A pointer to an integer that specifies the total number of ranges, some or all of which will be returned in the ranges array.</param>
        /// <param name="ranges">[out] An array of <see cref="COR_PRF_GC_GENERATION_RANGE"/> structures, each of which describes a range (that is, block) of memory within the generation that is undergoing garbage collection.</param>
        /// <remarks>
        /// The GetGenerationBounds method can be called from any profiler callback, provided that garbage collection is not
        /// in progress. Most shifting of generations takes place during garbage collections. Generations might grow between
        /// collections but generally do not move around. Therefore, the most interesting places to call GetGenerationBounds
        /// are in ICorProfilerCallback2::GarbageCollectionStarted and ICorProfilerCallback2::GarbageCollectionFinished. During
        /// program startup, some objects are allocated by the common language runtime (CLR) itself, generally in generations
        /// 3 and 0. Thus, by the time managed code starts executing, these generations will already contain objects. Generations
        /// 1 and 2 will normally be empty, except for dummy objects that are generated by the garbage collector. (The size
        /// of dummy objects is 12 bytes in 32-bit implementations of the CLR; the size is larger in 64-bit implementations.)
        /// You might also see generation 2 ranges that are inside modules produced by the Native Image Generator (NGen.exe).
        /// In this case, the objects in generation 2 are frozen objects, which are allocated when NGen.exe runs rather than
        /// by the garbage collector. This function uses caller-allocated buffers.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetGenerationBounds(
            [In] int cObjectRanges,
            [Out] out int pcObjectRanges,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), SRI.Out] COR_PRF_GC_GENERATION_RANGE[] ranges);

        /// <summary>
        /// Gets the segment of the heap that contains the specified object.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object.</param>
        /// <param name="range">[out] A pointer to a <see cref="COR_PRF_GC_GENERATION_RANGE"/> structure, which describes a range (that is, a block) of memory within the generation that is undergoing garbage collection.<para/>
        /// This range contains the specified object.</param>
        /// <remarks>
        /// The GetObjectGeneration method may be called from any profiler callback, provided that garbage collection is not
        /// in progress. That is, it may be called from any callback except those that occur between <see cref="ICorProfilerCallback2.GarbageCollectionStarted"/>
        /// and <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetObjectGeneration(
            [In] ObjectID objectId,
            [Out] out COR_PRF_GC_GENERATION_RANGE range);

        /// <summary>
        /// Gets the native address and frame information for the exception clause (catch/finally/filter) that is about to be run or has just been run.
        /// </summary>
        /// <param name="pinfo">[out] A pointer to a <see cref="COR_PRF_EX_CLAUSE_INFO"/> structure that describes the current exception clause instance and its associated frame.</param>
        /// <remarks>
        /// When an exception notification is received, GetNotifiedExceptionClauseInfo can be used to get the native address
        /// and frame information for the exception clause (catch/finally/filter) that is about to be run (<see cref="ICorProfilerCallback.ExceptionCatcherEnter"/>,
        /// <see cref="ICorProfilerCallback.ExceptionUnwindFinallyEnter"/>, or <see cref="ICorProfilerCallback.ExceptionSearchFilterEnter"/>
        /// callback is received by the profiler) or has just been run (<see cref="ICorProfilerCallback.ExceptionCatcherLeave"/>,
        /// <see cref="ICorProfilerCallback.ExceptionUnwindFinallyLeave"/>, or <see cref="ICorProfilerCallback.ExceptionSearchFilterLeave"/>
        /// callback is received by the profiler). This call can be made at any time after one of the Enter callbacks above
        /// until either the matching Leave callback is received or a nested exception is thrown in the current clause, in
        /// which case there is no Leave notification for that clause. Note that it is not possible for a thrown exception
        /// to escape a filter exception clause, so there is always a Leave notification in that case.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNotifiedExceptionClauseInfo(
            [Out] out COR_PRF_EX_CLAUSE_INFO pinfo);
#endif

        /// <summary>
        /// Returns an enumerator for all functions that were previously JIT-compiled.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the <see cref="ICorProfilerFunctionEnum"/> enumerator.</param>
        /// <remarks>
        /// This method may overlap with JITCompilation callbacks such as the <see cref="ICorProfilerCallback.JITCompilationStarted"/>
        /// method. The enumerator returned by this method does not include functions that are loaded from native images generated
        /// with Ngen.exe.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumJITedFunctions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerFunctionEnum ppEnum);

        /// <summary>
        /// Instructs the runtime to detach the profiler.
        /// </summary>
        /// <param name="dwExpectedCompletionMilliseconds">[in] The length of time, in milliseconds, the common language runtime (CLR) should wait before checking to see whether it is safe to unload the profiler.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                                        | Description                                                                                                                                                                                                                                                                                                                                                     |
        /// | ---------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                                           | The detach request is valid, and the detach procedure is now continuing on another thread. When the detach is fully complete, a ProfilerDetachSucceeded event is issued.                                                                                                                                                                                        |
        /// | E_CORPROF_E_CALLBACK3_REQUIRED                 | The profiler failed an IUnknown attempt for the <see cref="ICorProfilerCallback3"/> interface, which it must implement to support the detach operation. Detach was not attempted.                                                                                                                                                                               |
        /// | CORPROF_E_IMMUTABLE_FLAGS_SET                  | Detachment is impossible because the profiler set immutable flags at startup. Detachment was not attempted; the profiler is still fully attached.                                                                                                                                                                                                               |
        /// | CORPROF_E_IRREVERSIBLE_INSTRUMENTATION_PRESENT | Detachment is impossible because the profiler used instrumented Microsoft intermediate language (MSIL) code, or inserted enter/leave hooks. Detachment was not attempted; the profiler is still fully attached. Note Instrumented MSIL is code is code that is provided by the profiler using the <see cref="ICorProfilerInfo.SetILFunctionBody"/> method.      |
        /// | CORPROF_E_RUNTIME_UNINITIALIZED                | The runtime has not been initialized yet in the managed application. (That is, the runtime has not been fully loaded.) This error code may be returned when detachment is requested inside the profiler callback's <see cref="ICorProfilerCallback.Initialize"/> method.                                                                                        |
        /// | CORPROF_E_UNSUPPORTED_CALL_SEQUENCE            | RequestProfilerDetach was called at an unsupported time. This occurs if the method is called on a managed thread but not from within an <see cref="ICorProfilerCallback"/> method or from within an <see cref="ICorProfilerCallback"/> method that cannot tolerate a garbage collection. For more information, see CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT. |
        /// </returns>
        /// <remarks>
        /// During the detach procedure, the detach thread (the thread created specifically for detaching the profiler) occasionally
        /// checks whether all threads have exited the profiler’s code. The profiler should provide an estimate of how long
        /// this should take through the dwExpectedCompletionMilliseconds parameter. A good value to use is the typical amount
        /// of time the profiler spends inside any given ICorProfilerCallback* method; this value should not be less than half
        /// of the maximum amount of time the profiler expects to spend. The detach thread uses dwExpectedCompletionMilliseconds
        /// to decide how long to sleep before checking whether profiler callback code has been popped off all stacks. Although
        /// the details of the following algorithm may change in future releases of the CLR, it illustrates one way dwExpectedCompletionMilliseconds
        /// can be used when determining when it is safe to unload the profiler. The detach thread first sleeps for dwExpectedCompletionMilliseconds
        /// milliseconds. If, after awakening from the sleep, the CLR finds that profiler callback code is still present, the
        /// detach thread sleeps again, this time for two times dwExpectedCompletionMilliseconds milliseconds. If, after awakening
        /// from this second sleep, the detach thread finds that profiler callback code is still present, it sleeps for 10
        /// minutes before checking again. The detach thread continues to recheck every 10 minutes. If the profiler specifies
        /// dwExpectedCompletionMilliseconds as 0 (zero), the CLR uses a default value of 5000, which means that it will perform
        /// a check after 5 seconds, again after 10 seconds, and then every 10 minutes thereafter.
        /// </remarks>
        [PreserveSig]
        HRESULT RequestProfilerDetach(
            [In] int dwExpectedCompletionMilliseconds);

        /// <summary>
        /// Specifies the profiler-implemented function that will be called to map FunctionID values to alternative values, which are passed to the profiler's function entry/exit hooks.<para/>
        /// This method extends the <see cref="ICorProfilerInfo.SetFunctionIDMapper"/> method with an additional data parameter, which profilers may use to disambiguate among runtimes.
        /// </summary>
        /// <param name="pFunc">[in] A pointer to a FunctionIDMapper2 implementation that will be called to map the FunctionID values to their alternative values.</param>
        /// <param name="clientData">[in] A pointer that is passed to every FunctionIDMapper2 function call made by the current runtime. The profiler can use this information to disambiguate among runtimes.</param>
        /// <remarks>
        /// The alternatives for the FunctionID values will be passed to the profiler's function entry/exit hooks (FunctionEnter3,
        /// FunctionLeave3, and FunctionTailcall3; or FunctionEnter3WithInfo, FunctionLeave3WithInfo, and FunctionTailcall3WithInfo)
        /// that are specified by the <see cref="SetEnterLeaveFunctionHooks3"/> or <see cref="SetEnterLeaveFunctionHooks3WithInfo"/>
        /// method. The FunctionIDMapper2 method can be set only once; we recommend that you set it in the <see cref="ICorProfilerCallback.Initialize"/>
        /// callback.
        /// </remarks>
        [PreserveSig]
        HRESULT SetFunctionIDMapper2(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionIDMapper2 pFunc,
            [In] IntPtr clientData);

        /// <summary>
        /// Gets information about the layout of a string object. This method supersedes the <see cref="ICorProfilerInfo2.GetStringLayout"/> method.
        /// </summary>
        /// <param name="pStringLengthOffset">[out] A pointer to the offset of the location, relative to the ObjectID pointer, that stores the length of the string itself.<para/>
        /// The length is stored as a DWORD.</param>
        /// <param name="pBufferOffset">[out] A pointer to the offset of the buffer, relative to the ObjectID pointer, which stores the string of wide characters.</param>
        /// <remarks>
        /// Strings may or may not be null-terminated.
        /// </remarks>
        [PreserveSig]
        HRESULT GetStringLayout2(
            [Out] out int pStringLengthOffset,
            [Out] out int pBufferOffset);

        /// <summary>
        /// Specifies the profiler-implemented functions that will be called on the FunctionEnter3, FunctionLeave3, and FunctionTailcall3 functions.
        /// </summary>
        /// <param name="pFuncEnter3">[in] A pointer to the implementation to be used as the FunctionEnter3 callback.</param>
        /// <param name="pFuncLeave3">[in] A pointer to the implementation to be used as the FunctionLeave3 callback.</param>
        /// <param name="pFuncTailcall3">[in] A pointer to the implementation to be used as the FunctionTailcall3 callback.</param>
        /// <remarks>
        /// FunctionEnter3, FunctionLeave3, and FunctionTailcall3 hooks do not provide stack frame and argument inspection.
        /// To access that information, the COR_PRF_ENABLE_FUNCTION_ARGS, COR_PRF_ENABLE_FUNCTION_RETVAL, and/or COR_PRF_ENABLE_FRAME_INFO
        /// flags have to be set. The profiler can use the <see cref="ICorProfilerInfo.SetEventMask"/> method to set the event
        /// flags, and then use the <see cref="SetEnterLeaveFunctionHooks3WithInfo"/> method to register your implementation
        /// of this function. Only one set of callbacks may be active at a time, and the newest version takes precedence. Therefore,
        /// if a profiler calls both the <see cref="ICorProfilerInfo2.SetEnterLeaveFunctionHooks2"/> and the SetEnterLeaveFunctionHooks3
        /// method, SetEnterLeaveFunctionHooks3 is used. The SetEnterLeaveFunctionHooks3 method may be called only from the
        /// profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        [PreserveSig]
        HRESULT SetEnterLeaveFunctionHooks3(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter3 pFuncEnter3,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave3 pFuncLeave3,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall3 pFuncTailcall3);

        /// <summary>
        /// Specifies the profiler-implemented functions that will be called on the FunctionEnter3WithInfo, FunctionLeave3WithInfo, and FunctionTailcall3WithInfo hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter3WithInfo">[in] A pointer to the implementation to be used as the FunctionEnter3WithInfo callback.</param>
        /// <param name="pFuncLeave3WithInfo">[in] A pointer to the implementation to be used as the FunctionLeave3WithInfo callback.</param>
        /// <param name="pFuncTailcall3WithInfo">[in] A pointer to the implementation to be used as the FunctionTailcall3WithInfo callback.</param>
        /// <remarks>
        /// The FunctionEnter3WithInfo, FunctionLeave3WithInfo, and FunctionTailcall3WithInfo hooks provide stack frame and
        /// argument inspection. To access that information, the COR_PRF_ENABLE_FUNCTION_ARGS, COR_PRF_ENABLE_FUNCTION_RETVAL,
        /// and/or COR_PRF_ENABLE_FRAME_INFO flags have to be set. The profiler can use the <see cref="ICorProfilerInfo.SetEventMask"/>
        /// method to set the event flags, and then use the SetEnterLeaveFunctionHooks3WithInfo method to register your implementation
        /// of this function. Only one set of callbacks may be active at a time, and the newest version takes precedence. Therefore,
        /// if a profiler calls both <see cref="ICorProfilerInfo2.SetEnterLeaveFunctionHooks2"/> and SetEnterLeaveFunctionHooks3WithInfo,
        /// SetEnterLeaveFunctionHooks3WithInfo is used. The SetEnterLeaveFunctionHooks3WithInfo method may be called only
        /// from the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        [PreserveSig]
        HRESULT SetEnterLeaveFunctionHooks3WithInfo(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter3WithInfo pFuncEnter3WithInfo,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave3WithInfo pFuncLeave3WithInfo,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall3WithInfo pFuncTailcall3WithInfo);

        /// <summary>
        /// Provides the stack frame and argument information of the function that is being reported to the profiler by the FunctionEnter3WithInfo function.<para/>
        /// This method can be called only during the FunctionEnter3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is being entered.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that it was given by the FunctionEnter3WithInfo function.</param>
        /// <param name="pFrameInfo">[out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the FunctionEnter3WithInfo callback in which the profiler called the GetFunctionEnter3Info method.</param>
        /// <param name="pcbArgumentInfo">[in, out] A pointer to the total size, in bytes, of the <see cref="COR_PRF_FUNCTION_ARGUMENT_INFO"/> structure (plus any additional <see cref="COR_PRF_FUNCTION_ARGUMENT_RANGE"/> structures for the argument ranges pointed to by pArgumentInfo).<para/>
        /// If the specified size is not enough, ERROR_INSUFFICIENT_BUFFER is returned and the expected size is stored in pcbArgumentInfo.<para/>
        /// To call GetFunctionEnter3Info just to retrieve the expected value for *pcbArgumentInfo, set *pcbArgumentInfo=0 and pArgumentInfo=NULL.</param>
        /// <param name="pArgumentInfo">[out] A pointer to a <see cref="COR_PRF_FUNCTION_ARGUMENT_INFO"/> structure that describes the locations of the function's arguments in memory, in left-to-right order.</param>
        /// <remarks>
        /// The profiler must allocate sufficient space for the COR_PRF_FUNCTION_ARGUMENT_INFO structure of the function that
        /// is being inspected, and must indicate the size in the pcbArgumentInfo parameter.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFunctionEnter3Info(
            [In] FunctionID functionId,
            [In] COR_PRF_ELT_INFO eltInfo,
            [Out] out COR_PRF_FRAME_INFO pFrameInfo,
            [In, Out] ref int pcbArgumentInfo,
            [Out] out COR_PRF_FUNCTION_ARGUMENT_INFO pArgumentInfo);

        /// <summary>
        /// Provides the stack frame and return value of the function that is being reported to the profiler by the FunctionLeave3WithInfo function function.<para/>
        /// This method can be called only during the FunctionLeave3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is returning.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that was given to the profiler by the FunctionLeave3WithInfo function.</param>
        /// <param name="pFrameInfo">[out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the FunctionLeave3WithInfo callback in which the profiler called the GetFunctionLeave3Info method.</param>
        /// <param name="pRetvalRange">[out] A pointer to a <see cref="COR_PRF_FUNCTION_ARGUMENT_RANGE"/> structure that contains the value that is returned from the function.<para/>
        /// To access return value information, the COR_PRF_ENABLE_FUNCTION_RETVAL flag must be set. The profiler can use the <see cref="ICorProfilerInfo.SetEventMask"/> to set the event flags.</param>
        [PreserveSig]
        HRESULT GetFunctionLeave3Info(
            [In] FunctionID functionId,
            [In] COR_PRF_ELT_INFO eltInfo,
            [Out] out COR_PRF_FRAME_INFO pFrameInfo,
            [Out] out COR_PRF_FUNCTION_ARGUMENT_RANGE pRetvalRange);

        /// <summary>
        /// Provides the stack frame of the function that is being reported to the profiler by the FunctionTailcall3WithInfo function.<para/>
        /// This method can be called only during the FunctionTailcall3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is returning.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that was given to the profiler by the FunctionTailcall3WithInfo function.</param>
        /// <param name="pFrameInfo">[out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the FunctionTailcall3WithInfo callback in which the profiler called the GetFunctionTailcall3Info method.</param>
        [PreserveSig]
        HRESULT GetFunctionTailcall3Info(
            [In] FunctionID functionId,
            [In] COR_PRF_ELT_INFO eltInfo,
            [Out] out COR_PRF_FRAME_INFO pFrameInfo);

        /// <summary>
        /// Returns an enumerator that provides methods to sequentially iterate through a collection of managed modules that are loaded into the application.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to an <see cref="ICorProfilerModuleEnum"/> interface.</param>
        [PreserveSig]
        HRESULT EnumModules(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerModuleEnum ppEnum);

        /// <summary>
        /// Provides version information about the common language runtime (CLR) that is being profiled.
        /// </summary>
        /// <param name="pClrInstanceId">[out] The representative ID of a running CLR instance in a process. This is the same as the ClrInstanceID that the event tracing for Windows (ETW) startup event reports.</param>
        /// <param name="pRuntimeType">[out] The runtime type. This parameter returns COR_PRF_DESKTOP_CLR for the desktop version of the CLR, or COR_PRF_CORE_CLR for the core version of the CLR used in Silverlight.</param>
        /// <param name="pMajorVersion">[out] The major version number of the CLR.</param>
        /// <param name="pMinorVersion">[out] The minor version number of the CLR.</param>
        /// <param name="pBuildNumber">[out] The build version number of the CLR.</param>
        /// <param name="pQFEVersion">[out] The version number of the CLR that is associated with a software update.</param>
        /// <param name="cchVersionString">[in] The length, in characters, of the buffer that szVersionString points to.</param>
        /// <param name="pcchVersionString">[out] The length, in characters, of szVersionString.</param>
        /// <param name="szVersionString">[out] The CLR version string.</param>
        /// <remarks>
        /// You may pass null for any parameter. However, pcchVersionString cannot be null unless szVersionString is also null.
        /// </remarks>
        [PreserveSig]
        HRESULT GetRuntimeInformation(
            [Out] out ushort pClrInstanceId,
            [Out] out COR_PRF_RUNTIME_TYPE pRuntimeType,
            [Out] out ushort pMajorVersion,
            [Out] out ushort pMinorVersion,
            [Out] out ushort pBuildNumber,
            [Out] out ushort pQFEVersion,
            [In] int cchVersionString,
            [Out] out int pcchVersionString,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 6)] char[] szVersionString);

        /// <summary>
        /// Gets the address of the specified thread-static field that is in the scope of the specified thread and application domain.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested thread-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested thread-static field.</param>
        /// <param name="appDomainId">[in] The ID of the application domain.</param>
        /// <param name="threadId">[in] The ID of the thread that is the scope for the requested static field.</param>
        /// <param name="ppAddress">[out] A pointer to the address of the static field that is within the specified thread.</param>
        /// <remarks>
        /// The GetThreadStaticAddress2 method may return one of the following: Before a class’s class constructor is completed,
        /// GetThreadStaticAddress2 will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and rooting garbage collection objects. The <see cref="ICorProfilerInfo2.GetThreadStaticAddress"/>
        /// method is similar to the GetThreadStaticAddress2 method, but does not accept an application domain argument.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadStaticAddress2(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] AppDomainID appDomainId,
            [In] ThreadID threadId,
            [Out] out IntPtr ppAddress);

        /// <summary>
        /// Gets the identifiers of the application domains in which the given module has been loaded.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the loaded module.</param>
        /// <param name="cAppDomainIds">[in] The size of the appDomainIds array.</param>
        /// <param name="pcAppDomainIds">[out] A pointer to the total number of returned elements.</param>
        /// <param name="appDomainIds">[out] An array of application domain ID values.</param>
        /// <remarks>
        /// The method uses caller allocated buffers.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAppDomainsContainingModule(
            [In] ModuleID moduleId,
            [In] int cAppDomainIds,
            [Out] out int pcAppDomainIds,
            [MarshalAs(UnmanagedType.LPArray), SRI.Out] AppDomainID[] appDomainIds);

        /// <summary>
        /// Given a module ID, returns the file name of the module, the ID of the module's parent assembly, and a bitmask that describes the properties of the module.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module for which information will be retrieved.</param>
        /// <param name="ppBaseLoadAddress">[out] The base address at which the module is loaded.</param>
        /// <param name="cchName">[in] The length, in characters, of the szName return buffer.</param>
        /// <param name="pcchName">[out] A pointer to the total character length of the module's file name that is returned.</param>
        /// <param name="szName">[out] A caller-provided wide character buffer. When the method returns, this buffer contains the file name of the module.</param>
        /// <param name="pAssemblyId">[out] A pointer to the ID of the module's parent assembly.</param>
        /// <param name="pdwModuleFlags">[out] A bitmask of values from the COR_PRF_MODULE_FLAGS enumeration that specify the properties of the module.</param>
        /// <remarks>
        /// For dynamic modules, the szName parameter is the metadata name of the module, and the base address is 0 (zero).
        /// The metadata name is the value in the Name column from the Module table inside metadata. This is also exposed as
        /// the <see cref="Module.ScopeName"/> property to managed code, and as the szName parameter of the IMetaDataImport
        /// method to unmanaged metadata client code. Although the GetModuleInfo2 method may be called as soon as the module's
        /// ID exists, the ID of the parent assembly will not be available until the profiler receives the <see cref="ICorProfilerCallback.ModuleAttachedToAssembly"/>
        /// callback. When GetModuleInfo2 returns, you must verify that the szName buffer was large enough to contain the full
        /// file name of the module. To do this, compare the value that pcchName points to with the value of the cchName parameter.
        /// If pcchName points to a value that is larger than cchName, allocate a larger szName buffer, update cchName with
        /// the new, larger size, and call GetModuleInfo2 again. Alternatively, you can first call GetModuleInfo2 with a zero-length
        /// szName buffer to obtain the correct buffer size. You can then set the buffer size to the value returned in pcchName
        /// and call GetModuleInfo2 again.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleInfo2(
            [In] ModuleID moduleId,
            [Out] out IntPtr ppBaseLoadAddress,
            [In] int cchName,
            [Out] out int pcchName,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] szName,
            [Out] out AssemblyID pAssemblyId,
            [Out] out COR_PRF_MODULE_FLAGS pdwModuleFlags);
    }
}
