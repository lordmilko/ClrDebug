using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FFFB5A2D-49C9-4530-9226-7A6BCA1D6856")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugClientInternal2 : IDebugClientInternal
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT OpenProtocolConnectionWide(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString);
#endif

        [PreserveSig]
        HRESULT OpenProtocolConnectionWide2(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString,
            [Out] out ProtocolConnectionKind connectionKind,
            [Out] out int systemId,
            [Out] out long server);
    }
}
