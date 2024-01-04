namespace ClrDebug.DbgEng
{
    public class SvcJITSymbolProvider : ComObject<ISvcJITSymbolProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcJITSymbolProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcJITSymbolProvider(ISvcJITSymbolProvider raw) : base(raw)
        {
        }

        #region ISvcJITSymbolProvider
        #region LocateSymbolsForJITSegment

        public LocateSymbolsForJITSegmentResult LocateSymbolsForJITSegment(ISvcAddressContext addressContext, long address)
        {
            LocateSymbolsForJITSegmentResult result;
            TryLocateSymbolsForJITSegment(addressContext, address, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryLocateSymbolsForJITSegment(ISvcAddressContext addressContext, long address, out LocateSymbolsForJITSegmentResult result)
        {
            /*HRESULT LocateSymbolsForJITSegment(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule image);*/
            ISvcSymbolSet symbolSet;
            ISvcModule image;
            HRESULT hr = Raw.LocateSymbolsForJITSegment(addressContext, address, out symbolSet, out image);

            if (hr == HRESULT.S_OK)
                result = new LocateSymbolsForJITSegmentResult(symbolSet == null ? null : new SvcSymbolSet(symbolSet), SvcModule.New(image));
            else
                result = default(LocateSymbolsForJITSegmentResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
