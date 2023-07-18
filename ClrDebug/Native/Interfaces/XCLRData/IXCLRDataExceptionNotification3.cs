using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("31201a94-4337-49b7-aef7-0c7550540920")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataExceptionNotification3
    {
        [PreserveSig]
        HRESULT OnGcEvent(
            [In] GcEvtArgs gcEvtArgs);
    }
}
