using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("44CFC4B1-02B5-490A-A51A-AD34E49457F4")]
    [ComImport]
    public interface ISvcStackFrameUnwind
    {
        [PreserveSig]
        HRESULT UnwindFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pInRegisterContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppOutRegisterContext);
    }
}
