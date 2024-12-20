namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsSymbolUnload : ComObject<ISvcEventArgumentsSymbolUnload>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsSymbolUnload"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsSymbolUnload(ISvcEventArgumentsSymbolUnload raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsSymbolUnload
        #region Module

        /// <summary>
        /// Gets the module for which symbols are being unloaded.
        /// </summary>
        public SvcModule Module
        {
            get
            {
                SvcModule moduleResult;
                TryGetModule(out moduleResult).ThrowDbgEngNotOK();

                return moduleResult;
            }
        }

        /// <summary>
        /// Gets the module for which symbols are being unloaded.
        /// </summary>
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

        /// <summary>
        /// Gets the symbols which were loaded for the module. The caller should check the output result for nullptr for symbol formats which are not (currently) expressable as a symbol set.
        /// </summary>
        public SvcSymbolSet Symbols
        {
            get
            {
                SvcSymbolSet symbolsResult;
                TryGetSymbols(out symbolsResult).ThrowDbgEngNotOK();

                return symbolsResult;
            }
        }

        /// <summary>
        /// Gets the symbols which were loaded for the module. The caller should check the output result for nullptr for symbol formats which are not (currently) expressable as a symbol set.
        /// </summary>
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
