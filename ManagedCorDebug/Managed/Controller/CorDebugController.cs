using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
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

        protected CorDebugController(ICorDebugController raw) : base(raw)
        {
        }

        #region ICorDebugController
        #region IsRunning

        public int IsRunning
        {
            get
            {
                HRESULT hr;
                int pbRunning;

                if ((hr = TryIsRunning(out pbRunning)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbRunning;
            }
        }

        public HRESULT TryIsRunning(out int pbRunning)
        {
            /*HRESULT IsRunning(out int pbRunning);*/
            return Raw.IsRunning(out pbRunning);
        }

        #endregion
        #region Stop

        public void Stop(uint dwTimeoutIgnored)
        {
            HRESULT hr;

            if ((hr = TryStop(dwTimeoutIgnored)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStop(uint dwTimeoutIgnored)
        {
            /*HRESULT Stop([In] uint dwTimeoutIgnored);*/
            return Raw.Stop(dwTimeoutIgnored);
        }

        #endregion
        #region Continue

        public void Continue(int fIsOutOfBand)
        {
            HRESULT hr;

            if ((hr = TryContinue(fIsOutOfBand)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryContinue(int fIsOutOfBand)
        {
            /*HRESULT Continue([In] int fIsOutOfBand);*/
            return Raw.Continue(fIsOutOfBand);
        }

        #endregion
        #region HasQueuedCallbacks

        public int HasQueuedCallbacks(ICorDebugThread pThread)
        {
            HRESULT hr;
            int pbQueued;

            if ((hr = TryHasQueuedCallbacks(pThread, out pbQueued)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbQueued;
        }

        public HRESULT TryHasQueuedCallbacks(ICorDebugThread pThread, out int pbQueued)
        {
            /*HRESULT HasQueuedCallbacks([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, out int pbQueued);*/
            return Raw.HasQueuedCallbacks(pThread, out pbQueued);
        }

        #endregion
        #region EnumerateThreads

        public CorDebugThreadEnum EnumerateThreads()
        {
            HRESULT hr;
            CorDebugThreadEnum ppThreadsResult;

            if ((hr = TryEnumerateThreads(out ppThreadsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppThreadsResult;
        }

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

        public void SetAllThreadsDebugState(CorDebugThreadState state, ICorDebugThread pExceptThisThread)
        {
            HRESULT hr;

            if ((hr = TrySetAllThreadsDebugState(state, pExceptThisThread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetAllThreadsDebugState(CorDebugThreadState state, ICorDebugThread pExceptThisThread)
        {
            /*HRESULT SetAllThreadsDebugState([In] CorDebugThreadState state, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pExceptThisThread);*/
            return Raw.SetAllThreadsDebugState(state, pExceptThisThread);
        }

        #endregion
        #region Detach

        public void Detach()
        {
            HRESULT hr;

            if ((hr = TryDetach()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDetach()
        {
            /*HRESULT Detach();*/
            return Raw.Detach();
        }

        #endregion
        #region Terminate

        public void Terminate(uint exitCode)
        {
            HRESULT hr;

            if ((hr = TryTerminate(exitCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTerminate(uint exitCode)
        {
            /*HRESULT Terminate([In] uint exitCode);*/
            return Raw.Terminate(exitCode);
        }

        #endregion
        #region CanCommitChanges

        [Obsolete]
        public CorDebugErrorInfoEnum CanCommitChanges(uint cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots)
        {
            HRESULT hr;
            CorDebugErrorInfoEnum pErrorResult;

            if ((hr = TryCanCommitChanges(cSnapshots, pSnapshots, out pErrorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pErrorResult;
        }

        [Obsolete]
        public HRESULT TryCanCommitChanges(uint cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots, out CorDebugErrorInfoEnum pErrorResult)
        {
            /*HRESULT CanCommitChanges(
            [In] uint cSnapshots,
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

        [Obsolete]
        public CorDebugErrorInfoEnum CommitChanges(uint cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots)
        {
            HRESULT hr;
            CorDebugErrorInfoEnum pErrorResult;

            if ((hr = TryCommitChanges(cSnapshots, pSnapshots, out pErrorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pErrorResult;
        }

        [Obsolete]
        public HRESULT TryCommitChanges(uint cSnapshots, ICorDebugEditAndContinueSnapshot pSnapshots, out CorDebugErrorInfoEnum pErrorResult)
        {
            /*HRESULT CommitChanges(
            [In] uint cSnapshots,
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