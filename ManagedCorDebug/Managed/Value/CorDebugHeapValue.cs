using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of "ICorDebugValue" that represents an object that has been collected by the common language runtime (CLR) garbage collector.
    /// </summary>
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

        /// <summary>
        /// Gets a value that indicates whether the object represented by this <see cref="ICorDebugHeapValue"/> is valid. This method has been deprecated in the .NET Framework version 2.0.
        /// </summary>
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

        /// <summary>
        /// Gets a value that indicates whether the object represented by this <see cref="ICorDebugHeapValue"/> is valid. This method has been deprecated in the .NET Framework version 2.0.
        /// </summary>
        /// <param name="pbValid">[out] A pointer to a Boolean value that indicates whether this value on the heap is valid.</param>
        /// <remarks>
        /// The value is invalid if it has been reclaimed by the garbage collector. This method has been deprecated. In the
        /// .NET Framework 2.0, all values are valid until <see cref="CorDebugController.Continue"/> is called, at which time
        /// the values are invalidated.
        /// </remarks>
        public HRESULT TryIsValid(out int pbValid)
        {
            /*HRESULT IsValid(out int pbValid);*/
            return Raw.IsValid(out pbValid);
        }

        #endregion
        #region CreateRelocBreakpoint

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        public CorDebugValueBreakpoint CreateRelocBreakpoint()
        {
            HRESULT hr;
            CorDebugValueBreakpoint ppBreakpointResult;

            if ((hr = TryCreateRelocBreakpoint(out ppBreakpointResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointResult;
        }

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new ICorDebugHeapValue2 Raw2 => (ICorDebugHeapValue2) Raw;

        #region CreateHandle

        /// <summary>
        /// Creates a handle of the specified type for the heap value represented by this <see cref="ICorDebugHeapValue2"/> object.
        /// </summary>
        /// <param name="type">[in] A value of the <see cref="CorDebugHandleType"/> enumeration that specifies the type of handle to be created.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugHandleValue"/> object that represents the new handle for this heap value.</returns>
        /// <remarks>
        /// The handle will be created in the application domain that is associated with the heap value, and will become invalid
        /// if the application domain gets unloaded. Multiple calls to this function for the same heap value will create multiple
        /// handles. Because handles affect the performance of the garbage collector, the debugger should limit itself to a
        /// relatively small number of handles (about 256) that are active at a time.
        /// </remarks>
        public CorDebugHandleValue CreateHandle(CorDebugHandleType type)
        {
            HRESULT hr;
            CorDebugHandleValue ppHandleResult;

            if ((hr = TryCreateHandle(type, out ppHandleResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppHandleResult;
        }

        /// <summary>
        /// Creates a handle of the specified type for the heap value represented by this <see cref="ICorDebugHeapValue2"/> object.
        /// </summary>
        /// <param name="type">[in] A value of the <see cref="CorDebugHandleType"/> enumeration that specifies the type of handle to be created.</param>
        /// <param name="ppHandleResult">[out] A pointer to the address of an <see cref="ICorDebugHandleValue"/> object that represents the new handle for this heap value.</param>
        /// <remarks>
        /// The handle will be created in the application domain that is associated with the heap value, and will become invalid
        /// if the application domain gets unloaded. Multiple calls to this function for the same heap value will create multiple
        /// handles. Because handles affect the performance of the garbage collector, the debugger should limit itself to a
        /// relatively small number of handles (about 256) that are active at a time.
        /// </remarks>
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new ICorDebugHeapValue3 Raw3 => (ICorDebugHeapValue3) Raw;

        #region ThreadOwningMonitorLock

        /// <summary>
        /// Returns the managed thread that owns the monitor lock on this object.
        /// </summary>
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

        /// <summary>
        /// Returns the managed thread that owns the monitor lock on this object.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                                             |
        /// | ------- | ------------------------------------------------------- |
        /// | S_OK    | The method completed successfully.                      |
        /// | S_FALSE | No managed thread owns the monitor lock on this object. |
        /// </returns>
        /// <remarks>
        /// If a managed thread owns the monitor lock on this object: If no managed thread owns the monitor lock on this object,
        /// ppThread and pAcquisitionCount are unchanged, and the method returns S_FALSE. If ppThread or pAcquisitionCount
        /// is not a valid pointer, the result is undefined. If an error occurs such that it cannot be determined which, if
        /// any, thread owns the monitor lock on this object, the method returns an <see cref="HRESULT"/> that indicates failure.
        /// </remarks>
        public HRESULT TryGetThreadOwningMonitorLock(out GetThreadOwningMonitorLockResult result)
        {
            /*HRESULT GetThreadOwningMonitorLock([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread,
            out int pAcquisitionCount);*/
            ICorDebugThread ppThread;
            int pAcquisitionCount;
            HRESULT hr = Raw3.GetThreadOwningMonitorLock(out ppThread, out pAcquisitionCount);

            if (hr == HRESULT.S_OK)
                result = new GetThreadOwningMonitorLockResult(new CorDebugThread(ppThread), pAcquisitionCount);
            else
                result = default(GetThreadOwningMonitorLockResult);

            return hr;
        }

        #endregion
        #region MonitorEventWaitList

        /// <summary>
        /// Provides an ordered list of threads that are queued on the event that is associated with a monitor lock.
        /// </summary>
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

        /// <summary>
        /// Provides an ordered list of threads that are queued on the event that is associated with a monitor lock.
        /// </summary>
        /// <param name="ppThreadEnumResult">[out] The <see cref="ICorDebugThreadEnum"/> enumerator that provides the ordered list of threads.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description            |
        /// | ------- | ---------------------- |
        /// | S_OK    | The list is not empty. |
        /// | S_FALSE | The list is empty.     |
        /// </returns>
        /// <remarks>
        /// The first thread in the list is the first thread that is released by the next call to <see cref="Monitor.Pulse(System.Object)"/>.
        /// The next thread in the list is released on the following call, and so on. If the list is not empty, this method
        /// returns S_OK. If the list is empty, the method returns S_FALSE; in this case, the enumeration is still valid, although
        /// it is empty. In either case, the enumeration interface is usable only for the duration of the current synchronized
        /// state. However, the thread's interfaces dispensed from it are valid until the thread exits. If ppThreadEnum is
        /// not a valid pointer, the result is undefined. If an error occurs such that it cannot be determined which, if any,
        /// threads are waiting for the monitor, the method returns an <see cref="HRESULT"/> that indicates failure.
        /// </remarks>
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