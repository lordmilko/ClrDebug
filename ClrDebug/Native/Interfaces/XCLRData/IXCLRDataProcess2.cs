using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("5c552ab6-fc09-4cb3-8e36-22fa03c798b8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataProcess2
    {
        [PreserveSig]
        HRESULT GetGcNotification(
            [Out] out GcEvtArgs gcEvtArgs);

        [PreserveSig]
        HRESULT SetGcNotification(
            [In] GcEvtArgs gcEvtArgs);
    }
}
