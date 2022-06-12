using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a scope, either a <see cref="Process"/> or an <see cref="AppDomain"/>, in which code execution context can be controlled.
    /// </summary>
    /// <remarks>
    /// If <see cref="ICorDebugController"/> is controlling a process, the scope includes all threads of the process. If <see cref="ICorDebugController"/>
    /// is controlling an application domain, the scope includes only the threads of that particular application domain.
    /// </remarks>
    public abstract class CorDebugController : ComObject<ICorDebugController>
    {
        public static CorDebugController New(ICorDebugController value)
        {
            if (value is ICorDebugAppDomain)
                return new CorDebugAppDomain((ICorDebugAppDomain) value);

            if (value is ICorDebugProcess)
                return new CorDebugProcess((ICorDebugProcess) value);

            throw new NotImplementedException("Encountered an ICorDebugController' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugController"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugController(ICorDebugController raw) : base(raw)
        {
        }

        #region ICorDebugController
        #region IsRunning

        /// <summary>
        /// Gets a value that indicates whether the threads in the process are currently running freely.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                HRESULT hr;
                bool pbRunningResult;

                if ((hr = TryIsRunning(out pbRunningResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbRunningResult;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the threads in the process are currently running freely.
        /// </summary>
        /// <param name="pbRunningResult">[out] A pointer to a value that is true if the threads in the process are running freely; otherwise, false.</param>
        public HRESULT TryIsRunning(out bool pbRunningResult)
        {
            /*HRESULT IsRunning(out int pbRunning);*/
            int pbRunning;
            HRESULT hr = Raw.IsRunning(out pbRunning);

            if (hr == HRESULT.S_OK)
                pbRunningResult = pbRunning == 1;
            else
                pbRunningResult = default(bool);

            return hr;
        }

        #endregion
        #region Stop

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
        /// call to Stop or each dispatched callback increments the counter. Each call to <see cref="Continue"/> decrements
        /// the counter.
        /// </remarks>
        public void Stop(int dwTimeoutIgnored)
        {
            HRESULT hr;

            if ((hr = TryStop(dwTimeoutIgnored)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        /// call to Stop or each dispatched callback increments the counter. Each call to <see cref="Continue"/> decrements
        /// the counter.
        /// </remarks>
        public HRESULT TryStop(int dwTimeoutIgnored)
        {
            /*HRESULT Stop([In] int dwTimeoutIgnored);*/
            return Raw.Stop(dwTimeoutIgnored);
        }

        #endregion
        #region Continue

        /// <summary>
        /// Resumes execution of managed threads after a call to <see cref="Stop"/>.
        /// </summary>
        /// <param name="fIsOutOfBand">[in] Set to true if continuing from an out-of-band event; otherwise, set to false.</param>
        /// <remarks>
        /// Continue continues the process after a call to the <see cref="Stop"/> method. When doing mixed-mode debugging,
        /// do not call Continue on the Win32 event thread unless you are continuing from an out-of-band event. An in-band
        /// event is either a managed event or a normal unmanaged event during which the debugger supports interaction with
        /// the managed state of the process. In this case, the debugger receives the <see cref="CorDebugUnmanagedCallback.DebugEvent"/>
        /// callback with its fOutOfBand parameter set to false. An out-of-band event is an unmanaged event during which interaction
        /// with the managed state of the process is impossible while the process is stopped due to the event. In this case,
        /// the debugger receives the <see cref="CorDebugUnmanagedCallback.DebugEvent"/> callback with its fOutOfBand parameter set to
        /// true.
        /// </remarks>
        public void Continue(int fIsOutOfBand)
        {
            HRESULT hr;

            if ((hr = TryContinue(fIsOutOfBand)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Resumes execution of managed threads after a call to <see cref="Stop"/>.
        /// </summary>
        /// <param name="fIsOutOfBand">[in] Set to true if continuing from an out-of-band event; otherwise, set to false.</param>
        /// <remarks>
        /// Continue continues the process after a call to the <see cref="Stop"/> method. When doing mixed-mode debugging,
        /// do not call Continue on the Win32 event thread unless you are continuing from an out-of-band event. An in-band
        /// event is either a managed event or a normal unmanaged event during which the debugger supports interaction with
        /// the managed state of the process. In this case, the debugger receives the <see cref="CorDebugUnmanagedCallback.DebugEvent"/>
        /// callback with its fOutOfBand parameter set to false. An out-of-band event is an unmanaged event during which interaction
        /// with the managed state of the process is impossible while the process is stopped due to the event. In this case,
        /// the debugger receives the <see cref="CorDebugUnmanagedCallback.DebugEvent"/> callback with its fOutOfBand parameter set to
        /// true.
        /// </remarks>
        public HRESULT TryContinue(int fIsOutOfBand)
        {
            /*HRESULT Continue([In] int fIsOutOfBand);*/
            return Raw.Continue(fIsOutOfBand);
        }

        #endregion
        #region HasQueuedCallbacks

        /// <summary>
        /// Gets a value that indicates whether any managed callbacks are currently queued for the specified thread.
        /// </summary>
        /// <param name="pThread">[in] A pointer to an "ICorDebugThread" object that represents the thread.</param>
        /// <returns>[out] A pointer to a value that is true if any managed callbacks are currently queued for the specified thread; otherwise, false.<para/>
        /// If null is specified for the pThread parameter, HasQueuedCallbacks will return true if there are currently managed callbacks queued for any thread.</returns>
        /// <remarks>
        /// Callbacks will be dispatched one at a time, each time <see cref="Continue"/> is called. The debugger can check
        /// this flag if it wants to report multiple debugging events that occur simultaneously. When debugging events are
        /// queued, they have already occurred, so the debugger must drain the entire queue to be sure of the state of the
        /// debuggee. (Call <see cref="Continue"/> to drain the queue.) For example, if the queue contains two debugging
        /// events on thread X, and the debugger suspends thread X after the first debugging event and then calls <see cref="Continue"/>,
        /// the second debugging event for thread X will be dispatched although the thread has been suspended.
        /// </remarks>
        public int HasQueuedCallbacks(ICorDebugThread pThread)
        {
            HRESULT hr;
            int pbQueued;

            if ((hr = TryHasQueuedCallbacks(pThread, out pbQueued)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbQueued;
        }

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
        /// debuggee. (Call <see cref="Continue"/> to drain the queue.) For example, if the queue contains two debugging
        /// events on thread X, and the debugger suspends thread X after the first debugging event and then calls <see cref="Continue"/>,
        /// the second debugging event for thread X will be dispatched although the thread has been suspended.
        /// </remarks>
        public HRESULT TryHasQueuedCallbacks(ICorDebugThread pThread, out int pbQueued)
        {
            /*HRESULT HasQueuedCallbacks([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, out int pbQueued);*/
            return Raw.HasQueuedCallbacks(pThread, out pbQueued);
        }

        #endregion
        #region EnumerateThreads

        /// <summary>
        /// Gets an enumerator for the active managed threads in the process.
        /// </summary>
        /// <returns>[out] A pointer to the address of an "ICorDebugThreadEnum" object that represents an enumerator for all managed threads that are active in the process.</returns>
        /// <remarks>
        /// A thread is considered active after the <see cref="CorDebugManagedCallback.CreateThread"/> callback has been dispatched
        /// and before the <see cref="CorDebugManagedCallback.ExitThread"/> callback has been dispatched. A managed thread
        /// may not necessarily have any managed frames on its stack. Threads can be enumerated even before the <see cref="CorDebugManagedCallback.CreateProcess"/>
        /// callback. The enumeration will naturally be empty.
        /// </remarks>
        public CorDebugThreadEnum EnumerateThreads()
        {
            HRESULT hr;
            CorDebugThreadEnum ppThreadsResult;

            if ((hr = TryEnumerateThreads(out ppThreadsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppThreadsResult;
        }

        /// <summary>
        /// Gets an enumerator for the active managed threads in the process.
        /// </summary>
        /// <param name="ppThreadsResult">[out] A pointer to the address of an "ICorDebugThreadEnum" object that represents an enumerator for all managed threads that are active in the process.</param>
        /// <remarks>
        /// A thread is considered active after the <see cref="CorDebugManagedCallback.CreateThread"/> callback has been dispatched
        /// and before the <see cref="CorDebugManagedCallback.ExitThread"/> callback has been dispatched. A managed thread
        /// may not necessarily have any managed frames on its stack. Threads can be enumerated even before the <see cref="CorDebugManagedCallback.CreateProcess"/>
        /// callback. The enumeration will naturally be empty.
        /// </remarks>
        public HRESULT TryEnumerateThreads(out CorDebugThreadEnum ppThreadsResult)
        {
            /*HRESULT EnumerateThreads([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreads);*/
            ICorDebugThreadEnum ppThreads;
            HRESULT hr = Raw.EnumerateThreads(out ppThreads);

            if (hr == HRESULT.S_OK)
                ppThreadsResult = new CorDebugThreadEnum(ppThreads);
            else
                ppThreadsResult = default(CorDebugThreadEnum);

            return hr;
        }

        #endregion
        #region SetAllThreadsDebugState

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
        public void SetAllThreadsDebugState(CorDebugThreadState state, ICorDebugThread pExceptThisThread)
        {
            HRESULT hr;

            if ((hr = TrySetAllThreadsDebugState(state, pExceptThisThread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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
        public HRESULT TrySetAllThreadsDebugState(CorDebugThreadState state, ICorDebugThread pExceptThisThread)
        {
            /*HRESULT SetAllThreadsDebugState([In] CorDebugThreadState state, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pExceptThisThread);*/
            return Raw.SetAllThreadsDebugState(state, pExceptThisThread);
        }

        #endregion
        #region Detach

        /// <summary>
        /// Detaches the debugger from the process or application domain.
        /// </summary>
        /// <remarks>
        /// The process or application domain continues execution normally, but the "ICorDebugProcess" or "ICorDebugAppDomain"
        /// object is no longer valid and no further callbacks will occur. In the .NET Framework version 2.0, if unmanaged
        /// debugging is enabled, this method will fail due to operating system limitations.
        /// </remarks>
        public void Detach()
        {
            HRESULT hr;

            if ((hr = TryDetach()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Detaches the debugger from the process or application domain.
        /// </summary>
        /// <remarks>
        /// The process or application domain continues execution normally, but the "ICorDebugProcess" or "ICorDebugAppDomain"
        /// object is no longer valid and no further callbacks will occur. In the .NET Framework version 2.0, if unmanaged
        /// debugging is enabled, this method will fail due to operating system limitations.
        /// </remarks>
        public HRESULT TryDetach()
        {
            /*HRESULT Detach();*/
            return Raw.Detach();
        }

        #endregion
        #region Terminate

        /// <summary>
        /// Terminates the process with the specified exit code.
        /// </summary>
        /// <param name="exitCode">[in] A numeric value that is the exit code. The valid numeric values are defined in Winbase.h.</param>
        /// <remarks>
        /// If the process is stopped when Terminate is called, the process should be continued by using the <see cref="Continue"/>
        /// method so that the debugger receives confirmation of the termination through the <see cref="CorDebugManagedCallback.ExitProcess"/>
        /// or <see cref="CorDebugManagedCallback.ExitAppDomain"/> callback.
        /// </remarks>
        public void Terminate(int exitCode)
        {
            HRESULT hr;

            if ((hr = TryTerminate(exitCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Terminates the process with the specified exit code.
        /// </summary>
        /// <param name="exitCode">[in] A numeric value that is the exit code. The valid numeric values are defined in Winbase.h.</param>
        /// <remarks>
        /// If the process is stopped when Terminate is called, the process should be continued by using the <see cref="Continue"/>
        /// method so that the debugger receives confirmation of the termination through the <see cref="CorDebugManagedCallback.ExitProcess"/>
        /// or <see cref="CorDebugManagedCallback.ExitAppDomain"/> callback.
        /// </remarks>
        public HRESULT TryTerminate(int exitCode)
        {
            /*HRESULT Terminate([In] int exitCode);*/
            return Raw.Terminate(exitCode);
        }

        #endregion
        #region CanCommitChanges

        /// <summary>
        /// CanCommitChanges is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public CorDebugErrorInfoEnum CanCommitChanges(int cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots)
        {
            HRESULT hr;
            CorDebugErrorInfoEnum pErrorResult;

            if ((hr = TryCanCommitChanges(cSnapshots, pSnapshots, out pErrorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pErrorResult;
        }

        /// <summary>
        /// CanCommitChanges is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryCanCommitChanges(int cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots, out CorDebugErrorInfoEnum pErrorResult)
        {
            /*HRESULT CanCommitChanges(
            [In] int cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);*/
            ICorDebugErrorInfoEnum pError;
            HRESULT hr = Raw.CanCommitChanges(cSnapshots, ref pSnapshots, out pError);

            if (hr == HRESULT.S_OK)
                pErrorResult = new CorDebugErrorInfoEnum(pError);
            else
                pErrorResult = default(CorDebugErrorInfoEnum);

            return hr;
        }

        #endregion
        #region CommitChanges

        /// <summary>
        /// CommitChanges is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public CorDebugErrorInfoEnum CommitChanges(int cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots)
        {
            HRESULT hr;
            CorDebugErrorInfoEnum pErrorResult;

            if ((hr = TryCommitChanges(cSnapshots, pSnapshots, out pErrorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pErrorResult;
        }

        /// <summary>
        /// CommitChanges is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryCommitChanges(int cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots, out CorDebugErrorInfoEnum pErrorResult)
        {
            /*HRESULT CommitChanges(
            [In] int cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);*/
            ICorDebugErrorInfoEnum pError;
            HRESULT hr = Raw.CommitChanges(cSnapshots, ref pSnapshots, out pError);

            if (hr == HRESULT.S_OK)
                pErrorResult = new CorDebugErrorInfoEnum(pError);
            else
                pErrorResult = default(CorDebugErrorInfoEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}