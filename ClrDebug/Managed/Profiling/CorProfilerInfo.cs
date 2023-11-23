using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using static ClrDebug.Extensions;

namespace ClrDebug
{
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
    public class CorProfilerInfo : ComObject<ICorProfilerInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorProfilerInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorProfilerInfo(ICorProfilerInfo raw) : base(raw)
        {
        }

        #region ICorProfilerInfo
        #region EventMask

        /// <summary>
        /// Gets or sets the current event categories for which the profiler wants to receive event notifications from the common language runtime (CLR).
        /// </summary>
        public COR_PRF_MONITOR EventMask
        {
            get
            {
                COR_PRF_MONITOR pdwEvents;
                TryGetEventMask(out pdwEvents).ThrowOnNotOK();

                return pdwEvents;
            }
            set
            {
                TrySetEventMask(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Gets the current event categories for which the profiler wants to receive event notifications from the common language runtime (CLR).
        /// </summary>
        /// <param name="pdwEvents">[out] A pointer to a 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.</param>
        public HRESULT TryGetEventMask(out COR_PRF_MONITOR pdwEvents)
        {
            /*HRESULT GetEventMask(
            [Out] out COR_PRF_MONITOR pdwEvents);*/
            return Raw.GetEventMask(out pdwEvents);
        }

        /// <summary>
        /// Sets a value that specifies the types of events for which the profiler wants to receive notification from the common language runtime (CLR).
        /// </summary>
        /// <param name="dwEvents">[in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.</param>
        public HRESULT TrySetEventMask(COR_PRF_MONITOR dwEvents)
        {
            /*HRESULT SetEventMask(
            [In] COR_PRF_MONITOR dwEvents);*/
            return Raw.SetEventMask(dwEvents);
        }

        #endregion
        #region CurrentThreadID

        /// <summary>
        /// Gets the ID of the current thread, if it is a managed thread.
        /// </summary>
        public ThreadID CurrentThreadID
        {
            get
            {
                ThreadID pThreadId;
                TryGetCurrentThreadID(out pThreadId).ThrowOnNotOK();

                return pThreadId;
            }
        }

        /// <summary>
        /// Gets the ID of the current thread, if it is a managed thread.
        /// </summary>
        /// <param name="pThreadId">[out] A pointer to the returned ID of the managed thread.</param>
        /// <remarks>
        /// If the current thread is an internal runtime thread or other unmanaged thread, GetCurrentThreadID returns CORPROF_E_NOT_MANAGED_THREAD
        /// as the HRESULT, and the returned value of the pThreadId parameter will be null.
        /// </remarks>
        public HRESULT TryGetCurrentThreadID(out ThreadID pThreadId)
        {
            /*HRESULT GetCurrentThreadID(
            [Out] out ThreadID pThreadId);*/
            return Raw.GetCurrentThreadID(out pThreadId);
        }

        #endregion
        #region InprocInspectionInterface

        /// <summary>
        /// Gets an object that can be queried for an "ICorDebugProcess" interface. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        public object InprocInspectionInterface
        {
            get
            {
                object ppicd;
                TryGetInprocInspectionInterface(out ppicd).ThrowOnNotOK();

                return ppicd;
            }
        }

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
        public HRESULT TryGetInprocInspectionInterface(out object ppicd)
        {
            /*HRESULT GetInprocInspectionInterface(
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppicd);*/
            return Raw.GetInprocInspectionInterface(out ppicd);
        }

        #endregion
        #region InprocInspectionIThisThread

        /// <summary>
        /// Gets an object that can be queried for the ICorDebugThread interface. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        public object InprocInspectionIThisThread
        {
            get
            {
                object ppicd;
                TryGetInprocInspectionIThisThread(out ppicd).ThrowOnNotOK();

                return ppicd;
            }
        }

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
        public HRESULT TryGetInprocInspectionIThisThread(out object ppicd)
        {
            /*HRESULT GetInprocInspectionIThisThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppicd);*/
            return Raw.GetInprocInspectionIThisThread(out ppicd);
        }

        #endregion
        #region GetClassFromObject

        /// <summary>
        /// Gets the ClassID of an object, given its ObjectID.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object for which to get the ClassID.</param>
        /// <returns>[out] A pointer to the returned ClassID.</returns>
        /// <remarks>
        /// A null pClassId indicates that objectId has a type that is unloading.
        /// </remarks>
        public ClassID GetClassFromObject(ObjectID objectId)
        {
            ClassID pClassId;
            TryGetClassFromObject(objectId, out pClassId).ThrowOnNotOK();

            return pClassId;
        }

        /// <summary>
        /// Gets the ClassID of an object, given its ObjectID.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object for which to get the ClassID.</param>
        /// <param name="pClassId">[out] A pointer to the returned ClassID.</param>
        /// <remarks>
        /// A null pClassId indicates that objectId has a type that is unloading.
        /// </remarks>
        public HRESULT TryGetClassFromObject(ObjectID objectId, out ClassID pClassId)
        {
            /*HRESULT GetClassFromObject(
            [In] ObjectID objectId,
            [Out] out ClassID pClassId);*/
            return Raw.GetClassFromObject(objectId, out pClassId);
        }

        #endregion
        #region GetClassFromToken

        /// <summary>
        /// Gets the ID of the class, given the metadata token. This method is obsolete in .NET Framework version 2.0. Use <see cref="GetClassFromTokenAndTypeArgs"/> instead.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that contains the class.</param>
        /// <param name="typeDef">[in] An mdTypeDef metadata token that references the class.</param>
        /// <returns>[out] A pointer to the class ID.</returns>
        /// <remarks>
        /// This method is obsolete; instead, use ICorProfilerInfo2::GetClassFromTokenAndTypeArgs for all types.
        /// </remarks>
        public ClassID GetClassFromToken(ModuleID moduleId, mdTypeDef typeDef)
        {
            ClassID pClassId;
            TryGetClassFromToken(moduleId, typeDef, out pClassId).ThrowOnNotOK();

            return pClassId;
        }

        /// <summary>
        /// Gets the ID of the class, given the metadata token. This method is obsolete in .NET Framework version 2.0. Use <see cref="GetClassFromTokenAndTypeArgs"/> instead.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that contains the class.</param>
        /// <param name="typeDef">[in] An mdTypeDef metadata token that references the class.</param>
        /// <param name="pClassId">[out] A pointer to the class ID.</param>
        /// <remarks>
        /// This method is obsolete; instead, use ICorProfilerInfo2::GetClassFromTokenAndTypeArgs for all types.
        /// </remarks>
        public HRESULT TryGetClassFromToken(ModuleID moduleId, mdTypeDef typeDef, out ClassID pClassId)
        {
            /*HRESULT GetClassFromToken(
            [In] ModuleID moduleId,
            [In] mdTypeDef typeDef,
            [Out] out ClassID pClassId);*/
            return Raw.GetClassFromToken(moduleId, typeDef, out pClassId);
        }

        #endregion
        #region GetCodeInfo

        /// <summary>
        /// Gets the extent of native code associated with the specified function ID. This method is obsolete. Use the <see cref="GetCodeInfo2"/> method instead.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// To optimize performance, the runtime in the .NET Framework version 2.0 splits the precompiled, native code of a
        /// function into multiple regions. Consequently, the GetCodeInfo method is obsolete in the .NET Framework 2.0 because
        /// it is unable to handle the extent of a function's native code. Profilers should switch to using the more general
        /// ICorProfilerInfo2::GetCodeInfo2 method instead. This function uses caller-allocated buffers.
        /// </remarks>
        public GetCodeInfoResult GetCodeInfo(FunctionID functionId)
        {
            GetCodeInfoResult result;
            TryGetCodeInfo(functionId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the extent of native code associated with the specified function ID. This method is obsolete. Use the <see cref="GetCodeInfo2"/> method instead.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// To optimize performance, the runtime in the .NET Framework version 2.0 splits the precompiled, native code of a
        /// function into multiple regions. Consequently, the GetCodeInfo method is obsolete in the .NET Framework 2.0 because
        /// it is unable to handle the extent of a function's native code. Profilers should switch to using the more general
        /// ICorProfilerInfo2::GetCodeInfo2 method instead. This function uses caller-allocated buffers.
        /// </remarks>
        public HRESULT TryGetCodeInfo(FunctionID functionId, out GetCodeInfoResult result)
        {
            /*HRESULT GetCodeInfo(
            [In] FunctionID functionId,
            [Out] out IntPtr pStart,
            [Out] out int pcSize);*/
            IntPtr pStart;
            int pcSize;
            HRESULT hr = Raw.GetCodeInfo(functionId, out pStart, out pcSize);

            if (hr == HRESULT.S_OK)
                result = new GetCodeInfoResult(pStart, pcSize);
            else
                result = default(GetCodeInfoResult);

            return hr;
        }

        #endregion
        #region GetFunctionFromIP

        /// <summary>
        /// Maps a managed code instruction pointer to a FunctionID.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <returns>[out] The returned function ID.</returns>
        public FunctionID GetFunctionFromIP(IntPtr ip)
        {
            FunctionID pFunctionId;
            TryGetFunctionFromIP(ip, out pFunctionId).ThrowOnNotOK();

            return pFunctionId;
        }

        /// <summary>
        /// Maps a managed code instruction pointer to a FunctionID.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <param name="pFunctionId">[out] The returned function ID.</param>
        public HRESULT TryGetFunctionFromIP(IntPtr ip, out FunctionID pFunctionId)
        {
            /*HRESULT GetFunctionFromIP(
            [In] IntPtr ip,
            [Out] out FunctionID pFunctionId);*/
            return Raw.GetFunctionFromIP(ip, out pFunctionId);
        }

        #endregion
        #region GetFunctionFromToken

        /// <summary>
        /// Gets the ID of a function. This method is obsolete in .NET Framework version 2.0. Use the <see cref="GetFunctionFromTokenAndTypeArgs"/> method instead.
        /// </summary>
        /// <remarks>
        /// The GetFunctionFromToken method will not work for generic functions or functions in generic types; it is now obsolete.
        /// Use ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs for all functions.
        /// </remarks>
        public FunctionID GetFunctionFromToken(ModuleID moduleId, mdToken token)
        {
            FunctionID pFunctionId;
            TryGetFunctionFromToken(moduleId, token, out pFunctionId).ThrowOnNotOK();

            return pFunctionId;
        }

        /// <summary>
        /// Gets the ID of a function. This method is obsolete in .NET Framework version 2.0. Use the <see cref="GetFunctionFromTokenAndTypeArgs"/> method instead.
        /// </summary>
        /// <remarks>
        /// The GetFunctionFromToken method will not work for generic functions or functions in generic types; it is now obsolete.
        /// Use ICorProfilerInfo2::GetFunctionFromTokenAndTypeArgs for all functions.
        /// </remarks>
        public HRESULT TryGetFunctionFromToken(ModuleID moduleId, mdToken token, out FunctionID pFunctionId)
        {
            /*HRESULT GetFunctionFromToken(
            [In] ModuleID moduleId,
            [In] mdToken token,
            [Out] out FunctionID pFunctionId);*/
            return Raw.GetFunctionFromToken(moduleId, token, out pFunctionId);
        }

        #endregion
        #region GetHandleFromThread

        /// <summary>
        /// Maps the ID of a thread to a Win32 thread handle.
        /// </summary>
        /// <param name="threadId">[in] The thread ID to be mapped.</param>
        /// <returns>[out] A pointer to a Win32 thread handle.</returns>
        /// <remarks>
        /// The profiler must call the Win32 DuplicateHandle function on the handle before using it. The handle returned from
        /// this method is owned by the runtime and the profiler should never close it.
        /// </remarks>
        public IntPtr GetHandleFromThread(ThreadID threadId)
        {
            IntPtr phThread;
            TryGetHandleFromThread(threadId, out phThread).ThrowOnNotOK();

            return phThread;
        }

        /// <summary>
        /// Maps the ID of a thread to a Win32 thread handle.
        /// </summary>
        /// <param name="threadId">[in] The thread ID to be mapped.</param>
        /// <param name="phThread">[out] A pointer to a Win32 thread handle.</param>
        /// <remarks>
        /// The profiler must call the Win32 DuplicateHandle function on the handle before using it. The handle returned from
        /// this method is owned by the runtime and the profiler should never close it.
        /// </remarks>
        public HRESULT TryGetHandleFromThread(ThreadID threadId, out IntPtr phThread)
        {
            /*HRESULT GetHandleFromThread(
            [In] ThreadID threadId,
            [Out] out IntPtr phThread);*/
            return Raw.GetHandleFromThread(threadId, out phThread);
        }

        #endregion
        #region GetObjectSize

        /// <summary>
        /// Gets the size of a specified object.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object.</param>
        /// <returns>[out] A pointer to the object's size, in bytes.</returns>
        /// <remarks>
        /// Different objects of the same types often have the same size. However, some types, such as arrays or strings, may
        /// have a different size for each object. The size returned by the GetObjectSize method does not include any alignment
        /// padding that may appear after the object is on the garbage collection heap. If you use the GetObjectSize method
        /// to advance from object to object on the garbage collection heap, add alignment padding manually, as necessary.
        /// </remarks>
        public int GetObjectSize(ObjectID objectId)
        {
            int pcSize;
            TryGetObjectSize(objectId, out pcSize).ThrowOnNotOK();

            return pcSize;
        }

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
        public HRESULT TryGetObjectSize(ObjectID objectId, out int pcSize)
        {
            /*HRESULT GetObjectSize(
            [In] ObjectID objectId,
            [Out] out int pcSize);*/
            return Raw.GetObjectSize(objectId, out pcSize);
        }

        #endregion
        #region IsArrayClass

        /// <summary>
        /// Determines whether the specified class is an array class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class to be examined.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// If the specified class is an array class, the IsArrayClass method returns an S_OK HRESULT and values for any non-null
        /// output parameters. Otherwise, it returns S_FALSE.
        /// </remarks>
        public IsArrayClassResult IsArrayClass(ClassID classId)
        {
            IsArrayClassResult result;
            TryIsArrayClass(classId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Determines whether the specified class is an array class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class to be examined.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// If the specified class is an array class, the IsArrayClass method returns an S_OK HRESULT and values for any non-null
        /// output parameters. Otherwise, it returns S_FALSE.
        /// </remarks>
        public HRESULT TryIsArrayClass(ClassID classId, out IsArrayClassResult result)
        {
            /*HRESULT IsArrayClass(
            [In] ClassID classId,
            [Out] out CorElementType pBaseElemType,
            [Out] out ClassID pBaseClassId,
            [Out] out int pcRank);*/
            CorElementType pBaseElemType;
            ClassID pBaseClassId;
            int pcRank;
            HRESULT hr = Raw.IsArrayClass(classId, out pBaseElemType, out pBaseClassId, out pcRank);

            if (hr == HRESULT.S_OK)
                result = new IsArrayClassResult(pBaseElemType, pBaseClassId, pcRank);
            else
                result = default(IsArrayClassResult);

            return hr;
        }

        #endregion
        #region GetThreadInfo

        /// <summary>
        /// Gets the current Win32 thread identity for the specified thread.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread for which to get the current Win32 ID.</param>
        /// <returns>[out] A pointer to the specified thread's current Win32 thread ID.</returns>
        public int GetThreadInfo(ThreadID threadId)
        {
            int pdwWin32ThreadId;
            TryGetThreadInfo(threadId, out pdwWin32ThreadId).ThrowOnNotOK();

            return pdwWin32ThreadId;
        }

        /// <summary>
        /// Gets the current Win32 thread identity for the specified thread.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread for which to get the current Win32 ID.</param>
        /// <param name="pdwWin32ThreadId">[out] A pointer to the specified thread's current Win32 thread ID.</param>
        public HRESULT TryGetThreadInfo(ThreadID threadId, out int pdwWin32ThreadId)
        {
            /*HRESULT GetThreadInfo(
            [In] ThreadID threadId,
            [Out] out int pdwWin32ThreadId);*/
            return Raw.GetThreadInfo(threadId, out pdwWin32ThreadId);
        }

        #endregion
        #region GetClassIDInfo

        /// <summary>
        /// Gets the parent module and the metadata token for the specified class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which to get the information.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for a given module. The
        /// metadata token that is returned to the location referenced by pTypeDefToken can then be used to access the metadata
        /// for the class. To get more information for generic types, use <see cref="GetClassIDInfo2"/>.
        /// </remarks>
        public GetClassIDInfoResult GetClassIDInfo(ClassID classId)
        {
            GetClassIDInfoResult result;
            TryGetClassIDInfo(classId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the parent module and the metadata token for the specified class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which to get the information.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for a given module. The
        /// metadata token that is returned to the location referenced by pTypeDefToken can then be used to access the metadata
        /// for the class. To get more information for generic types, use <see cref="GetClassIDInfo2"/>.
        /// </remarks>
        public HRESULT TryGetClassIDInfo(ClassID classId, out GetClassIDInfoResult result)
        {
            /*HRESULT GetClassIDInfo(
            [In] ClassID classId,
            [Out] out ModuleID pModuleId,
            [Out] out mdTypeDef pTypeDefToken);*/
            ModuleID pModuleId;
            mdTypeDef pTypeDefToken;
            HRESULT hr = Raw.GetClassIDInfo(classId, out pModuleId, out pTypeDefToken);

            if (hr == HRESULT.S_OK)
                result = new GetClassIDInfoResult(pModuleId, pTypeDefToken);
            else
                result = default(GetClassIDInfoResult);

            return hr;
        }

        #endregion
        #region GetFunctionInfo

        /// <summary>
        /// Gets the parent class and metadata token for the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to get the parent class and metadata token.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for a given module. The
        /// metadata token that is returned to the location referenced by pToken can then be used to access the metadata for
        /// the function. The ClassID of a function on a generic class might not be obtainable without more contextual information
        /// about the use of the function. In this case, pClassId will be 0. Profiler code should use <see cref="GetFunctionInfo2"/>
        /// with a COR_PRF_FRAME_INFO value to provide more context.
        /// </remarks>
        public GetFunctionInfoResult GetFunctionInfo(FunctionID functionId)
        {
            GetFunctionInfoResult result;
            TryGetFunctionInfo(functionId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the parent class and metadata token for the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to get the parent class and metadata token.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for a given module. The
        /// metadata token that is returned to the location referenced by pToken can then be used to access the metadata for
        /// the function. The ClassID of a function on a generic class might not be obtainable without more contextual information
        /// about the use of the function. In this case, pClassId will be 0. Profiler code should use <see cref="GetFunctionInfo2"/>
        /// with a COR_PRF_FRAME_INFO value to provide more context.
        /// </remarks>
        public HRESULT TryGetFunctionInfo(FunctionID functionId, out GetFunctionInfoResult result)
        {
            /*HRESULT GetFunctionInfo(
            [In] FunctionID functionId,
            [Out] out ClassID pClassId,
            [Out] out ModuleID pModuleId,
            [Out] out mdToken pToken);*/
            ClassID pClassId;
            ModuleID pModuleId;
            mdToken pToken;
            HRESULT hr = Raw.GetFunctionInfo(functionId, out pClassId, out pModuleId, out pToken);

            if (hr == HRESULT.S_OK)
                result = new GetFunctionInfoResult(pClassId, pModuleId, pToken);
            else
                result = default(GetFunctionInfoResult);

            return hr;
        }

        #endregion
        #region SetEnterLeaveFunctionHooks

        /// <summary>
        /// Specifies profiler-implemented functions to be called on "enter", "leave", and "tailcall" hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter">[in] A pointer to the implementation to be used as the FunctionEnter callback.</param>
        /// <param name="pFuncLeave">[in] A pointer to the implementation to be used as the FunctionLeave callback.</param>
        /// <param name="pFuncTailcall">[in] A pointer to the implementation to be used as the FunctionTailcall callback.</param>
        /// <remarks>
        /// In .NET Framework version 1.0, each function pointer can be null to disable that corresponding callback. Only one
        /// set of callbacks can be active at a time. Thus, if a profiler calls both SetEnterLeaveFunctionHooks and <see cref="SetEnterLeaveFunctionHooks2"/>,
        /// then SetEnterLeaveFunctionHooks2 takes precedence. The SetEnterLeaveFunctionHooks method can be called only from
        /// the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public void SetEnterLeaveFunctionHooks(FunctionEnter pFuncEnter, FunctionLeave pFuncLeave, FunctionTailcall pFuncTailcall)
        {
            TrySetEnterLeaveFunctionHooks(pFuncEnter, pFuncLeave, pFuncTailcall).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies profiler-implemented functions to be called on "enter", "leave", and "tailcall" hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter">[in] A pointer to the implementation to be used as the FunctionEnter callback.</param>
        /// <param name="pFuncLeave">[in] A pointer to the implementation to be used as the FunctionLeave callback.</param>
        /// <param name="pFuncTailcall">[in] A pointer to the implementation to be used as the FunctionTailcall callback.</param>
        /// <remarks>
        /// In .NET Framework version 1.0, each function pointer can be null to disable that corresponding callback. Only one
        /// set of callbacks can be active at a time. Thus, if a profiler calls both SetEnterLeaveFunctionHooks and <see cref="SetEnterLeaveFunctionHooks2"/>,
        /// then SetEnterLeaveFunctionHooks2 takes precedence. The SetEnterLeaveFunctionHooks method can be called only from
        /// the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public HRESULT TrySetEnterLeaveFunctionHooks(FunctionEnter pFuncEnter, FunctionLeave pFuncLeave, FunctionTailcall pFuncTailcall)
        {
            /*HRESULT SetEnterLeaveFunctionHooks(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter pFuncEnter,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave pFuncLeave,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall pFuncTailcall);*/
            return Raw.SetEnterLeaveFunctionHooks(pFuncEnter, pFuncLeave, pFuncTailcall);
        }

        #endregion
        #region SetFunctionIDMapper

        /// <summary>
        /// Specifies the profiler-implemented function that will be called to map FunctionID values to alternative values, which are passed to the profiler's function entry/exit hooks.
        /// </summary>
        /// <param name="pFunc">[in] A pointer to the FunctionIDMapper implementation that will be called to map the FunctionID values to their alternative values.</param>
        /// <remarks>
        /// The alternatives for the FunctionID values will be passed to the profiler's function entry/exit hooks (FunctionEnter2,
        /// FunctionLeave2, and FunctionTailcall2) that are specified by the <see cref="SetEnterLeaveFunctionHooks2"/>
        /// method. The FunctionIDMapper can be set only once and it is recommended that you set it in the <see cref="ICorProfilerCallback.Initialize"/>
        /// callback.
        /// </remarks>
        public void SetFunctionIDMapper(FunctionIDMapper pFunc)
        {
            TrySetFunctionIDMapper(pFunc).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the profiler-implemented function that will be called to map FunctionID values to alternative values, which are passed to the profiler's function entry/exit hooks.
        /// </summary>
        /// <param name="pFunc">[in] A pointer to the FunctionIDMapper implementation that will be called to map the FunctionID values to their alternative values.</param>
        /// <remarks>
        /// The alternatives for the FunctionID values will be passed to the profiler's function entry/exit hooks (FunctionEnter2,
        /// FunctionLeave2, and FunctionTailcall2) that are specified by the <see cref="SetEnterLeaveFunctionHooks2"/>
        /// method. The FunctionIDMapper can be set only once and it is recommended that you set it in the <see cref="ICorProfilerCallback.Initialize"/>
        /// callback.
        /// </remarks>
        public HRESULT TrySetFunctionIDMapper(FunctionIDMapper pFunc)
        {
            /*HRESULT SetFunctionIDMapper(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionIDMapper pFunc);*/
            return Raw.SetFunctionIDMapper(pFunc);
        }

        #endregion
        #region GetTokenAndMetaDataFromFunction

        /// <summary>
        /// Gets the metadata token and a metadata interface instance that can be used against the token for the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to get the metadata token and metadata interface.</param>
        /// <param name="riid">[in] The reference ID of the metadata interface to get the instance of.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetTokenAndMetaDataFromFunctionResult GetTokenAndMetaDataFromFunction(FunctionID functionId, Guid riid)
        {
            GetTokenAndMetaDataFromFunctionResult result;
            TryGetTokenAndMetaDataFromFunction(functionId, riid, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the metadata token and a metadata interface instance that can be used against the token for the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to get the metadata token and metadata interface.</param>
        /// <param name="riid">[in] The reference ID of the metadata interface to get the instance of.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetTokenAndMetaDataFromFunction(FunctionID functionId, Guid riid, out GetTokenAndMetaDataFromFunctionResult result)
        {
            /*HRESULT GetTokenAndMetaDataFromFunction(
            [In] FunctionID functionId,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppImport,
            [Out] out mdToken pToken);*/
            object ppImport;
            mdToken pToken;
            HRESULT hr = Raw.GetTokenAndMetaDataFromFunction(functionId, riid, out ppImport, out pToken);

            if (hr == HRESULT.S_OK)
                result = new GetTokenAndMetaDataFromFunctionResult(ppImport, pToken);
            else
                result = default(GetTokenAndMetaDataFromFunctionResult);

            return hr;
        }

        #endregion
        #region GetModuleInfo

        /// <summary>
        /// Given a module ID, returns the file name of the module and the ID of the module's parent assembly.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module for which information will be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
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
        public GetModuleInfoResult GetModuleInfo(ModuleID moduleId)
        {
            GetModuleInfoResult result;
            TryGetModuleInfo(moduleId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Given a module ID, returns the file name of the module and the ID of the module's parent assembly.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module for which information will be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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
        public HRESULT TryGetModuleInfo(ModuleID moduleId, out GetModuleInfoResult result)
        {
            /*HRESULT GetModuleInfo(
            [In] ModuleID moduleId,
            [Out] out IntPtr ppBaseLoadAddress,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] szName,
            [Out] out AssemblyID pAssemblyId);*/
            IntPtr ppBaseLoadAddress;
            int cchName = 0;
            int pcchName;
            char[] szName;
            AssemblyID pAssemblyId;
            HRESULT hr = Raw.GetModuleInfo(moduleId, out ppBaseLoadAddress, cchName, out pcchName, null, out pAssemblyId);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw.GetModuleInfo(moduleId, out ppBaseLoadAddress, cchName, out pcchName, szName, out pAssemblyId);

            if (hr == HRESULT.S_OK)
            {
                result = new GetModuleInfoResult(ppBaseLoadAddress, CreateString(szName, pcchName), pAssemblyId);

                return hr;
            }

            fail:
            result = default(GetModuleInfoResult);

            return hr;
        }

        #endregion
        #region GetModuleMetaData

        /// <summary>
        /// Gets a metadata interface instance that maps to the specified module.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module to which the interface instance will be mapped.</param>
        /// <param name="dwOpenFlags">[in] A value of the CorOpenFlags enumeration that specifies the mode for opening manifest files. Only the ofRead, ofWrite and ofNoTransform bits are valid.</param>
        /// <param name="riid">[in] The reference ID (GUID) of the metadata interface whose instance will be retrieved. See Metadata Interfaces for a list of the interfaces.</param>
        /// <returns>[out] A pointer to the address of the metadata interface instance.</returns>
        /// <remarks>
        /// You may ask for the metadata to be opened in read/write mode, but this will result in slower metadata execution
        /// of the program, because changes made to the metadata cannot be optimized as they were from the compiler. Some modules
        /// (such as resource modules) have no metadata. In those cases, GetModuleMetaData will return an HRESULT value of
        /// S_FALSE, and a null in *ppOut.
        /// </remarks>
        public object GetModuleMetaData(ModuleID moduleId, CorOpenFlags dwOpenFlags, Guid riid)
        {
            object ppOut;
            TryGetModuleMetaData(moduleId, dwOpenFlags, riid, out ppOut).ThrowOnNotOK();

            return ppOut;
        }

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
        public HRESULT TryGetModuleMetaData(ModuleID moduleId, CorOpenFlags dwOpenFlags, Guid riid, out object ppOut)
        {
            /*HRESULT GetModuleMetaData(
            [In] ModuleID moduleId,
            [In] CorOpenFlags dwOpenFlags,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppOut);*/
            return Raw.GetModuleMetaData(moduleId, dwOpenFlags, riid, out ppOut);
        }

        #endregion
        #region GetILFunctionBody

        /// <summary>
        /// Gets a pointer to the body of a method in Microsoft intermediate language (MSIL) code, starting at its header.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the function resides.</param>
        /// <param name="methodId">[in] The metadata token for the method.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// A method is scoped by the module in which it lives. Because the GetILFunctionBody method is designed to give a
        /// tool access to the MSIL code before it has been loaded by the common language runtime (CLR), it uses the metadata
        /// token of the method to find the desired instance. GetILFunctionBody can return a CORPROF_E_FUNCTION_NOT_IL HRESULT
        /// if the methodId points to a method without any MSIL code (such as an abstract method, or a platform invoke (PInvoke)
        /// method).
        /// </remarks>
        public GetILFunctionBodyResult GetILFunctionBody(ModuleID moduleId, mdMethodDef methodId)
        {
            GetILFunctionBodyResult result;
            TryGetILFunctionBody(moduleId, methodId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets a pointer to the body of a method in Microsoft intermediate language (MSIL) code, starting at its header.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the function resides.</param>
        /// <param name="methodId">[in] The metadata token for the method.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// A method is scoped by the module in which it lives. Because the GetILFunctionBody method is designed to give a
        /// tool access to the MSIL code before it has been loaded by the common language runtime (CLR), it uses the metadata
        /// token of the method to find the desired instance. GetILFunctionBody can return a CORPROF_E_FUNCTION_NOT_IL HRESULT
        /// if the methodId points to a method without any MSIL code (such as an abstract method, or a platform invoke (PInvoke)
        /// method).
        /// </remarks>
        public HRESULT TryGetILFunctionBody(ModuleID moduleId, mdMethodDef methodId, out GetILFunctionBodyResult result)
        {
            /*HRESULT GetILFunctionBody(
            [In] ModuleID moduleId,
            [In] mdMethodDef methodId,
            [Out] out IntPtr ppMethodHeader,
            [Out] out int pcbMethodSize);*/
            IntPtr ppMethodHeader;
            int pcbMethodSize;
            HRESULT hr = Raw.GetILFunctionBody(moduleId, methodId, out ppMethodHeader, out pcbMethodSize);

            if (hr == HRESULT.S_OK)
                result = new GetILFunctionBodyResult(ppMethodHeader, pcbMethodSize);
            else
                result = default(GetILFunctionBodyResult);

            return hr;
        }

        #endregion
        #region GetILFunctionBodyAllocator

        /// <summary>
        /// Gets an interface that provides a method to allocate memory to be used for swapping out the body of a method in Microsoft intermediate language (MSIL) code.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the method resides.</param>
        /// <returns>[out] A pointer to an <see cref="IMethodMalloc"/> interface that provides a method to allocate the memory.</returns>
        /// <remarks>
        /// A method body in MSIL code must be located as a relative virtual address (RVA), relative to the loaded module,
        /// which means that it follows the module within 4 GB. To make it easier for a tool to swap out the body of a method,
        /// the GetILFunctionBodyAllocator method ensures that memory is allocated within that range.
        /// </remarks>
        public MethodMalloc GetILFunctionBodyAllocator(ModuleID moduleId)
        {
            MethodMalloc ppMallocResult;
            TryGetILFunctionBodyAllocator(moduleId, out ppMallocResult).ThrowOnNotOK();

            return ppMallocResult;
        }

        /// <summary>
        /// Gets an interface that provides a method to allocate memory to be used for swapping out the body of a method in Microsoft intermediate language (MSIL) code.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the method resides.</param>
        /// <param name="ppMallocResult">[out] A pointer to an <see cref="IMethodMalloc"/> interface that provides a method to allocate the memory.</param>
        /// <remarks>
        /// A method body in MSIL code must be located as a relative virtual address (RVA), relative to the loaded module,
        /// which means that it follows the module within 4 GB. To make it easier for a tool to swap out the body of a method,
        /// the GetILFunctionBodyAllocator method ensures that memory is allocated within that range.
        /// </remarks>
        public HRESULT TryGetILFunctionBodyAllocator(ModuleID moduleId, out MethodMalloc ppMallocResult)
        {
            /*HRESULT GetILFunctionBodyAllocator(
            [In] ModuleID moduleId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMethodMalloc ppMalloc);*/
            IMethodMalloc ppMalloc;
            HRESULT hr = Raw.GetILFunctionBodyAllocator(moduleId, out ppMalloc);

            if (hr == HRESULT.S_OK)
                ppMallocResult = ppMalloc == null ? null : new MethodMalloc(ppMalloc);
            else
                ppMallocResult = default(MethodMalloc);

            return hr;
        }

        #endregion
        #region SetILFunctionBody

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
        public void SetILFunctionBody(ModuleID moduleId, mdMethodDef methodId, IntPtr pbNewILMethodHeader)
        {
            TrySetILFunctionBody(moduleId, methodId, pbNewILMethodHeader).ThrowOnNotOK();
        }

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
        public HRESULT TrySetILFunctionBody(ModuleID moduleId, mdMethodDef methodId, IntPtr pbNewILMethodHeader)
        {
            /*HRESULT SetILFunctionBody(
            [In] ModuleID moduleId,
            [In] mdMethodDef methodId,
            [In] IntPtr pbNewILMethodHeader);*/
            return Raw.SetILFunctionBody(moduleId, methodId, pbNewILMethodHeader);
        }

        #endregion
        #region GetAppDomainInfo

        /// <summary>
        /// Accepts an application domain ID. Returns an application domain name and the ID of the process that contains it.
        /// </summary>
        /// <param name="appDomainId">[in] The ID of the application domain.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// After this method returns, you must verify that the szName buffer was large enough to contain the full name of
        /// the application domain. To do this, compare the value that pcchName points to with the value of the cchName parameter.
        /// If pcchName points to a value that is larger than cchName, allocate a larger szName buffer, update cchName with
        /// the new, larger size, and call GetAppDomainInfo again. Alternatively, you can first call GetAppDomainInfo with
        /// a zero-length szName buffer to obtain the correct buffer size. You can then set the buffer size to the value returned
        /// in pcchName and call GetAppDomainInfo again.
        /// </remarks>
        public GetAppDomainInfoResult GetAppDomainInfo(AppDomainID appDomainId)
        {
            GetAppDomainInfoResult result;
            TryGetAppDomainInfo(appDomainId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Accepts an application domain ID. Returns an application domain name and the ID of the process that contains it.
        /// </summary>
        /// <param name="appDomainId">[in] The ID of the application domain.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// After this method returns, you must verify that the szName buffer was large enough to contain the full name of
        /// the application domain. To do this, compare the value that pcchName points to with the value of the cchName parameter.
        /// If pcchName points to a value that is larger than cchName, allocate a larger szName buffer, update cchName with
        /// the new, larger size, and call GetAppDomainInfo again. Alternatively, you can first call GetAppDomainInfo with
        /// a zero-length szName buffer to obtain the correct buffer size. You can then set the buffer size to the value returned
        /// in pcchName and call GetAppDomainInfo again.
        /// </remarks>
        public HRESULT TryGetAppDomainInfo(AppDomainID appDomainId, out GetAppDomainInfoResult result)
        {
            /*HRESULT GetAppDomainInfo(
            [In] AppDomainID appDomainId,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName,
            [Out] out ProcessID pProcessId);*/
            int cchName = 0;
            int pcchName;
            char[] szName;
            ProcessID pProcessId;
            HRESULT hr = Raw.GetAppDomainInfo(appDomainId, cchName, out pcchName, null, out pProcessId);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw.GetAppDomainInfo(appDomainId, cchName, out pcchName, szName, out pProcessId);

            if (hr == HRESULT.S_OK)
            {
                result = new GetAppDomainInfoResult(CreateString(szName, pcchName), pProcessId);

                return hr;
            }

            fail:
            result = default(GetAppDomainInfoResult);

            return hr;
        }

        #endregion
        #region GetAssemblyInfo

        /// <summary>
        /// Accepts an assembly ID, and returns the assembly's name and the ID of its manifest module.
        /// </summary>
        /// <param name="assemblyId">[in] The identifier of the assembly.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// After this method returns, you must verify that the szName buffer was large enough to contain the full name of
        /// the assembly. To do this, compare the value that pcchName points to with the value of the cchName parameter. If
        /// pcchName points to a value that is larger than cchName, allocate a larger szName buffer, update cchName with the
        /// new, larger size, and call GetAssemblyInfo again. Alternatively, you can first call GetAssemblyInfo with a zero-length
        /// szName buffer to obtain the correct buffer size. You can then adjust the buffer size based on the value returned
        /// in pcchName and call GetAssemblyInfo again.
        /// </remarks>
        public GetAssemblyInfoResult GetAssemblyInfo(AssemblyID assemblyId)
        {
            GetAssemblyInfoResult result;
            TryGetAssemblyInfo(assemblyId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Accepts an assembly ID, and returns the assembly's name and the ID of its manifest module.
        /// </summary>
        /// <param name="assemblyId">[in] The identifier of the assembly.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// After this method returns, you must verify that the szName buffer was large enough to contain the full name of
        /// the assembly. To do this, compare the value that pcchName points to with the value of the cchName parameter. If
        /// pcchName points to a value that is larger than cchName, allocate a larger szName buffer, update cchName with the
        /// new, larger size, and call GetAssemblyInfo again. Alternatively, you can first call GetAssemblyInfo with a zero-length
        /// szName buffer to obtain the correct buffer size. You can then adjust the buffer size based on the value returned
        /// in pcchName and call GetAssemblyInfo again.
        /// </remarks>
        public HRESULT TryGetAssemblyInfo(AssemblyID assemblyId, out GetAssemblyInfoResult result)
        {
            /*HRESULT GetAssemblyInfo(
            [In] AssemblyID assemblyId,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szName,
            [Out] out AppDomainID pAppDomainId,
            [Out] out ModuleID pModuleId);*/
            int cchName = 0;
            int pcchName;
            char[] szName;
            AppDomainID pAppDomainId;
            ModuleID pModuleId;
            HRESULT hr = Raw.GetAssemblyInfo(assemblyId, cchName, out pcchName, null, out pAppDomainId, out pModuleId);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw.GetAssemblyInfo(assemblyId, cchName, out pcchName, szName, out pAppDomainId, out pModuleId);

            if (hr == HRESULT.S_OK)
            {
                result = new GetAssemblyInfoResult(CreateString(szName, pcchName), pAppDomainId, pModuleId);

                return hr;
            }

            fail:
            result = default(GetAssemblyInfoResult);

            return hr;
        }

        #endregion
        #region SetFunctionReJIT

        /// <summary>
        /// Not implemented. Do not use.
        /// </summary>
        public void SetFunctionReJIT(FunctionID functionId)
        {
            TrySetFunctionReJIT(functionId).ThrowOnNotOK();
        }

        /// <summary>
        /// Not implemented. Do not use.
        /// </summary>
        public HRESULT TrySetFunctionReJIT(FunctionID functionId)
        {
            /*HRESULT SetFunctionReJIT(
            [In] FunctionID functionId);*/
            return Raw.SetFunctionReJIT(functionId);
        }

        #endregion
        #region ForceGC

        /// <summary>
        /// Forces garbage collection to occur within the common language runtime (CLR).
        /// </summary>
        /// <remarks>
        /// The ForceGC method must be called only from a thread that has never run managed code and does not have any profiler
        /// callbacks on its stack. The most convenient implementation is to create a separate thread within the profiler that
        /// calls ForceGC when signaled.
        /// </remarks>
        public void ForceGC()
        {
            TryForceGC().ThrowOnNotOK();
        }

        /// <summary>
        /// Forces garbage collection to occur within the common language runtime (CLR).
        /// </summary>
        /// <remarks>
        /// The ForceGC method must be called only from a thread that has never run managed code and does not have any profiler
        /// callbacks on its stack. The most convenient implementation is to create a separate thread within the profiler that
        /// calls ForceGC when signaled.
        /// </remarks>
        public HRESULT TryForceGC()
        {
            /*HRESULT ForceGC();*/
            return Raw.ForceGC();
        }

        #endregion
        #region SetILInstrumentedCodeMap

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
        public void SetILInstrumentedCodeMap(FunctionID functionId, bool fStartJit, int cILMapEntries, COR_IL_MAP[] rgILMapEntries)
        {
            TrySetILInstrumentedCodeMap(functionId, fStartJit, cILMapEntries, rgILMapEntries).ThrowOnNotOK();
        }

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
        public HRESULT TrySetILInstrumentedCodeMap(FunctionID functionId, bool fStartJit, int cILMapEntries, COR_IL_MAP[] rgILMapEntries)
        {
            /*HRESULT SetILInstrumentedCodeMap(
            [In] FunctionID functionId,
            [In, MarshalAs(UnmanagedType.Bool)] bool fStartJit,
            [In] int cILMapEntries,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_IL_MAP[] rgILMapEntries);*/
            return Raw.SetILInstrumentedCodeMap(functionId, fStartJit, cILMapEntries, rgILMapEntries);
        }

        #endregion
        #region GetThreadContext

        /// <summary>
        /// Gets the context identity currently associated with the specified thread.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread.</param>
        /// <returns>[out] A pointer to the context ID currently associated with the specified thread. If the thread has no context currently associated with it, this function will return CORPROF_E_DATAINCOMPLETE.</returns>
        public ContextID GetThreadContext(ThreadID threadId)
        {
            ContextID pContextId;
            TryGetThreadContext(threadId, out pContextId).ThrowOnNotOK();

            return pContextId;
        }

        /// <summary>
        /// Gets the context identity currently associated with the specified thread.
        /// </summary>
        /// <param name="threadId">[in] The ID of the thread.</param>
        /// <param name="pContextId">[out] A pointer to the context ID currently associated with the specified thread. If the thread has no context currently associated with it, this function will return CORPROF_E_DATAINCOMPLETE.</param>
        public HRESULT TryGetThreadContext(ThreadID threadId, out ContextID pContextId)
        {
            /*HRESULT GetThreadContext(
            [In] ThreadID threadId,
            [Out] out ContextID pContextId);*/
            return Raw.GetThreadContext(threadId, out pContextId);
        }

        #endregion
        #region BeginInprocDebugging

        /// <summary>
        /// Initializes in-process debugging support. This method is obsolete in .NET Framework version 2.0.
        /// </summary>
        /// <param name="fThisThreadOnly">[in] Set this value to true to initialize debugging support for only the current thread; set it to false to initialize debugging support for all threads.</param>
        /// <returns>[out] The pointer to a returned value that identifies the debugging session.</returns>
        /// <remarks>
        /// The CLR debugging services supported limited in-process debugging in the .NET Framework versions 1.0 and 1.1. In-process
        /// debugging enabled a profiler to use the inspection portions of the debugging API. However, due to customer feedback,
        /// in-process debugging has been removed from the .NET Framework in version 2.0, and replaced with a set of functionality
        /// that is more in line with the profiling API.
        /// </remarks>
        public int BeginInprocDebugging(bool fThisThreadOnly)
        {
            int pdwProfilerContext;
            TryBeginInprocDebugging(fThisThreadOnly, out pdwProfilerContext).ThrowOnNotOK();

            return pdwProfilerContext;
        }

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
        public HRESULT TryBeginInprocDebugging(bool fThisThreadOnly, out int pdwProfilerContext)
        {
            /*HRESULT BeginInprocDebugging(
            [In, MarshalAs(UnmanagedType.Bool)] bool fThisThreadOnly,
            [Out] out int pdwProfilerContext);*/
            return Raw.BeginInprocDebugging(fThisThreadOnly, out pdwProfilerContext);
        }

        #endregion
        #region EndInprocDebugging

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
        public void EndInprocDebugging(int dwProfilerContext)
        {
            TryEndInprocDebugging(dwProfilerContext).ThrowOnNotOK();
        }

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
        public HRESULT TryEndInprocDebugging(int dwProfilerContext)
        {
            /*HRESULT EndInprocDebugging(
            [In] int dwProfilerContext);*/
            return Raw.EndInprocDebugging(dwProfilerContext);
        }

        #endregion
        #region GetILToNativeMapping

        /// <summary>
        /// Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the code.</param>
        /// <returns>[out] An array of COR_DEBUG_IL_TO_NATIVE_MAP structures, each of which specifies the offsets. After the GetILToNativeMapping method returns, map will contain some or all of the COR_DEBUG_IL_TO_NATIVE_MAP structures.</returns>
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
        public COR_DEBUG_IL_TO_NATIVE_MAP[] GetILToNativeMapping(FunctionID functionId)
        {
            COR_DEBUG_IL_TO_NATIVE_MAP[] map;
            TryGetILToNativeMapping(functionId, out map).ThrowOnNotOK();

            return map;
        }

        /// <summary>
        /// Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the code.</param>
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
        public HRESULT TryGetILToNativeMapping(FunctionID functionId, out COR_DEBUG_IL_TO_NATIVE_MAP[] map)
        {
            /*HRESULT GetILToNativeMapping(
            [In] FunctionID functionId,
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] COR_DEBUG_IL_TO_NATIVE_MAP[] map);*/
            int cMap = 0;
            int pcMap;
            map = null;
            HRESULT hr = Raw.GetILToNativeMapping(functionId, cMap, out pcMap, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMap = pcMap;
            map = new COR_DEBUG_IL_TO_NATIVE_MAP[cMap];
            hr = Raw.GetILToNativeMapping(functionId, cMap, out pcMap, map);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region ICorProfilerInfo2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo2 Raw2 => (ICorProfilerInfo2) Raw;

        #region StringLayout

        /// <summary>
        /// Gets information about the layout of a string object. This method is deprecated in the .NET Framework 4, and is superseded by the <see cref="StringLayout2"/> property.
        /// </summary>
        public GetStringLayoutResult StringLayout
        {
            get
            {
                GetStringLayoutResult result;
                TryGetStringLayout(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets information about the layout of a string object. This method is deprecated in the .NET Framework 4, and is superseded by the <see cref="StringLayout2"/> property.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The GetStringLayout method gets the offsets, relative to the ObjectID pointer, of the locations in which the following
        /// are stored: Strings may be null-terminated.
        /// </remarks>
        public HRESULT TryGetStringLayout(out GetStringLayoutResult result)
        {
            /*HRESULT GetStringLayout(
            [Out] out int pBufferLengthOffset,
            [Out] out int pStringLengthOffset,
            [Out] out int pBufferOffset);*/
            int pBufferLengthOffset;
            int pStringLengthOffset;
            int pBufferOffset;
            HRESULT hr = Raw2.GetStringLayout(out pBufferLengthOffset, out pStringLengthOffset, out pBufferOffset);

            if (hr == HRESULT.S_OK)
                result = new GetStringLayoutResult(pBufferLengthOffset, pStringLengthOffset, pBufferOffset);
            else
                result = default(GetStringLayoutResult);

            return hr;
        }

        #endregion
        #region GenerationBounds

        /// <summary>
        /// Gets the memory regions, which are segments of the heap, that make up the various garbage collection generations.
        /// </summary>
        public COR_PRF_GC_GENERATION_RANGE[] GenerationBounds
        {
            get
            {
                COR_PRF_GC_GENERATION_RANGE[] ranges;
                TryGetGenerationBounds(out ranges).ThrowOnNotOK();

                return ranges;
            }
        }

        /// <summary>
        /// Gets the memory regions, which are segments of the heap, that make up the various garbage collection generations.
        /// </summary>
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
        public HRESULT TryGetGenerationBounds(out COR_PRF_GC_GENERATION_RANGE[] ranges)
        {
            /*HRESULT GetGenerationBounds(
            [In] int cObjectRanges,
            [Out] out int pcObjectRanges,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] COR_PRF_GC_GENERATION_RANGE[] ranges);*/
            int cObjectRanges = 0;
            int pcObjectRanges;
            ranges = null;
            HRESULT hr = Raw2.GetGenerationBounds(cObjectRanges, out pcObjectRanges, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cObjectRanges = pcObjectRanges;
            ranges = new COR_PRF_GC_GENERATION_RANGE[cObjectRanges];
            hr = Raw2.GetGenerationBounds(cObjectRanges, out pcObjectRanges, ranges);
            fail:
            return hr;
        }

        #endregion
        #region NotifiedExceptionClauseInfo

        /// <summary>
        /// Gets the native address and frame information for the exception clause (catch/finally/filter) that is about to be run or has just been run.
        /// </summary>
        public COR_PRF_EX_CLAUSE_INFO NotifiedExceptionClauseInfo
        {
            get
            {
                COR_PRF_EX_CLAUSE_INFO pinfo;
                TryGetNotifiedExceptionClauseInfo(out pinfo).ThrowOnNotOK();

                return pinfo;
            }
        }

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
        public HRESULT TryGetNotifiedExceptionClauseInfo(out COR_PRF_EX_CLAUSE_INFO pinfo)
        {
            /*HRESULT GetNotifiedExceptionClauseInfo(
            [Out] out COR_PRF_EX_CLAUSE_INFO pinfo);*/
            return Raw2.GetNotifiedExceptionClauseInfo(out pinfo);
        }

        #endregion
        #region DoStackSnapshot

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
        public void DoStackSnapshot(ThreadID thread, StackSnapshotCallback callback, COR_PRF_SNAPSHOT_INFO infoFlags, IntPtr clientData, IntPtr context, int contextSize)
        {
            TryDoStackSnapshot(thread, callback, infoFlags, clientData, context, contextSize).ThrowOnNotOK();
        }

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
        public HRESULT TryDoStackSnapshot(ThreadID thread, StackSnapshotCallback callback, COR_PRF_SNAPSHOT_INFO infoFlags, IntPtr clientData, IntPtr context, int contextSize)
        {
            /*HRESULT DoStackSnapshot(
            [In] ThreadID thread,
            [MarshalAs(UnmanagedType.FunctionPtr), In] StackSnapshotCallback callback,
            [In] COR_PRF_SNAPSHOT_INFO infoFlags,
            [In] IntPtr clientData,
            [In] IntPtr context,
            [In] int contextSize);*/
            return Raw2.DoStackSnapshot(thread, callback, infoFlags, clientData, context, contextSize);
        }

        #endregion
        #region SetEnterLeaveFunctionHooks2

        /// <summary>
        /// Specifies profiler-implemented functions to be called on the updated versions of the "enter", "leave", and "tailcall" hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter">[in] A pointer to the implementation to be used as the FunctionEnter2 callback.</param>
        /// <param name="pFuncLeave">[in] A pointer to the implementation to be used as the FunctionLeave2 callback.</param>
        /// <param name="pFuncTailcall">[in] A pointer to the implementation to be used as the FunctionTailcall2 callback.</param>
        /// <remarks>
        /// The SetEnterLeaveFunctionHooks2 method is similar to the <see cref="SetEnterLeaveFunctionHooks"/>
        /// method. Use the former to specify functions to be used as the newer versions of the enter/leave/tailcall callbacks,
        /// and the latter to specify functions to be used as the older versions of the enter/leave/tailcall callbacks. Only
        /// one set of callbacks may be active at a time. Thus, if a profiler calls both ICorProfilerInfo::SetEnterLeaveFunctionHooks
        /// and SetEnterLeaveFunctionHooks2, SetEnterLeaveFunctionHooks2 is used. The SetEnterLeaveFunctionHooks2 method may
        /// be called only from the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public void SetEnterLeaveFunctionHooks2(FunctionEnter2 pFuncEnter, FunctionLeave2 pFuncLeave, FunctionTailcall2 pFuncTailcall)
        {
            TrySetEnterLeaveFunctionHooks2(pFuncEnter, pFuncLeave, pFuncTailcall).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies profiler-implemented functions to be called on the updated versions of the "enter", "leave", and "tailcall" hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter">[in] A pointer to the implementation to be used as the FunctionEnter2 callback.</param>
        /// <param name="pFuncLeave">[in] A pointer to the implementation to be used as the FunctionLeave2 callback.</param>
        /// <param name="pFuncTailcall">[in] A pointer to the implementation to be used as the FunctionTailcall2 callback.</param>
        /// <remarks>
        /// The SetEnterLeaveFunctionHooks2 method is similar to the <see cref="SetEnterLeaveFunctionHooks"/>
        /// method. Use the former to specify functions to be used as the newer versions of the enter/leave/tailcall callbacks,
        /// and the latter to specify functions to be used as the older versions of the enter/leave/tailcall callbacks. Only
        /// one set of callbacks may be active at a time. Thus, if a profiler calls both ICorProfilerInfo::SetEnterLeaveFunctionHooks
        /// and SetEnterLeaveFunctionHooks2, SetEnterLeaveFunctionHooks2 is used. The SetEnterLeaveFunctionHooks2 method may
        /// be called only from the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public HRESULT TrySetEnterLeaveFunctionHooks2(FunctionEnter2 pFuncEnter, FunctionLeave2 pFuncLeave, FunctionTailcall2 pFuncTailcall)
        {
            /*HRESULT SetEnterLeaveFunctionHooks2(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter2 pFuncEnter,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave2 pFuncLeave,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall2 pFuncTailcall);*/
            return Raw2.SetEnterLeaveFunctionHooks2(pFuncEnter, pFuncLeave, pFuncTailcall);
        }

        #endregion
        #region GetFunctionInfo2

        /// <summary>
        /// Gets the parent class, the metadata token, and the ClassID of each type argument, if present, of a function.
        /// </summary>
        /// <param name="funcID">[in] The ID of the function for which to get the parent class and other information.</param>
        /// <param name="frameInfo">[in] A COR_PRF_FRAME_INFO value that points to information about a stack frame.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for
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
        public GetFunctionInfo2Result GetFunctionInfo2(FunctionID funcID, COR_PRF_FRAME_INFO frameInfo)
        {
            GetFunctionInfo2Result result;
            TryGetFunctionInfo2(funcID, frameInfo, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the parent class, the metadata token, and the ClassID of each type argument, if present, of a function.
        /// </summary>
        /// <param name="funcID">[in] The ID of the function for which to get the parent class and other information.</param>
        /// <param name="frameInfo">[in] A COR_PRF_FRAME_INFO value that points to information about a stack frame.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The profiler code can call <see cref="GetModuleMetaData"/> to obtain a metadata interface for
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
        public HRESULT TryGetFunctionInfo2(FunctionID funcID, COR_PRF_FRAME_INFO frameInfo, out GetFunctionInfo2Result result)
        {
            /*HRESULT GetFunctionInfo2(
            [In] FunctionID funcID,
            [In] COR_PRF_FRAME_INFO frameInfo,
            [Out] out ClassID pClassId,
            [Out] out ModuleID pModuleId,
            [Out] out mdToken pToken,
            [In] int cTypeArgs,
            [Out] out int pcTypeArgs,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ClassID[] typeArgs);*/
            ClassID pClassId;
            ModuleID pModuleId;
            mdToken pToken;
            int cTypeArgs = 0;
            int pcTypeArgs;
            ClassID[] typeArgs;
            HRESULT hr = Raw2.GetFunctionInfo2(funcID, frameInfo, out pClassId, out pModuleId, out pToken, cTypeArgs, out pcTypeArgs, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cTypeArgs = pcTypeArgs;
            typeArgs = new ClassID[cTypeArgs];
            hr = Raw2.GetFunctionInfo2(funcID, frameInfo, out pClassId, out pModuleId, out pToken, cTypeArgs, out pcTypeArgs, typeArgs);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFunctionInfo2Result(pClassId, pModuleId, pToken, typeArgs);

                return hr;
            }

            fail:
            result = default(GetFunctionInfo2Result);

            return hr;
        }

        #endregion
        #region GetClassLayout

        /// <summary>
        /// Gets information about the layout, in memory, of the fields defined by the specified class. That is, this method gets the offsets of the class's fields.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which the layout will be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The GetClassLayout method returns only the fields defined by the class itself. If the class's parent class has
        /// defined fields as well, the profiler must call GetClassLayout on the parent class to obtain those fields. If you
        /// use GetClassLayout with string classes, the method will fail with error code E_INVALIDARG. Use <see cref="StringLayout"/>
        /// to get information about the layout of a string. GetClassLayout will also fail when called with an array class.
        /// After GetClassLayout returns, you must verify that the rFieldOffset buffer was large enough to contain all the
        /// available COR_FIELD_OFFSET structures. To do this, compare the value that pcFieldOffset points to with the size
        /// of rFieldOffset divided by the size of a COR_FIELD_OFFSET structure. If rFieldOffset is not large enough, allocate
        /// a larger rFieldOffset buffer, update cFieldOffset with the new, larger size, and call GetClassLayout again. Alternatively,
        /// you can first call GetClassLayout with a zero-length rFieldOffset buffer to obtain the correct buffer size. You
        /// can then set the buffer size to the value returned in pcFieldOffset and call GetClassLayout again.
        /// </remarks>
        public GetClassLayoutResult GetClassLayout(ClassID classId)
        {
            GetClassLayoutResult result;
            TryGetClassLayout(classId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets information about the layout, in memory, of the fields defined by the specified class. That is, this method gets the offsets of the class's fields.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which the layout will be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The GetClassLayout method returns only the fields defined by the class itself. If the class's parent class has
        /// defined fields as well, the profiler must call GetClassLayout on the parent class to obtain those fields. If you
        /// use GetClassLayout with string classes, the method will fail with error code E_INVALIDARG. Use <see cref="StringLayout"/>
        /// to get information about the layout of a string. GetClassLayout will also fail when called with an array class.
        /// After GetClassLayout returns, you must verify that the rFieldOffset buffer was large enough to contain all the
        /// available COR_FIELD_OFFSET structures. To do this, compare the value that pcFieldOffset points to with the size
        /// of rFieldOffset divided by the size of a COR_FIELD_OFFSET structure. If rFieldOffset is not large enough, allocate
        /// a larger rFieldOffset buffer, update cFieldOffset with the new, larger size, and call GetClassLayout again. Alternatively,
        /// you can first call GetClassLayout with a zero-length rFieldOffset buffer to obtain the correct buffer size. You
        /// can then set the buffer size to the value returned in pcFieldOffset and call GetClassLayout again.
        /// </remarks>
        public HRESULT TryGetClassLayout(ClassID classId, out GetClassLayoutResult result)
        {
            /*HRESULT GetClassLayout(
            [In] ClassID classId,
            [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_FIELD_OFFSET[] rFieldOffset,
            [In] int cFieldOffset,
            [Out] out int pcFieldOffset,
            [Out] out int pulClassSize);*/
            COR_FIELD_OFFSET[] rFieldOffset;
            int cFieldOffset = 0;
            int pcFieldOffset;
            int pulClassSize;
            HRESULT hr = Raw2.GetClassLayout(classId, null, cFieldOffset, out pcFieldOffset, out pulClassSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cFieldOffset = pcFieldOffset;
            rFieldOffset = new COR_FIELD_OFFSET[cFieldOffset];
            hr = Raw2.GetClassLayout(classId, rFieldOffset, cFieldOffset, out pcFieldOffset, out pulClassSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetClassLayoutResult(rFieldOffset, pulClassSize);

                return hr;
            }

            fail:
            result = default(GetClassLayoutResult);

            return hr;
        }

        #endregion
        #region GetClassIDInfo2

        /// <summary>
        /// Gets the parent module and metadata token for the open generic definition of the specified class, the ClassID of its parent class, and the ClassID for each type argument, if present, of the class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which information will be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The GetClassIDInfo2 method is similar to the <see cref="GetClassIDInfo"/> method, but GetClassIDInfo2
        /// obtains additional information about a generic type. The profiler code can call <see cref="GetModuleMetaData"/>
        /// to obtain a metadata interface for a given module. The metadata token that is returned to the location referenced
        /// by pTypeDefToken can then be used to access the metadata for the class. After GetClassIDInfo2 returns, you must
        /// verify that the typeArgs buffer was large enough to contain all the ClassID values. To do this, compare the value
        /// that pcNumTypeArgs points to with the value of the cNumTypeArgs parameter. If pcNumTypeArgs points to a value that
        /// is larger than cNumTypeArgs, allocate a larger typeArgs buffer, update cNumTypeArgs with the new, larger size,
        /// and call GetClassIDInfo2 again. Alternatively, you can first call GetClassIDInfo2 with a zero-length typeArgs buffer
        /// to obtain the correct buffer size. You can then set the typeArgs buffer size to the value returned in pcNumTypeArgs
        /// and call GetClassIDInfo2 again.
        /// </remarks>
        public GetClassIDInfo2Result GetClassIDInfo2(ClassID classId)
        {
            GetClassIDInfo2Result result;
            TryGetClassIDInfo2(classId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the parent module and metadata token for the open generic definition of the specified class, the ClassID of its parent class, and the ClassID for each type argument, if present, of the class.
        /// </summary>
        /// <param name="classId">[in] The ID of the class for which information will be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The GetClassIDInfo2 method is similar to the <see cref="GetClassIDInfo"/> method, but GetClassIDInfo2
        /// obtains additional information about a generic type. The profiler code can call <see cref="GetModuleMetaData"/>
        /// to obtain a metadata interface for a given module. The metadata token that is returned to the location referenced
        /// by pTypeDefToken can then be used to access the metadata for the class. After GetClassIDInfo2 returns, you must
        /// verify that the typeArgs buffer was large enough to contain all the ClassID values. To do this, compare the value
        /// that pcNumTypeArgs points to with the value of the cNumTypeArgs parameter. If pcNumTypeArgs points to a value that
        /// is larger than cNumTypeArgs, allocate a larger typeArgs buffer, update cNumTypeArgs with the new, larger size,
        /// and call GetClassIDInfo2 again. Alternatively, you can first call GetClassIDInfo2 with a zero-length typeArgs buffer
        /// to obtain the correct buffer size. You can then set the typeArgs buffer size to the value returned in pcNumTypeArgs
        /// and call GetClassIDInfo2 again.
        /// </remarks>
        public HRESULT TryGetClassIDInfo2(ClassID classId, out GetClassIDInfo2Result result)
        {
            /*HRESULT GetClassIDInfo2(
            [In] ClassID classId,
            [Out] out ModuleID pModuleId,
            [Out] out mdTypeDef pTypeDefToken,
            [Out] out ClassID pParentClassId,
            [In] int cNumTypeArgs,
            [Out] out int pcNumTypeArgs,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ClassID[] typeArgs);*/
            ModuleID pModuleId;
            mdTypeDef pTypeDefToken;
            ClassID pParentClassId;
            int cNumTypeArgs = 0;
            int pcNumTypeArgs;
            ClassID[] typeArgs;
            HRESULT hr = Raw2.GetClassIDInfo2(classId, out pModuleId, out pTypeDefToken, out pParentClassId, cNumTypeArgs, out pcNumTypeArgs, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cNumTypeArgs = pcNumTypeArgs;
            typeArgs = new ClassID[cNumTypeArgs];
            hr = Raw2.GetClassIDInfo2(classId, out pModuleId, out pTypeDefToken, out pParentClassId, cNumTypeArgs, out pcNumTypeArgs, typeArgs);

            if (hr == HRESULT.S_OK)
            {
                result = new GetClassIDInfo2Result(pModuleId, pTypeDefToken, pParentClassId, typeArgs);

                return hr;
            }

            fail:
            result = default(GetClassIDInfo2Result);

            return hr;
        }

        #endregion
        #region GetCodeInfo2

        /// <summary>
        /// Gets the extents of native code associated with the specified FunctionID.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
        /// <returns>[out] A caller-provided buffer. After the method returns, it contains an array of COR_PRF_CODE_INFO structures, each of which describes a block of native code.</returns>
        /// <remarks>
        /// The extents are sorted in order of increasing Microsoft intermediate language (MSIL) offset. After GetCodeInfo2
        /// returns, you must verify that the codeInfos buffer was large enough to contain all the COR_PRF_CODE_INFO structures.
        /// To do this, compare the value of cCodeInfos with the value of the cchName parameter. If cCodeInfos divided by the
        /// size of a COR_PRF_CODE_INFO structure is smaller than pcCodeInfos, allocate a larger codeInfos buffer, update cCodeInfos
        /// with the new, larger size, and call GetCodeInfo2 again. Alternatively, you can first call GetCodeInfo2 with a zero-length
        /// codeInfos buffer to obtain the correct buffer size. You can then set the codeInfos buffer size to the value returned
        /// in pcCodeInfos, multiplied by the size of a COR_PRF_CODE_INFO structure, and call GetCodeInfo2 again.
        /// </remarks>
        public COR_PRF_CODE_INFO[] GetCodeInfo2(FunctionID functionId)
        {
            COR_PRF_CODE_INFO[] codeInfos;
            TryGetCodeInfo2(functionId, out codeInfos).ThrowOnNotOK();

            return codeInfos;
        }

        /// <summary>
        /// Gets the extents of native code associated with the specified FunctionID.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
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
        public HRESULT TryGetCodeInfo2(FunctionID functionId, out COR_PRF_CODE_INFO[] codeInfos)
        {
            /*HRESULT GetCodeInfo2(
            [In] FunctionID functionId,
            [In] int cCodeInfos,
            [Out] out int pcCodeInfos,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] COR_PRF_CODE_INFO[] codeInfos);*/
            int cCodeInfos = 0;
            int pcCodeInfos;
            codeInfos = null;
            HRESULT hr = Raw2.GetCodeInfo2(functionId, cCodeInfos, out pcCodeInfos, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cCodeInfos = pcCodeInfos;
            codeInfos = new COR_PRF_CODE_INFO[cCodeInfos];
            hr = Raw2.GetCodeInfo2(functionId, cCodeInfos, out pcCodeInfos, codeInfos);
            fail:
            return hr;
        }

        #endregion
        #region GetClassFromTokenAndTypeArgs

        /// <summary>
        /// Gets the ClassID of a type by using the specified metadata token and the ClassID values of any type arguments.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the type resides.</param>
        /// <param name="typeDef">[in] An mdTypeDef metadata token that references the type.</param>
        /// <param name="cTypeArgs">[in] The number of type parameters for the given type. This value must be zero for non-generic types.</param>
        /// <param name="typeArgs">[in] An array of ClassID values, each of which is an argument of the type. The value of typeArgs can be NULL if cTypeArgs is set to zero.</param>
        /// <returns>[out] A pointer to the ClassID of the specified type.</returns>
        /// <remarks>
        /// Calling the GetClassFromTokenAndTypeArgs method with an mdTypeRef instead of an mdTypeDef metadata token can have
        /// unpredictable results; callers should resolve the mdTypeRef to an mdTypeDef when passing it. If the type is not
        /// already loaded, calling GetClassFromTokenAndTypeArgs will trigger loading, which is a dangerous operation in many
        /// contexts. For example, calling this method during loading of modules or other types could lead to an infinite loop
        /// as the runtime attempts to circularly load things. In general, use of GetClassFromTokenAndTypeArgs is discouraged.
        /// If profilers are interested in events for a particular type, they should store the ModuleID and mdTypeDef of that
        /// type, and use <see cref="GetClassIDInfo2"/> to check whether a given ClassID is that of the desired type.
        /// </remarks>
        public ClassID GetClassFromTokenAndTypeArgs(ModuleID moduleId, mdTypeDef typeDef, int cTypeArgs, ClassID[] typeArgs)
        {
            ClassID pClassId;
            TryGetClassFromTokenAndTypeArgs(moduleId, typeDef, cTypeArgs, typeArgs, out pClassId).ThrowOnNotOK();

            return pClassId;
        }

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
        public HRESULT TryGetClassFromTokenAndTypeArgs(ModuleID moduleId, mdTypeDef typeDef, int cTypeArgs, ClassID[] typeArgs, out ClassID pClassId)
        {
            /*HRESULT GetClassFromTokenAndTypeArgs(
            [In] ModuleID moduleId,
            [In] mdTypeDef typeDef,
            [In] int cTypeArgs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ClassID[] typeArgs,
            [Out] out ClassID pClassId);*/
            return Raw2.GetClassFromTokenAndTypeArgs(moduleId, typeDef, cTypeArgs, typeArgs, out pClassId);
        }

        #endregion
        #region GetFunctionFromTokenAndTypeArgs

        /// <summary>
        /// Gets the FunctionID of a function by using the specified metadata token, containing class, and ClassID values of any type arguments.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module in which the function resides.</param>
        /// <param name="funcDef">[in] An mdMethodDef metadata token that references the function.</param>
        /// <param name="classId">[in] The ID of the function's containing class.</param>
        /// <param name="cTypeArgs">[in] The number of type parameters for the given function. This value must be zero for non-generic functions.</param>
        /// <param name="typeArgs">[in] An array of ClassID values, each of which is an argument of the function. The value of typeArgs can be NULL if cTypeArgs is set to zero.</param>
        /// <returns>[out] A pointer to the FunctionID of the specified function.</returns>
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
        public FunctionID GetFunctionFromTokenAndTypeArgs(ModuleID moduleId, mdMethodDef funcDef, ClassID classId, int cTypeArgs, ClassID[] typeArgs)
        {
            FunctionID pFunctionId;
            TryGetFunctionFromTokenAndTypeArgs(moduleId, funcDef, classId, cTypeArgs, typeArgs, out pFunctionId).ThrowOnNotOK();

            return pFunctionId;
        }

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
        public HRESULT TryGetFunctionFromTokenAndTypeArgs(ModuleID moduleId, mdMethodDef funcDef, ClassID classId, int cTypeArgs, ClassID[] typeArgs, out FunctionID pFunctionId)
        {
            /*HRESULT GetFunctionFromTokenAndTypeArgs(
            [In] ModuleID moduleId,
            [In] mdMethodDef funcDef,
            [In] ClassID classId,
            [In] int cTypeArgs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ClassID[] typeArgs,
            [Out] out FunctionID pFunctionId);*/
            return Raw2.GetFunctionFromTokenAndTypeArgs(moduleId, funcDef, classId, cTypeArgs, typeArgs, out pFunctionId);
        }

        #endregion
        #region EnumModuleFrozenObjects

        /// <summary>
        /// Gets an enumerator that allows iteration over the frozen objects in the specified module.This method is obsolete.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that contains the frozen objects to be enumerated.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorProfilerObjectEnum"/> interface, which enumerates the frozen objects.</returns>
        public CorProfilerObjectEnum EnumModuleFrozenObjects(ModuleID moduleId)
        {
            CorProfilerObjectEnum ppEnumResult;
            TryEnumModuleFrozenObjects(moduleId, out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Gets an enumerator that allows iteration over the frozen objects in the specified module.This method is obsolete.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module that contains the frozen objects to be enumerated.</param>
        /// <param name="ppEnumResult">[out] A pointer to the address of an <see cref="ICorProfilerObjectEnum"/> interface, which enumerates the frozen objects.</param>
        public HRESULT TryEnumModuleFrozenObjects(ModuleID moduleId, out CorProfilerObjectEnum ppEnumResult)
        {
            /*HRESULT EnumModuleFrozenObjects(
            [In] ModuleID moduleId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerObjectEnum ppEnum);*/
            ICorProfilerObjectEnum ppEnum;
            HRESULT hr = Raw2.EnumModuleFrozenObjects(moduleId, out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new CorProfilerObjectEnum(ppEnum);
            else
                ppEnumResult = default(CorProfilerObjectEnum);

            return hr;
        }

        #endregion
        #region GetArrayObjectInfo

        /// <summary>
        /// Gets detailed information about an array object.
        /// </summary>
        /// <param name="objectId">[in] The ID of a valid array object.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The pDimensionSizes and pDimensionLowerBounds are parallel arrays, so the elements located at the same index in
        /// each array are characteristics of the same entity.
        /// </remarks>
        public GetArrayObjectInfoResult GetArrayObjectInfo(ObjectID objectId)
        {
            GetArrayObjectInfoResult result;
            TryGetArrayObjectInfo(objectId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets detailed information about an array object.
        /// </summary>
        /// <param name="objectId">[in] The ID of a valid array object.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The pDimensionSizes and pDimensionLowerBounds are parallel arrays, so the elements located at the same index in
        /// each array are characteristics of the same entity.
        /// </remarks>
        public HRESULT TryGetArrayObjectInfo(ObjectID objectId, out GetArrayObjectInfoResult result)
        {
            /*HRESULT GetArrayObjectInfo(
            [In] ObjectID objectId,
            [In] int cDimensions,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] pDimensionSizes,
            [Out] out int pDimensionLowerBounds,
            [Out] out IntPtr ppData);*/
            int cDimensions = 0;
            int[] pDimensionSizes;
            int pDimensionLowerBounds;
            IntPtr ppData;
            HRESULT hr = Raw2.GetArrayObjectInfo(objectId, cDimensions, null, out pDimensionLowerBounds, out ppData);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cDimensions = pDimensionLowerBounds;
            pDimensionSizes = new int[cDimensions];
            hr = Raw2.GetArrayObjectInfo(objectId, cDimensions, pDimensionSizes, out pDimensionLowerBounds, out ppData);

            if (hr == HRESULT.S_OK)
            {
                result = new GetArrayObjectInfoResult(pDimensionSizes, ppData);

                return hr;
            }

            fail:
            result = default(GetArrayObjectInfoResult);

            return hr;
        }

        #endregion
        #region GetBoxClassLayout

        /// <summary>
        /// Gets information about where the specified value type is located when it is boxed.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that describes the value type that is boxed.</param>
        /// <returns>[out] An integer that is the offset, relative to the boxed object ID pointer, of the value type.</returns>
        /// <remarks>
        /// The pBufferOffset value is the location of the value type within a box. After pBufferOffset is applied to a boxed
        /// object, the value type's class layout can be used to interpret the object's value.
        /// </remarks>
        public int GetBoxClassLayout(ClassID classId)
        {
            int pBufferOffset;
            TryGetBoxClassLayout(classId, out pBufferOffset).ThrowOnNotOK();

            return pBufferOffset;
        }

        /// <summary>
        /// Gets information about where the specified value type is located when it is boxed.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that describes the value type that is boxed.</param>
        /// <param name="pBufferOffset">[out] An integer that is the offset, relative to the boxed object ID pointer, of the value type.</param>
        /// <remarks>
        /// The pBufferOffset value is the location of the value type within a box. After pBufferOffset is applied to a boxed
        /// object, the value type's class layout can be used to interpret the object's value.
        /// </remarks>
        public HRESULT TryGetBoxClassLayout(ClassID classId, out int pBufferOffset)
        {
            /*HRESULT GetBoxClassLayout(
            [In] ClassID classId,
            [Out] out int pBufferOffset);*/
            return Raw2.GetBoxClassLayout(classId, out pBufferOffset);
        }

        #endregion
        #region GetThreadAppDomain

        /// <summary>
        /// Gets the ID of the application domain in which the specified thread is currently executing code.
        /// </summary>
        /// <param name="threadId">[in] The ID specifying the thread.</param>
        /// <returns>[out] A pointer to the ID of the application domain.</returns>
        public AppDomainID GetThreadAppDomain(ThreadID threadId)
        {
            AppDomainID pAppDomainId;
            TryGetThreadAppDomain(threadId, out pAppDomainId).ThrowOnNotOK();

            return pAppDomainId;
        }

        /// <summary>
        /// Gets the ID of the application domain in which the specified thread is currently executing code.
        /// </summary>
        /// <param name="threadId">[in] The ID specifying the thread.</param>
        /// <param name="pAppDomainId">[out] A pointer to the ID of the application domain.</param>
        public HRESULT TryGetThreadAppDomain(ThreadID threadId, out AppDomainID pAppDomainId)
        {
            /*HRESULT GetThreadAppDomain(
            [In] ThreadID threadId,
            [Out] out AppDomainID pAppDomainId);*/
            return Raw2.GetThreadAppDomain(threadId, out pAppDomainId);
        }

        #endregion
        #region GetRVAStaticAddress

        /// <summary>
        /// Gets the address of the specified relative virtual address (RVA) static field.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested RVA-static field.</param>
        /// <param name="fieldToken">[in] Metadata token for the requested RVA-static field.</param>
        /// <returns>[out] A pointer to the address of the RVA-static field.</returns>
        /// <remarks>
        /// The GetRVAStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetRVAStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and may be rooting garbage collection objects.
        /// </remarks>
        public IntPtr GetRVAStaticAddress(ClassID classId, mdFieldDef fieldToken)
        {
            IntPtr ppAddress;
            TryGetRVAStaticAddress(classId, fieldToken, out ppAddress).ThrowOnNotOK();

            return ppAddress;
        }

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
        public HRESULT TryGetRVAStaticAddress(ClassID classId, mdFieldDef fieldToken, out IntPtr ppAddress)
        {
            /*HRESULT GetRVAStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [Out] out IntPtr ppAddress);*/
            return Raw2.GetRVAStaticAddress(classId, fieldToken, out ppAddress);
        }

        #endregion
        #region GetAppDomainStaticAddress

        /// <summary>
        /// Gets the address of the specified application domain-static field that is in the scope of the specified application domain.
        /// </summary>
        /// <param name="classId">[in] The class ID of the class that contains the requested application domain-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested application domain-static field.</param>
        /// <param name="appDomainId">[in] The ID of the application domain that is the scope for the requested static field.</param>
        /// <returns>[out] A pointer to the address of the static field that is within the specified application domain.</returns>
        /// <remarks>
        /// The GetAppDomainStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetAppDomainStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the
        /// static fields may already be initialized and rooting garbage collection objects.
        /// </remarks>
        public IntPtr GetAppDomainStaticAddress(ClassID classId, mdFieldDef fieldToken, ThreadID appDomainId)
        {
            IntPtr ppAddress;
            TryGetAppDomainStaticAddress(classId, fieldToken, appDomainId, out ppAddress).ThrowOnNotOK();

            return ppAddress;
        }

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
        public HRESULT TryGetAppDomainStaticAddress(ClassID classId, mdFieldDef fieldToken, ThreadID appDomainId, out IntPtr ppAddress)
        {
            /*HRESULT GetAppDomainStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] ThreadID appDomainId,
            [Out] out IntPtr ppAddress);*/
            return Raw2.GetAppDomainStaticAddress(classId, fieldToken, appDomainId, out ppAddress);
        }

        #endregion
        #region GetThreadStaticAddress

        /// <summary>
        /// Gets the address of the specified thread-static field that is in the scope of the specified thread.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested thread-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested thread-static field.</param>
        /// <param name="threadId">[in] The ID of the thread that is the scope for the requested static field.</param>
        /// <returns>[out] A pointer to the address of the static field that is within the specified thread.</returns>
        /// <remarks>
        /// The GetThreadStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetThreadStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and rooting garbage collection objects.
        /// </remarks>
        public IntPtr GetThreadStaticAddress(ClassID classId, mdFieldDef fieldToken, ContextID threadId)
        {
            IntPtr ppAddress;
            TryGetThreadStaticAddress(classId, fieldToken, threadId, out ppAddress).ThrowOnNotOK();

            return ppAddress;
        }

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
        public HRESULT TryGetThreadStaticAddress(ClassID classId, mdFieldDef fieldToken, ContextID threadId, out IntPtr ppAddress)
        {
            /*HRESULT GetThreadStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] ContextID threadId,
            [Out] out IntPtr ppAddress);*/
            return Raw2.GetThreadStaticAddress(classId, fieldToken, threadId, out ppAddress);
        }

        #endregion
        #region GetContextStaticAddress

        /// <summary>
        /// Gets the address for the specified context-static field that is in the scope of the specified context.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested context-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested context-static field.</param>
        /// <param name="contextId">[in] The ID of the context that is the scope for the requested context-static field.</param>
        /// <returns>[out] A pointer to the address of the static field that is within the specified context.</returns>
        /// <remarks>
        /// The GetContextStaticAddress method may return one of the following: Before a class’s class constructor is completed,
        /// GetContextStaticAddress will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and rooting garbage collection objects.
        /// </remarks>
        public IntPtr GetContextStaticAddress(ClassID classId, mdFieldDef fieldToken, ContextID contextId)
        {
            IntPtr ppAddress;
            TryGetContextStaticAddress(classId, fieldToken, contextId, out ppAddress).ThrowOnNotOK();

            return ppAddress;
        }

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
        public HRESULT TryGetContextStaticAddress(ClassID classId, mdFieldDef fieldToken, ContextID contextId, out IntPtr ppAddress)
        {
            /*HRESULT GetContextStaticAddress(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] ContextID contextId,
            [Out] out IntPtr ppAddress);*/
            return Raw2.GetContextStaticAddress(classId, fieldToken, contextId, out ppAddress);
        }

        #endregion
        #region GetStaticFieldInfo

        /// <summary>
        /// Gets a value that indicates the kind of static that applies to the specified field.
        /// </summary>
        /// <param name="classId">[in] The ID of the class in which the static field is defined.</param>
        /// <param name="fieldToken">[in] The metadata token for the static field.</param>
        /// <returns>[out] A pointer to a value of the <see cref="COR_PRF_STATIC_TYPE"/> enumeration that indicates whether the specified field is static, and if so, the kind of static that applies to the field.</returns>
        /// <remarks>
        /// This information can be used to determine which function to call to get the address of the static field. The profiler
        /// code should still check the metadata for a static field to ensure that it actually has an address. Static literals
        /// (that is, constants) exist only in the metadata and do not have an address.
        /// </remarks>
        public COR_PRF_STATIC_TYPE GetStaticFieldInfo(ClassID classId, mdFieldDef fieldToken)
        {
            COR_PRF_STATIC_TYPE pFieldInfo;
            TryGetStaticFieldInfo(classId, fieldToken, out pFieldInfo).ThrowOnNotOK();

            return pFieldInfo;
        }

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
        public HRESULT TryGetStaticFieldInfo(ClassID classId, mdFieldDef fieldToken, out COR_PRF_STATIC_TYPE pFieldInfo)
        {
            /*HRESULT GetStaticFieldInfo(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [Out] out COR_PRF_STATIC_TYPE pFieldInfo);*/
            return Raw2.GetStaticFieldInfo(classId, fieldToken, out pFieldInfo);
        }

        #endregion
        #region GetObjectGeneration

        /// <summary>
        /// Gets the segment of the heap that contains the specified object.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object.</param>
        /// <returns>[out] A pointer to a <see cref="COR_PRF_GC_GENERATION_RANGE"/> structure, which describes a range (that is, a block) of memory within the generation that is undergoing garbage collection.<para/>
        /// This range contains the specified object.</returns>
        /// <remarks>
        /// The GetObjectGeneration method may be called from any profiler callback, provided that garbage collection is not
        /// in progress. That is, it may be called from any callback except those that occur between <see cref="ICorProfilerCallback2.GarbageCollectionStarted"/>
        /// and <see cref="ICorProfilerCallback2.GarbageCollectionFinished"/>.
        /// </remarks>
        public COR_PRF_GC_GENERATION_RANGE GetObjectGeneration(ObjectID objectId)
        {
            COR_PRF_GC_GENERATION_RANGE range;
            TryGetObjectGeneration(objectId, out range).ThrowOnNotOK();

            return range;
        }

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
        public HRESULT TryGetObjectGeneration(ObjectID objectId, out COR_PRF_GC_GENERATION_RANGE range)
        {
            /*HRESULT GetObjectGeneration(
            [In] ObjectID objectId,
            [Out] out COR_PRF_GC_GENERATION_RANGE range);*/
            return Raw2.GetObjectGeneration(objectId, out range);
        }

        #endregion
        #endregion
        #region ICorProfilerInfo3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo3 Raw3 => (ICorProfilerInfo3) Raw;

        #region StringLayout2

        /// <summary>
        /// Gets information about the layout of a string object. This method supersedes the <see cref="StringLayout"/> property.
        /// </summary>
        public GetStringLayout2Result StringLayout2
        {
            get
            {
                GetStringLayout2Result result;
                TryGetStringLayout2(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets information about the layout of a string object. This method supersedes the <see cref="StringLayout"/> property.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// Strings may or may not be null-terminated.
        /// </remarks>
        public HRESULT TryGetStringLayout2(out GetStringLayout2Result result)
        {
            /*HRESULT GetStringLayout2(
            [Out] out int pStringLengthOffset,
            [Out] out int pBufferOffset);*/
            int pStringLengthOffset;
            int pBufferOffset;
            HRESULT hr = Raw3.GetStringLayout2(out pStringLengthOffset, out pBufferOffset);

            if (hr == HRESULT.S_OK)
                result = new GetStringLayout2Result(pStringLengthOffset, pBufferOffset);
            else
                result = default(GetStringLayout2Result);

            return hr;
        }

        #endregion
        #region RuntimeInformation

        /// <summary>
        /// Provides version information about the common language runtime (CLR) that is being profiled.
        /// </summary>
        public GetRuntimeInformationResult RuntimeInformation
        {
            get
            {
                GetRuntimeInformationResult result;
                TryGetRuntimeInformation(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// Provides version information about the common language runtime (CLR) that is being profiled.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// You may pass null for any parameter. However, pcchVersionString cannot be null unless szVersionString is also null.
        /// </remarks>
        public HRESULT TryGetRuntimeInformation(out GetRuntimeInformationResult result)
        {
            /*HRESULT GetRuntimeInformation(
            [Out] out ushort pClrInstanceId,
            [Out] out COR_PRF_RUNTIME_TYPE pRuntimeType,
            [Out] out ushort pMajorVersion,
            [Out] out ushort pMinorVersion,
            [Out] out ushort pBuildNumber,
            [Out] out ushort pQFEVersion,
            [In] int cchVersionString,
            [Out] out int pcchVersionString,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 6)] char[] szVersionString);*/
            ushort pClrInstanceId;
            COR_PRF_RUNTIME_TYPE pRuntimeType;
            ushort pMajorVersion;
            ushort pMinorVersion;
            ushort pBuildNumber;
            ushort pQFEVersion;
            int cchVersionString = 0;
            int pcchVersionString;
            char[] szVersionString;
            HRESULT hr = Raw3.GetRuntimeInformation(out pClrInstanceId, out pRuntimeType, out pMajorVersion, out pMinorVersion, out pBuildNumber, out pQFEVersion, cchVersionString, out pcchVersionString, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchVersionString = pcchVersionString;
            szVersionString = new char[cchVersionString];
            hr = Raw3.GetRuntimeInformation(out pClrInstanceId, out pRuntimeType, out pMajorVersion, out pMinorVersion, out pBuildNumber, out pQFEVersion, cchVersionString, out pcchVersionString, szVersionString);

            if (hr == HRESULT.S_OK)
            {
                result = new GetRuntimeInformationResult(pClrInstanceId, pRuntimeType, pMajorVersion, pMinorVersion, pBuildNumber, pQFEVersion, CreateString(szVersionString, pcchVersionString));

                return hr;
            }

            fail:
            result = default(GetRuntimeInformationResult);

            return hr;
        }

        #endregion
        #region EnumJITedFunctions

        /// <summary>
        /// Returns an enumerator for all functions that were previously JIT-compiled.
        /// </summary>
        public COR_PRF_FUNCTION[] JITedFunctions => EnumJITedFunctions().ToArray();

        /// <summary>
        /// Returns an enumerator for all functions that were previously JIT-compiled.
        /// </summary>
        /// <returns>[out] A pointer to the <see cref="ICorProfilerFunctionEnum"/> enumerator.</returns>
        /// <remarks>
        /// This method may overlap with JITCompilation callbacks such as the <see cref="ICorProfilerCallback.JITCompilationStarted"/>
        /// method. The enumerator returned by this method does not include functions that are loaded from native images generated
        /// with Ngen.exe.
        /// </remarks>
        public CorProfilerFunctionEnum EnumJITedFunctions()
        {
            CorProfilerFunctionEnum ppEnumResult;
            TryEnumJITedFunctions(out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Returns an enumerator for all functions that were previously JIT-compiled.
        /// </summary>
        /// <param name="ppEnumResult">[out] A pointer to the <see cref="ICorProfilerFunctionEnum"/> enumerator.</param>
        /// <remarks>
        /// This method may overlap with JITCompilation callbacks such as the <see cref="ICorProfilerCallback.JITCompilationStarted"/>
        /// method. The enumerator returned by this method does not include functions that are loaded from native images generated
        /// with Ngen.exe.
        /// </remarks>
        public HRESULT TryEnumJITedFunctions(out CorProfilerFunctionEnum ppEnumResult)
        {
            /*HRESULT EnumJITedFunctions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerFunctionEnum ppEnum);*/
            ICorProfilerFunctionEnum ppEnum;
            HRESULT hr = Raw3.EnumJITedFunctions(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new CorProfilerFunctionEnum(ppEnum);
            else
                ppEnumResult = default(CorProfilerFunctionEnum);

            return hr;
        }

        #endregion
        #region RequestProfilerDetach

        /// <summary>
        /// Instructs the runtime to detach the profiler.
        /// </summary>
        /// <param name="dwExpectedCompletionMilliseconds">[in] The length of time, in milliseconds, the common language runtime (CLR) should wait before checking to see whether it is safe to unload the profiler.</param>
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
        public void RequestProfilerDetach(int dwExpectedCompletionMilliseconds)
        {
            TryRequestProfilerDetach(dwExpectedCompletionMilliseconds).ThrowOnNotOK();
        }

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
        /// | CORPROF_E_IRREVERSIBLE_INSTRUMENTATION_PRESENT | Detachment is impossible because the profiler used instrumented Microsoft intermediate language (MSIL) code, or inserted enter/leave hooks. Detachment was not attempted; the profiler is still fully attached. Note Instrumented MSIL is code is code that is provided by the profiler using the <see cref="SetILFunctionBody"/> method.      |
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
        public HRESULT TryRequestProfilerDetach(int dwExpectedCompletionMilliseconds)
        {
            /*HRESULT RequestProfilerDetach(
            [In] int dwExpectedCompletionMilliseconds);*/
            return Raw3.RequestProfilerDetach(dwExpectedCompletionMilliseconds);
        }

        #endregion
        #region SetFunctionIDMapper2

        /// <summary>
        /// Specifies the profiler-implemented function that will be called to map FunctionID values to alternative values, which are passed to the profiler's function entry/exit hooks.<para/>
        /// This method extends the <see cref="SetFunctionIDMapper"/> method with an additional data parameter, which profilers may use to disambiguate among runtimes.
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
        public void SetFunctionIDMapper2(FunctionIDMapper2 pFunc, IntPtr clientData)
        {
            TrySetFunctionIDMapper2(pFunc, clientData).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the profiler-implemented function that will be called to map FunctionID values to alternative values, which are passed to the profiler's function entry/exit hooks.<para/>
        /// This method extends the <see cref="SetFunctionIDMapper"/> method with an additional data parameter, which profilers may use to disambiguate among runtimes.
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
        public HRESULT TrySetFunctionIDMapper2(FunctionIDMapper2 pFunc, IntPtr clientData)
        {
            /*HRESULT SetFunctionIDMapper2(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionIDMapper2 pFunc,
            [In] IntPtr clientData);*/
            return Raw3.SetFunctionIDMapper2(pFunc, clientData);
        }

        #endregion
        #region SetEnterLeaveFunctionHooks3

        /// <summary>
        /// Specifies the profiler-implemented functions that will be called on the FunctionEnter3, FunctionLeave3, and FunctionTailcall3 functions.
        /// </summary>
        /// <param name="pFuncEnter3">[in] A pointer to the implementation to be used as the FunctionEnter3 callback.</param>
        /// <param name="pFuncLeave3">[in] A pointer to the implementation to be used as the FunctionLeave3 callback.</param>
        /// <param name="pFuncTailcall3">[in] A pointer to the implementation to be used as the FunctionTailcall3 callback.</param>
        /// <remarks>
        /// FunctionEnter3, FunctionLeave3, and FunctionTailcall3 hooks do not provide stack frame and argument inspection.
        /// To access that information, the COR_PRF_ENABLE_FUNCTION_ARGS, COR_PRF_ENABLE_FUNCTION_RETVAL, and/or COR_PRF_ENABLE_FRAME_INFO
        /// flags have to be set. The profiler can use the <see cref="EventMask"/> property to set the event
        /// flags, and then use the <see cref="SetEnterLeaveFunctionHooks3WithInfo"/> method to register your implementation
        /// of this function. Only one set of callbacks may be active at a time, and the newest version takes precedence. Therefore,
        /// if a profiler calls both the <see cref="SetEnterLeaveFunctionHooks2"/> and the SetEnterLeaveFunctionHooks3
        /// method, SetEnterLeaveFunctionHooks3 is used. The SetEnterLeaveFunctionHooks3 method may be called only from the
        /// profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public void SetEnterLeaveFunctionHooks3(FunctionEnter3 pFuncEnter3, FunctionLeave3 pFuncLeave3, FunctionTailcall3 pFuncTailcall3)
        {
            TrySetEnterLeaveFunctionHooks3(pFuncEnter3, pFuncLeave3, pFuncTailcall3).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the profiler-implemented functions that will be called on the FunctionEnter3, FunctionLeave3, and FunctionTailcall3 functions.
        /// </summary>
        /// <param name="pFuncEnter3">[in] A pointer to the implementation to be used as the FunctionEnter3 callback.</param>
        /// <param name="pFuncLeave3">[in] A pointer to the implementation to be used as the FunctionLeave3 callback.</param>
        /// <param name="pFuncTailcall3">[in] A pointer to the implementation to be used as the FunctionTailcall3 callback.</param>
        /// <remarks>
        /// FunctionEnter3, FunctionLeave3, and FunctionTailcall3 hooks do not provide stack frame and argument inspection.
        /// To access that information, the COR_PRF_ENABLE_FUNCTION_ARGS, COR_PRF_ENABLE_FUNCTION_RETVAL, and/or COR_PRF_ENABLE_FRAME_INFO
        /// flags have to be set. The profiler can use the <see cref="EventMask"/> property to set the event
        /// flags, and then use the <see cref="SetEnterLeaveFunctionHooks3WithInfo"/> method to register your implementation
        /// of this function. Only one set of callbacks may be active at a time, and the newest version takes precedence. Therefore,
        /// if a profiler calls both the <see cref="SetEnterLeaveFunctionHooks2"/> and the SetEnterLeaveFunctionHooks3
        /// method, SetEnterLeaveFunctionHooks3 is used. The SetEnterLeaveFunctionHooks3 method may be called only from the
        /// profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public HRESULT TrySetEnterLeaveFunctionHooks3(FunctionEnter3 pFuncEnter3, FunctionLeave3 pFuncLeave3, FunctionTailcall3 pFuncTailcall3)
        {
            /*HRESULT SetEnterLeaveFunctionHooks3(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter3 pFuncEnter3,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave3 pFuncLeave3,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall3 pFuncTailcall3);*/
            return Raw3.SetEnterLeaveFunctionHooks3(pFuncEnter3, pFuncLeave3, pFuncTailcall3);
        }

        #endregion
        #region SetEnterLeaveFunctionHooks3WithInfo

        /// <summary>
        /// Specifies the profiler-implemented functions that will be called on the FunctionEnter3WithInfo, FunctionLeave3WithInfo, and FunctionTailcall3WithInfo hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter3WithInfo">[in] A pointer to the implementation to be used as the FunctionEnter3WithInfo callback.</param>
        /// <param name="pFuncLeave3WithInfo">[in] A pointer to the implementation to be used as the FunctionLeave3WithInfo callback.</param>
        /// <param name="pFuncTailcall3WithInfo">[in] A pointer to the implementation to be used as the FunctionTailcall3WithInfo callback.</param>
        /// <remarks>
        /// The FunctionEnter3WithInfo, FunctionLeave3WithInfo, and FunctionTailcall3WithInfo hooks provide stack frame and
        /// argument inspection. To access that information, the COR_PRF_ENABLE_FUNCTION_ARGS, COR_PRF_ENABLE_FUNCTION_RETVAL,
        /// and/or COR_PRF_ENABLE_FRAME_INFO flags have to be set. The profiler can use the <see cref="EventMask"/>
        /// property to set the event flags, and then use the SetEnterLeaveFunctionHooks3WithInfo method to register your implementation
        /// of this function. Only one set of callbacks may be active at a time, and the newest version takes precedence. Therefore,
        /// if a profiler calls both <see cref="SetEnterLeaveFunctionHooks2"/> and SetEnterLeaveFunctionHooks3WithInfo,
        /// SetEnterLeaveFunctionHooks3WithInfo is used. The SetEnterLeaveFunctionHooks3WithInfo method may be called only
        /// from the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public void SetEnterLeaveFunctionHooks3WithInfo(FunctionEnter3WithInfo pFuncEnter3WithInfo, FunctionLeave3WithInfo pFuncLeave3WithInfo, FunctionTailcall3WithInfo pFuncTailcall3WithInfo)
        {
            TrySetEnterLeaveFunctionHooks3WithInfo(pFuncEnter3WithInfo, pFuncLeave3WithInfo, pFuncTailcall3WithInfo).ThrowOnNotOK();
        }

        /// <summary>
        /// Specifies the profiler-implemented functions that will be called on the FunctionEnter3WithInfo, FunctionLeave3WithInfo, and FunctionTailcall3WithInfo hooks of managed functions.
        /// </summary>
        /// <param name="pFuncEnter3WithInfo">[in] A pointer to the implementation to be used as the FunctionEnter3WithInfo callback.</param>
        /// <param name="pFuncLeave3WithInfo">[in] A pointer to the implementation to be used as the FunctionLeave3WithInfo callback.</param>
        /// <param name="pFuncTailcall3WithInfo">[in] A pointer to the implementation to be used as the FunctionTailcall3WithInfo callback.</param>
        /// <remarks>
        /// The FunctionEnter3WithInfo, FunctionLeave3WithInfo, and FunctionTailcall3WithInfo hooks provide stack frame and
        /// argument inspection. To access that information, the COR_PRF_ENABLE_FUNCTION_ARGS, COR_PRF_ENABLE_FUNCTION_RETVAL,
        /// and/or COR_PRF_ENABLE_FRAME_INFO flags have to be set. The profiler can use the <see cref="EventMask"/>
        /// property to set the event flags, and then use the SetEnterLeaveFunctionHooks3WithInfo method to register your implementation
        /// of this function. Only one set of callbacks may be active at a time, and the newest version takes precedence. Therefore,
        /// if a profiler calls both <see cref="SetEnterLeaveFunctionHooks2"/> and SetEnterLeaveFunctionHooks3WithInfo,
        /// SetEnterLeaveFunctionHooks3WithInfo is used. The SetEnterLeaveFunctionHooks3WithInfo method may be called only
        /// from the profiler's <see cref="ICorProfilerCallback.Initialize"/> callback.
        /// </remarks>
        public HRESULT TrySetEnterLeaveFunctionHooks3WithInfo(FunctionEnter3WithInfo pFuncEnter3WithInfo, FunctionLeave3WithInfo pFuncLeave3WithInfo, FunctionTailcall3WithInfo pFuncTailcall3WithInfo)
        {
            /*HRESULT SetEnterLeaveFunctionHooks3WithInfo(
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionEnter3WithInfo pFuncEnter3WithInfo,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionLeave3WithInfo pFuncLeave3WithInfo,
            [MarshalAs(UnmanagedType.FunctionPtr), In] FunctionTailcall3WithInfo pFuncTailcall3WithInfo);*/
            return Raw3.SetEnterLeaveFunctionHooks3WithInfo(pFuncEnter3WithInfo, pFuncLeave3WithInfo, pFuncTailcall3WithInfo);
        }

        #endregion
        #region GetFunctionEnter3Info

        /// <summary>
        /// Provides the stack frame and argument information of the function that is being reported to the profiler by the FunctionEnter3WithInfo function.<para/>
        /// This method can be called only during the FunctionEnter3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is being entered.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that it was given by the FunctionEnter3WithInfo function.</param>
        /// <param name="pcbArgumentInfo">[in, out] A pointer to the total size, in bytes, of the <see cref="COR_PRF_FUNCTION_ARGUMENT_INFO"/> structure (plus any additional <see cref="COR_PRF_FUNCTION_ARGUMENT_RANGE"/> structures for the argument ranges pointed to by pArgumentInfo).<para/>
        /// If the specified size is not enough, ERROR_INSUFFICIENT_BUFFER is returned and the expected size is stored in pcbArgumentInfo.<para/>
        /// To call GetFunctionEnter3Info just to retrieve the expected value for *pcbArgumentInfo, set *pcbArgumentInfo=0 and pArgumentInfo=NULL.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The profiler must allocate sufficient space for the COR_PRF_FUNCTION_ARGUMENT_INFO structure of the function that
        /// is being inspected, and must indicate the size in the pcbArgumentInfo parameter.
        /// </remarks>
        public GetFunctionEnter3InfoResult GetFunctionEnter3Info(FunctionID functionId, COR_PRF_ELT_INFO eltInfo, ref int pcbArgumentInfo)
        {
            GetFunctionEnter3InfoResult result;
            TryGetFunctionEnter3Info(functionId, eltInfo, ref pcbArgumentInfo, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Provides the stack frame and argument information of the function that is being reported to the profiler by the FunctionEnter3WithInfo function.<para/>
        /// This method can be called only during the FunctionEnter3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is being entered.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that it was given by the FunctionEnter3WithInfo function.</param>
        /// <param name="pcbArgumentInfo">[in, out] A pointer to the total size, in bytes, of the <see cref="COR_PRF_FUNCTION_ARGUMENT_INFO"/> structure (plus any additional <see cref="COR_PRF_FUNCTION_ARGUMENT_RANGE"/> structures for the argument ranges pointed to by pArgumentInfo).<para/>
        /// If the specified size is not enough, ERROR_INSUFFICIENT_BUFFER is returned and the expected size is stored in pcbArgumentInfo.<para/>
        /// To call GetFunctionEnter3Info just to retrieve the expected value for *pcbArgumentInfo, set *pcbArgumentInfo=0 and pArgumentInfo=NULL.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The profiler must allocate sufficient space for the COR_PRF_FUNCTION_ARGUMENT_INFO structure of the function that
        /// is being inspected, and must indicate the size in the pcbArgumentInfo parameter.
        /// </remarks>
        public HRESULT TryGetFunctionEnter3Info(FunctionID functionId, COR_PRF_ELT_INFO eltInfo, ref int pcbArgumentInfo, out GetFunctionEnter3InfoResult result)
        {
            /*HRESULT GetFunctionEnter3Info(
            [In] FunctionID functionId,
            [In] COR_PRF_ELT_INFO eltInfo,
            [Out] out COR_PRF_FRAME_INFO pFrameInfo,
            [In, Out] ref int pcbArgumentInfo,
            [Out] out COR_PRF_FUNCTION_ARGUMENT_INFO pArgumentInfo);*/
            COR_PRF_FRAME_INFO pFrameInfo;
            COR_PRF_FUNCTION_ARGUMENT_INFO pArgumentInfo;
            HRESULT hr = Raw3.GetFunctionEnter3Info(functionId, eltInfo, out pFrameInfo, ref pcbArgumentInfo, out pArgumentInfo);

            if (hr == HRESULT.S_OK)
                result = new GetFunctionEnter3InfoResult(pFrameInfo, pArgumentInfo);
            else
                result = default(GetFunctionEnter3InfoResult);

            return hr;
        }

        #endregion
        #region GetFunctionLeave3Info

        /// <summary>
        /// Provides the stack frame and return value of the function that is being reported to the profiler by the FunctionLeave3WithInfo function function.<para/>
        /// This method can be called only during the FunctionLeave3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is returning.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that was given to the profiler by the FunctionLeave3WithInfo function.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetFunctionLeave3InfoResult GetFunctionLeave3Info(FunctionID functionId, COR_PRF_ELT_INFO eltInfo)
        {
            GetFunctionLeave3InfoResult result;
            TryGetFunctionLeave3Info(functionId, eltInfo, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Provides the stack frame and return value of the function that is being reported to the profiler by the FunctionLeave3WithInfo function function.<para/>
        /// This method can be called only during the FunctionLeave3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is returning.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that was given to the profiler by the FunctionLeave3WithInfo function.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetFunctionLeave3Info(FunctionID functionId, COR_PRF_ELT_INFO eltInfo, out GetFunctionLeave3InfoResult result)
        {
            /*HRESULT GetFunctionLeave3Info(
            [In] FunctionID functionId,
            [In] COR_PRF_ELT_INFO eltInfo,
            [Out] out COR_PRF_FRAME_INFO pFrameInfo,
            [Out] out COR_PRF_FUNCTION_ARGUMENT_RANGE pRetvalRange);*/
            COR_PRF_FRAME_INFO pFrameInfo;
            COR_PRF_FUNCTION_ARGUMENT_RANGE pRetvalRange;
            HRESULT hr = Raw3.GetFunctionLeave3Info(functionId, eltInfo, out pFrameInfo, out pRetvalRange);

            if (hr == HRESULT.S_OK)
                result = new GetFunctionLeave3InfoResult(pFrameInfo, pRetvalRange);
            else
                result = default(GetFunctionLeave3InfoResult);

            return hr;
        }

        #endregion
        #region GetFunctionTailcall3Info

        /// <summary>
        /// Provides the stack frame of the function that is being reported to the profiler by the FunctionTailcall3WithInfo function.<para/>
        /// This method can be called only during the FunctionTailcall3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is returning.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that was given to the profiler by the FunctionTailcall3WithInfo function.</param>
        /// <returns>[out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the FunctionTailcall3WithInfo callback in which the profiler called the GetFunctionTailcall3Info method.</returns>
        public COR_PRF_FRAME_INFO GetFunctionTailcall3Info(FunctionID functionId, COR_PRF_ELT_INFO eltInfo)
        {
            COR_PRF_FRAME_INFO pFrameInfo;
            TryGetFunctionTailcall3Info(functionId, eltInfo, out pFrameInfo).ThrowOnNotOK();

            return pFrameInfo;
        }

        /// <summary>
        /// Provides the stack frame of the function that is being reported to the profiler by the FunctionTailcall3WithInfo function.<para/>
        /// This method can be called only during the FunctionTailcall3WithInfo callback.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function that is returning.</param>
        /// <param name="eltInfo">[in] An opaque handle that represents information about a given stack frame. The profiler should provide the same eltInfo that was given to the profiler by the FunctionTailcall3WithInfo function.</param>
        /// <param name="pFrameInfo">[out] An opaque handle that represents generics information about a given stack frame. This handle is valid only during the FunctionTailcall3WithInfo callback in which the profiler called the GetFunctionTailcall3Info method.</param>
        public HRESULT TryGetFunctionTailcall3Info(FunctionID functionId, COR_PRF_ELT_INFO eltInfo, out COR_PRF_FRAME_INFO pFrameInfo)
        {
            /*HRESULT GetFunctionTailcall3Info(
            [In] FunctionID functionId,
            [In] COR_PRF_ELT_INFO eltInfo,
            [Out] out COR_PRF_FRAME_INFO pFrameInfo);*/
            return Raw3.GetFunctionTailcall3Info(functionId, eltInfo, out pFrameInfo);
        }

        #endregion
        #region EnumModules

        /// <summary>
        /// Returns an enumerator that provides methods to sequentially iterate through a collection of managed modules that are loaded into the application.
        /// </summary>
        public ModuleID[] Modules => EnumModules().ToArray();

        /// <summary>
        /// Returns an enumerator that provides methods to sequentially iterate through a collection of managed modules that are loaded into the application.
        /// </summary>
        /// <returns>[out] A pointer to an <see cref="ICorProfilerModuleEnum"/> interface.</returns>
        public CorProfilerModuleEnum EnumModules()
        {
            CorProfilerModuleEnum ppEnumResult;
            TryEnumModules(out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Returns an enumerator that provides methods to sequentially iterate through a collection of managed modules that are loaded into the application.
        /// </summary>
        /// <param name="ppEnumResult">[out] A pointer to an <see cref="ICorProfilerModuleEnum"/> interface.</param>
        public HRESULT TryEnumModules(out CorProfilerModuleEnum ppEnumResult)
        {
            /*HRESULT EnumModules(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerModuleEnum ppEnum);*/
            ICorProfilerModuleEnum ppEnum;
            HRESULT hr = Raw3.EnumModules(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new CorProfilerModuleEnum(ppEnum);
            else
                ppEnumResult = default(CorProfilerModuleEnum);

            return hr;
        }

        #endregion
        #region GetThreadStaticAddress2

        /// <summary>
        /// Gets the address of the specified thread-static field that is in the scope of the specified thread and application domain.
        /// </summary>
        /// <param name="classId">[in] The ID of the class that contains the requested thread-static field.</param>
        /// <param name="fieldToken">[in] The metadata token for the requested thread-static field.</param>
        /// <param name="appDomainId">[in] The ID of the application domain.</param>
        /// <param name="threadId">[in] The ID of the thread that is the scope for the requested static field.</param>
        /// <returns>[out] A pointer to the address of the static field that is within the specified thread.</returns>
        /// <remarks>
        /// The GetThreadStaticAddress2 method may return one of the following: Before a class’s class constructor is completed,
        /// GetThreadStaticAddress2 will return CORPROF_E_DATAINCOMPLETE for all its static fields, although some of the static
        /// fields may already be initialized and rooting garbage collection objects. The <see cref="GetThreadStaticAddress"/>
        /// method is similar to the GetThreadStaticAddress2 method, but does not accept an application domain argument.
        /// </remarks>
        public IntPtr GetThreadStaticAddress2(ClassID classId, mdFieldDef fieldToken, AppDomainID appDomainId, ThreadID threadId)
        {
            IntPtr ppAddress;
            TryGetThreadStaticAddress2(classId, fieldToken, appDomainId, threadId, out ppAddress).ThrowOnNotOK();

            return ppAddress;
        }

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
        /// fields may already be initialized and rooting garbage collection objects. The <see cref="GetThreadStaticAddress"/>
        /// method is similar to the GetThreadStaticAddress2 method, but does not accept an application domain argument.
        /// </remarks>
        public HRESULT TryGetThreadStaticAddress2(ClassID classId, mdFieldDef fieldToken, AppDomainID appDomainId, ThreadID threadId, out IntPtr ppAddress)
        {
            /*HRESULT GetThreadStaticAddress2(
            [In] ClassID classId,
            [In] mdFieldDef fieldToken,
            [In] AppDomainID appDomainId,
            [In] ThreadID threadId,
            [Out] out IntPtr ppAddress);*/
            return Raw3.GetThreadStaticAddress2(classId, fieldToken, appDomainId, threadId, out ppAddress);
        }

        #endregion
        #region GetAppDomainsContainingModule

        /// <summary>
        /// Gets the identifiers of the application domains in which the given module has been loaded.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the loaded module.</param>
        /// <returns>[out] An array of application domain ID values.</returns>
        /// <remarks>
        /// The method uses caller allocated buffers.
        /// </remarks>
        public AppDomainID[] GetAppDomainsContainingModule(ModuleID moduleId)
        {
            AppDomainID[] appDomainIds;
            TryGetAppDomainsContainingModule(moduleId, out appDomainIds).ThrowOnNotOK();

            return appDomainIds;
        }

        /// <summary>
        /// Gets the identifiers of the application domains in which the given module has been loaded.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the loaded module.</param>
        /// <param name="appDomainIds">[out] An array of application domain ID values.</param>
        /// <remarks>
        /// The method uses caller allocated buffers.
        /// </remarks>
        public HRESULT TryGetAppDomainsContainingModule(ModuleID moduleId, out AppDomainID[] appDomainIds)
        {
            /*HRESULT GetAppDomainsContainingModule(
            [In] ModuleID moduleId,
            [In] int cAppDomainIds,
            [Out] out int pcAppDomainIds,
            [MarshalAs(UnmanagedType.LPArray), Out] AppDomainID[] appDomainIds);*/
            int cAppDomainIds = 0;
            int pcAppDomainIds;
            appDomainIds = null;
            HRESULT hr = Raw3.GetAppDomainsContainingModule(moduleId, cAppDomainIds, out pcAppDomainIds, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cAppDomainIds = pcAppDomainIds;
            appDomainIds = new AppDomainID[cAppDomainIds];
            hr = Raw3.GetAppDomainsContainingModule(moduleId, cAppDomainIds, out pcAppDomainIds, appDomainIds);
            fail:
            return hr;
        }

        #endregion
        #region GetModuleInfo2

        /// <summary>
        /// Given a module ID, returns the file name of the module, the ID of the module's parent assembly, and a bitmask that describes the properties of the module.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module for which information will be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
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
        public GetModuleInfo2Result GetModuleInfo2(ModuleID moduleId)
        {
            GetModuleInfo2Result result;
            TryGetModuleInfo2(moduleId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Given a module ID, returns the file name of the module, the ID of the module's parent assembly, and a bitmask that describes the properties of the module.
        /// </summary>
        /// <param name="moduleId">[in] The ID of the module for which information will be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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
        public HRESULT TryGetModuleInfo2(ModuleID moduleId, out GetModuleInfo2Result result)
        {
            /*HRESULT GetModuleInfo2(
            [In] ModuleID moduleId,
            [Out] out IntPtr ppBaseLoadAddress,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] szName,
            [Out] out AssemblyID pAssemblyId,
            [Out] out COR_PRF_MODULE_FLAGS pdwModuleFlags);*/
            IntPtr ppBaseLoadAddress;
            int cchName = 0;
            int pcchName;
            char[] szName;
            AssemblyID pAssemblyId;
            COR_PRF_MODULE_FLAGS pdwModuleFlags;
            HRESULT hr = Raw3.GetModuleInfo2(moduleId, out ppBaseLoadAddress, cchName, out pcchName, null, out pAssemblyId, out pdwModuleFlags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw3.GetModuleInfo2(moduleId, out ppBaseLoadAddress, cchName, out pcchName, szName, out pAssemblyId, out pdwModuleFlags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetModuleInfo2Result(ppBaseLoadAddress, CreateString(szName, pcchName), pAssemblyId, pdwModuleFlags);

                return hr;
            }

            fail:
            result = default(GetModuleInfo2Result);

            return hr;
        }

        #endregion
        #endregion
        #region ICorProfilerInfo4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo4 Raw4 => (ICorProfilerInfo4) Raw;

        #region EnumThreads

        /// <summary>
        /// Returns an enumerator that provides methods to sequentially iterate through the collection of all managed threads in the profiled process.
        /// </summary>
        public ThreadID[] Threads => EnumThreads().ToArray();

        /// <summary>
        /// Returns an enumerator that provides methods to sequentially iterate through the collection of all managed threads in the profiled process.
        /// </summary>
        /// <returns>[out] A pointer to an <see cref="ICorProfilerThreadEnum"/> interface.</returns>
        public CorProfilerThreadEnum EnumThreads()
        {
            CorProfilerThreadEnum ppEnumResult;
            TryEnumThreads(out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Returns an enumerator that provides methods to sequentially iterate through the collection of all managed threads in the profiled process.
        /// </summary>
        /// <param name="ppEnumResult">[out] A pointer to an <see cref="ICorProfilerThreadEnum"/> interface.</param>
        public HRESULT TryEnumThreads(out CorProfilerThreadEnum ppEnumResult)
        {
            /*HRESULT EnumThreads(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerThreadEnum ppEnum);*/
            ICorProfilerThreadEnum ppEnum;
            HRESULT hr = Raw4.EnumThreads(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new CorProfilerThreadEnum(ppEnum);
            else
                ppEnumResult = default(CorProfilerThreadEnum);

            return hr;
        }

        #endregion
        #region InitializeCurrentThread

        /// <summary>
        /// Initializes the current thread in advance of subsequent profiler API calls on the same thread, so that deadlock can be avoided.
        /// </summary>
        /// <remarks>
        /// We recommend that you call InitializeCurrentThread on any thread that will call a profiler API while there are
        /// suspended threads. This method is typically used by sampling profilers that create their own thread to call the
        /// <see cref="DoStackSnapshot"/> method to perform stack walks while the target thread is suspended.
        /// By calling InitializeCurrentThread once when the profiler first creates the sampling thread, profilers can ensure
        /// that lazy per-thread initialization that the CLR would otherwise perform during the first call to DoStackSnapshot
        /// can now occur safely when no other threads are suspended.
        /// </remarks>
        public void InitializeCurrentThread()
        {
            TryInitializeCurrentThread().ThrowOnNotOK();
        }

        /// <summary>
        /// Initializes the current thread in advance of subsequent profiler API calls on the same thread, so that deadlock can be avoided.
        /// </summary>
        /// <remarks>
        /// We recommend that you call InitializeCurrentThread on any thread that will call a profiler API while there are
        /// suspended threads. This method is typically used by sampling profilers that create their own thread to call the
        /// <see cref="DoStackSnapshot"/> method to perform stack walks while the target thread is suspended.
        /// By calling InitializeCurrentThread once when the profiler first creates the sampling thread, profilers can ensure
        /// that lazy per-thread initialization that the CLR would otherwise perform during the first call to DoStackSnapshot
        /// can now occur safely when no other threads are suspended.
        /// </remarks>
        public HRESULT TryInitializeCurrentThread()
        {
            /*HRESULT InitializeCurrentThread();*/
            return Raw4.InitializeCurrentThread();
        }

        #endregion
        #region RequestReJIT

        /// <summary>
        /// Requests a JIT recompilation of all instances of the specified functions.
        /// </summary>
        /// <param name="cFunctions">[in] The number of functions to recompile.</param>
        /// <param name="moduleIds">[in] Specifies the moduleId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <param name="methodIds">[in] Specifies the methodId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <remarks>
        /// Call RequestReJIT to have the runtime recompile a specified set of functions. A code profiler can then use the
        /// <see cref="ICorProfilerFunctionControl"/> interface to adjust the code that is generated when the functions are
        /// recompiled. This does not affect currently executing functions, only future function invocations. If any of the
        /// specified functions has previously been JIT-recompiled, requesting a recompilation is equivalent to reverting and
        /// recompiling the function. To preserve reversibility, when the JIT compiler compiles the original version of a function,
        /// it considers only the original versions of its callees for inlining decisions. When the JIT compiler recompiles
        /// a function, it considers the current versions (recompiled or original) of its callees for inlining. A profiler
        /// typically calls RequestReJIT in response to user input requesting that the profiler instrument one or more methods.
        /// RequestReJIT typically suspends the runtime in order to do some of its work, and can potentially trigger a garbage
        /// collection. As such, the profiler should call RequestReJIT from a thread it previously created, and not from a
        /// CLR-created thread that is currently executing a profiler callback.
        /// </remarks>
        public void RequestReJIT(int cFunctions, ModuleID[] moduleIds, mdMethodDef[] methodIds)
        {
            TryRequestReJIT(cFunctions, moduleIds, methodIds).ThrowOnNotOK();
        }

        /// <summary>
        /// Requests a JIT recompilation of all instances of the specified functions.
        /// </summary>
        /// <param name="cFunctions">[in] The number of functions to recompile.</param>
        /// <param name="moduleIds">[in] Specifies the moduleId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <param name="methodIds">[in] Specifies the methodId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                      | Description                                                                                                                                                                                                                         |
        /// | ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                         | An attempt was made to mark all the methods for JIT recompilation. The profiler must implement the <see cref="ICorProfilerCallback4.ReJITError"/> method to determine which methods were successfully marked for JIT recompilation. |
        /// | CORPROF_E_CALLBACK4_REQUIRED | The profiler must implement the <see cref="ICorProfilerCallback4"/> interface for this call to be supported.                                                                                                                        |
        /// | CORPROF_E_REJIT_NOT_ENABLED  | JIT recompilation has not been enabled. You must enable JIT recompilation during initialization by using the <see cref="EventMask"/> property to set the COR_PRF_ENABLE_REJIT flag.                               |
        /// | E_INVALIDARG                 | cFunctions is 0, or moduleIds or methodIds is NULL.                                                                                                                                                                                 |
        /// | E_OUTOFMEMORY                | The CLR was unable to complete the request because it ran out of memory.                                                                                                                                                            |
        /// </returns>
        /// <remarks>
        /// Call RequestReJIT to have the runtime recompile a specified set of functions. A code profiler can then use the
        /// <see cref="ICorProfilerFunctionControl"/> interface to adjust the code that is generated when the functions are
        /// recompiled. This does not affect currently executing functions, only future function invocations. If any of the
        /// specified functions has previously been JIT-recompiled, requesting a recompilation is equivalent to reverting and
        /// recompiling the function. To preserve reversibility, when the JIT compiler compiles the original version of a function,
        /// it considers only the original versions of its callees for inlining decisions. When the JIT compiler recompiles
        /// a function, it considers the current versions (recompiled or original) of its callees for inlining. A profiler
        /// typically calls RequestReJIT in response to user input requesting that the profiler instrument one or more methods.
        /// RequestReJIT typically suspends the runtime in order to do some of its work, and can potentially trigger a garbage
        /// collection. As such, the profiler should call RequestReJIT from a thread it previously created, and not from a
        /// CLR-created thread that is currently executing a profiler callback.
        /// </remarks>
        public HRESULT TryRequestReJIT(int cFunctions, ModuleID[] moduleIds, mdMethodDef[] methodIds)
        {
            /*HRESULT RequestReJIT(
            [In] int cFunctions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ModuleID[] moduleIds,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] mdMethodDef[] methodIds);*/
            return Raw4.RequestReJIT(cFunctions, moduleIds, methodIds);
        }

        #endregion
        #region RequestRevert

        /// <summary>
        /// Reverts all instances of the specified functions to their original versions.
        /// </summary>
        /// <param name="cFunctions">[in] The number of functions to revert.</param>
        /// <param name="moduleIds">[in] Specifies the moduleId portion of the (module, methodDef) pairs that identify the functions to be reverted.</param>
        /// <param name="methodIds">[in] Specifies the methodId portion of the (module, methodDef) pairs that identify the functions to be reverted.</param>
        /// <returns>[out] An array of HRESULTs listed in the "Status HRESULTs" section later in this topic. Each HRESULT indicates the success or failure of trying to revert each function specified in the parallel arrays moduleIds and methodIds.</returns>
        /// <remarks>
        /// The next time any of the reverted function instances are called, the original versions of the functions will be
        /// run. If a function is already running, it will finish executing the version that is running.
        /// </remarks>
        public HRESULT RequestRevert(int cFunctions, ModuleID[] moduleIds, mdMethodDef[] methodIds)
        {
            HRESULT status;
            TryRequestRevert(cFunctions, moduleIds, methodIds, out status).ThrowOnNotOK();

            return status;
        }

        /// <summary>
        /// Reverts all instances of the specified functions to their original versions.
        /// </summary>
        /// <param name="cFunctions">[in] The number of functions to revert.</param>
        /// <param name="moduleIds">[in] Specifies the moduleId portion of the (module, methodDef) pairs that identify the functions to be reverted.</param>
        /// <param name="methodIds">[in] Specifies the methodId portion of the (module, methodDef) pairs that identify the functions to be reverted.</param>
        /// <param name="status">[out] An array of HRESULTs listed in the "Status HRESULTs" section later in this topic. Each HRESULT indicates the success or failure of trying to revert each function specified in the parallel arrays moduleIds and methodIds.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                      | Description                                                                                                                                                                                           |
        /// | ---------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                         | An attempt was made to revert all requests; however, the returned status array must be checked to determine which functions were successfully reverted.                                               |
        /// | CORPROF_E_CALLBACK4_REQUIRED | The profiler must implement the <see cref="ICorProfilerCallback4"/> interface for this call to be supported.                                                                                          |
        /// | CORPROF_E_REJIT_NOT_ENABLED  | JIT recompilation has not been enabled. You must enable JIT recompilation during initialization by using the <see cref="EventMask"/> property to set the COR_PRF_ENABLE_REJIT flag. |
        /// | E_INVALIDARG                 | cFunctions is 0, or moduleIds or methodIds is NULL.                                                                                                                                                   |
        /// | E_OUTOFMEMORY                | The CLR was unable to complete the request because it ran out of memory.                                                                                                                              |
        /// </returns>
        /// <remarks>
        /// The next time any of the reverted function instances are called, the original versions of the functions will be
        /// run. If a function is already running, it will finish executing the version that is running.
        /// </remarks>
        public HRESULT TryRequestRevert(int cFunctions, ModuleID[] moduleIds, mdMethodDef[] methodIds, out HRESULT status)
        {
            /*HRESULT RequestRevert(
            [In] int cFunctions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ModuleID[] moduleIds,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] mdMethodDef[] methodIds,
            [Out] out HRESULT status);*/
            return Raw4.RequestRevert(cFunctions, moduleIds, methodIds, out status);
        }

        #endregion
        #region GetCodeInfo3

        /// <summary>
        /// Gets the extents of native code associated with the JIT-recompiled version of the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
        /// <param name="reJitId">[in] The identity of the JIT-recompiled function.</param>
        /// <returns>[out] A caller-provided buffer. After the method returns, it contains an array of COR_PRF_CODE_INFO structures, each of which describes a block of native code.</returns>
        /// <remarks>
        /// The GetCodeInfo3 method is similar to <see cref="GetCodeInfo2"/>, except that it will get the
        /// JIT-recompiled ID of the function that contains the specified IP address. The extents are sorted in order of increasing
        /// Common Intermediate Language (CIL) offset. After GetCodeInfo3 returns, you must verify that the codeInfos buffer
        /// was large enough to contain all the <see cref="COR_PRF_CODE_INFO"/> structures. To do this, compare the value of
        /// cCodeInfos with the value of the cchName parameter. If cCodeInfos divided by the size of a <see cref="COR_PRF_CODE_INFO"/>
        /// structure is smaller than pcCodeInfos, allocate a larger codeInfos buffer, update cCodeInfos with the new, larger
        /// size, and call GetCodeInfo3 again. Alternatively, you can first call GetCodeInfo3 with a zero-length codeInfos
        /// buffer to obtain the correct buffer size. You can then set the codeInfos buffer size to the value returned in pcCodeInfos,
        /// multiplied by the size of a <see cref="COR_PRF_CODE_INFO"/> structure, and call GetCodeInfo3 again.
        /// </remarks>
        public COR_PRF_CODE_INFO[] GetCodeInfo3(FunctionID functionId, ReJITID reJitId)
        {
            COR_PRF_CODE_INFO[] codeInfos;
            TryGetCodeInfo3(functionId, reJitId, out codeInfos).ThrowOnNotOK();

            return codeInfos;
        }

        /// <summary>
        /// Gets the extents of native code associated with the JIT-recompiled version of the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function with which the native code is associated.</param>
        /// <param name="reJitId">[in] The identity of the JIT-recompiled function.</param>
        /// <param name="codeInfos">[out] A caller-provided buffer. After the method returns, it contains an array of COR_PRF_CODE_INFO structures, each of which describes a block of native code.</param>
        /// <remarks>
        /// The GetCodeInfo3 method is similar to <see cref="GetCodeInfo2"/>, except that it will get the
        /// JIT-recompiled ID of the function that contains the specified IP address. The extents are sorted in order of increasing
        /// Common Intermediate Language (CIL) offset. After GetCodeInfo3 returns, you must verify that the codeInfos buffer
        /// was large enough to contain all the <see cref="COR_PRF_CODE_INFO"/> structures. To do this, compare the value of
        /// cCodeInfos with the value of the cchName parameter. If cCodeInfos divided by the size of a <see cref="COR_PRF_CODE_INFO"/>
        /// structure is smaller than pcCodeInfos, allocate a larger codeInfos buffer, update cCodeInfos with the new, larger
        /// size, and call GetCodeInfo3 again. Alternatively, you can first call GetCodeInfo3 with a zero-length codeInfos
        /// buffer to obtain the correct buffer size. You can then set the codeInfos buffer size to the value returned in pcCodeInfos,
        /// multiplied by the size of a <see cref="COR_PRF_CODE_INFO"/> structure, and call GetCodeInfo3 again.
        /// </remarks>
        public HRESULT TryGetCodeInfo3(FunctionID functionId, ReJITID reJitId, out COR_PRF_CODE_INFO[] codeInfos)
        {
            /*HRESULT GetCodeInfo3(
            [In] FunctionID functionId,
            [In] ReJITID reJitId,
            [In] int cCodeInfos,
            [Out] out int pcCodeInfos,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_PRF_CODE_INFO[] codeInfos);*/
            int cCodeInfos = 0;
            int pcCodeInfos;
            codeInfos = null;
            HRESULT hr = Raw4.GetCodeInfo3(functionId, reJitId, cCodeInfos, out pcCodeInfos, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cCodeInfos = pcCodeInfos;
            codeInfos = new COR_PRF_CODE_INFO[cCodeInfos];
            hr = Raw4.GetCodeInfo3(functionId, reJitId, cCodeInfos, out pcCodeInfos, codeInfos);
            fail:
            return hr;
        }

        #endregion
        #region GetFunctionFromIP2

        /// <summary>
        /// Maps a managed code instruction pointer to the JIT-recompiled version of a function.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// GetFunctionFromIP2 is similar to GetFunctionFromIP, except that it gets the JIT-recompiled ID instead of the function
        /// ID of the function that contains the specified IP address.
        /// </remarks>
        public GetFunctionFromIP2Result GetFunctionFromIP2(IntPtr ip)
        {
            GetFunctionFromIP2Result result;
            TryGetFunctionFromIP2(ip, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Maps a managed code instruction pointer to the JIT-recompiled version of a function.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// GetFunctionFromIP2 is similar to GetFunctionFromIP, except that it gets the JIT-recompiled ID instead of the function
        /// ID of the function that contains the specified IP address.
        /// </remarks>
        public HRESULT TryGetFunctionFromIP2(IntPtr ip, out GetFunctionFromIP2Result result)
        {
            /*HRESULT GetFunctionFromIP2(
            [In] IntPtr ip,
            [Out] out FunctionID pFunctionId,
            [Out] out ReJITID pReJitId);*/
            FunctionID pFunctionId;
            ReJITID pReJitId;
            HRESULT hr = Raw4.GetFunctionFromIP2(ip, out pFunctionId, out pReJitId);

            if (hr == HRESULT.S_OK)
                result = new GetFunctionFromIP2Result(pFunctionId, pReJitId);
            else
                result = default(GetFunctionFromIP2Result);

            return hr;
        }

        #endregion
        #region GetReJITIDs

        /// <summary>
        /// Returns an array of IDs that identify all JIT-recompiled versions of the specified function that are still allocated.<para/>
        /// This includes JIT-recompiled versions of functions that have been subsequently reverted but not yet freed (for example, when the application domain that contains the reverted function is still in use).
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function instance for which to enumerate versions.</param>
        /// <returns>[out] A caller-allocated array that will contain the JIT-recompiled IDs for the specified function.</returns>
        /// <remarks>
        /// GetReJITIDs enumerates the active JIT-recompiled IDs for a given function instance. It follows the same usage pattern
        /// as other ICorProfilerInfo functions that accept caller-allocated buffers.
        /// </remarks>
        public ReJITID[] GetReJITIDs(FunctionID functionId)
        {
            ReJITID[] reJitIds;
            TryGetReJITIDs(functionId, out reJitIds).ThrowOnNotOK();

            return reJitIds;
        }

        /// <summary>
        /// Returns an array of IDs that identify all JIT-recompiled versions of the specified function that are still allocated.<para/>
        /// This includes JIT-recompiled versions of functions that have been subsequently reverted but not yet freed (for example, when the application domain that contains the reverted function is still in use).
        /// </summary>
        /// <param name="functionId">[in] The FunctionID of the function instance for which to enumerate versions.</param>
        /// <param name="reJitIds">[out] A caller-allocated array that will contain the JIT-recompiled IDs for the specified function.</param>
        /// <remarks>
        /// GetReJITIDs enumerates the active JIT-recompiled IDs for a given function instance. It follows the same usage pattern
        /// as other ICorProfilerInfo functions that accept caller-allocated buffers.
        /// </remarks>
        public HRESULT TryGetReJITIDs(FunctionID functionId, out ReJITID[] reJitIds)
        {
            /*HRESULT GetReJITIDs(
            [In] FunctionID functionId,
            [In] int cReJitIds,
            [Out] out int pcReJitIds,
            [MarshalAs(UnmanagedType.LPArray), Out] ReJITID[] reJitIds);*/
            int cReJitIds = 0;
            int pcReJitIds;
            reJitIds = null;
            HRESULT hr = Raw4.GetReJITIDs(functionId, cReJitIds, out pcReJitIds, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cReJitIds = pcReJitIds;
            reJitIds = new ReJITID[cReJitIds];
            hr = Raw4.GetReJITIDs(functionId, cReJitIds, out pcReJitIds, reJitIds);
            fail:
            return hr;
        }

        #endregion
        #region GetILToNativeMapping2

        /// <summary>
        /// Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the JIT-recompiled version of the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the code.</param>
        /// <param name="reJitId">[in] The identity of the JIT-recompiled function. The identity must be zero in .NET Framework 4.5.</param>
        /// <returns>[out] An array of COR_DEBUG_IL_TO_NATIVE_MAP structures, each of which specifies the offsets. After the GetILToNativeMapping2 method returns, map will contain some or all of the COR_DEBUG_IL_TO_NATIVE_MAP structures.</returns>
        /// <remarks>
        /// GetILToNativeMapping2 is similar to the <see cref="GetILToNativeMapping"/> method, except that
        /// it will allow the profiler to specify the ID of the recompiled function in future releases. The GetILToNativeMapping2
        /// method returns an array of COR_DEBUG_IL_TO_NATIVE_MAP structures. To convey that certain ranges of native instructions
        /// correspond to special regions of code (for example, the prolog), an entry in the array can have its ilOffset field
        /// set to a value of the CorDebugIlToNativeMappingTypes enumeration. After GetILToNativeMapping2 returns, you must
        /// verify that the map buffer was large enough to contain all the COR_DEBUG_IL_TO_NATIVE_MAP structures. To do this,
        /// compare the value of cMap with the value of the pcMap parameter. If the pcMap value, when it is multiplied by the
        /// size of a COR_DEBUG_IL_TO_NATIVE_MAP structure, is larger than cMap, allocate a larger map buffer, update cMap
        /// with the new, larger size, and call GetILToNativeMapping2 again. Alternatively, you can first call GetILToNativeMapping2
        /// with a zero-length map buffer to obtain the correct buffer size. You can then set the buffer size to the value
        /// returned in pcMap and call GetILToNativeMapping2 again.
        /// </remarks>
        public COR_DEBUG_IL_TO_NATIVE_MAP[] GetILToNativeMapping2(FunctionID functionId, ReJITID reJitId)
        {
            COR_DEBUG_IL_TO_NATIVE_MAP[] map;
            TryGetILToNativeMapping2(functionId, reJitId, out map).ThrowOnNotOK();

            return map;
        }

        /// <summary>
        /// Gets a map from Microsoft intermediate language (MSIL) offsets to native offsets for the code contained in the JIT-recompiled version of the specified function.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function that contains the code.</param>
        /// <param name="reJitId">[in] The identity of the JIT-recompiled function. The identity must be zero in .NET Framework 4.5.</param>
        /// <param name="map">[out] An array of COR_DEBUG_IL_TO_NATIVE_MAP structures, each of which specifies the offsets. After the GetILToNativeMapping2 method returns, map will contain some or all of the COR_DEBUG_IL_TO_NATIVE_MAP structures.</param>
        /// <remarks>
        /// GetILToNativeMapping2 is similar to the <see cref="GetILToNativeMapping"/> method, except that
        /// it will allow the profiler to specify the ID of the recompiled function in future releases. The GetILToNativeMapping2
        /// method returns an array of COR_DEBUG_IL_TO_NATIVE_MAP structures. To convey that certain ranges of native instructions
        /// correspond to special regions of code (for example, the prolog), an entry in the array can have its ilOffset field
        /// set to a value of the CorDebugIlToNativeMappingTypes enumeration. After GetILToNativeMapping2 returns, you must
        /// verify that the map buffer was large enough to contain all the COR_DEBUG_IL_TO_NATIVE_MAP structures. To do this,
        /// compare the value of cMap with the value of the pcMap parameter. If the pcMap value, when it is multiplied by the
        /// size of a COR_DEBUG_IL_TO_NATIVE_MAP structure, is larger than cMap, allocate a larger map buffer, update cMap
        /// with the new, larger size, and call GetILToNativeMapping2 again. Alternatively, you can first call GetILToNativeMapping2
        /// with a zero-length map buffer to obtain the correct buffer size. You can then set the buffer size to the value
        /// returned in pcMap and call GetILToNativeMapping2 again.
        /// </remarks>
        public HRESULT TryGetILToNativeMapping2(FunctionID functionId, ReJITID reJitId, out COR_DEBUG_IL_TO_NATIVE_MAP[] map)
        {
            /*HRESULT GetILToNativeMapping2(
            [In] FunctionID functionId,
            [In] ReJITID reJitId,
            [In] int cMap,
            [Out] out int pcMap,
            [MarshalAs(UnmanagedType.LPArray), Out] COR_DEBUG_IL_TO_NATIVE_MAP[] map);*/
            int cMap = 0;
            int pcMap;
            map = null;
            HRESULT hr = Raw4.GetILToNativeMapping2(functionId, reJitId, cMap, out pcMap, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMap = pcMap;
            map = new COR_DEBUG_IL_TO_NATIVE_MAP[cMap];
            hr = Raw4.GetILToNativeMapping2(functionId, reJitId, cMap, out pcMap, map);
            fail:
            return hr;
        }

        #endregion
        #region EnumJITedFunctions2

        /// <summary>
        /// Returns an enumerator for all functions that were previously JIT-compiled and JIT-recompiled. This method replaces the <see cref="ICorProfilerInfo3.EnumJITedFunctions"/> method, which does not enumerate JIT-recompiled IDs.
        /// </summary>
        public COR_PRF_FUNCTION[] JITedFunctions2s => EnumJITedFunctions2().ToArray();

        /// <summary>
        /// Returns an enumerator for all functions that were previously JIT-compiled and JIT-recompiled. This method replaces the <see cref="EnumJITedFunctions"/> method, which does not enumerate JIT-recompiled IDs.
        /// </summary>
        /// <returns>[out] A pointer to the <see cref="ICorProfilerFunctionEnum"/> enumerator.</returns>
        /// <remarks>
        /// This method may overlap with JITCompilation callbacks such as the <see cref="ICorProfilerCallback.JITCompilationStarted"/>
        /// method. The returned enumeration includes values for the COR_PRF_FUNCTION::reJitId field. The <see cref="EnumJITedFunctions"/>
        /// method, which this method replaces, does not enumerate JIT-recompiled IDs, because the COR_PRF_FUNCTION::reJitId
        /// field is always set to 0. The ICorProfilerInfo4::EnumJITedFunctions method does enumerate JIT-recompiled IDs, because
        /// the COR_PRF_FUNCTION::reJitId field is set properly. Note that the <see cref="EnumJITedFunctions2"/> method can
        /// trigger a garbage collection, whereas <see cref="EnumJITedFunctions"/> will not. For more information,
        /// see CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT.
        /// </remarks>
        public CorProfilerFunctionEnum EnumJITedFunctions2()
        {
            CorProfilerFunctionEnum ppEnumResult;
            TryEnumJITedFunctions2(out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Returns an enumerator for all functions that were previously JIT-compiled and JIT-recompiled. This method replaces the <see cref="EnumJITedFunctions"/> method, which does not enumerate JIT-recompiled IDs.
        /// </summary>
        /// <param name="ppEnumResult">[out] A pointer to the <see cref="ICorProfilerFunctionEnum"/> enumerator.</param>
        /// <remarks>
        /// This method may overlap with JITCompilation callbacks such as the <see cref="ICorProfilerCallback.JITCompilationStarted"/>
        /// method. The returned enumeration includes values for the COR_PRF_FUNCTION::reJitId field. The <see cref="EnumJITedFunctions"/>
        /// method, which this method replaces, does not enumerate JIT-recompiled IDs, because the COR_PRF_FUNCTION::reJitId
        /// field is always set to 0. The ICorProfilerInfo4::EnumJITedFunctions method does enumerate JIT-recompiled IDs, because
        /// the COR_PRF_FUNCTION::reJitId field is set properly. Note that the <see cref="EnumJITedFunctions2"/> method can
        /// trigger a garbage collection, whereas <see cref="EnumJITedFunctions"/> will not. For more information,
        /// see CORPROF_E_UNSUPPORTED_CALL_SEQUENCE HRESULT.
        /// </remarks>
        public HRESULT TryEnumJITedFunctions2(out CorProfilerFunctionEnum ppEnumResult)
        {
            /*HRESULT EnumJITedFunctions2(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerFunctionEnum ppEnum);*/
            ICorProfilerFunctionEnum ppEnum;
            HRESULT hr = Raw4.EnumJITedFunctions2(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new CorProfilerFunctionEnum(ppEnum);
            else
                ppEnumResult = default(CorProfilerFunctionEnum);

            return hr;
        }

        #endregion
        #region GetObjectSize2

        /// <summary>
        /// Returns the size of a specified object. Replaces the <see cref="GetObjectSize"/> method by reporting sizes of objects that are larger than what can be expressed in a ULONG.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object.</param>
        /// <returns>[out] A pointer to the object's size, in bytes.</returns>
        /// <remarks>
        /// Different objects of the same types often have the same size. However, some types, such as arrays or strings, may
        /// have a different size for each object.
        /// </remarks>
        public IntPtr GetObjectSize2(ObjectID objectId)
        {
            IntPtr pcSize;
            TryGetObjectSize2(objectId, out pcSize).ThrowOnNotOK();

            return pcSize;
        }

        /// <summary>
        /// Returns the size of a specified object. Replaces the <see cref="GetObjectSize"/> method by reporting sizes of objects that are larger than what can be expressed in a ULONG.
        /// </summary>
        /// <param name="objectId">[in] The ID of the object.</param>
        /// <param name="pcSize">[out] A pointer to the object's size, in bytes.</param>
        /// <remarks>
        /// Different objects of the same types often have the same size. However, some types, such as arrays or strings, may
        /// have a different size for each object.
        /// </remarks>
        public HRESULT TryGetObjectSize2(ObjectID objectId, out IntPtr pcSize)
        {
            /*HRESULT GetObjectSize2(
            [In] ObjectID objectId,
            [Out] out IntPtr pcSize);*/
            return Raw4.GetObjectSize2(objectId, out pcSize);
        }

        #endregion
        #endregion
        #region ICorProfilerInfo5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo5 Raw5 => (ICorProfilerInfo5) Raw;

        #region EventMask2

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the current event categories for which the profiler wants to receive notifications from the common language runtime (CLR).<para/>
        /// It provides functionality not provided by the <see cref="EventMask"/> property.
        /// </summary>
        public GetEventMask2Result EventMask2
        {
            get
            {
                GetEventMask2Result result;
                TryGetEventMask2(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets the current event categories for which the profiler wants to receive notifications from the common language runtime (CLR).<para/>
        /// It provides functionality not provided by the <see cref="EventMask"/> property.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The GetEventMask2 method is used to determine which callbacks the profiler has subscribed to. Typically, you perform
        /// a logical OR of the pdwEventsLow and pdwEventsHigh values and any new bits you want to set, and then call the <see
        /// cref="SetEventMask2"/> method. This method is the recommended alternative to the <see cref="EventMask"/>
        /// property.
        /// </remarks>
        public HRESULT TryGetEventMask2(out GetEventMask2Result result)
        {
            /*HRESULT GetEventMask2(
            [Out] out COR_PRF_MONITOR pdwEventsLow,
            [Out] out COR_PRF_HIGH_MONITOR pdwEventsHigh);*/
            COR_PRF_MONITOR pdwEventsLow;
            COR_PRF_HIGH_MONITOR pdwEventsHigh;
            HRESULT hr = Raw5.GetEventMask2(out pdwEventsLow, out pdwEventsHigh);

            if (hr == HRESULT.S_OK)
                result = new GetEventMask2Result(pdwEventsLow, pdwEventsHigh);
            else
                result = default(GetEventMask2Result);

            return hr;
        }

        #endregion
        #region SetEventMask2

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Sets a value that specifies the types of events for which the profiler wants to receive event notifications from the common language runtime (CLR).<para/>
        /// It provides more functionality than the <see cref="EventMask"/> property.
        /// </summary>
        /// <param name="dwEventsLow">[in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.</param>
        /// <param name="dwEventsHigh">[in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_HIGH_MONITOR enumeration.</param>
        /// <remarks>
        /// The SetEventMask2 method is used to set the callbacks to which the profiler subscribes. Typically, you call the
        /// <see cref="EventMask2"/> property to determine which bits are set, perform a logical OR of its pdwEventsLow and
        /// pdwEventsHigh values and any new bits you want to set, and then call the SetEventMask2 method. This method is the
        /// recommended alternative to the <see cref="EventMask"/> property.
        /// </remarks>
        public void SetEventMask2(COR_PRF_MONITOR dwEventsLow, COR_PRF_HIGH_MONITOR dwEventsHigh)
        {
            TrySetEventMask2(dwEventsLow, dwEventsHigh).ThrowOnNotOK();
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Sets a value that specifies the types of events for which the profiler wants to receive event notifications from the common language runtime (CLR).<para/>
        /// It provides more functionality than the <see cref="EventMask"/> property.
        /// </summary>
        /// <param name="dwEventsLow">[in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.</param>
        /// <param name="dwEventsHigh">[in] A 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_HIGH_MONITOR enumeration.</param>
        /// <remarks>
        /// The SetEventMask2 method is used to set the callbacks to which the profiler subscribes. Typically, you call the
        /// <see cref="EventMask2"/> property to determine which bits are set, perform a logical OR of its pdwEventsLow and
        /// pdwEventsHigh values and any new bits you want to set, and then call the SetEventMask2 method. This method is the
        /// recommended alternative to the <see cref="EventMask"/> property.
        /// </remarks>
        public HRESULT TrySetEventMask2(COR_PRF_MONITOR dwEventsLow, COR_PRF_HIGH_MONITOR dwEventsHigh)
        {
            /*HRESULT SetEventMask2(
            [In] COR_PRF_MONITOR dwEventsLow,
            [In] COR_PRF_HIGH_MONITOR dwEventsHigh);*/
            return Raw5.SetEventMask2(dwEventsLow, dwEventsHigh);
        }

        #endregion
        #endregion
        #region ICorProfilerInfo6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo6 Raw6 => (ICorProfilerInfo6) Raw;

        #region EnumNgenModuleMethodsInliningThisMethod

        /// <summary>
        /// Returns an enumerator to all the methods that are defined in a given NGen module and inline a given method.
        /// </summary>
        /// <param name="inlinersModuleId">[in] The identifier of an NGen module.</param>
        /// <param name="inlineeModuleId">[in] The identifier of a module that defines inlineeMethodId. See the Remarks section for more information.</param>
        /// <param name="inlineeMethodId">[in] The identifier of an inlined method. See the Remarks section for more information.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// inlineeModuleId and inlineeMethodId together form the full identifier for the method that might be inlined. For
        /// example, assume module A defines a method Simple.Add: and module B defines Fancy.AddTwice: Lets also assume that
        /// Fancy.AddTwice inlines the call to SimpleAdd. A profiler could use this enumerator to find all methods defined
        /// in module B which inline Simple.Add, and the result would enumerate AddTwice. inlineeModuleId is the identifier
        /// of module A, and inlineeMethodId is the identifier of Simple.Add(int a, int b). If incompleteData is true after
        /// the function returns, the enumerator does not contain all methods inlining a given method. This can happen when
        /// one or more direct or indirect dependencies of inliners module haven't been loaded yet. If a profiler needs accurate
        /// data, it should retry later when more modules are loaded, preferably on each module load. The EnumNgenModuleMethodsInliningThisMethod
        /// method can be used to work around limitations on inlining for ReJIT. ReJIT lets a profiler change the implementation
        /// of a method and then create new code for it on the fly. For example, we could change Simple.Add as follows: However
        /// because Fancy.AddTwice has already inlined Simple.Add, it continues to have the same behavior as before. To work
        /// around that limitation, the caller has to search for all methods in all modules that inline Simple.Add and use
        /// ICorProfilerInfo5::RequestRejit on each of those methods. When the methods are re-compiled, they will have the
        /// new behavior of Simple.Add instead of the old behavior.
        /// </remarks>
        public EnumNgenModuleMethodsInliningThisMethodResult EnumNgenModuleMethodsInliningThisMethod(ModuleID inlinersModuleId, ModuleID inlineeModuleId, mdMethodDef inlineeMethodId)
        {
            EnumNgenModuleMethodsInliningThisMethodResult result;
            TryEnumNgenModuleMethodsInliningThisMethod(inlinersModuleId, inlineeModuleId, inlineeMethodId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Returns an enumerator to all the methods that are defined in a given NGen module and inline a given method.
        /// </summary>
        /// <param name="inlinersModuleId">[in] The identifier of an NGen module.</param>
        /// <param name="inlineeModuleId">[in] The identifier of a module that defines inlineeMethodId. See the Remarks section for more information.</param>
        /// <param name="inlineeMethodId">[in] The identifier of an inlined method. See the Remarks section for more information.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// inlineeModuleId and inlineeMethodId together form the full identifier for the method that might be inlined. For
        /// example, assume module A defines a method Simple.Add: and module B defines Fancy.AddTwice: Lets also assume that
        /// Fancy.AddTwice inlines the call to SimpleAdd. A profiler could use this enumerator to find all methods defined
        /// in module B which inline Simple.Add, and the result would enumerate AddTwice. inlineeModuleId is the identifier
        /// of module A, and inlineeMethodId is the identifier of Simple.Add(int a, int b). If incompleteData is true after
        /// the function returns, the enumerator does not contain all methods inlining a given method. This can happen when
        /// one or more direct or indirect dependencies of inliners module haven't been loaded yet. If a profiler needs accurate
        /// data, it should retry later when more modules are loaded, preferably on each module load. The EnumNgenModuleMethodsInliningThisMethod
        /// method can be used to work around limitations on inlining for ReJIT. ReJIT lets a profiler change the implementation
        /// of a method and then create new code for it on the fly. For example, we could change Simple.Add as follows: However
        /// because Fancy.AddTwice has already inlined Simple.Add, it continues to have the same behavior as before. To work
        /// around that limitation, the caller has to search for all methods in all modules that inline Simple.Add and use
        /// ICorProfilerInfo5::RequestRejit on each of those methods. When the methods are re-compiled, they will have the
        /// new behavior of Simple.Add instead of the old behavior.
        /// </remarks>
        public HRESULT TryEnumNgenModuleMethodsInliningThisMethod(ModuleID inlinersModuleId, ModuleID inlineeModuleId, mdMethodDef inlineeMethodId, out EnumNgenModuleMethodsInliningThisMethodResult result)
        {
            /*HRESULT EnumNgenModuleMethodsInliningThisMethod(
            [In] ModuleID inlinersModuleId,
            [In] ModuleID inlineeModuleId,
            [In] mdMethodDef inlineeMethodId,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool incompleteData,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerMethodEnum ppEnum);*/
            bool incompleteData;
            ICorProfilerMethodEnum ppEnum;
            HRESULT hr = Raw6.EnumNgenModuleMethodsInliningThisMethod(inlinersModuleId, inlineeModuleId, inlineeMethodId, out incompleteData, out ppEnum);

            if (hr == HRESULT.S_OK)
                result = new EnumNgenModuleMethodsInliningThisMethodResult(incompleteData, ppEnum == null ? null : new CorProfilerMethodEnum(ppEnum));
            else
                result = default(EnumNgenModuleMethodsInliningThisMethodResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorProfilerInfo7

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo7 Raw7 => (ICorProfilerInfo7) Raw;

        #region ApplyMetaData

        /// <summary>
        /// [Supported in the .NET Framework 4.6.1 and later versions] Applies the metadata newly defined by the IMetadataEmit::Define* methods to a specified module.
        /// </summary>
        /// <param name="moduleId">[in] The identifier of the module whose metadata was changed.</param>
        /// <remarks>
        /// If metadata changes are made after the <see cref="ICorProfilerCallback.ModuleLoadFinished"/> callback, you must
        /// call this method before using the new metadata. ApplyMetaData only supports adding the following types of metadata:
        /// Starting with .NET Core 3.0, ApplyMetaData also supports the following types:
        /// </remarks>
        public void ApplyMetaData(ModuleID moduleId)
        {
            TryApplyMetaData(moduleId).ThrowOnNotOK();
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.6.1 and later versions] Applies the metadata newly defined by the IMetadataEmit::Define* methods to a specified module.
        /// </summary>
        /// <param name="moduleId">[in] The identifier of the module whose metadata was changed.</param>
        /// <remarks>
        /// If metadata changes are made after the <see cref="ICorProfilerCallback.ModuleLoadFinished"/> callback, you must
        /// call this method before using the new metadata. ApplyMetaData only supports adding the following types of metadata:
        /// Starting with .NET Core 3.0, ApplyMetaData also supports the following types:
        /// </remarks>
        public HRESULT TryApplyMetaData(ModuleID moduleId)
        {
            /*HRESULT ApplyMetaData(
            [In] ModuleID moduleId);*/
            return Raw7.ApplyMetaData(moduleId);
        }

        #endregion
        #region GetInMemorySymbolsLength

        /// <summary>
        /// [Supported in the .NET Framework 4.6.1 and later versions] Returns the length of an in-memory symbol stream.
        /// </summary>
        /// <param name="moduleId">[in] The identifier of the module containing the in-memory stream.</param>
        /// <returns>[out] A pointer to a DWORD value that, when the method returns, contains the length of the stream in bytes.</returns>
        /// <remarks>
        /// If the module has in-memory symbols, the length of the stream is placed in pCountSymbolBytes. If the module doesn't
        /// have in-memory symbols, *pCountSymbolBytes = 0.
        /// </remarks>
        public int GetInMemorySymbolsLength(ModuleID moduleId)
        {
            int pCountSymbolBytes;
            TryGetInMemorySymbolsLength(moduleId, out pCountSymbolBytes).ThrowOnNotOK();

            return pCountSymbolBytes;
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.6.1 and later versions] Returns the length of an in-memory symbol stream.
        /// </summary>
        /// <param name="moduleId">[in] The identifier of the module containing the in-memory stream.</param>
        /// <param name="pCountSymbolBytes">[out] A pointer to a DWORD value that, when the method returns, contains the length of the stream in bytes.</param>
        /// <returns>The method returns S_OK if the length of the memory stream can be determined, even if it is zero (0). The method returns CORPROF_E_MODULE_IS_DYNAMIC if the method was created using <see cref="System.Reflection.Emit"/>.</returns>
        /// <remarks>
        /// If the module has in-memory symbols, the length of the stream is placed in pCountSymbolBytes. If the module doesn't
        /// have in-memory symbols, *pCountSymbolBytes = 0.
        /// </remarks>
        public HRESULT TryGetInMemorySymbolsLength(ModuleID moduleId, out int pCountSymbolBytes)
        {
            /*HRESULT GetInMemorySymbolsLength(
            [In] ModuleID moduleId,
            [Out] out int pCountSymbolBytes);*/
            return Raw7.GetInMemorySymbolsLength(moduleId, out pCountSymbolBytes);
        }

        #endregion
        #region ReadInMemorySymbols

        public int ReadInMemorySymbols(ModuleID moduleId, int symbolsReadOffset, IntPtr pSymbolBytes, int countSymbolBytes)
        {
            int pCountSymbolBytesRead;
            TryReadInMemorySymbols(moduleId, symbolsReadOffset, pSymbolBytes, countSymbolBytes, out pCountSymbolBytesRead).ThrowOnNotOK();

            return pCountSymbolBytesRead;
        }

        public HRESULT TryReadInMemorySymbols(ModuleID moduleId, int symbolsReadOffset, IntPtr pSymbolBytes, int countSymbolBytes, out int pCountSymbolBytesRead)
        {
            /*HRESULT ReadInMemorySymbols(
            [In] ModuleID moduleId,
            [In] int symbolsReadOffset,
            [Out] IntPtr pSymbolBytes,
            [In] int countSymbolBytes,
            [Out] out int pCountSymbolBytesRead);*/
            return Raw7.ReadInMemorySymbols(moduleId, symbolsReadOffset, pSymbolBytes, countSymbolBytes, out pCountSymbolBytesRead);
        }

        #endregion
        #endregion
        #region ICorProfilerInfo8

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo8 Raw8 => (ICorProfilerInfo8) Raw;

        #region IsFunctionDynamic

        /// <summary>
        /// Determines if a function does not have associated metadata.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID that identifies the function in question.</param>
        /// <returns>[out] A pointer to a BOOL that will contain a value indicating if the function has no metadata.</returns>
        /// <remarks>
        /// A function is considered dynamic if it has no metadata. Certain methods like IL Stubs or LCG Methods do not have
        /// associated metadata that can be retrieved using the IMetaDataImport APIs. These methods can be encountered by profilers
        /// through instruction pointers or by listening to <see cref="ICorProfilerCallback8.DynamicMethodJITCompilationStarted"/>.
        /// </remarks>
        public bool IsFunctionDynamic(FunctionID functionId)
        {
            bool isDynamic;
            TryIsFunctionDynamic(functionId, out isDynamic).ThrowOnNotOK();

            return isDynamic;
        }

        /// <summary>
        /// Determines if a function does not have associated metadata.
        /// </summary>
        /// <param name="functionId">[in] The FunctionID that identifies the function in question.</param>
        /// <param name="isDynamic">[out] A pointer to a BOOL that will contain a value indicating if the function has no metadata.</param>
        /// <remarks>
        /// A function is considered dynamic if it has no metadata. Certain methods like IL Stubs or LCG Methods do not have
        /// associated metadata that can be retrieved using the IMetaDataImport APIs. These methods can be encountered by profilers
        /// through instruction pointers or by listening to <see cref="ICorProfilerCallback8.DynamicMethodJITCompilationStarted"/>.
        /// </remarks>
        public HRESULT TryIsFunctionDynamic(FunctionID functionId, out bool isDynamic)
        {
            /*HRESULT IsFunctionDynamic(
            [In] FunctionID functionId,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isDynamic);*/
            return Raw8.IsFunctionDynamic(functionId, out isDynamic);
        }

        #endregion
        #region GetFunctionFromIP3

        /// <summary>
        /// Maps a managed code instruction pointer to a FunctionID. This method works for both dynamic and non-dynamic methods.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method works for both dynamic and non-dynamic methods. It is a superset of <see cref="GetFunctionFromIP2"/>,
        /// which only works for functions with metadata.
        /// </remarks>
        public GetFunctionFromIP3Result GetFunctionFromIP3(IntPtr ip)
        {
            GetFunctionFromIP3Result result;
            TryGetFunctionFromIP3(ip, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Maps a managed code instruction pointer to a FunctionID. This method works for both dynamic and non-dynamic methods.
        /// </summary>
        /// <param name="ip">[in] The instruction pointer in managed code.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// This method works for both dynamic and non-dynamic methods. It is a superset of <see cref="GetFunctionFromIP2"/>,
        /// which only works for functions with metadata.
        /// </remarks>
        public HRESULT TryGetFunctionFromIP3(IntPtr ip, out GetFunctionFromIP3Result result)
        {
            /*HRESULT GetFunctionFromIP3(
            [In] IntPtr ip,
            [Out] out FunctionID functionId,
            [Out] out ReJITID pReJitId);*/
            FunctionID functionId;
            ReJITID pReJitId;
            HRESULT hr = Raw8.GetFunctionFromIP3(ip, out functionId, out pReJitId);

            if (hr == HRESULT.S_OK)
                result = new GetFunctionFromIP3Result(functionId, pReJitId);
            else
                result = default(GetFunctionFromIP3Result);

            return hr;
        }

        #endregion
        #region GetDynamicFunctionInfo

        /// <summary>
        /// Retrieves information about dynamic methods.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to retrieve information.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Certain methods like IL Stubs or LCG do not have associated metadata that can be retrieved using the IMetaDataImport
        /// and IMetaDataImport2 APIs. Such methods can be encountered by profilers through instruction pointers or by listening
        /// to <see cref="ICorProfilerCallback8.DynamicMethodJITCompilationStarted"/>. This API can be used to retrieve information
        /// about dynamic methods, including a friendly name, if available.
        /// </remarks>
        public GetDynamicFunctionInfoResult GetDynamicFunctionInfo(FunctionID functionId)
        {
            GetDynamicFunctionInfoResult result;
            TryGetDynamicFunctionInfo(functionId, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves information about dynamic methods.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function for which to retrieve information.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// Certain methods like IL Stubs or LCG do not have associated metadata that can be retrieved using the IMetaDataImport
        /// and IMetaDataImport2 APIs. Such methods can be encountered by profilers through instruction pointers or by listening
        /// to <see cref="ICorProfilerCallback8.DynamicMethodJITCompilationStarted"/>. This API can be used to retrieve information
        /// about dynamic methods, including a friendly name, if available.
        /// </remarks>
        public HRESULT TryGetDynamicFunctionInfo(FunctionID functionId, out GetDynamicFunctionInfoResult result)
        {
            /*HRESULT GetDynamicFunctionInfo(
            [In] FunctionID functionId,
            [Out] out ModuleID moduleId,
            [Out] out IntPtr ppvSig,
            [Out] out int pbSig,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] wszName);*/
            ModuleID moduleId;
            IntPtr ppvSig;
            int pbSig;
            int cchName = 0;
            int pcchName;
            char[] wszName;
            HRESULT hr = Raw8.GetDynamicFunctionInfo(functionId, out moduleId, out ppvSig, out pbSig, cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            wszName = new char[cchName];
            hr = Raw8.GetDynamicFunctionInfo(functionId, out moduleId, out ppvSig, out pbSig, cchName, out pcchName, wszName);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDynamicFunctionInfoResult(moduleId, ppvSig, pbSig, CreateString(wszName, pcchName));

                return hr;
            }

            fail:
            result = default(GetDynamicFunctionInfoResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorProfilerInfo9

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo9 Raw9 => (ICorProfilerInfo9) Raw;

        #region GetNativeCodeStartAddresses

        /// <summary>
        /// Given a functionId and rejitId, enumerates the native code start address of all jitted versions of this code that currently exist.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function whose native code start addresses should be returned.</param>
        /// <param name="reJitId">[in] The identity of the JIT-recompiled function.</param>
        /// <returns>[out] An array of UINT_PTR, each one of which is the start address for a native body for the specified function.</returns>
        /// <remarks>
        /// When tiered compilation is enabled, a function may have more than one native code body.
        /// </remarks>
        public IntPtr[] GetNativeCodeStartAddresses(FunctionID functionId, ReJITID reJitId)
        {
            IntPtr[] codeStartAddresses;
            TryGetNativeCodeStartAddresses(functionId, reJitId, out codeStartAddresses).ThrowOnNotOK();

            return codeStartAddresses;
        }

        /// <summary>
        /// Given a functionId and rejitId, enumerates the native code start address of all jitted versions of this code that currently exist.
        /// </summary>
        /// <param name="functionId">[in] The ID of the function whose native code start addresses should be returned.</param>
        /// <param name="reJitId">[in] The identity of the JIT-recompiled function.</param>
        /// <param name="codeStartAddresses">[out] An array of UINT_PTR, each one of which is the start address for a native body for the specified function.</param>
        /// <remarks>
        /// When tiered compilation is enabled, a function may have more than one native code body.
        /// </remarks>
        public HRESULT TryGetNativeCodeStartAddresses(FunctionID functionId, ReJITID reJitId, out IntPtr[] codeStartAddresses)
        {
            /*HRESULT GetNativeCodeStartAddresses(
            [In] FunctionID functionId,
            [In] ReJITID reJitId,
            [In] int cCodeStartAddresses,
            [Out] out int pcCodeStartAddresses,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] codeStartAddresses);*/
            int cCodeStartAddresses = 0;
            int pcCodeStartAddresses;
            codeStartAddresses = null;
            HRESULT hr = Raw9.GetNativeCodeStartAddresses(functionId, reJitId, cCodeStartAddresses, out pcCodeStartAddresses, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cCodeStartAddresses = pcCodeStartAddresses;
            codeStartAddresses = new IntPtr[cCodeStartAddresses];
            hr = Raw9.GetNativeCodeStartAddresses(functionId, reJitId, cCodeStartAddresses, out pcCodeStartAddresses, codeStartAddresses);
            fail:
            return hr;
        }

        #endregion
        #region GetILToNativeMapping3

        /// <summary>
        /// Given the native code start address, returns the native to IL mapping information for this jitted version of the code.
        /// </summary>
        /// <param name="pNativeCodeStartAddress">[in] A pointer to the start of a native function.</param>
        /// <param name="cMap">[in] The maximum size of the map array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// When tiered compilation is enabled, a method may have more than one native code body. <see cref="GetNativeCodeStartAddresses"/>
        /// will return the start addresses for all of the native code bodies.
        /// </remarks>
        public GetILToNativeMapping3Result GetILToNativeMapping3(IntPtr pNativeCodeStartAddress, int cMap)
        {
            GetILToNativeMapping3Result result;
            TryGetILToNativeMapping3(pNativeCodeStartAddress, cMap, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Given the native code start address, returns the native to IL mapping information for this jitted version of the code.
        /// </summary>
        /// <param name="pNativeCodeStartAddress">[in] A pointer to the start of a native function.</param>
        /// <param name="cMap">[in] The maximum size of the map array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// When tiered compilation is enabled, a method may have more than one native code body. <see cref="GetNativeCodeStartAddresses"/>
        /// will return the start addresses for all of the native code bodies.
        /// </remarks>
        public HRESULT TryGetILToNativeMapping3(IntPtr pNativeCodeStartAddress, int cMap, out GetILToNativeMapping3Result result)
        {
            /*HRESULT GetILToNativeMapping3(
            [In] IntPtr pNativeCodeStartAddress,
            [In] int cMap,
            [Out] out int pcMap,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] COR_DEBUG_IL_TO_NATIVE_MAP[] map);*/
            int pcMap;
            COR_DEBUG_IL_TO_NATIVE_MAP[] map = new COR_DEBUG_IL_TO_NATIVE_MAP[cMap];
            HRESULT hr = Raw9.GetILToNativeMapping3(pNativeCodeStartAddress, cMap, out pcMap, map);

            if (hr == HRESULT.S_OK)
                result = new GetILToNativeMapping3Result(pcMap, map);
            else
                result = default(GetILToNativeMapping3Result);

            return hr;
        }

        #endregion
        #region GetCodeInfo4

        /// <summary>
        /// Given the native code start address, returns the blocks of virtual memory that store this code.
        /// </summary>
        /// <param name="pNativeCodeStartAddress">[in] A pointer to the start of a native function.</param>
        /// <param name="cCodeInfos">[in] The size of the codeInfos array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The GetCodeInfo4 method is similar to <see cref="GetCodeInfo3"/>, except that it can look up
        /// code information for different native versions of a method. The extents are sorted in order of increasing Common
        /// Intermediate Language (CIL) offset. After GetCodeInfo4 returns, you must verify that the codeInfos buffer was large
        /// enough to contain all the <see cref="COR_PRF_CODE_INFO"/> structures. To do this, compare the value of cCodeInfos
        /// with the value of the cchName parameter. If cCodeInfos divided by the size of a <see cref="COR_PRF_CODE_INFO"/>
        /// structure is smaller than pcCodeInfos, allocate a larger codeInfos buffer, update cCodeInfos with the new, larger
        /// size, and call GetCodeInfo4 again. Alternatively, you can first call GetCodeInfo4 with a zero-length codeInfos
        /// buffer to obtain the correct buffer size. You can then set the codeInfos buffer size to the value returned in pcCodeInfos,
        /// multiplied by the size of a <see cref="COR_PRF_CODE_INFO"/> structure, and call GetCodeInfo4 again.
        /// </remarks>
        public GetCodeInfo4Result GetCodeInfo4(IntPtr pNativeCodeStartAddress, int cCodeInfos)
        {
            GetCodeInfo4Result result;
            TryGetCodeInfo4(pNativeCodeStartAddress, cCodeInfos, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Given the native code start address, returns the blocks of virtual memory that store this code.
        /// </summary>
        /// <param name="pNativeCodeStartAddress">[in] A pointer to the start of a native function.</param>
        /// <param name="cCodeInfos">[in] The size of the codeInfos array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The GetCodeInfo4 method is similar to <see cref="GetCodeInfo3"/>, except that it can look up
        /// code information for different native versions of a method. The extents are sorted in order of increasing Common
        /// Intermediate Language (CIL) offset. After GetCodeInfo4 returns, you must verify that the codeInfos buffer was large
        /// enough to contain all the <see cref="COR_PRF_CODE_INFO"/> structures. To do this, compare the value of cCodeInfos
        /// with the value of the cchName parameter. If cCodeInfos divided by the size of a <see cref="COR_PRF_CODE_INFO"/>
        /// structure is smaller than pcCodeInfos, allocate a larger codeInfos buffer, update cCodeInfos with the new, larger
        /// size, and call GetCodeInfo4 again. Alternatively, you can first call GetCodeInfo4 with a zero-length codeInfos
        /// buffer to obtain the correct buffer size. You can then set the codeInfos buffer size to the value returned in pcCodeInfos,
        /// multiplied by the size of a <see cref="COR_PRF_CODE_INFO"/> structure, and call GetCodeInfo4 again.
        /// </remarks>
        public HRESULT TryGetCodeInfo4(IntPtr pNativeCodeStartAddress, int cCodeInfos, out GetCodeInfo4Result result)
        {
            /*HRESULT GetCodeInfo4(
            [In] IntPtr pNativeCodeStartAddress,
            [In] int cCodeInfos,
            [Out] out int pcCodeInfos,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] COR_PRF_CODE_INFO[] codeInfos);*/
            int pcCodeInfos;
            COR_PRF_CODE_INFO[] codeInfos = new COR_PRF_CODE_INFO[cCodeInfos];
            HRESULT hr = Raw9.GetCodeInfo4(pNativeCodeStartAddress, cCodeInfos, out pcCodeInfos, codeInfos);

            if (hr == HRESULT.S_OK)
                result = new GetCodeInfo4Result(pcCodeInfos, codeInfos);
            else
                result = default(GetCodeInfo4Result);

            return hr;
        }

        #endregion
        #endregion
        #region ICorProfilerInfo10

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo10 Raw10 => (ICorProfilerInfo10) Raw;

        #region LOHObjectSizeThreshold

        /// <summary>
        /// Gets the value of the configured large object heap (LOH) threshold.
        /// </summary>
        public int LOHObjectSizeThreshold
        {
            get
            {
                int pThreshold;
                TryGetLOHObjectSizeThreshold(out pThreshold).ThrowOnNotOK();

                return pThreshold;
            }
        }

        /// <summary>
        /// Gets the value of the configured large object heap (LOH) threshold.
        /// </summary>
        /// <param name="pThreshold">[out] The large object heap threshold in bytes.</param>
        /// <remarks>
        /// Objects larger than the large object heap threshold will be allocated on the large object heap. Starting with .NET
        /// Core 3.0 the large object heap threshold is configurable, pThreshold will contain the active large object heap
        /// threshold size in bytes.
        /// </remarks>
        public HRESULT TryGetLOHObjectSizeThreshold(out int pThreshold)
        {
            /*HRESULT GetLOHObjectSizeThreshold(
            [Out] out int pThreshold);*/
            return Raw10.GetLOHObjectSizeThreshold(out pThreshold);
        }

        #endregion
        #region EnumerateObjectReferences

        /// <summary>
        /// Given an ObjectID, callback and clientData, enumerates each object reference (if any).
        /// </summary>
        /// <param name="objectId">[in] The object to enumerate references on.</param>
        /// <param name="callback">[in] The function that will be called with the references for the object.</param>
        /// <param name="clientData">[in] Profiler-provided data to pass to the callback function.</param>
        /// <remarks>
        /// The EnumerateObjectReferences method is similar to <see cref="ICorProfilerCallback.ObjectReferences"/>, except
        /// that it walks the references on demand for the profiler instead of pre-allocating an array to store the references.
        /// </remarks>
        public void EnumerateObjectReferences(ObjectID objectId, ObjectReferenceCallback callback, IntPtr clientData)
        {
            TryEnumerateObjectReferences(objectId, callback, clientData).ThrowOnNotOK();
        }

        /// <summary>
        /// Given an ObjectID, callback and clientData, enumerates each object reference (if any).
        /// </summary>
        /// <param name="objectId">[in] The object to enumerate references on.</param>
        /// <param name="callback">[in] The function that will be called with the references for the object.</param>
        /// <param name="clientData">[in] Profiler-provided data to pass to the callback function.</param>
        /// <remarks>
        /// The EnumerateObjectReferences method is similar to <see cref="ICorProfilerCallback.ObjectReferences"/>, except
        /// that it walks the references on demand for the profiler instead of pre-allocating an array to store the references.
        /// </remarks>
        public HRESULT TryEnumerateObjectReferences(ObjectID objectId, ObjectReferenceCallback callback, IntPtr clientData)
        {
            /*HRESULT EnumerateObjectReferences(
            [In] ObjectID objectId,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] ObjectReferenceCallback callback,
            [In] IntPtr clientData);*/
            return Raw10.EnumerateObjectReferences(objectId, callback, clientData);
        }

        #endregion
        #region IsFrozenObject

        /// <summary>
        /// Given an ObjectID, determines whether the object is in a read-only segment.
        /// </summary>
        /// <param name="objectId">[in] The object to examine.</param>
        /// <returns>[out] A BOOL indicating if the object is in a read-only segment.</returns>
        public bool IsFrozenObject(ObjectID objectId)
        {
            bool pbFrozen;
            TryIsFrozenObject(objectId, out pbFrozen).ThrowOnNotOK();

            return pbFrozen;
        }

        /// <summary>
        /// Given an ObjectID, determines whether the object is in a read-only segment.
        /// </summary>
        /// <param name="objectId">[in] The object to examine.</param>
        /// <param name="pbFrozen">[out] A BOOL indicating if the object is in a read-only segment.</param>
        public HRESULT TryIsFrozenObject(ObjectID objectId, out bool pbFrozen)
        {
            /*HRESULT IsFrozenObject(
            [In] ObjectID objectId,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbFrozen);*/
            return Raw10.IsFrozenObject(objectId, out pbFrozen);
        }

        #endregion
        #region RequestReJITWithInliners

        /// <summary>
        /// ReJITs the methods requested, as well as any inliners of the methods requested.
        /// </summary>
        /// <param name="dwRejitFlags">[in] A bitmask of COR_PRF_REJIT_FLAGS.</param>
        /// <param name="cFunctions">[in] The number of functions to recompile.</param>
        /// <param name="moduleIds">[in] Specifies the moduleId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <param name="methodIds">[in] Specifies the methodId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <remarks>
        /// <see cref="RequestReJIT"/> does not do any tracking of inlined methods. The profiler was expected
        /// to either block inlining or track inlining and call RequestReJIT for all inliners to make sure every instance of
        /// an inlined method was ReJITted. This poses a problem with ReJIT on attach, since the profiler is not present to
        /// monitor inlining. This method can be called to guarantee that the full set of inliners will be ReJITted as well.
        /// </remarks>
        public void RequestReJITWithInliners(COR_PRF_REJIT_FLAGS dwRejitFlags, int cFunctions, ModuleID[] moduleIds, mdMethodDef[] methodIds)
        {
            TryRequestReJITWithInliners(dwRejitFlags, cFunctions, moduleIds, methodIds).ThrowOnNotOK();
        }

        /// <summary>
        /// ReJITs the methods requested, as well as any inliners of the methods requested.
        /// </summary>
        /// <param name="dwRejitFlags">[in] A bitmask of COR_PRF_REJIT_FLAGS.</param>
        /// <param name="cFunctions">[in] The number of functions to recompile.</param>
        /// <param name="moduleIds">[in] Specifies the moduleId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <param name="methodIds">[in] Specifies the methodId portion of the (module, methodDef) pairs that identify the functions to be recompiled.</param>
        /// <remarks>
        /// <see cref="RequestReJIT"/> does not do any tracking of inlined methods. The profiler was expected
        /// to either block inlining or track inlining and call RequestReJIT for all inliners to make sure every instance of
        /// an inlined method was ReJITted. This poses a problem with ReJIT on attach, since the profiler is not present to
        /// monitor inlining. This method can be called to guarantee that the full set of inliners will be ReJITted as well.
        /// </remarks>
        public HRESULT TryRequestReJITWithInliners(COR_PRF_REJIT_FLAGS dwRejitFlags, int cFunctions, ModuleID[] moduleIds, mdMethodDef[] methodIds)
        {
            /*HRESULT RequestReJITWithInliners(
            [In] COR_PRF_REJIT_FLAGS dwRejitFlags,
            [In] int cFunctions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ModuleID[] moduleIds,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] mdMethodDef[] methodIds);*/
            return Raw10.RequestReJITWithInliners(dwRejitFlags, cFunctions, moduleIds, methodIds);
        }

        #endregion
        #region SuspendRuntime

        /// <summary>
        /// Suspends the runtime without performing a GC.
        /// </summary>
        public void SuspendRuntime()
        {
            TrySuspendRuntime().ThrowOnNotOK();
        }

        /// <summary>
        /// Suspends the runtime without performing a GC.
        /// </summary>
        public HRESULT TrySuspendRuntime()
        {
            /*HRESULT SuspendRuntime();*/
            return Raw10.SuspendRuntime();
        }

        #endregion
        #region ResumeRuntime

        /// <summary>
        /// Resumes the runtime without performing a GC.
        /// </summary>
        public void ResumeRuntime()
        {
            TryResumeRuntime().ThrowOnNotOK();
        }

        /// <summary>
        /// Resumes the runtime without performing a GC.
        /// </summary>
        public HRESULT TryResumeRuntime()
        {
            /*HRESULT ResumeRuntime();*/
            return Raw10.ResumeRuntime();
        }

        #endregion
        #endregion
        #region ICorProfilerInfo11

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo11 Raw11 => (ICorProfilerInfo11) Raw;

        #region GetEnvironmentVariable

        /// <summary>
        /// Gets an environment variable from the process. On non-Windows platforms the runtime keeps an internal cache of environment variables to ensure thread safety.<para/>
        /// This means that calling getenv will not read any new or updated environment variables set by managed code running in the process after startup.
        /// </summary>
        /// <param name="szName">[in] A pointer to a null terminated wide character string containing the name of the environment variable to get.</param>
        /// <returns>[out] A caller provided wide character buffer. When the function returns the buffer will contain the value of the environment variable.</returns>
        public string GetEnvironmentVariable(string szName)
        {
            string szValueResult;
            TryGetEnvironmentVariable(szName, out szValueResult).ThrowOnNotOK();

            return szValueResult;
        }

        /// <summary>
        /// Gets an environment variable from the process. On non-Windows platforms the runtime keeps an internal cache of environment variables to ensure thread safety.<para/>
        /// This means that calling getenv will not read any new or updated environment variables set by managed code running in the process after startup.
        /// </summary>
        /// <param name="szName">[in] A pointer to a null terminated wide character string containing the name of the environment variable to get.</param>
        /// <param name="szValueResult">[out] A caller provided wide character buffer. When the function returns the buffer will contain the value of the environment variable.</param>
        public HRESULT TryGetEnvironmentVariable(string szName, out string szValueResult)
        {
            /*HRESULT GetEnvironmentVariable(
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] int cchValue,
            [Out] out int pcchValue,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] szValue);*/
            int cchValue = 0;
            int pcchValue;
            char[] szValue;
            HRESULT hr = Raw11.GetEnvironmentVariable(szName, cchValue, out pcchValue, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchValue = pcchValue;
            szValue = new char[cchValue];
            hr = Raw11.GetEnvironmentVariable(szName, cchValue, out pcchValue, szValue);

            if (hr == HRESULT.S_OK)
            {
                szValueResult = CreateString(szValue, pcchValue);

                return hr;
            }

            fail:
            szValueResult = default(string);

            return hr;
        }

        #endregion
        #region SetEnvironmentVariable

        /// <summary>
        /// Sets an environment variable in the process. On non-Windows platforms the runtime keeps an internal cache of environment variables to ensure thread safety.<para/>
        /// This means that if the profiler calls setenv the new environment variable will not be picked up by managed code running in the process.
        /// </summary>
        /// <param name="szName">[in] A pointer to a null terminated wide character string containing the name of the environment variable to set.</param>
        /// <param name="szValue">[in] A pointer to a null terminated wide character string containing the value of the environment variable to set.</param>
        public void SetEnvironmentVariable(string szName, string szValue)
        {
            TrySetEnvironmentVariable(szName, szValue).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets an environment variable in the process. On non-Windows platforms the runtime keeps an internal cache of environment variables to ensure thread safety.<para/>
        /// This means that if the profiler calls setenv the new environment variable will not be picked up by managed code running in the process.
        /// </summary>
        /// <param name="szName">[in] A pointer to a null terminated wide character string containing the name of the environment variable to set.</param>
        /// <param name="szValue">[in] A pointer to a null terminated wide character string containing the value of the environment variable to set.</param>
        public HRESULT TrySetEnvironmentVariable(string szName, string szValue)
        {
            /*HRESULT SetEnvironmentVariable(
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [MarshalAs(UnmanagedType.LPWStr), In] string szValue);*/
            return Raw11.SetEnvironmentVariable(szName, szValue);
        }

        #endregion
        #endregion
        #region ICorProfilerInfo12

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorProfilerInfo12 Raw12 => (ICorProfilerInfo12) Raw;

        #region EventPipeStartSession

        /// <summary>
        /// Starts an EventPipe session. The session can be used by the profiler to write events which can be listened to by any EventPipe consumer.
        /// </summary>
        /// <param name="cProviderConfigs">[in] The number of providers in pProviderConfigs.</param>
        /// <param name="pProviderConfigs">[in] An array of COR_PRF_EVENTPIPE_PROVIDER_CONFIG used to specify what providers should be enabled for the session.</param>
        /// <param name="requestRundown">[in] A BOOL indicating whether to emit rundown events when the session is closed.</param>
        /// <returns>[out] A caller provided pointer that will be filled with the session ID when the method returns.</returns>
        public EVENTPIPE_SESSION EventPipeStartSession(int cProviderConfigs, COR_PRF_EVENTPIPE_PROVIDER_CONFIG[] pProviderConfigs, bool requestRundown)
        {
            EVENTPIPE_SESSION pSession;
            TryEventPipeStartSession(cProviderConfigs, pProviderConfigs, requestRundown, out pSession).ThrowOnNotOK();

            return pSession;
        }

        /// <summary>
        /// Starts an EventPipe session. The session can be used by the profiler to write events which can be listened to by any EventPipe consumer.
        /// </summary>
        /// <param name="cProviderConfigs">[in] The number of providers in pProviderConfigs.</param>
        /// <param name="pProviderConfigs">[in] An array of COR_PRF_EVENTPIPE_PROVIDER_CONFIG used to specify what providers should be enabled for the session.</param>
        /// <param name="requestRundown">[in] A BOOL indicating whether to emit rundown events when the session is closed.</param>
        /// <param name="pSession">[out] A caller provided pointer that will be filled with the session ID when the method returns.</param>
        public HRESULT TryEventPipeStartSession(int cProviderConfigs, COR_PRF_EVENTPIPE_PROVIDER_CONFIG[] pProviderConfigs, bool requestRundown, out EVENTPIPE_SESSION pSession)
        {
            /*HRESULT EventPipeStartSession(
            [In] int cProviderConfigs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COR_PRF_EVENTPIPE_PROVIDER_CONFIG[] pProviderConfigs,
            [In, MarshalAs(UnmanagedType.Bool)] bool requestRundown,
            [Out] out EVENTPIPE_SESSION pSession);*/
            return Raw12.EventPipeStartSession(cProviderConfigs, pProviderConfigs, requestRundown, out pSession);
        }

        #endregion
        #region EventPipeAddProviderToSession

        /// <summary>
        /// Adds a provider to an existing EventPipe session.
        /// </summary>
        /// <param name="session">[in] The ID of the session to add the provider to.</param>
        /// <param name="providerConfig">[in] A COR_PRF_EVENTPIPE_PROVIDER_CONFIG describing the provider to add to the session.</param>
        public void EventPipeAddProviderToSession(EVENTPIPE_SESSION session, COR_PRF_EVENTPIPE_PROVIDER_CONFIG providerConfig)
        {
            TryEventPipeAddProviderToSession(session, providerConfig).ThrowOnNotOK();
        }

        /// <summary>
        /// Adds a provider to an existing EventPipe session.
        /// </summary>
        /// <param name="session">[in] The ID of the session to add the provider to.</param>
        /// <param name="providerConfig">[in] A COR_PRF_EVENTPIPE_PROVIDER_CONFIG describing the provider to add to the session.</param>
        public HRESULT TryEventPipeAddProviderToSession(EVENTPIPE_SESSION session, COR_PRF_EVENTPIPE_PROVIDER_CONFIG providerConfig)
        {
            /*HRESULT EventPipeAddProviderToSession(
            [In] EVENTPIPE_SESSION session,
            [In] COR_PRF_EVENTPIPE_PROVIDER_CONFIG providerConfig);*/
            return Raw12.EventPipeAddProviderToSession(session, providerConfig);
        }

        #endregion
        #region EventPipeStopSession

        /// <summary>
        /// Stops an EventPipe session, preventing any future events from being written to the session.
        /// </summary>
        /// <param name="session">[in] The ID of the session to stop.</param>
        public void EventPipeStopSession(EVENTPIPE_SESSION session)
        {
            TryEventPipeStopSession(session).ThrowOnNotOK();
        }

        /// <summary>
        /// Stops an EventPipe session, preventing any future events from being written to the session.
        /// </summary>
        /// <param name="session">[in] The ID of the session to stop.</param>
        public HRESULT TryEventPipeStopSession(EVENTPIPE_SESSION session)
        {
            /*HRESULT EventPipeStopSession(
            [In] EVENTPIPE_SESSION session);*/
            return Raw12.EventPipeStopSession(session);
        }

        #endregion
        #region EventPipeCreateProvider

        /// <summary>
        /// Creates an EventPipe provider that the profiler can use to write events for other EventPipe listeners to receive.
        /// </summary>
        /// <param name="providerName">[in] The name of the provider to create.</param>
        /// <returns>[out] A caller provided pointer that will be filled with the ID of the provider when the function returns.</returns>
        public EVENTPIPE_PROVIDER EventPipeCreateProvider(string providerName)
        {
            EVENTPIPE_PROVIDER pProvider;
            TryEventPipeCreateProvider(providerName, out pProvider).ThrowOnNotOK();

            return pProvider;
        }

        /// <summary>
        /// Creates an EventPipe provider that the profiler can use to write events for other EventPipe listeners to receive.
        /// </summary>
        /// <param name="providerName">[in] The name of the provider to create.</param>
        /// <param name="pProvider">[out] A caller provided pointer that will be filled with the ID of the provider when the function returns.</param>
        public HRESULT TryEventPipeCreateProvider(string providerName, out EVENTPIPE_PROVIDER pProvider)
        {
            /*HRESULT EventPipeCreateProvider(
            [MarshalAs(UnmanagedType.LPWStr), In] string providerName,
            [Out] out EVENTPIPE_PROVIDER pProvider);*/
            return Raw12.EventPipeCreateProvider(providerName, out pProvider);
        }

        #endregion
        #region EventPipeGetProviderInfo

        /// <summary>
        /// Creates an EventPipe provider that the profiler can use to write events for other EventPipe listeners to receive.
        /// </summary>
        /// <param name="provider">[in] The ID of the provider to provide the name for.</param>
        /// <returns>[out] A caller provided wide character buffer. When the function returns the buffer will contain the name of the provider.</returns>
        public string EventPipeGetProviderInfo(EVENTPIPE_PROVIDER provider)
        {
            string providerNameResult;
            TryEventPipeGetProviderInfo(provider, out providerNameResult).ThrowOnNotOK();

            return providerNameResult;
        }

        /// <summary>
        /// Creates an EventPipe provider that the profiler can use to write events for other EventPipe listeners to receive.
        /// </summary>
        /// <param name="provider">[in] The ID of the provider to provide the name for.</param>
        /// <param name="providerNameResult">[out] A caller provided wide character buffer. When the function returns the buffer will contain the name of the provider.</param>
        public HRESULT TryEventPipeGetProviderInfo(EVENTPIPE_PROVIDER provider, out string providerNameResult)
        {
            /*HRESULT EventPipeGetProviderInfo(
            [In] EVENTPIPE_PROVIDER provider,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] providerName);*/
            int cchName = 0;
            int pcchName;
            char[] providerName;
            HRESULT hr = Raw12.EventPipeGetProviderInfo(provider, cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            providerName = new char[cchName];
            hr = Raw12.EventPipeGetProviderInfo(provider, cchName, out pcchName, providerName);

            if (hr == HRESULT.S_OK)
            {
                providerNameResult = CreateString(providerName, pcchName);

                return hr;
            }

            fail:
            providerNameResult = default(string);

            return hr;
        }

        #endregion
        #region EventPipeDefineEvent

        /// <summary>
        /// Defines an EventPipe event on an existing provider. This provider can be used to write EventPipe events that other listeners can receive.
        /// </summary>
        /// <param name="provider">[in] The ID of the provider to define an event on.</param>
        /// <param name="eventName">[in] A pointer to a null terminated wide character string that contains the event name.</param>
        /// <param name="eventId">[in] The ID of the event being defined.</param>
        /// <param name="keywords">[in] The keywords of the event being defined.</param>
        /// <param name="eventVersion">[in] The version of the event being defined.</param>
        /// <param name="level">[in] The level of the event being defined.</param>
        /// <param name="opcode">[in] The opcode of the event being defined.</param>
        /// <param name="needStack">[in] A BOOL indicating whether managed stacks should be collected each time this event fires.</param>
        /// <param name="cParamDescs">[in] The count of the number of parameters in pParamDescs.</param>
        /// <param name="pParamDescs">[in] An array of COR_PRF_EVENTPIPE_PARAM_DESC defining the parameter types to the event being defined.</param>
        /// <returns>[out] A caller provided pointer that will be filled with the ID of the event being defined when the function returns.</returns>
        public EVENTPIPE_EVENT EventPipeDefineEvent(EVENTPIPE_PROVIDER provider, string eventName, int eventId, long keywords, int eventVersion, int level, byte opcode, bool needStack, int cParamDescs, COR_PRF_EVENTPIPE_PARAM_DESC[] pParamDescs)
        {
            EVENTPIPE_EVENT pEvent;
            TryEventPipeDefineEvent(provider, eventName, eventId, keywords, eventVersion, level, opcode, needStack, cParamDescs, pParamDescs, out pEvent).ThrowOnNotOK();

            return pEvent;
        }

        /// <summary>
        /// Defines an EventPipe event on an existing provider. This provider can be used to write EventPipe events that other listeners can receive.
        /// </summary>
        /// <param name="provider">[in] The ID of the provider to define an event on.</param>
        /// <param name="eventName">[in] A pointer to a null terminated wide character string that contains the event name.</param>
        /// <param name="eventId">[in] The ID of the event being defined.</param>
        /// <param name="keywords">[in] The keywords of the event being defined.</param>
        /// <param name="eventVersion">[in] The version of the event being defined.</param>
        /// <param name="level">[in] The level of the event being defined.</param>
        /// <param name="opcode">[in] The opcode of the event being defined.</param>
        /// <param name="needStack">[in] A BOOL indicating whether managed stacks should be collected each time this event fires.</param>
        /// <param name="cParamDescs">[in] The count of the number of parameters in pParamDescs.</param>
        /// <param name="pParamDescs">[in] An array of COR_PRF_EVENTPIPE_PARAM_DESC defining the parameter types to the event being defined.</param>
        /// <param name="pEvent">[out] A caller provided pointer that will be filled with the ID of the event being defined when the function returns.</param>
        public HRESULT TryEventPipeDefineEvent(EVENTPIPE_PROVIDER provider, string eventName, int eventId, long keywords, int eventVersion, int level, byte opcode, bool needStack, int cParamDescs, COR_PRF_EVENTPIPE_PARAM_DESC[] pParamDescs, out EVENTPIPE_EVENT pEvent)
        {
            /*HRESULT EventPipeDefineEvent(
            [In] EVENTPIPE_PROVIDER provider,
            [MarshalAs(UnmanagedType.LPWStr), In] string eventName,
            [In] int eventId,
            [In] long keywords,
            [In] int eventVersion,
            [In] int level,
            [In] byte opcode,
            [In, MarshalAs(UnmanagedType.Bool)] bool needStack,
            [In] int cParamDescs,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 8)] COR_PRF_EVENTPIPE_PARAM_DESC[] pParamDescs,
            [Out] out EVENTPIPE_EVENT pEvent);*/
            return Raw12.EventPipeDefineEvent(provider, eventName, eventId, keywords, eventVersion, level, opcode, needStack, cParamDescs, pParamDescs, out pEvent);
        }

        #endregion
        #region EventPipeWriteEvent

        /// <summary>
        /// Writes an EventPipe event to any listeners who have enabled this event.
        /// </summary>
        /// <param name="event">[in] The ID of the event being written.</param>
        /// <param name="cData">[in] The number of elements in data.</param>
        /// <param name="data">[in] An array of COR_PRF_EVENT_DATA containing the event arguments.</param>
        /// <param name="pActivityId">[in] A pointer to a GUID specifying the event's activity ID.</param>
        /// <param name="pRelatedActivityId">[in] A pointer to a GUID specifying the event's related activity ID.</param>
        public void EventPipeWriteEvent(EVENTPIPE_EVENT @event, int cData, COR_PRF_EVENT_DATA[] data, Guid pActivityId, Guid pRelatedActivityId)
        {
            TryEventPipeWriteEvent(@event, cData, data, pActivityId, pRelatedActivityId).ThrowOnNotOK();
        }

        /// <summary>
        /// Writes an EventPipe event to any listeners who have enabled this event.
        /// </summary>
        /// <param name="event">[in] The ID of the event being written.</param>
        /// <param name="cData">[in] The number of elements in data.</param>
        /// <param name="data">[in] An array of COR_PRF_EVENT_DATA containing the event arguments.</param>
        /// <param name="pActivityId">[in] A pointer to a GUID specifying the event's activity ID.</param>
        /// <param name="pRelatedActivityId">[in] A pointer to a GUID specifying the event's related activity ID.</param>
        public HRESULT TryEventPipeWriteEvent(EVENTPIPE_EVENT @event, int cData, COR_PRF_EVENT_DATA[] data, Guid pActivityId, Guid pRelatedActivityId)
        {
            /*HRESULT EventPipeWriteEvent(
            [In] EVENTPIPE_EVENT @event,
            [In] int cData,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] COR_PRF_EVENT_DATA[] data,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pActivityId,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pRelatedActivityId);*/
            return Raw12.EventPipeWriteEvent(@event, cData, data, pActivityId, pRelatedActivityId);
        }

        #endregion
        #endregion
    }
}
