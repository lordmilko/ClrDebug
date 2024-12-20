using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EB64279F-6EEF-451F-9DA4-55DB69FC2A95")]
    [ComImport]
    public interface ISvcStackProviderPhysicalFrame
    {
        /// <summary>
        /// Gets the underlying SVC_STACK_FRAME and register context for the frame. This would be equivalent to having called ISvcStackFrameUnwind::UnwindFrame and gotten the same values out.
        /// </summary>
        [PreserveSig]
        HRESULT GetFrame(
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);
    }
}
