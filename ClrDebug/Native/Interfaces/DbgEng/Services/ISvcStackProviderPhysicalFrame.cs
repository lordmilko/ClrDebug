using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EB64279F-6EEF-451F-9DA4-55DB69FC2A95")]
    [ComImport]
    public interface ISvcStackProviderPhysicalFrame
    {
        [PreserveSig]
        HRESULT GetFrame(
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);
    }
}
