using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to support debugger exception handling and managed debugging assistants (MDAs). <see cref="ICorDebugManagedCallback2"/> is a logical extension of the <see cref="ICorDebugManagedCallback"/> interface.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugManagedCallback2"/> interface extends the <see cref="ICorDebugManagedCallback"/> interface to handle new debug events
    /// introduced in the .NET Framework version 2.0. A debugger must implement <see cref="ICorDebugManagedCallback2"/> if it is debugging
    /// .NET Framework 2.0 applications. An instance of <see cref="ICorDebugManagedCallback"/> or <see cref="ICorDebugManagedCallback2"/> is passed
    /// as the callback object to <see cref="ICorDebug.SetManagedHandler"/>.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("250E5EEA-DB5C-4C76-B6F3-8C46F12E3203")]
    [ComImport]
    public interface ICorDebugManagedCallback2
    {
        /// <summary>
        /// Notifies the debugger that code execution has reached a sequence point in an older version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pOldFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function that is currently running on the thread.</param>
        /// <param name="pNewFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the latest version of the function.</param>
        /// <param name="oldILOffset">[in] The Microsoft intermediate language (MSIL) offset of the instruction pointer in the old version of the function.</param>
        /// <remarks>
        /// This callback gives the debugger an opportunity to remap the instruction pointer to its proper place in the new
        /// version of the specified function by calling the <see cref="ICorDebugILFrame2.RemapFunction"/> method. If the debugger
        /// does not call RemapFunction before calling the <see cref="ICorDebugController.Continue"/> method, the runtime will
        /// continue to execute the old code and will fire another FunctionRemapOpportunity callback at the next sequence point.
        /// This callback will be invoked for every frame that is executing an older version of the given function until the
        /// debugger returns S_OK.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT FunctionRemapOpportunity(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFunction pOldFunction,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFunction pNewFunction,
            [In] int oldILOffset);

        /// <summary>
        /// Notifies the debugger that a new connection has been created.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process in which the connection was created</param>
        /// <param name="dwConnectionId">[in] The ID of the new connection.</param>
        /// <param name="pConnName">[in] A pointer to the name of the new connection.</param>
        /// <remarks>
        /// A CreateConnection callback will be fired in either of the following cases:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateConnection(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess,
            [In] int dwConnectionId,
            [MarshalAs(UnmanagedType.LPWStr), In] string pConnName);

        /// <summary>
        /// Notifies the debugger that the set of tasks associated with the specified connection has changed.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an "ICorDebugProcess" object that represents the process containing the connection that changed.</param>
        /// <param name="dwConnectionId">[in] The ID of the connection that changed.</param>
        /// <remarks>
        /// A ChangeConnection callback will be fired in either of the following cases: The debugger should scan all threads
        /// in the process to pick up the new changes.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ChangeConnection(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess,
            [In] int dwConnectionId);

        /// <summary>
        /// Notifies the debugger that the specified connection has been terminated.
        /// </summary>
        /// <param name="pProcess">[in] A pointer to an <see cref="ICorDebugProcess"/> object that represents the process containing the connection that was destroyed.</param>
        /// <param name="dwConnectionId">[in] The ID of the connection that was destroyed.</param>
        /// <remarks>
        /// A DestroyConnection callback will be fired when a host calls <see cref="ICLRDebugManager.EndConnection"/> in the
        /// Hosting API.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DestroyConnection(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugProcess pProcess,
            [In] int dwConnectionId);

        /// <summary>
        /// Notifies the debugger that a search for an exception handler has started.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> object that represents a frame, as determined by the dwEventType parameter.<para/>
        /// For more information, see the table in the Remarks section.</param>
        /// <param name="nOffset">[in] An integer that specifies an offset, as determined by the dwEventType parameter. For more information, see the table in the Remarks section.</param>
        /// <param name="dwEventType">[in] A value of the <see cref="CorDebugExceptionCallbackType"/> enumeration that specifies the type of this exception callback.</param>
        /// <param name="dwFlags">[in] A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception</param>
        /// <remarks>
        /// The Exception callback is called at various points during the search phase of the exception-handling process. That
        /// is, it can be called more than once while unwinding an exception. The exception being processed can be retrieved
        /// from the <see cref="ICorDebugThread"/> object referenced by the pThread parameter. The particular frame and offset are determined
        /// by the dwEventType parameter as follows:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Exception(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFrame pFrame,
            [In] int nOffset,
            [In] CorDebugExceptionCallbackType dwEventType,
            [In] int dwFlags);

        /// <summary>
        /// Provides a status notification during the exception unwinding process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread on which the exception was thrown.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the exception was thrown.</param>
        /// <param name="dwEventType">[in] A value of the <see cref="CorDebugExceptionUnwindCallbackType"/> enumeration that specifies the event that is being signaled by the callback during the unwind phase.</param>
        /// <param name="dwFlags">[in] A value of the <see cref="CorDebugExceptionFlags"/> enumeration that specifies additional information about the exception.</param>
        /// <remarks>
        /// ExceptionUnwind is called at various points during the unwind phase of the exception-handling process. ExceptionUnwind
        /// can be called more than once while unwinding a single exception. If dwEventType = DEBUG_EXCEPTION_INTERCEPTED,
        /// the instruction pointer will be in the leaf frame of the thread, at the sequence point before (this may be several
        /// instructions before) the instruction that led to the exception.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExceptionUnwind(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [In] CorDebugExceptionUnwindCallbackType dwEventType,
            [In] int dwFlags);

        /// <summary>
        /// Notifies the debugger that code execution has switched to a new version of an edited function.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the edited function.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> object that represents the thread on which the remap breakpoint was encountered.</param>
        /// <param name="pFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the version of the function currently running on the thread.</param>
        /// <remarks>
        /// This callback gives the debugger an opportunity to recreate any steppers that previously existed.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT FunctionRemapComplete(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFunction pFunction);

        /// <summary>
        /// Provides notification that code execution has encountered a managed debugging assistant (MDA) in the application that is being debugged.
        /// </summary>
        /// <param name="pController">[in] A pointer to an <see cref="ICorDebugController"/> interface that exposes the process or application domain in which the MDA occurred.<para/>
        /// A debugger should not make any assumptions about whether the controller is a process or an application domain, although it can always query the interface to make a determination.</param>
        /// <param name="pThread">[in] A pointer to an <see cref="ICorDebugThread"/> interface that exposes the managed thread on which the debug event occurred.<para/>
        /// If the MDA occurred on an unmanaged thread, the value of pThread will be null. You must get the operating system (OS) thread ID from the MDA object itself.</param>
        /// <param name="pMDA">[in] A pointer to an <see cref="ICorDebugMDA"/> interface that exposes the MDA information.</param>
        /// <remarks>
        /// An MDA is a heuristic warning and does not require any explicit debugger action except for calling <see cref="ICorDebugController.Continue"/>
        /// to resume execution of the application that is being debugged. The common language runtime (CLR) can determine
        /// which MDAs are fired and which data is in any given MDA at any point. Therefore, debuggers should not build any
        /// functionality requiring specific MDA patterns. MDAs may be queued and fired shortly after the MDA is encountered.
        /// This could happen if the runtime needs to wait until it reaches a safe point for firing the MDA, instead of firing
        /// the MDA when it encounters it. It also means that the runtime may fire a number of MDAs in a single set of queued
        /// callbacks (similar to an "attach" event operation). A debugger should release the reference to an <see cref="ICorDebugMDA"/>
        /// instance immediately after returning from the MDANotification callback, to allow the CLR to recycle the memory
        /// consumed by an MDA. Releasing the instance may improve performance if many MDAs are firing.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT MDANotification(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugController pController,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugMDA pMDA);
    }
}
