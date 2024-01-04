using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BF990D96-9D77-4A39-A611-74DE8F0F6B45")]
    [ComImport]
    public interface ISvcImageMemoryViewRegionEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);
    }
}
