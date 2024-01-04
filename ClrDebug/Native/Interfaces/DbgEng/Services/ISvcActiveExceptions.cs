using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1579B0C9-A848-447D-BB65-0CFFE3F985FB")]
    [ComImport]
    public interface ISvcActiveExceptions
    {
        [PreserveSig]
        HRESULT GetLastExceptionEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExceptionInformation exceptionInfo);
        
        [PreserveSig]
        HRESULT GetActiveExceptionEvent(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pExecutionUnit,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExceptionInformation exceptionInfo);
    }
}
