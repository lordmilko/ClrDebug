namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_VIRTUAL_MEMORY. DEBUG_SERVICE_PHYSICAL_MEMORY DEBUG_SERVICE_VIRTUAL_MEMORY_UNCACHED DEBUG_SERVICE_PHYSICAL_MEMORY_UNCACHED DEBUG_SERVICE_VIRTUAL_MEMORY_TRANSLATED An *OPTIONAL* interface on a memory provider (virtual, physical, or otherwise) which describes the address space.
    /// </summary>
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

        /// <summary>
        /// If Offset is contained within a valid memory region in the given address space, an ISvcMemoryRegion describing that memory region is returned along with an S_OK result.<para/>
        /// If, on the other hand, Offset is not within a valid memory region in the given address space, the implementation will find the next valid memory region with a starting address greater than Offset within the address space and return an ISvcMemoryRegion describing that along with an S_FALSE result.<para/>
        /// If there is no "next higher" address region, E_BOUNDS will be returned.
        /// </summary>
        public SvcMemoryRegion FindMemoryRegion(ISvcAddressContext addressContext, long offset)
        {
            SvcMemoryRegion regionResult;
            TryFindMemoryRegion(addressContext, offset, out regionResult).ThrowDbgEngNotOK();

            return regionResult;
        }

        /// <summary>
        /// If Offset is contained within a valid memory region in the given address space, an ISvcMemoryRegion describing that memory region is returned along with an S_OK result.<para/>
        /// If, on the other hand, Offset is not within a valid memory region in the given address space, the implementation will find the next valid memory region with a starting address greater than Offset within the address space and return an ISvcMemoryRegion describing that along with an S_FALSE result.<para/>
        /// If there is no "next higher" address region, E_BOUNDS will be returned.
        /// </summary>
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

        /// <summary>
        /// Enumerates all memory regions in the address space in *ARBITRARY ORDER*. One can achieve a monotonically increasing enumeration by repeatedly calling FindMemoryRegion starting with an Offset of zero.
        /// </summary>
        public SvcMemoryRegionEnumerator EnumerateMemoryRegions(ISvcAddressContext addressContext)
        {
            SvcMemoryRegionEnumerator regionEnumResult;
            TryEnumerateMemoryRegions(addressContext, out regionEnumResult).ThrowDbgEngNotOK();

            return regionEnumResult;
        }

        /// <summary>
        /// Enumerates all memory regions in the address space in *ARBITRARY ORDER*. One can achieve a monotonically increasing enumeration by repeatedly calling FindMemoryRegion starting with an Offset of zero.
        /// </summary>
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
