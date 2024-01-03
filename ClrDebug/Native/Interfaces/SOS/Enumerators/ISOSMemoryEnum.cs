using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("E4B860EC-337A-40C0-A591-F09A9680690F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSMemoryEnum : ISOSEnum
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT Skip(
            [In] int count);

        [PreserveSig]
        new HRESULT Reset();

        [PreserveSig]
        new HRESULT GetCount(
            [Out] out int pCount);
#endif

        [PreserveSig]
        HRESULT Next(
            [In] int count,
            [Out] out SOSMemoryRegion handles,
            [Out] out int pNeeded);
    }
}
