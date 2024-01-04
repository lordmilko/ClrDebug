using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("199A57B0-1967-4363-B25E-90C7E8A07F22")]
    [ComImport]
    public interface IDebugHostFunctionLocalDetails2 : IDebugHostFunctionLocalDetails
    {
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
        
        [return: MarshalAs(UnmanagedType.U1)]
        bool IsInlineScope();
        
        [PreserveSig]
        HRESULT GetInlinedFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol inlineFunction);
    }
}
