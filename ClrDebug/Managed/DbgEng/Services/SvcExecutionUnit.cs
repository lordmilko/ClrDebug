namespace ClrDebug.DbgEng
{
    public class SvcExecutionUnit : ComObject<ISvcExecutionUnit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcExecutionUnit"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcExecutionUnit(ISvcExecutionUnit raw) : base(raw)
        {
        }

        #region ISvcExecutionUnit
        #region GetContext

        public SvcRegisterContext GetContext(SvcContextFlags contextFlags)
        {
            SvcRegisterContext ppRegisterContextResult;
            TryGetContext(contextFlags, out ppRegisterContextResult).ThrowDbgEngNotOK();

            return ppRegisterContextResult;
        }

        public HRESULT TryGetContext(SvcContextFlags contextFlags, out SvcRegisterContext ppRegisterContextResult)
        {
            /*HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);*/
            ISvcRegisterContext ppRegisterContext;
            HRESULT hr = Raw.GetContext(contextFlags, out ppRegisterContext);

            if (hr == HRESULT.S_OK)
                ppRegisterContextResult = ppRegisterContext == null ? null : new SvcRegisterContext(ppRegisterContext);
            else
                ppRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region SetContext

        public void SetContext(SvcContextFlags contextFlags, ISvcRegisterContext pRegisterContext)
        {
            TrySetContext(contextFlags, pRegisterContext).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetContext(SvcContextFlags contextFlags, ISvcRegisterContext pRegisterContext)
        {
            /*HRESULT SetContext(
            [In] SvcContextFlags contextFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pRegisterContext);*/
            return Raw.SetContext(contextFlags, pRegisterContext);
        }

        #endregion
        #endregion
    }
}
