namespace ClrDebug.DbgEng
{
    public class SvcSymbolSet : ComObject<ISvcSymbolSet>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSet"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSet(ISvcSymbolSet raw) : base(raw)
        {
        }

        #region ISvcSymbolSet
        #region GetSymbolById

        public SvcSymbol GetSymbolById(long symbolId)
        {
            SvcSymbol ppSymbolResult;
            TryGetSymbolById(symbolId, out ppSymbolResult).ThrowDbgEngNotOK();

            return ppSymbolResult;
        }

        public HRESULT TryGetSymbolById(long symbolId, out SvcSymbol ppSymbolResult)
        {
            /*HRESULT GetSymbolById(
            [In] long symbolId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppSymbol);*/
            ISvcSymbol ppSymbol;
            HRESULT hr = Raw.GetSymbolById(symbolId, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new SvcSymbol(ppSymbol);
            else
                ppSymbolResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region EnumerateAllSymbols

        public SvcSymbolSetEnumerator EnumerateAllSymbols()
        {
            SvcSymbolSetEnumerator ppEnumeratorResult;
            TryEnumerateAllSymbols(out ppEnumeratorResult).ThrowDbgEngNotOK();

            return ppEnumeratorResult;
        }

        public HRESULT TryEnumerateAllSymbols(out SvcSymbolSetEnumerator ppEnumeratorResult)
        {
            /*HRESULT EnumerateAllSymbols(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator ppEnumerator);*/
            ISvcSymbolSetEnumerator ppEnumerator;
            HRESULT hr = Raw.EnumerateAllSymbols(out ppEnumerator);

            if (hr == HRESULT.S_OK)
                ppEnumeratorResult = ppEnumerator == null ? null : new SvcSymbolSetEnumerator(ppEnumerator);
            else
                ppEnumeratorResult = default(SvcSymbolSetEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
