using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("31201a94-4337-49b7-aef7-0c755054091f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataExceptionNotification2
    {
        [PreserveSig]
        HRESULT OnAppDomainLoaded(
            [In] IXCLRDataAppDomain domain);

        [PreserveSig]
        HRESULT OnAppDomainUnloaded(
            [In] IXCLRDataAppDomain domain);

        [PreserveSig]
        HRESULT OnException(
            [In] IXCLRDataExceptionState exception);
    }
}
