namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetSimpleNameResolution : ComObject<ISvcSymbolSetSimpleNameResolution>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetSimpleNameResolution"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetSimpleNameResolution(ISvcSymbolSetSimpleNameResolution raw) : base(raw)
        {
        }

        #region ISvcSymbolSetSimpleNameResolution
        #region FindSymbolByName

        public SvcSymbol FindSymbolByName(string symbolName)
        {
            SvcSymbol symbolResult;
            TryFindSymbolByName(symbolName, out symbolResult).ThrowDbgEngNotOK();

            return symbolResult;
        }

        public HRESULT TryFindSymbolByName(string symbolName, out SvcSymbol symbolResult)
        {
            /*HRESULT FindSymbolByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string symbolName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol);*/
            ISvcSymbol symbol;
            HRESULT hr = Raw.FindSymbolByName(symbolName, out symbol);

            if (hr == HRESULT.S_OK)
                symbolResult = symbol == null ? null : new SvcSymbol(symbol);
            else
                symbolResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region FindSymbolByOffset

        public FindSymbolByOffsetResult FindSymbolByOffset(long moduleOffset, bool exactMatchOnly)
        {
            FindSymbolByOffsetResult result;
            TryFindSymbolByOffset(moduleOffset, exactMatchOnly, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryFindSymbolByOffset(long moduleOffset, bool exactMatchOnly, out FindSymbolByOffsetResult result)
        {
            /*HRESULT FindSymbolByOffset(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.U1)] bool exactMatchOnly,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol,
            [Out] out long symbolOffset);*/
            ISvcSymbol symbol;
            long symbolOffset;
            HRESULT hr = Raw.FindSymbolByOffset(moduleOffset, exactMatchOnly, out symbol, out symbolOffset);

            if (hr == HRESULT.S_OK)
                result = new FindSymbolByOffsetResult(symbol == null ? null : new SvcSymbol(symbol), symbolOffset);
            else
                result = default(FindSymbolByOffsetResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
