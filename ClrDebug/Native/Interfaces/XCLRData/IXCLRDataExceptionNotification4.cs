using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("C25E926E-5F09-4AA2-BBAD-B7FC7F10CFD7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataExceptionNotification4
    {
        [PreserveSig]
        HRESULT ExceptionCatcherEnter(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance catchingMethod,
            [In] int catcherNativeOffset);
    }
}
