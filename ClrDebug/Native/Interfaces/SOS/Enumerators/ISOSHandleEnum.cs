using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("3E269830-4A2B-4301-8EE2-D6805B29B2FA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSHandleEnum : ISOSEnum
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
            [Out] out SOSHandleData handles,
            [Out] out int pNeeded);
    }
}
