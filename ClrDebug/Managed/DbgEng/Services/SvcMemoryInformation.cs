namespace ClrDebug.DbgEng
{
    public class SvcMemoryInformation : ComObject<ISvcMemoryInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMemoryInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMemoryInformation(ISvcMemoryInformation raw) : base(raw)
        {
        }

        #region ISvcMemoryInformation
        #region FindMemoryRegion

        public SvcMemoryRegion FindMemoryRegion(ISvcAddressContext addressContext, long offset)
        {
            SvcMemoryRegion regionResult;
            TryFindMemoryRegion(addressContext, offset, out regionResult).ThrowDbgEngNotOK();

            return regionResult;
        }

        public HRESULT TryFindMemoryRegion(ISvcAddressContext addressContext, long offset, out SvcMemoryRegion regionResult)
        {
            /*HRESULT FindMemoryRegion(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegion Region);*/
            ISvcMemoryRegion region;
            HRESULT hr = Raw.FindMemoryRegion(addressContext, offset, out region);

            if (hr == HRESULT.S_OK)
                regionResult = region == null ? null : new SvcMemoryRegion(region);
            else
                regionResult = default(SvcMemoryRegion);

            return hr;
        }

        #endregion
        #region EnumerateMemoryRegions

        public SvcMemoryRegionEnumerator EnumerateMemoryRegions(ISvcAddressContext addressContext)
        {
            SvcMemoryRegionEnumerator regionEnumResult;
            TryEnumerateMemoryRegions(addressContext, out regionEnumResult).ThrowDbgEngNotOK();

            return regionEnumResult;
        }

        public HRESULT TryEnumerateMemoryRegions(ISvcAddressContext addressContext, out SvcMemoryRegionEnumerator regionEnumResult)
        {
            /*HRESULT EnumerateMemoryRegions(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegionEnumerator RegionEnum);*/
            ISvcMemoryRegionEnumerator regionEnum;
            HRESULT hr = Raw.EnumerateMemoryRegions(addressContext, out regionEnum);

            if (hr == HRESULT.S_OK)
                regionEnumResult = regionEnum == null ? null : new SvcMemoryRegionEnumerator(regionEnum);
            else
                regionEnumResult = default(SvcMemoryRegionEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
