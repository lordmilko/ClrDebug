using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("66FF5B9F-A8D1-4A78-ADA9-4DFEDCC12C3A")]
    [ComImport]
    public interface ISvcMemoryRegionEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegion Region);
    }
}
