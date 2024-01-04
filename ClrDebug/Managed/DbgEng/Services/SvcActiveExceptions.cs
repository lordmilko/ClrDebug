namespace ClrDebug.DbgEng
{
    public class SvcActiveExceptions : ComObject<ISvcActiveExceptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcActiveExceptions"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcActiveExceptions(ISvcActiveExceptions raw) : base(raw)
        {
        }

        #region ISvcActiveExceptions
        #region GetLastExceptionEvent

        public SvcExceptionInformation GetLastExceptionEvent(ISvcProcess pProcess)
        {
            SvcExceptionInformation exceptionInfoResult;
            TryGetLastExceptionEvent(pProcess, out exceptionInfoResult).ThrowDbgEngNotOK();

            return exceptionInfoResult;
        }

        public HRESULT TryGetLastExceptionEvent(ISvcProcess pProcess, out SvcExceptionInformation exceptionInfoResult)
        {
            /*HRESULT GetLastExceptionEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExceptionInformation exceptionInfo);*/
            ISvcExceptionInformation exceptionInfo;
            HRESULT hr = Raw.GetLastExceptionEvent(pProcess, out exceptionInfo);

            if (hr == HRESULT.S_OK)
                exceptionInfoResult = exceptionInfo == null ? null : new SvcExceptionInformation(exceptionInfo);
            else
                exceptionInfoResult = default(SvcExceptionInformation);

            return hr;
        }

        #endregion
        #region GetActiveExceptionEvent

        public SvcExceptionInformation GetActiveExceptionEvent(ISvcExecutionUnit pExecutionUnit)
        {
            SvcExceptionInformation exceptionInfoResult;
            TryGetActiveExceptionEvent(pExecutionUnit, out exceptionInfoResult).ThrowDbgEngNotOK();

            return exceptionInfoResult;
        }

        public HRESULT TryGetActiveExceptionEvent(ISvcExecutionUnit pExecutionUnit, out SvcExceptionInformation exceptionInfoResult)
        {
            /*HRESULT GetActiveExceptionEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pExecutionUnit,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExceptionInformation exceptionInfo);*/
            ISvcExceptionInformation exceptionInfo;
            HRESULT hr = Raw.GetActiveExceptionEvent(pExecutionUnit, out exceptionInfo);

            if (hr == HRESULT.S_OK)
                exceptionInfoResult = exceptionInfo == null ? null : new SvcExceptionInformation(exceptionInfo);
            else
                exceptionInfoResult = default(SvcExceptionInformation);

            return hr;
        }

        #endregion
        #endregion
    }
}
