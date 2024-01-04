namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to which errors will be sinked. An interface implemented by callers to receive errors from certain portions of the host and data model.
    /// </summary>
    public class DebugHostErrorSink : ComObject<IDebugHostErrorSink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostErrorSink"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostErrorSink(IDebugHostErrorSink raw) : base(raw)
        {
        }

        #region IDebugHostErrorSink
        #region ReportError

        /// <summary>
        /// The ReportError method is a callback on the error sink to notify it that an error has occurred and allow the sink to route the error to whatever UI or mechanism is appropriate.
        /// </summary>
        /// <param name="errClass">An enumeration of type ErrorClass which indicates what class the error is (e.g.: warning or error)</param>
        /// <param name="hrError">The HRESULT of the error which occurred.</param>
        /// <param name="message">An optional message associated with the error.</param>
        public void ReportError(ErrorClass errClass, HRESULT hrError, string message)
        {
            TryReportError(errClass, hrError, message).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ReportError method is a callback on the error sink to notify it that an error has occurred and allow the sink to route the error to whatever UI or mechanism is appropriate.
        /// </summary>
        /// <param name="errClass">An enumeration of type ErrorClass which indicates what class the error is (e.g.: warning or error)</param>
        /// <param name="hrError">The HRESULT of the error which occurred.</param>
        /// <param name="message">An optional message associated with the error.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryReportError(ErrorClass errClass, HRESULT hrError, string message)
        {
            /*HRESULT ReportError(
            [In] ErrorClass errClass,
            [In] HRESULT hrError,
            [In, MarshalAs(UnmanagedType.LPWStr)] string message);*/
            return Raw.ReportError(errClass, hrError, message);
        }

        #endregion
        #endregion
    }
}
