using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A24E286B-891A-40FC-8A3A-89B66EDDCE57")]
    [ComImport]
    public interface IDebugHostFunctionIntrospection3 : IDebugHostFunctionIntrospection2
    {
        [PreserveSig]
        new HRESULT EnumerateLocalsDetails(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetailsEnumerator localsEnum);
        
        [PreserveSig]
        new HRESULT EnumerateInlineFunctionsByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator inlinesEnum);
        
        [PreserveSig]
        new HRESULT FindContainingCodeRangeByRVA(
            [In] long rva,
            [Out] out Location rangeStart,
            [Out] out Location rangeEnd);
        
        [PreserveSig]
        new HRESULT FindSourceLocationByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFile,
            [Out] out long sourceLine);
        
        [PreserveSig]
        new HRESULT EnumerateLocalsDetailsEx(
            [In, MarshalAs(UnmanagedType.U1)] bool enumerateInlinedLocals,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetailsEnumerator localsEnum);
        
        [PreserveSig]
        HRESULT IsNoReturnFunction(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsNoReturnFunction);
    }
}
