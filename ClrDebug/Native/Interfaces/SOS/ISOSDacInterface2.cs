using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("A16026EC-96F4-40BA-87FB-5575986FB7AF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface2
    {
        [PreserveSig]
        HRESULT GetObjectExceptionData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out DacpExceptionObjectData data);

        [PreserveSig]
        HRESULT IsRCWDCOMProxy(
            [In] CLRDATA_ADDRESS rcwAddr,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isDCOMProxy);
    }
}
