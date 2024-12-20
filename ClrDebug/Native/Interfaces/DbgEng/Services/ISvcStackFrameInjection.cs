using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// If a given stack unwinder service implements this interface, other components involved in unwind can inject a frame during the unwinder.<para/>
    /// The injected frame becomes the NEXT frame regardless of other Unwind* calls that may or may not be in progress.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("83D68882-2AF7-408C-9B4E-FA5677F44C3E")]
    [ComImport]
    public interface ISvcStackFrameInjection
    {
        /// <summary>
        /// InjectStackFrame Adds a stack frame with the given information and register context as the immediately next frame from the unwind.
        /// </summary>
        [PreserveSig]
        HRESULT InjectStackFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In] ref SVC_STACK_FRAME pStackFrame,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pRegisterContext);
    }
}
