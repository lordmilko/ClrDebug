namespace ClrDebug.DbgEng
{
    public class DebugHostSymbolSubstitutionEnumerator : DebugHostSymbolEnumerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostSymbolSubstitutionEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostSymbolSubstitutionEnumerator(IDebugHostSymbolSubstitutionEnumerator raw) : base(raw)
        {
        }

        #region IDebugHostSymbolSubstitutionEnumerator

        public new IDebugHostSymbolSubstitutionEnumerator Raw => (IDebugHostSymbolSubstitutionEnumerator) base.Raw;

        #region NextWithSubstitutionText

        public GetNextWithSubstitutionTextResult NextWithSubstitutionText
        {
            get
            {
                GetNextWithSubstitutionTextResult result;
                TryGetNextWithSubstitutionText(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetNextWithSubstitutionText(out GetNextWithSubstitutionTextResult result)
        {
            /*HRESULT GetNextWithSubstitutionText(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol,
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolText);*/
            IDebugHostSymbol symbol;
            string symbolText;
            HRESULT hr = Raw.GetNextWithSubstitutionText(out symbol, out symbolText);

            if (hr == HRESULT.S_OK)
                result = new GetNextWithSubstitutionTextResult(DebugHostSymbol.New(symbol), symbolText);
            else
                result = default(GetNextWithSubstitutionTextResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
