using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9d339be5-30cd-4403-92c3-57ea33799cb1")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugSettings
    {
        [PreserveSig]
        HRESULT LoadSettingsFromString(
            [MarshalAs(UnmanagedType.LPWStr), In] string contents);

        [PreserveSig]
        HRESULT StoreSettingsInStream(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream output);
    }
}
