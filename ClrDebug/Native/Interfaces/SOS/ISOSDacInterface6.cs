using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("11206399-4B66-4EDB-98EA-85654E59AD45")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface6
    {
        [PreserveSig]
        HRESULT GetMethodTableCollectibleData(
            [In] CLRDATA_ADDRESS mt,
            [Out] out DacpMethodTableCollectibleData data);
    }
}
