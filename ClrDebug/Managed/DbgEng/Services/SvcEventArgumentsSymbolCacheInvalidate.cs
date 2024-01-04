namespace ClrDebug.DbgEng
{
    public class SvcEventArgumentsSymbolCacheInvalidate : ComObject<ISvcEventArgumentsSymbolCacheInvalidate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcEventArgumentsSymbolCacheInvalidate"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcEventArgumentsSymbolCacheInvalidate(ISvcEventArgumentsSymbolCacheInvalidate raw) : base(raw)
        {
        }

        #region ISvcEventArgumentsSymbolCacheInvalidate
        #region SymbolsInformation

        public GetSymbolsInformationResult SymbolsInformation
        {
            get
            {
                GetSymbolsInformationResult result;
                TryGetSymbolsInformation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetSymbolsInformation(out GetSymbolsInformationResult result)
        {
            /*HRESULT GetSymbolsInformation(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule module,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet);*/
            ISvcModule module;
            ISvcSymbolSet symbolSet;
            HRESULT hr = Raw.GetSymbolsInformation(out module, out symbolSet);

            if (hr == HRESULT.S_OK)
                result = new GetSymbolsInformationResult(SvcModule.New(module), symbolSet == null ? null : new SvcSymbolSet(symbolSet));
            else
                result = default(GetSymbolsInformationResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
