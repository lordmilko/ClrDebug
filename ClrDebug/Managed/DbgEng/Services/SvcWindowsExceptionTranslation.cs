namespace ClrDebug.DbgEng
{
    public class SvcWindowsExceptionTranslation : ComObject<ISvcWindowsExceptionTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcWindowsExceptionTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcWindowsExceptionTranslation(ISvcWindowsExceptionTranslation raw) : base(raw)
        {
        }

        #region ISvcWindowsExceptionTranslation
        #region TranslateException

        /// <summary>
        /// Translates the exception from one record to another. It is legal for this method to do absolutely nothing other than succeed (or return an S_FALSE indication of no translation).
        /// </summary>
        public void TranslateException(ISvcExecutionUnit execUnit, ref EXCEPTION_RECORD64 exceptionRecord)
        {
            TryTranslateException(execUnit, ref exceptionRecord).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Translates the exception from one record to another. It is legal for this method to do absolutely nothing other than succeed (or return an S_FALSE indication of no translation).
        /// </summary>
        public HRESULT TryTranslateException(ISvcExecutionUnit execUnit, ref EXCEPTION_RECORD64 exceptionRecord)
        {
            /*HRESULT TranslateException(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In, Out] ref EXCEPTION_RECORD64 exceptionRecord);*/
            return Raw.TranslateException(execUnit, ref exceptionRecord);
        }

        #endregion
        #endregion
    }
}
