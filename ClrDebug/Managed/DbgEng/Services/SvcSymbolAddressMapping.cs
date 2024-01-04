namespace ClrDebug.DbgEng
{
    public class SvcSymbolAddressMapping : ComObject<ISvcSymbolAddressMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolAddressMapping"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolAddressMapping(ISvcSymbolAddressMapping raw) : base(raw)
        {
        }

        #region ISvcSymbolAddressMapping
        #region AddressRange

        public SvcAddressRange AddressRange
        {
            get
            {
                SvcAddressRange addressRange;
                TryGetAddressRange(out addressRange).ThrowDbgEngNotOK();

                return addressRange;
            }
        }

        public HRESULT TryGetAddressRange(out SvcAddressRange addressRange)
        {
            /*HRESULT GetAddressRange(
            [Out] out SvcAddressRange addressRange);*/
            return Raw.GetAddressRange(out addressRange);
        }

        #endregion
        #region EnumerateAddressRanges

        public SvcAddressRangeEnumerator EnumerateAddressRanges()
        {
            SvcAddressRangeEnumerator rangeEnumResult;
            TryEnumerateAddressRanges(out rangeEnumResult).ThrowDbgEngNotOK();

            return rangeEnumResult;
        }

        public HRESULT TryEnumerateAddressRanges(out SvcAddressRangeEnumerator rangeEnumResult)
        {
            /*HRESULT EnumerateAddressRanges(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressRangeEnumerator rangeEnum);*/
            ISvcAddressRangeEnumerator rangeEnum;
            HRESULT hr = Raw.EnumerateAddressRanges(out rangeEnum);

            if (hr == HRESULT.S_OK)
                rangeEnumResult = rangeEnum == null ? null : new SvcAddressRangeEnumerator(rangeEnum);
            else
                rangeEnumResult = default(SvcAddressRangeEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
