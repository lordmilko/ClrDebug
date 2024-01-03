using System;
using System.Diagnostics;
using System.Threading;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of "ICorDebugValue" that represents an object that has been collected by the common language runtime (CLR) garbage collector.
    /// </summary>
    public abstract class CorDebugHeapValue : CorDebugValue
    {
        public static CorDebugHeapValue New(ICorDebugHeapValue value)
        {
            if (value == null)
                return null;

            if (value is ICorDebugArrayValue)
                return new CorDebugArrayValue((ICorDebugArrayValue) value);

            if (value is ICorDebugBoxValue)
                return new CorDebugBoxValue((ICorDebugBoxValue) value);

            if (value is ICorDebugStringValue)
                return new CorDebugStringValue((ICorDebugStringValue) value);

            throw new NotImplementedException("Encountered an 'ICorDebugHeapValue' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugHeapValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugHeapValue(ICorDebugHeapValue raw) : base(raw)
        {
        }

        #region ICorDebugHeapValue

        public new ICorDebugHeapValue Raw => (ICorDebugHeapValue) base.Raw;

        #region IsValid

        /// <summary>
        /// Gets a value that indicates whether the object represented by this <see cref="ICorDebugHeapValue"/> is valid. This method has been deprecated in the .NET Framework version 2.0.
        /// </summary>
        public bool IsValid
        {
            get
            {
                bool pbValid;
                TryIsValid(out pbValid).ThrowOnNotOK();

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
        public HRESULT TryIsValid(out bool pbValid)
        {
            /*HRESULT IsValid(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbValid);*/
            return Raw.IsValid(out pbValid);
        }

        #endregion
        #region CreateRelocBreakpoint

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        public CorDebugValueBreakpoint CreateRelocBreakpoint()
        {
            CorDebugValueBreakpoint ppBreakpointResult;
            TryCreateRelocBreakpoint(out ppBreakpointResult).ThrowOnNotOK();

            return ppBreakpointResult;
        }

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        public HRESULT TryCreateRelocBreakpoint(out CorDebugValueBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateRelocBreakpoint(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);*/
            ICorDebugValueBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateRelocBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = ppBreakpoint == null ? null : new CorDebugValueBreakpoint(ppBreakpoint);
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
            CorDebugHandleValue ppHandleResult;
            TryCreateHandle(type, out ppHandleResult).ThrowOnNotOK();

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
            /*HRESULT CreateHandle(
            [In] CorDebugHandleType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugHandleValue ppHandle);*/
            ICorDebugHandleValue ppHandle;
            HRESULT hr = Raw2.CreateHandle(type, out ppHandle);

            if (hr == HRESULT.S_OK)
                ppHandleResult = ppHandle == null ? null : new CorDebugHandleValue(ppHandle);
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
                GetThreadOwningMonitorLockResult result;
                TryGetThreadOwningMonitorLock(out result).ThrowOnNotOK();

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
            /*HRESULT GetThreadOwningMonitorLock(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread,
            [Out] out int pAcquisitionCount);*/
            ICorDebugThread ppThread;
            int pAcquisitionCount;
            HRESULT hr = Raw3.GetThreadOwningMonitorLock(out ppThread, out pAcquisitionCount);

            if (hr == HRESULT.S_OK)
                result = new GetThreadOwningMonitorLockResult(ppThread == null ? null : new CorDebugThread(ppThread), pAcquisitionCount);
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
                CorDebugThreadEnum ppThreadEnumResult;
                TryGetMonitorEventWaitList(out ppThreadEnumResult).ThrowOnNotOK();

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
            /*HRESULT GetMonitorEventWaitList(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreadEnum);*/
            ICorDebugThreadEnum ppThreadEnum;
            HRESULT hr = Raw3.GetMonitorEventWaitList(out ppThreadEnum);

            if (hr == HRESULT.S_OK)
                ppThreadEnumResult = ppThreadEnum == null ? null : new CorDebugThreadEnum(ppThreadEnum);
            else
                ppThreadEnumResult = default(CorDebugThreadEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}
