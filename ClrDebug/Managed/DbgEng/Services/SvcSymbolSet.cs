namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents an abstract set of symbols. This may represent all symbols in a PDB. It may represent the "export symbols" of an image.<para/>
    /// It may represent a subset of the symbols in a PDB. There is no requirement that a symbol set represent a single "file".<para/>
    /// It may represent, in aggregate, multiple sources of symbolic information for a given set of functionality (often represented by an image).
    /// </summary>
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

        /// <summary>
        /// Returns the symbol for a given symbol ID (returned by ISvcSymbol::GetId).
        /// </summary>
        public SvcSymbol GetSymbolById(long symbolId)
        {
            SvcSymbol ppSymbolResult;
            TryGetSymbolById(symbolId, out ppSymbolResult).ThrowDbgEngNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Returns the symbol for a given symbol ID (returned by ISvcSymbol::GetId).
        /// </summary>
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

        /// <summary>
        /// Enumerates all symbols in the set.
        /// </summary>
        public SvcSymbolSetEnumerator EnumerateAllSymbols()
        {
            SvcSymbolSetEnumerator ppEnumeratorResult;
            TryEnumerateAllSymbols(out ppEnumeratorResult).ThrowDbgEngNotOK();

            return ppEnumeratorResult;
        }

        /// <summary>
        /// Enumerates all symbols in the set.
        /// </summary>
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
