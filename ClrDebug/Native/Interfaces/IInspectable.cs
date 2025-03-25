using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("AF86E2E0-B12D-4c6a-9C5A-D7AA65101E90")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IInspectable
    {
        [PreserveSig]
        HRESULT GetIids(
            [Out] out int iidCount,
            [Out] out IntPtr iids); //Guid[]

        [PreserveSig]
        HRESULT GetRuntimeClassName(
            [Out] out IntPtr className); //HSTRING. Not compatible with source generated COM

        [PreserveSig]
        HRESULT GetTrustLevel(
            [Out] out TrustLevel trustLevel);
    }
}
