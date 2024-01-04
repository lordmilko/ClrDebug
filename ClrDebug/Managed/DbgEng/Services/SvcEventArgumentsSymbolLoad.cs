namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsSymbolLoad : ComObject<ISvcEventArgumentsSymbolLoad>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsSymbolLoad"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsSymbolLoad(ISvcEventArgumentsSymbolLoad raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsSymbolLoad
        #region Module

        public SvcModule Module
        {
            get
            {
                SvcModule moduleResult;
                TryGetModule(out moduleResult).ThrowDbgEngNotOK();

                return moduleResult;
            }
        }

        public HRESULT TryGetModule(out SvcModule moduleResult)
        {
            /*HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module);*/
            ISvcModule module;
            HRESULT hr = Raw.GetModule(out module);

            if (hr == HRESULT.S_OK)
                moduleResult = SvcModule.New(module);
            else
                moduleResult = default(SvcModule);

            return hr;
        }

        #endregion
        #region Symbols

        public SvcSymbolSet Symbols
        {
            get
            {
                SvcSymbolSet symbolsResult;
                TryGetSymbols(out symbolsResult).ThrowDbgEngNotOK();

                return symbolsResult;
            }
        }

        public HRESULT TryGetSymbols(out SvcSymbolSet symbolsResult)
        {
            /*HRESULT GetSymbols(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbols);*/
            ISvcSymbolSet symbols;
            HRESULT hr = Raw.GetSymbols(out symbols);

            if (hr == HRESULT.S_OK)
                symbolsResult = symbols == null ? null : new SvcSymbolSet(symbols);
            else
                symbolsResult = default(SvcSymbolSet);

            return hr;
        }

        #endregion
        #endregion
    }
}
