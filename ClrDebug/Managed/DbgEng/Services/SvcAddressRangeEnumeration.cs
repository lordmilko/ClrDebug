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

        /// <summary>
        /// Enumerates a set of address ranges which define a memory layout. For modules Enumerates the set of address ranges which define the memory layout of the module.<para/>
        /// The first enumerated range *MUST* be the range returned from GetBaseAddress() and GetSize() for the module. It is legal for this method to return E_NOTIMPL for modules which are defined by a contiguous linear range of addresses [baseAddress, baseAddress + size).<para/>
        /// Any module which is defined by more than one range *MUST* return the *LOWEST* address range in GetBaseAddress() and GetSize() and must return S_FALSE from those two methods.<para/>
        /// Likewise, the implementation of the module enumeration service should be able to map any address returned here to the given module.
        /// </summary>
        public SvcAddressRangeEnumerator EnumerateAddressRanges()
        {
            SvcAddressRangeEnumerator ppEnumResult;
            TryEnumerateAddressRanges(out ppEnumResult).ThrowDbgEngNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Enumerates a set of address ranges which define a memory layout. For modules Enumerates the set of address ranges which define the memory layout of the module.<para/>
        /// The first enumerated range *MUST* be the range returned from GetBaseAddress() and GetSize() for the module. It is legal for this method to return E_NOTIMPL for modules which are defined by a contiguous linear range of addresses [baseAddress, baseAddress + size).<para/>
        /// Any module which is defined by more than one range *MUST* return the *LOWEST* address range in GetBaseAddress() and GetSize() and must return S_FALSE from those two methods.<para/>
        /// Likewise, the implementation of the module enumeration service should be able to map any address returned here to the given module.
        /// </summary>
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
