namespace ClrDebug.DbgEng
{
    public class SvcSymbolProvider : ComObject<ISvcSymbolProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolProvider(ISvcSymbolProvider raw) : base(raw)
        {
        }

        #region ISvcSymbolProvider
        #region LocateSymbolsForImage

        public SvcSymbolSet LocateSymbolsForImage(ISvcModule image)
        {
            SvcSymbolSet symbolSetResult;
            TryLocateSymbolsForImage(image, out symbolSetResult).ThrowDbgEngNotOK();

            return symbolSetResult;
        }

        public HRESULT TryLocateSymbolsForImage(ISvcModule image, out SvcSymbolSet symbolSetResult)
        {
            /*HRESULT LocateSymbolsForImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule image,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet);*/
            ISvcSymbolSet symbolSet;
            HRESULT hr = Raw.LocateSymbolsForImage(image, out symbolSet);

            if (hr == HRESULT.S_OK)
                symbolSetResult = symbolSet == null ? null : new SvcSymbolSet(symbolSet);
            else
                symbolSetResult = default(SvcSymbolSet);

            return hr;
        }

        #endregion
        #endregion
    }
}
