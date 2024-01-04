using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E5CFCBEE-E83D-451F-A26B-D687C72159DD")]
    [ComImport]
    public interface ISvcStackUnwindContext3 : ISvcStackUnwindContext2
    {
        [PreserveSig]
        new HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit execUnit);
        
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
        HRESULT GetAddressContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext addressContext);
    }
}
