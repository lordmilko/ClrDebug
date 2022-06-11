using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public abstract class CorDebugHeapValue : CorDebugValue
    {
        public static CorDebugHeapValue New(ICorDebugHeapValue value)
        {
            if (value is ICorDebugArrayValue)
                return new CorDebugArrayValue((ICorDebugArrayValue) value);

            if (value is ICorDebugBoxValue)
                return new CorDebugBoxValue((ICorDebugBoxValue) value);

            if (value is ICorDebugStringValue)
                return new CorDebugStringValue((ICorDebugStringValue) value);

            throw new NotImplementedException("Encountered an ICorDebugHeapValue' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugHeapValue(ICorDebugHeapValue raw) : base(raw)
        {
        }

        #region ICorDebugHeapValue

        public new ICorDebugHeapValue Raw => (ICorDebugHeapValue) base.Raw;

        #region IsValid

        public int IsValid
        {
            get
            {
                HRESULT hr;
                int pbValid;

                if ((hr = TryIsValid(out pbValid)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbValid;
            }
        }

        public HRESULT TryIsValid(out int pbValid)
        {
            /*HRESULT IsValid(out int pbValid);*/
            return Raw.IsValid(out pbValid);
        }

        #endregion
        #region CreateRelocBreakpoint

        public CorDebugValueBreakpoint CreateRelocBreakpoint()
        {
            HRESULT hr;
            CorDebugValueBreakpoint ppBreakpointResult;

            if ((hr = TryCreateRelocBreakpoint(out ppBreakpointResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointResult;
        }

        public HRESULT TryCreateRelocBreakpoint(out CorDebugValueBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateRelocBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);*/
            ICorDebugValueBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateRelocBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugValueBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugValueBreakpoint);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugHeapValue2

        public new ICorDebugHeapValue2 Raw2 => (ICorDebugHeapValue2) Raw;

        #region CreateHandle

        public CorDebugHandleValue CreateHandle(CorDebugHandleType type)
        {
            HRESULT hr;
            CorDebugHandleValue ppHandleResult;

            if ((hr = TryCreateHandle(type, out ppHandleResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppHandleResult;
        }

        public HRESULT TryCreateHandle(CorDebugHandleType type, out CorDebugHandleValue ppHandleResult)
        {
            /*HRESULT CreateHandle([In] CorDebugHandleType type,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugHandleValue ppHandle);*/
            ICorDebugHandleValue ppHandle;
            HRESULT hr = Raw2.CreateHandle(type, out ppHandle);

            if (hr == HRESULT.S_OK)
                ppHandleResult = new CorDebugHandleValue(ppHandle);
            else
                ppHandleResult = default(CorDebugHandleValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugHeapValue3

        public new ICorDebugHeapValue3 Raw3 => (ICorDebugHeapValue3) Raw;

        #region GetThreadOwningMonitorLock

        public GetThreadOwningMonitorLockResult ThreadOwningMonitorLock
        {
            get
            {
                HRESULT hr;
                GetThreadOwningMonitorLockResult result;

                if ((hr = TryGetThreadOwningMonitorLock(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetThreadOwningMonitorLock(out GetThreadOwningMonitorLockResult result)
        {
            /*HRESULT GetThreadOwningMonitorLock([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread,
            out uint pAcquisitionCount);*/
            ICorDebugThread ppThread;
            uint pAcquisitionCount;
            HRESULT hr = Raw3.GetThreadOwningMonitorLock(out ppThread, out pAcquisitionCount);

            if (hr == HRESULT.S_OK)
                result = new GetThreadOwningMonitorLockResult(new CorDebugThread(ppThread), pAcquisitionCount);
            else
                result = default(GetThreadOwningMonitorLockResult);

            return hr;
        }

        #endregion
        #region GetMonitorEventWaitList

        public CorDebugThreadEnum MonitorEventWaitList
        {
            get
            {
                HRESULT hr;
                CorDebugThreadEnum ppThreadEnumResult;

                if ((hr = TryGetMonitorEventWaitList(out ppThreadEnumResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppThreadEnumResult;
            }
        }

        public HRESULT TryGetMonitorEventWaitList(out CorDebugThreadEnum ppThreadEnumResult)
        {
            /*HRESULT GetMonitorEventWaitList([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreadEnum);*/
            ICorDebugThreadEnum ppThreadEnum;
            HRESULT hr = Raw3.GetMonitorEventWaitList(out ppThreadEnum);

            if (hr == HRESULT.S_OK)
                ppThreadEnumResult = new CorDebugThreadEnum(ppThreadEnum);
            else
                ppThreadEnumResult = default(CorDebugThreadEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}