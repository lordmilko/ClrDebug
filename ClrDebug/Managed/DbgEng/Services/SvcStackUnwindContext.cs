using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class SvcStackUnwindContext : ComObject<ISvcStackUnwindContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackUnwindContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackUnwindContext(ISvcStackUnwindContext raw) : base(raw)
        {
        }

        #region ISvcStackUnwindContext
        #region Process

        public SvcProcess Process
        {
            get
            {
                SvcProcess processResult;
                TryGetProcess(out processResult).ThrowDbgEngNotOK();

                return processResult;
            }
        }

        public HRESULT TryGetProcess(out SvcProcess processResult)
        {
            /*HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);*/
            ISvcProcess process;
            HRESULT hr = Raw.GetProcess(out process);

            if (hr == HRESULT.S_OK)
                processResult = process == null ? null : new SvcProcess(process);
            else
                processResult = default(SvcProcess);

            return hr;
        }

        #endregion
        #region Thread

        public SvcThread Thread
        {
            get
            {
                SvcThread threadResult;
                TryGetThread(out threadResult).ThrowDbgEngNotOK();

                return threadResult;
            }
        }

        public HRESULT TryGetThread(out SvcThread threadResult)
        {
            /*HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);*/
            ISvcThread thread;
            HRESULT hr = Raw.GetThread(out thread);

            if (hr == HRESULT.S_OK)
                threadResult = thread == null ? null : new SvcThread(thread);
            else
                threadResult = default(SvcThread);

            return hr;
        }

        #endregion
        #region SetContextData

        public void SetContextData(object component, object contextData)
        {
            TrySetContextData(component, contextData).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetContextData(object component, object contextData)
        {
            /*HRESULT SetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [In, MarshalAs(UnmanagedType.Interface)] object contextData);*/
            return Raw.SetContextData(component, contextData);
        }

        #endregion
        #region GetContextData

        public object GetContextData(object component)
        {
            object contextData;
            TryGetContextData(component, out contextData).ThrowDbgEngNotOK();

            return contextData;
        }

        public HRESULT TryGetContextData(object component, out object contextData)
        {
            /*HRESULT GetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [Out, MarshalAs(UnmanagedType.Interface)] out object contextData);*/
            return Raw.GetContextData(component, out contextData);
        }

        #endregion
        #endregion
        #region ISvcStackUnwindContext2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISvcStackUnwindContext2 Raw2 => (ISvcStackUnwindContext2) Raw;

        #region ExecutionUnit

        public SvcExecutionUnit ExecutionUnit
        {
            get
            {
                SvcExecutionUnit execUnitResult;
                TryGetExecutionUnit(out execUnitResult).ThrowDbgEngNotOK();

                return execUnitResult;
            }
        }

        public HRESULT TryGetExecutionUnit(out SvcExecutionUnit execUnitResult)
        {
            /*HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit execUnit);*/
            ISvcExecutionUnit execUnit;
            HRESULT hr = Raw2.GetExecutionUnit(out execUnit);

            if (hr == HRESULT.S_OK)
                execUnitResult = execUnit == null ? null : new SvcExecutionUnit(execUnit);
            else
                execUnitResult = default(SvcExecutionUnit);

            return hr;
        }

        #endregion
        #endregion
        #region ISvcStackUnwindContext3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISvcStackUnwindContext3 Raw3 => (ISvcStackUnwindContext3) Raw;

        #region AddressContext

        public SvcAddressContext AddressContext
        {
            get
            {
                SvcAddressContext addressContextResult;
                TryGetAddressContext(out addressContextResult).ThrowDbgEngNotOK();

                return addressContextResult;
            }
        }

        public HRESULT TryGetAddressContext(out SvcAddressContext addressContextResult)
        {
            /*HRESULT GetAddressContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext addressContext);*/
            ISvcAddressContext addressContext;
            HRESULT hr = Raw3.GetAddressContext(out addressContext);

            if (hr == HRESULT.S_OK)
                addressContextResult = addressContext == null ? null : new SvcAddressContext(addressContext);
            else
                addressContextResult = default(SvcAddressContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
