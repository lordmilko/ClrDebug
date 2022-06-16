using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("31201a94-4337-49b7-aef7-0c755054091f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataExceptionNotification2
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
