using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("1B93BACC-8CA4-432D-943A-3E6E7EC0B0A3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface12
    {
        [PreserveSig]
        HRESULT GetGlobalAllocationContext(
            [Out] out CLRDATA_ADDRESS allocPtr,
            [Out] out CLRDATA_ADDRESS allocLimit);
    }
}
