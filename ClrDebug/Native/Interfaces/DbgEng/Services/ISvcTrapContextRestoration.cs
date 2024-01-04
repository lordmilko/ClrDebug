using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3870640B-8D1E-469D-8552-F38D48E28766")]
    [ComImport]
    public interface ISvcTrapContextRestoration
    {
        [PreserveSig]
        HRESULT ReadTrapContext(
            [In] TrapContextKind trapKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext pAddressContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pInContext,
            [In] long trapContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppOutContext);
    }
}
