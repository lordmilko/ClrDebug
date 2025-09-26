using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("EEB8FB43-B44E-4B0F-B871-65F0886FCAF2")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostContextControl
    {
        [PreserveSig]
        HRESULT SwitchTo();
        
        [PreserveSig]
        HRESULT GetContextAlternator(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContextAlternator contextAlternator);
    }
}
