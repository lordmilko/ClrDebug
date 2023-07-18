using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("8FA642BD-9F10-4799-9AA3-512AE78C77EE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSStackRefEnum : ISOSEnum
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
            [Out] out SOSStackRefData _ref,
            [Out] out int pFetched);

        [PreserveSig]
        HRESULT EnumerateErrors(
            [Out] out ISOSStackRefErrorEnum ppEnum);
    }
}
