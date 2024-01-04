namespace ClrDebug.DbgEng
{
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

        public string GetDescription(ISvcExceptionInformation exceptionInformation)
        {
            string exceptionDescription;
            TryGetDescription(exceptionInformation, out exceptionDescription).ThrowDbgEngNotOK();

            return exceptionDescription;
        }

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
