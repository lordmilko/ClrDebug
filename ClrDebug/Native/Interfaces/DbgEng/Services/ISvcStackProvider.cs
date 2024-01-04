using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C11A8084-0BC4-45F8-AF3C-821FBC835312")]
    [ComImport]
    public interface ISvcStackProvider
    {
        [PreserveSig]
        HRESULT StartStackWalk(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext unwindContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrameSetEnumerator frameEnum);
        
        [PreserveSig]
        HRESULT StartStackWalkForAlternateContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext unwindContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrameSetEnumerator frameEnum);
    }
}
