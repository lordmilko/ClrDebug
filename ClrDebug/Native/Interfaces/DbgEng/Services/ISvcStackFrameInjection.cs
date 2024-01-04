using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("83D68882-2AF7-408C-9B4E-FA5677F44C3E")]
    [ComImport]
    public interface ISvcStackFrameInjection
    {
        [PreserveSig]
        HRESULT InjectStackFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In] ref SVC_STACK_FRAME pStackFrame,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pRegisterContext);
    }
}
