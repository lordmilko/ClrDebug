using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("e77a39ea-3548-44d9-b171-8569ed1a9423")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataExceptionNotification5
    {
        [PreserveSig]
        HRESULT OnCodeGenerated2(
            [In] IXCLRDataMethodInstance method,
            [In] CLRDATA_ADDRESS nativeCodeLocation);
    }
}
