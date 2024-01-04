namespace ClrDebug.DbgEng
{
    public class SvcDiagnosticLoggableControl : ComObject<ISvcDiagnosticLoggableControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDiagnosticLoggableControl"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDiagnosticLoggableControl(ISvcDiagnosticLoggableControl raw) : base(raw)
        {
        }

        #region ISvcDiagnosticLoggableControl
        #region LoggingLevel

        public DiagnosticLogLevel LoggingLevel
        {
            get
            {
                /*DiagnosticLogLevel GetLoggingLevel();*/
                return Raw.GetLoggingLevel();
            }
            set
            {
                /*void SetLoggingLevel(
            [In] DiagnosticLogLevel level);*/
                Raw.SetLoggingLevel(value);
            }
        }

        #endregion
        #endregion
    }
}
