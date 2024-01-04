using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A4AE6E38-E6DA-4BC8-9FC0-EC65821948E5")]
    [ComImport]
    public interface ISvcImageFileViewRegionEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);
    }
}
