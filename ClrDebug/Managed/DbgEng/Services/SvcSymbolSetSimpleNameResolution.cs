namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a "simple interface" around the mapping of symbol names to addresses within the image and vice-versa.<para/>
    /// All symbol sets are required to support this basic level of symbol resolution. Interfaces beyond this are optional depending on the capabilities of the provider.
    /// </summary>
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

        /// <summary>
        /// Finds symbolic information for a given name. The method fails if the symbol cannot be located.
        /// </summary>
        public SvcSymbol FindSymbolByName(string symbolName)
        {
            SvcSymbol symbolResult;
            TryFindSymbolByName(symbolName, out symbolResult).ThrowDbgEngNotOK();

            return symbolResult;
        }

        /// <summary>
        /// Finds symbolic information for a given name. The method fails if the symbol cannot be located.
        /// </summary>
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

        /// <summary>
        /// Finds symbolic information for a given offset. If the "exactMatchOnly" parameter is true, this will only return a symbol which is exactly at the offset given.<para/>
        /// If the "exactMatchOnly" parameter is false, this will return the closest symbol before the given offset. If no such symbol can be found, the method fails.<para/>
        /// Note that if a given symbol (e.g.: a function) has multiple disjoint address ranges and one of those address ranges has been moved to *BELOW* the base address of the symbol, the returned "symbolOffset" may be interpreted as a signed value (and S_FALSE should be returned in such a case).<para/>
        /// This can be confirmed by querying the symbol for its address ranges.
        /// </summary>
        public FindSymbolByOffsetResult FindSymbolByOffset(long moduleOffset, bool exactMatchOnly)
        {
            FindSymbolByOffsetResult result;
            TryFindSymbolByOffset(moduleOffset, exactMatchOnly, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Finds symbolic information for a given offset. If the "exactMatchOnly" parameter is true, this will only return a symbol which is exactly at the offset given.<para/>
        /// If the "exactMatchOnly" parameter is false, this will return the closest symbol before the given offset. If no such symbol can be found, the method fails.<para/>
        /// Note that if a given symbol (e.g.: a function) has multiple disjoint address ranges and one of those address ranges has been moved to *BELOW* the base address of the symbol, the returned "symbolOffset" may be interpreted as a signed value (and S_FALSE should be returned in such a case).<para/>
        /// This can be confirmed by querying the symbol for its address ranges.
        /// </summary>
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
