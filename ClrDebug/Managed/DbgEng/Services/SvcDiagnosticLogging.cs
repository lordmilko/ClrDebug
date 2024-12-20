namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_DIAGNOSTIC_LOGGING.
    /// </summary>
    public class SvcDiagnosticLogging : ComObject<ISvcDiagnosticLogging>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDiagnosticLogging"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDiagnosticLogging(ISvcDiagnosticLogging raw) : base(raw)
        {
        }

        #region ISvcDiagnosticLogging
        #region Log

        /// <summary>
        /// Sends a message to a diagnostic logging sink. What the host does with the log message is entirely up to it.
        /// </summary>
        public void Log(DiagnosticLogLevel level, string logMessage, string component, string category)
        {
            TryLog(level, logMessage, component, category).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Sends a message to a diagnostic logging sink. What the host does with the log message is entirely up to it.
        /// </summary>
        public HRESULT TryLog(DiagnosticLogLevel level, string logMessage, string component, string category)
        {
            /*HRESULT Log(
            [In] DiagnosticLogLevel level,
            [In, MarshalAs(UnmanagedType.LPWStr)] string logMessage,
            [In, MarshalAs(UnmanagedType.LPWStr)] string component,
            [In, MarshalAs(UnmanagedType.LPWStr)] string category);*/
            return Raw.Log(level, logMessage, component, category);
        }

        #endregion
        #endregion
    }
}
