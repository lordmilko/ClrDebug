using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("199A57B0-1967-4363-B25E-90C7E8A07F22")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostFunctionLocalDetails2 : IDebugHostFunctionLocalDetails
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);
        
        [PreserveSig]
        new HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType localType);
        
        [PreserveSig]
        new HRESULT EnumerateStorage(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalStorageEnumerator storageEnum);
        
        [PreserveSig]
        new HRESULT GetLocalKind(
            [Out] out LocalKind kind);
        
        [PreserveSig]
        new HRESULT GetArgumentPosition(
            [Out] out long argPosition);
#endif

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.U1)]
        bool IsInlineScope();
        
        [PreserveSig]
        HRESULT GetInlinedFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol inlineFunction);
    }
}
