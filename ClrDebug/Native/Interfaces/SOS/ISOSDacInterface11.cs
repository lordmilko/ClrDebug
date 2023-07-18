using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("96BA1DB9-14CD-4492-8065-1CAAECF6E5CF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface11
    {
        [PreserveSig]
        HRESULT IsTrackedType(
            [In] CLRDATA_ADDRESS objAddr,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isTrackedType,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool hasTaggedMemory);

        [PreserveSig]
        HRESULT GetTaggedMemory(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out CLRDATA_ADDRESS taggedMemory,
            [Out] out long taggedMemorySizeInBytes);
    }
}
