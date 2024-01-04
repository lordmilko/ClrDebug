using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3AADC353-2B14-4ABB-9893-5E03458E07EE")]
    [ComImport]
    public interface IDebugHostTypeSignature
    {
        [PreserveSig]
        HRESULT GetHashCode(
            [Out] out int hashCode);
        
        [PreserveSig]
        HRESULT IsMatch(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType type,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isMatch,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator wildcardMatches);
        
        [PreserveSig]
        HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostTypeSignature typeSignature,
            [Out] out SignatureComparison result);
    }
}
