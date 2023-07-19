using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("8F378F6F-1017-4461-9890-ECF64C54079F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugProcess10
    {
        [PreserveSig]
        HRESULT EnableGCNotificationEvents(
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);
    }
}
