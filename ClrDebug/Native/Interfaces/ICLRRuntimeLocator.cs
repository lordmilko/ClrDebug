using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B760BF44-9377-4597-8BE7-58083BDC5146")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICLRRuntimeLocator
    {
        [PreserveSig]
        HRESULT GetRuntimeBase(
            [Out] out CLRDATA_ADDRESS baseAddress);
    }
}