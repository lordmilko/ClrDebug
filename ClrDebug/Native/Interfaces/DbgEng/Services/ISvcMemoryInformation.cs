using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2506F23D-C4B3-4248-9C37-7F80BB7E4893")]
    [ComImport]
    public interface ISvcMemoryInformation
    {
        [PreserveSig]
        HRESULT FindMemoryRegion(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegion Region);
        
        [PreserveSig]
        HRESULT EnumerateMemoryRegions(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegionEnumerator RegionEnum);
    }
}
