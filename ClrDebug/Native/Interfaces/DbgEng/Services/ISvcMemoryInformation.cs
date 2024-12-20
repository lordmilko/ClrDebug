using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By:
    ///     DEBUG_SERVICE_VIRTUAL_MEMORY
    ///     DEBUG_SERVICE_PHYSICAL_MEMORY
    ///     DEBUG_SERVICE_VIRTUAL_MEMORY_UNCACHED
    ///     DEBUG_SERVICE_PHYSICAL_MEMORY_UNCACHED
    ///     DEBUG_SERVICE_VIRTUAL_MEMORY_TRANSLATED
    ///
    /// An *OPTIONAL* interface on a memory provider (virtual, physical, or otherwise) which describes the address space.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2506F23D-C4B3-4248-9C37-7F80BB7E4893")]
    [ComImport]
    public interface ISvcMemoryInformation
    {
        /// <summary>
        /// If Offset is contained within a valid memory region in the given address space, an ISvcMemoryRegion describing that memory region is returned along with an S_OK result.<para/>
        /// If, on the other hand, Offset is not within a valid memory region in the given address space, the implementation will find the next valid memory region with a starting address greater than Offset within the address space and return an ISvcMemoryRegion describing that along with an S_FALSE result.<para/>
        /// If there is no "next higher" address region, E_BOUNDS will be returned.
        /// </summary>
        [PreserveSig]
        HRESULT FindMemoryRegion(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegion Region);

        /// <summary>
        /// Enumerates all memory regions in the address space in *ARBITRARY ORDER*. One can achieve a monotonically increasing enumeration by repeatedly calling FindMemoryRegion starting with an Offset of zero.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateMemoryRegions(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegionEnumerator RegionEnum);
    }
}
