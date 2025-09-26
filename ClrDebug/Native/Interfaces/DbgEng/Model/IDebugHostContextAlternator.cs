using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6301EEE8-85E3-4058-A7C0-D37E0EA65F75")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostContextAlternator
    {
        [PreserveSig]
        HRESULT SwitchTo(
            [In, MarshalAs(UnmanagedType.U1)] bool fullSwitch);
        
        [PreserveSig]
        HRESULT SwitchBack();
    }
}
