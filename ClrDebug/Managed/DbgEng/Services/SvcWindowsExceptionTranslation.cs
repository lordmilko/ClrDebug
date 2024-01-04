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

        public void TranslateException(ISvcExecutionUnit execUnit, ref EXCEPTION_RECORD64 exceptionRecord)
        {
            TryTranslateException(execUnit, ref exceptionRecord).ThrowDbgEngNotOK();
        }

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
