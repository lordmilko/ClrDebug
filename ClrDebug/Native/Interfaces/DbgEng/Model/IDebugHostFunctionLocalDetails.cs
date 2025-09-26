using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("89280EA8-B3B9-408C-BE16-32AB28F5C0AC")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostFunctionLocalDetails
    {
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);
        
        [PreserveSig]
        HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType localType);
        
        [PreserveSig]
        HRESULT EnumerateStorage(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalStorageEnumerator storageEnum);
        
        [PreserveSig]
        HRESULT GetLocalKind(
            [Out] out LocalKind kind);
        
        [PreserveSig]
        HRESULT GetArgumentPosition(
            [Out] out long argPosition);
    }
}
