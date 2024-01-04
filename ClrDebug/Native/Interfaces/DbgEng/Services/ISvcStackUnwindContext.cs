using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B44285F2-5FAC-4BA9-8A1F-DD264EF1F1D3")]
    [ComImport]
    public interface ISvcStackUnwindContext
    {
        [PreserveSig]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);
        
        [PreserveSig]
        HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);
        
        [PreserveSig]
        HRESULT SetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [In, MarshalAs(UnmanagedType.Interface)] object contextData);
        
        [PreserveSig]
        HRESULT GetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [Out, MarshalAs(UnmanagedType.Interface)] out object contextData);
    }
}
