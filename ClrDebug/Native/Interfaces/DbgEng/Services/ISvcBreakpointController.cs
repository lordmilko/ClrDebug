using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5D62C1F1-D49A-4749-90AA-C13443184C99")]
    [ComImport]
    public interface ISvcBreakpointController
    {
        [PreserveSig]
        HRESULT EnumerateBreakpoints(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpointEnumerator ppBreakpointEnum);
        
        [PreserveSig]
        HRESULT CreateCodeBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long address,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);
        
        [PreserveSig]
        HRESULT CreateDataBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long address,
            [In] long dataWidth,
            [In] DataAccessFlags accessFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);
    }
}
