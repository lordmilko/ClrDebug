using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0995BEC6-8A12-453d-A694-09CD2712BDD7")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugClientInternal
    {
        [PreserveSig]
        HRESULT OpenProtocolConnectionWide(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString);
    }
}
