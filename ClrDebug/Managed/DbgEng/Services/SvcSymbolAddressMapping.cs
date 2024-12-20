namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which has an address mapping (e.g.: code symbols, functions, lexical blocks, etc...) which can be described by one or more ranges implements this interface.<para/>
    /// This interface does *NOT* represent locations for things like variables which describe enregistered or register relative locations.
    /// </summary>
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

        /// <summary>
        /// Gets the base address range of this symbol. If the symbol is defined by a **SINGLE** linear address range, this method *MUST* return such address range and S_OK.<para/>
        /// If the symbol is defined by **MULTIPLE** linear address ranges (e.g.: a BBT'd or otherwise such optimized function), this method *MUST* return the base address range and S_FALSE.<para/>
        /// In either case, EnumerateAddressRanges() includes **ALL** address ranges of the symbol.
        /// </summary>
        public SvcAddressRange AddressRange
        {
            get
            {
                SvcAddressRange addressRange;
                TryGetAddressRange(out addressRange).ThrowDbgEngNotOK();

                return addressRange;
            }
        }

        /// <summary>
        /// Gets the base address range of this symbol. If the symbol is defined by a **SINGLE** linear address range, this method *MUST* return such address range and S_OK.<para/>
        /// If the symbol is defined by **MULTIPLE** linear address ranges (e.g.: a BBT'd or otherwise such optimized function), this method *MUST* return the base address range and S_FALSE.<para/>
        /// In either case, EnumerateAddressRanges() includes **ALL** address ranges of the symbol.
        /// </summary>
        public HRESULT TryGetAddressRange(out SvcAddressRange addressRange)
        {
            /*HRESULT GetAddressRange(
            [Out] out SvcAddressRange addressRange);*/
            return Raw.GetAddressRange(out addressRange);
        }

        #endregion
        #region EnumerateAddressRanges

        /// <summary>
        /// Enumerates the set of address ranges which define this symbol.
        /// </summary>
        public SvcAddressRangeEnumerator EnumerateAddressRanges()
        {
            SvcAddressRangeEnumerator rangeEnumResult;
            TryEnumerateAddressRanges(out rangeEnumResult).ThrowDbgEngNotOK();

            return rangeEnumResult;
        }

        /// <summary>
        /// Enumerates the set of address ranges which define this symbol.
        /// </summary>
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
