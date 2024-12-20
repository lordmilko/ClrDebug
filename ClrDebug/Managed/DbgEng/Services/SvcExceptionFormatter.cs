namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_EXCEPTION_FORMATTER.
    /// </summary>
    public class SvcExceptionFormatter : ComObject<ISvcExceptionFormatter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcExceptionFormatter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcExceptionFormatter(ISvcExceptionFormatter raw) : base(raw)
        {
        }

        #region ISvcExceptionFormatter
        #region GetDescription

        /// <summary>
        /// Gets a description of the given exceptional event (Win32 exception, Linux signal, etc...).
        /// </summary>
        public string GetDescription(ISvcExceptionInformation exceptionInformation)
        {
            string exceptionDescription;
            TryGetDescription(exceptionInformation, out exceptionDescription).ThrowDbgEngNotOK();

            return exceptionDescription;
        }

        /// <summary>
        /// Gets a description of the given exceptional event (Win32 exception, Linux signal, etc...).
        /// </summary>
        public HRESULT TryGetDescription(ISvcExceptionInformation exceptionInformation, out string exceptionDescription)
        {
            /*HRESULT GetDescription(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExceptionInformation exceptionInformation,
            [Out, MarshalAs(UnmanagedType.BStr)] out string exceptionDescription);*/
            return Raw.GetDescription(exceptionInformation, out exceptionDescription);
        }

        #endregion
        #endregion
    }
}
