using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("127d6abe-6c86-4e48-8e7b-220781c58101")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface5
    {
        [PreserveSig]
        HRESULT GetTieredVersions(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int rejitId,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DacpTieredVersionData[] nativeCodeAddrs,
            [In] int cNativeCodeAddrs,
            [Out] out int pcNativeCodeAddrs);
    }
}
