using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2D742534-FC20-4472-A5DD-3A66BFED5832")]
    [ComImport]
    public interface ISvcStackUnwindContext2 : ISvcStackUnwindContext
    {
        [PreserveSig]
        new HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process);
        
        [PreserveSig]
        new HRESULT GetThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread thread);
        
        [PreserveSig]
        new HRESULT SetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [In, MarshalAs(UnmanagedType.Interface)] object contextData);
        
        [PreserveSig]
        new HRESULT GetContextData(
            [In, MarshalAs(UnmanagedType.Interface)] object component,
            [Out, MarshalAs(UnmanagedType.Interface)] out object contextData);
        
        [PreserveSig]
        HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit execUnit);
    }
}
