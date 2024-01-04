namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetScopeResolution : ComObject<ISvcSymbolSetScopeResolution>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetScopeResolution"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetScopeResolution(ISvcSymbolSetScopeResolution raw) : base(raw)
        {
        }

        #region ISvcSymbolSetScopeResolution
        #region GlobalScope

        public SvcSymbolSetScope GlobalScope
        {
            get
            {
                SvcSymbolSetScope scopeResult;
                TryGetGlobalScope(out scopeResult).ThrowDbgEngNotOK();

                return scopeResult;
            }
        }

        public HRESULT TryGetGlobalScope(out SvcSymbolSetScope scopeResult)
        {
            /*HRESULT GetGlobalScope(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);*/
            ISvcSymbolSetScope scope;
            HRESULT hr = Raw.GetGlobalScope(out scope);

            if (hr == HRESULT.S_OK)
                scopeResult = scope == null ? null : new SvcSymbolSetScope(scope);
            else
                scopeResult = default(SvcSymbolSetScope);

            return hr;
        }

        #endregion
        #region FindScopeByOffset

        public SvcSymbolSetScope FindScopeByOffset(long moduleOffset)
        {
            SvcSymbolSetScope scopeResult;
            TryFindScopeByOffset(moduleOffset, out scopeResult).ThrowDbgEngNotOK();

            return scopeResult;
        }

        public HRESULT TryFindScopeByOffset(long moduleOffset, out SvcSymbolSetScope scopeResult)
        {
            /*HRESULT FindScopeByOffset(
            [In] long moduleOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);*/
            ISvcSymbolSetScope scope;
            HRESULT hr = Raw.FindScopeByOffset(moduleOffset, out scope);

            if (hr == HRESULT.S_OK)
                scopeResult = scope == null ? null : new SvcSymbolSetScope(scope);
            else
                scopeResult = default(SvcSymbolSetScope);

            return hr;
        }

        #endregion
        #region FindScopeFrame

        public SvcSymbolSetScopeFrame FindScopeFrame(ISvcProcess process, ISvcRegisterContext registerContext)
        {
            SvcSymbolSetScopeFrame scopeFrameResult;
            TryFindScopeFrame(process, registerContext, out scopeFrameResult).ThrowDbgEngNotOK();

            return scopeFrameResult;
        }

        public HRESULT TryFindScopeFrame(ISvcProcess process, ISvcRegisterContext registerContext, out SvcSymbolSetScopeFrame scopeFrameResult)
        {
            /*HRESULT FindScopeFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScopeFrame scopeFrame);*/
            ISvcSymbolSetScopeFrame scopeFrame;
            HRESULT hr = Raw.FindScopeFrame(process, registerContext, out scopeFrame);

            if (hr == HRESULT.S_OK)
                scopeFrameResult = scopeFrame == null ? null : new SvcSymbolSetScopeFrame(scopeFrame);
            else
                scopeFrameResult = default(SvcSymbolSetScopeFrame);

            return hr;
        }

        #endregion
        #endregion
    }
}
