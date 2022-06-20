using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for debugging application domains. This interface is a subclass of <see cref="ICorDebugController"/>.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3D6F5F63-7538-11D3-8D5B-00104B35E7EF")]
    [ComImport]
    public interface ICorDebugAppDomain : ICorDebugController
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
        new HRESULT Stop([In] int dwTimeoutIgnored);

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
        new HRESULT Continue([In] bool fIsOutOfBand);

        /// <summary>
        /// Gets a value that indicates whether the threads in the process are currently running freely.
        /// </summary>
        /// <param name="pbRunning">[out] A pointer to a value that is true if the threads in the process are running freely; otherwise, false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsRunning([Out] out bool pbRunning);

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
            ICorDebugThread pThread, [Out] out bool pbQueued);

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
        new HRESULT EnumerateThreads([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreads);

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
        new HRESULT Terminate([In] int exitCode);

        /// <summary>
        /// CanCommitChanges is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CanCommitChanges(
            [In] int cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        /// <summary>
        /// CommitChanges is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CommitChanges(
            [In] int cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        /// <summary>
        /// Gets the process containing the application domain.
        /// </summary>
        /// <param name="ppProcess">[out] A pointer to the address of an <see cref="ICorDebugProcess"/> object that represents the process.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetProcess([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        /// <summary>
        /// Gets an enumerator for the assemblies in the application domain.
        /// </summary>
        /// <param name="ppAssemblies">[out] A pointer to the address of an <see cref="ICorDebugAssemblyEnum"/> object that is the enumerator for the assemblies in the application domain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateAssemblies([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAssemblyEnum ppAssemblies);

        /// <summary>
        /// Gets the module that corresponds to the given metadata interface.
        /// </summary>
        /// <param name="pIMetaData">[in] A pointer to an object that is one of the Metadata interfaces.</param>
        /// <param name="ppModule">[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the module corresponding to the given metadata interface.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModuleFromMetaDataInterface([MarshalAs(UnmanagedType.IUnknown), In]
            object pIMetaData, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        /// <summary>
        /// Gets an enumerator for all active breakpoints in the application domain.
        /// </summary>
        /// <param name="ppBreakpoints">[out] A pointer to the address of an <see cref="ICorDebugBreakpointEnum"/> object that is the enumerator for all active breakpoints in the application domain.</param>
        /// <remarks>
        /// The enumerator includes all types of breakpoints, including function breakpoints and data breakpoints.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateBreakpoints([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugBreakpointEnum ppBreakpoints);

        /// <summary>
        /// Gets an enumerator for all active steppers in the application domain.
        /// </summary>
        /// <param name="ppSteppers">[out] A pointer to the address of an <see cref="ICorDebugStepperEnum"/> object that is the enumerator for all active steppers in the application domain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateSteppers([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugStepperEnum ppSteppers);

        /// <summary>
        /// Gets a value that indicates whether the debugger is attached to the application domain.
        /// </summary>
        /// <param name="pbAttached">[out] true if the debugger is attached to the application domain; otherwise, false.</param>
        /// <remarks>
        /// The <see cref="ICorDebugController"/> methods cannot be used until the debugger attaches to the application domain.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsAttached([Out] out bool pbAttached);

        /// <summary>
        /// Gets the name of the application domain.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array. Set this value to zero to put this method in query mode.</param>
        /// <param name="pcchName">[out] A pointer to the size of the name or the number of characters actually returned in szName. In query mode, this value lets the caller know how large a buffer to allocate for the name.</param>
        /// <param name="szName">[out] An array that stores the name of the application domain.</param>
        /// <remarks>
        /// A debugger calls the GetName method once to get the size of a buffer needed for the name. The debugger allocates
        /// the buffer, and then calls the method a second time to fill the buffer. The first call, to get the size of the
        /// name, is referred to as query mode.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);

        /// <summary>
        /// Gets an interface pointer to the common language runtime (CLR) application domain.
        /// </summary>
        /// <param name="ppObject">[out] A pointer to the address of an <see cref="ICorDebugValue"/> interface object that represents the CLR application domain.</param>
        /// <returns>If a managed <see cref="AppDomain"/> object hasn't been constructed for this application domain, the method returns S_FALSE and places NULL in *ppObject.</returns>
        /// <remarks>
        /// Each application domain in a process may have a managed <see cref="AppDomain"/> object in the runtime that represents
        /// it. This function gets an <see cref="ICorDebugValue"/> interface object that corresponds to this managed <see cref="AppDomain"/>
        /// object.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObject([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);

        /// <summary>
        /// Attaches the debugger to the application domain.
        /// </summary>
        /// <remarks>
        /// The debugger must be attached to the application domain to receive events and to enable debugging of the application
        /// domain.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Attach();

        /// <summary>
        /// Gets the unique identifier of the application domain.
        /// </summary>
        /// <param name="pId">[out] The unique identifier of the application domain.</param>
        /// <remarks>
        /// The identifier for the application domain is unique within the containing process.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetID([Out] out int pId);
    }
}