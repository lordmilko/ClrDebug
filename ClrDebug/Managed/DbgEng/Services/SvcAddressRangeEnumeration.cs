namespace ClrDebug.DbgEng
{
    public class SvcAddressRangeEnumeration : ComObject<ISvcAddressRangeEnumeration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcAddressRangeEnumeration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcAddressRangeEnumeration(ISvcAddressRangeEnumeration raw) : base(raw)
        {
        }

        #region ISvcAddressRangeEnumeration
        #region EnumerateAddressRanges

        public SvcAddressRangeEnumerator EnumerateAddressRanges()
        {
            SvcAddressRangeEnumerator ppEnumResult;
            TryEnumerateAddressRanges(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        public HRESULT TryEnumerateAddressRanges(out SvcAddressRangeEnumerator ppEnumResult)
        {
            /*HRESULT EnumerateAddressRanges(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressRangeEnumerator ppEnum);*/
            ISvcAddressRangeEnumerator ppEnum;
            HRESULT hr = Raw.EnumerateAddressRanges(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SvcAddressRangeEnumerator(ppEnum);
            else
                ppEnumResult = default(SvcAddressRangeEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
