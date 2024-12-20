namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_ACTIVE_EXCEPTIONS. Defines a means of getting the currently active exceptions on execution units or stored within post-mortem data associated with a process.
    /// </summary>
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

        /// <summary>
        /// Gets the last exception event for a particular process. For a post-mortem target, this is often the "reason" for a snapshot.<para/>
        /// Such exceptional event is represented by an ISvcExceptionInformation interface but may represent a Win32 exception, a Linux signal, or something else entirely.<para/>
        /// If there is no "last exception event", E_NOT_SET may be returned.
        /// </summary>
        public SvcExceptionInformation GetLastExceptionEvent(ISvcProcess pProcess)
        {
            SvcExceptionInformation exceptionInfoResult;
            TryGetLastExceptionEvent(pProcess, out exceptionInfoResult).ThrowDbgEngNotOK();

            return exceptionInfoResult;
        }

        /// <summary>
        /// Gets the last exception event for a particular process. For a post-mortem target, this is often the "reason" for a snapshot.<para/>
        /// Such exceptional event is represented by an ISvcExceptionInformation interface but may represent a Win32 exception, a Linux signal, or something else entirely.<para/>
        /// If there is no "last exception event", E_NOT_SET may be returned.
        /// </summary>
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

        /// <summary>
        /// Gets the active exception event for a particular execution unit. As with GetLastExceptionEvent, such exceptional event is represented by an ISvcExceptionInformation interface but may represent a Win32 exception, a Linux signal, or something else entirely.<para/>
        /// If there is no "active exception event", E_NOT_SET may be returned.
        /// </summary>
        public SvcExceptionInformation GetActiveExceptionEvent(ISvcExecutionUnit pExecutionUnit)
        {
            SvcExceptionInformation exceptionInfoResult;
            TryGetActiveExceptionEvent(pExecutionUnit, out exceptionInfoResult).ThrowDbgEngNotOK();

            return exceptionInfoResult;
        }

        /// <summary>
        /// Gets the active exception event for a particular execution unit. As with GetLastExceptionEvent, such exceptional event is represented by an ISvcExceptionInformation interface but may represent a Win32 exception, a Linux signal, or something else entirely.<para/>
        /// If there is no "active exception event", E_NOT_SET may be returned.
        /// </summary>
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
