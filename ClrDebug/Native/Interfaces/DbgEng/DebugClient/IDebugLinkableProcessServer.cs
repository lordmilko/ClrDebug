using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4DE9A876-D3C5-4313-9D8F-660C29CBEB9A")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugLinkableProcessServer
    {
        [PreserveSig]
        HRESULT ConnectLinkedProcessServer(
            [In] long server,
            [MarshalAs(UnmanagedType.LPWStr), In] string remoteOptions,
            [Out] out long newServer);
    }
}
