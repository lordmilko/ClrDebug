namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetEnumerator : ComObject<ISvcSymbolSetEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetEnumerator(ISvcSymbolSetEnumerator raw) : base(raw)
        {
        }

        #region ISvcSymbolSetEnumerator
        #region Next

        public SvcSymbol Next
        {
            get
            {
                SvcSymbol symbolResult;
                TryGetNext(out symbolResult).ThrowDbgEngNotOK();

                return symbolResult;
            }
        }

        public HRESULT TryGetNext(out SvcSymbol symbolResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol);*/
            ISvcSymbol symbol;
            HRESULT hr = Raw.GetNext(out symbol);

            if (hr == HRESULT.S_OK)
                symbolResult = symbol == null ? null : new SvcSymbol(symbol);
            else
                symbolResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region Reset

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
