namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a lexical scope within code at a particular stack frame defined by its context record. An implementation of ISvcSymbolSetScopeFrame *MUST* QI for ISvcSymbolSetScope.
    /// </summary>
    public class SvcSymbolSetScopeFrame : ComObject<ISvcSymbolSetScopeFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetScopeFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetScopeFrame(ISvcSymbolSetScopeFrame raw) : base(raw)
        {
        }

        #region ISvcSymbolSetScopeFrame
        #region GetContext

        /// <summary>
        /// Gets the context for the scope frame.
        /// </summary>
        public SvcRegisterContext GetContext(SvcContextFlags contextFlags)
        {
            SvcRegisterContext registerContextResult;
            TryGetContext(contextFlags, out registerContextResult).ThrowDbgEngNotOK();

            return registerContextResult;
        }

        /// <summary>
        /// Gets the context for the scope frame.
        /// </summary>
        public HRESULT TryGetContext(SvcContextFlags contextFlags, out SvcRegisterContext registerContextResult)
        {
            /*HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext registerContext);*/
            ISvcRegisterContext registerContext;
            HRESULT hr = Raw.GetContext(contextFlags, out registerContext);

            if (hr == HRESULT.S_OK)
                registerContextResult = registerContext == null ? null : new SvcRegisterContext(registerContext);
            else
                registerContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
