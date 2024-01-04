using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A4D4186A-CA0E-483B-BB2A-A83F9D3F3115")]
    [ComImport]
    public interface ISvcThreadEnumeration
    {
        [PreserveSig]
        HRESULT FindThread(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long threadKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread targetThread);
        
        [PreserveSig]
        HRESULT EnumerateThreads(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThreadEnumerator targetThreadEnumerator);
    }
}
