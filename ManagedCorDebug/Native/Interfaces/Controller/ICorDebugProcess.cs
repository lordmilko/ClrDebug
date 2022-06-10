using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a process that is executing managed code. This interface is a subclass of <see cref="ICorDebugController"/>.
    /// </summary>
    [Guid("3D6F5F64-7538-11D3-8D5B-00104B35E7EF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess : ICorDebugController
    {
        /// <summary>
        /// Performs a cooperative stop on all threads that are running managed code in the process.
        /// </summary>
        /// <param name="dwTimeoutIgnored">Not used.</param>
        /// <remarks>
        /// Stop performs a cooperative stop on all threads running managed code in the process. During a managed-only debugging
        /// session, unmanaged threads may continue to run (but will be blocked when trying to call managed code). During an
        /// interop debugging session, unmanaged threads will also be stopped. The dwTimeoutIgnored value is currently ignored
        /// and treated as INFINITE (-1). If the cooperative stop fails due to a deadlock, all threads are suspended and E_TIMEOUT
        /// is returned. The debugger maintains a stop counter. When the counter goes to zero, the controller is resumed. Each
        /// call to Stop or each dispatched callback increments the counter. Each call to <see cref="ICorDebugController.Continue"/> decrements
        /// the counter.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Stop([In] uint dwTimeoutIgnored);

        /// <summary>
        /// Resumes execution of managed threads after a call to <see cref="Stop"/>.
        /// </summary>
        /// <param name="fIsOutOfBand">[in] Set to true if continuing from an out-of-band event; otherwise, set to false.</param>
        /// <remarks>
        /// Continue continues the process after a call to the <see cref="ICorDebugController.Stop"/> method. When doing mixed-mode debugging,
        /// do not call Continue on the Win32 event thread unless you are continuing from an out-of-band event. An in-band
        /// event is either a managed event or a normal unmanaged event during which the debugger supports interaction with
        /// the managed state of the process. In this case, the debugger receives the <see cref="ICorDebugUnmanagedCallback.DebugEvent"/>
        /// callback with its fOutOfBand parameter set to false. An out-of-band event is an unmanaged event during which interaction
        /// with the managed state of the process is impossible while the process is stopped due to the event. In this case,
        /// the debugger receives the <see cref="ICorDebugUnmanagedCallback.DebugEvent"/> callback with its fOutOfBand parameter set to
        /// true.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Continue([In] int fIsOutOfBand);

        /// <summary>
        /// Gets a value that indicates whether the threads in the process are currently running freely.
        /// </summary>
        /// <param name="pbRunning">[out] A pointer to a value that is true if the threads in the process are running freely; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsRunning(out int pbRunning);

        /// <summary>
        /// Gets a value that indicates whether any managed callbacks are currently queued for the specified thread.
        /// </summary>
        /// <param name="pThread">[in] A pointer to an "ICorDebugThread" object that represents the thread.</param>
        /// <param name="pbQueued">[out] A pointer to a value that is true if any managed callbacks are currently queued for the specified thread; otherwise, false.<para/>
        /// If null is specified for the pThread parameter, HasQueuedCallbacks will return true if there are currently managed callbacks queued for any thread.</param>
        /// <remarks>
        /// Callbacks will be dispatched one at a time, each time <see cref="Continue"/> is called. The debugger can check
        /// this flag if it wants to report multiple debugging events that occur simultaneously. When debugging events are
        /// queued, they have already occurred, so the debugger must drain the entire queue to be sure of the state of the
        /// debuggee. (Call <see cref="ICorDebugController.Continue"/> to drain the queue.) For example, if the queue contains two debugging
        /// events on thread X, and the debugger suspends thread X after the first debugging event and then calls <see cref="ICorDebugController.Continue"/>,
        /// the second debugging event for thread X will be dispatched although the thread has been suspended.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT HasQueuedCallbacks([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, out int pbQueued);

        /// <summary>
        /// Gets an enumerator for the active managed threads in the process.
        /// </summary>
        /// <param name="ppThreads">[out] A pointer to the address of an "ICorDebugThreadEnum" object that represents an enumerator for all managed threads that are active in the process.</param>
        /// <remarks>
        /// A thread is considered active after the <see cref="ICorDebugManagedCallback.CreateThread"/> callback has been dispatched
        /// and before the <see cref="ICorDebugManagedCallback.ExitThread"/> callback has been dispatched. A managed thread
        /// may not necessarily have any managed frames on its stack. Threads can be enumerated even before the <see cref="ICorDebugManagedCallback.CreateProcess"/>
        /// callback. The enumeration will naturally be empty.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT EnumerateThreads([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreads);

        /// <summary>
        /// Sets the debug state of all managed threads in the process.
        /// </summary>
        /// <param name="state">[in] A value of the "CorDebugThreadState" enumeration that specifies the state of the thread for debugging.</param>
        /// <param name="pExceptThisThread">[in] A pointer to an "ICorDebugThread" object that represents a thread to be exempted from the debug state setting.<para/>
        /// If this value is null, no thread is exempted.</param>
        /// <remarks>
        /// The SetAllThreadsDebugState method may affect threads that are not visible via <see cref="EnumerateThreads"/>,
        /// so threads that were suspended with the SetAllThreadsDebugState method will need to be resumed with the SetAllThreadsDebugState
        /// method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetAllThreadsDebugState([In] CorDebugThreadState state, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pExceptThisThread);

        /// <summary>
        /// Detaches the debugger from the process or application domain.
        /// </summary>
        /// <remarks>
        /// The process or application domain continues execution normally, but the "ICorDebugProcess" or "ICorDebugAppDomain"
        /// object is no longer valid and no further callbacks will occur. In the .NET Framework version 2.0, if unmanaged
        /// debugging is enabled, this method will fail due to operating system limitations.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Detach();

        /// <summary>
        /// Terminates the process with the specified exit code.
        /// </summary>
        /// <param name="exitCode">[in] A numeric value that is the exit code. The valid numeric values are defined in Winbase.h.</param>
        /// <remarks>
        /// If the process is stopped when Terminate is called, the process should be continued by using the <see cref="Continue"/>
        /// method so that the debugger receives confirmation of the termination through the <see cref="ICorDebugManagedCallback.ExitProcess"/>
        /// or <see cref="ICorDebugManagedCallback.ExitAppDomain"/> callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Terminate([In] uint exitCode);

        /// <summary>
        /// CanCommitChanges is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CanCommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        /// <summary>
        /// CommitChanges is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        /// <summary>
        /// Gets the operating system (OS) ID of the process.
        /// </summary>
        /// <param name="pdwProcessId">[out] The unique ID of the process.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetID(out uint pdwProcessId);

        /// <summary>
        /// Gets a handle to the process.
        /// </summary>
        /// <param name="phProcessHandle">[out] A pointer to an HPROCESS that is the handle to the process.</param>
        /// <remarks>
        /// The retrieved handle is owned by the debugging interface. The debugger should duplicate the handle before using
        /// it.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHandle(out IntPtr phProcessHandle);

        /// <summary>
        /// Gets this process's thread that has the specified operating system (OS) thread ID.
        /// </summary>
        /// <param name="dwThreadId">[in] The OS thread ID of the thread to be retrieved.</param>
        /// <param name="ppThread">[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThread([In] uint dwThreadId, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateObjects([MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectEnum ppObjects);

        /// <summary>
        /// Gets a value that indicates whether an address is inside a stub that will cause a transition to managed code.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address in question.</param>
        /// <param name="pbTransitionStub">[out] A pointer to a Boolean value that is true if the specified address is inside a stub that will cause a transition to managed code; otherwise *pbTransitionStub is false.</param>
        /// <remarks>
        /// The IsTransitionStub method can be used by unmanaged stepping code to decide when to return stepping control to
        /// the managed stepper. You can also identity transition stubs by looking at information in the portable executable
        /// (PE) file.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsTransitionStub([In] CORDB_ADDRESS address, out int pbTransitionStub);

        /// <summary>
        /// Gets a value that indicates whether the specified thread has been suspended as a result of the debugger stopping this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of thread in question.</param>
        /// <param name="pbSuspended">[out] A pointer to a Boolean value that is true if the specified thread has been suspended; otherwise *pbSuspended is false.</param>
        /// <remarks>
        /// When the specified thread has been suspended as a result of the debugger stopping this process, the specified thread's
        /// Win32 suspend count is incremented by one. The debugger user interface (UI) may want to take this information into
        /// account if it displays the operating system (OS) suspend count of the thread to the user. The IsOSSuspended method
        /// makes sense only in the context of unmanaged debugging. During managed debugging, threads are cooperatively suspended
        /// rather than OS-suspended.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsOSSuspended([In] uint threadID, out int pbSuspended);

        /// <summary>
        /// Gets the context for the given thread in this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread for which to retrieve the context.</param>
        /// <param name="contextSize">[in] The size of the context array.</param>
        /// <param name="context">[in, out] An array of bytes that describe the thread's context. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <remarks>
        /// The debugger should call this method rather than the Win32 GetThreadContext method, because the thread may actually
        /// be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when
        /// a thread is in native code. Use <see cref="ICorDebugRegisterSet"/> for threads in managed code. The data returned
        /// is a context structure for the current platform. Just as with the Win32 GetThreadContext method, the caller should
        /// initialize the context parameter before calling this method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThreadContext([In] uint threadID, [In] uint contextSize, [In, Out] byte[] context);

        /// <summary>
        /// Sets the context for the given thread in this process.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread for which to set the context.</param>
        /// <param name="contextSize">[in] The size of the context array.</param>
        /// <param name="context">[in] An array of bytes that describe the thread's context. The context specifies the architecture of the processor on which the thread is executing.</param>
        /// <remarks>
        /// The debugger should call this method rather than the Win32 SetThreadContext function, because the thread may actually
        /// be in a "hijacked" state, in which its context has been temporarily changed. This method should be used only when
        /// a thread is in native code. Use <see cref="ICorDebugRegisterSet"/> for threads in managed code. You should never
        /// need to modify the context of a thread during an out-of-band (OOB) debug event. The data passed must be a context
        /// structure for the current platform. This method can corrupt the runtime if used improperly.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetThreadContext([In] uint threadID, [In] uint contextSize, [In] byte[] context);

        /// <summary>
        /// Reads a specified area of memory for this process.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the base address of the memory to be read.</param>
        /// <param name="size">[in] The number of bytes to be read from memory.</param>
        /// <param name="buffer">[out] A buffer that receives the contents of the memory.</param>
        /// <param name="read">[out] A pointer to the number of bytes transferred into the specified buffer.</param>
        /// <remarks>
        /// The ReadMemory method is primarily intended to be used by interop debugging to inspect memory regions that are
        /// being used by the unmanaged portion of the debuggee. This method can also be used to read Microsoft intermediate
        /// language (MSIL) code and native JIT-compiled code. Any managed breakpoints will be removed from the data that is
        /// returned in the buffer parameter. No adjustments will be made for native breakpoints set by <see cref="ICorDebugProcess2.SetUnmanagedBreakpoint"/>.
        /// No caching of process memory is performed.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ReadMemory([In] CORDB_ADDRESS address, [In] uint size, [Out] byte[] buffer, out ulong read);

        /// <summary>
        /// Writes data to an area of memory in this process.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that is the base address of the memory area to which data is written. Before data transfer occurs, the system verifies that the memory area of the specified size, beginning at the base address, is accessible for writing.<para/>
        /// If it is not accessible, the method fails.</param>
        /// <param name="size">[in] The number of bytes to be written to the memory area.</param>
        /// <param name="buffer">[in] A buffer that contains data to be written.</param>
        /// <param name="written">[out] A pointer to a variable that receives the number of bytes written to the memory area in this process. If written is NULL, this parameter is ignored.</param>
        /// <remarks>
        /// Data is automatically written behind any breakpoints. In the .NET Framework version 2.0, native debuggers should
        /// not use this method to inject breakpoints into the instruction stream. Use <see cref="ICorDebugProcess2.SetUnmanagedBreakpoint"/>
        /// instead. The WriteMemory method should be used only outside of managed code. This method can corrupt the runtime
        /// if used improperly.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT WriteMemory([In] CORDB_ADDRESS address, [In] uint size, [In] IntPtr buffer,
            out ulong written);

        /// <summary>
        /// Clears the current unmanaged exception on the given thread.
        /// </summary>
        /// <param name="threadID">[in] The ID of the thread on which the current unmanaged exception will be cleared.</param>
        /// <remarks>
        /// Call this method before calling <see cref="ICorDebugController.Continue"/> when a thread has reported an unmanaged
        /// exception that should be ignored by the debuggee. This will clear both the outstanding in-band (IB) and out-of-band
        /// (OOB) events on the given thread. All OOB breakpoints and single-step exceptions are automatically cleared. Use
        /// <see cref="ICorDebugThread2.InterceptCurrentException"/> to intercept the current managed exception on a thread.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ClearCurrentException([In] uint threadID);

        /// <summary>
        /// Enables and disables the transmission of log messages to the debugger.
        /// </summary>
        /// <param name="fOnOff">[in] true enables the transmission of log messages; false disables the transmission.</param>
        /// <remarks>
        /// This method is valid only after the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback occurs.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableLogMessages([In] int fOnOff);

        /// <summary>
        /// Sets the severity level of the specified log switch.
        /// </summary>
        /// <param name="pLogSwitchName">[in] A pointer to a string that specifies the name of the log switch.</param>
        /// <param name="lLevel">[in] The severity level to be set for the specified log switch.</param>
        /// <remarks>
        /// This method is valid only after the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback has occurred.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ModifyLogSwitch([In] string pLogSwitchName, [In] int lLevel);

        /// <summary>
        /// Enumerates all the application domains in this process.
        /// </summary>
        /// <param name="ppAppDomains">[out] A pointer to the address of an <see cref="ICorDebugAppDomainEnum"/> that is an enumerator for the application domains in this process.</param>
        /// <remarks>
        /// This method can be used before the <see cref="ICorDebugManagedCallback.CreateProcess"/> callback.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateAppDomains([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomainEnum ppAppDomains);

        /// <summary>
        /// This method has not been implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ThreadForFiberCookie([In] uint fiberCookie,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        /// <summary>
        /// Gets the operating system (OS) thread ID of the debugger's internal helper thread.
        /// </summary>
        /// <param name="pThreadID">[out] A pointer to the OS thread ID of the debugger's internal helper thread.</param>
        /// <remarks>
        /// During managed and unmanaged debugging, it is the debugger's responsibility to ensure that the thread with the
        /// specified ID remains running if it hits a breakpoint placed by the debugger. A debugger may also wish to hide this
        /// thread from the user. If no helper thread exists in the process yet, the GetHelperThreadID method returns zero
        /// in *pThreadID. You cannot cache the thread ID of the helper thread, because it may change over time. You must re-query
        /// the thread ID at every stopping event. The thread ID of the debugger's helper thread will be correct on every unmanaged
        /// <see cref="ICorDebugManagedCallback.CreateThread"/> event, thus allowing a debugger to determine the thread ID
        /// of its helper thread and hide it from the user. A thread that is identified as a helper thread during an unmanaged
        /// <see cref="ICorDebugManagedCallback.CreateThread"/> event will never run managed user code.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHelperThreadID(out uint pThreadID);
    }
}