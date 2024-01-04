using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A754393C-4FBE-4178-8AD5-FE6079AC048D")]
    [ComImport]
    public interface IDebugHostFunctionIntrospection
    {
        [PreserveSig]
        HRESULT EnumerateLocalsDetails(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetailsEnumerator localsEnum);
        
        [PreserveSig]
        HRESULT EnumerateInlineFunctionsByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator inlinesEnum);
        
        [PreserveSig]
        HRESULT FindContainingCodeRangeByRVA(
            [In] long rva,
            [Out] out Location rangeStart,
            [Out] out Location rangeEnd);
        
        [PreserveSig]
        HRESULT FindSourceLocationByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFile,
            [Out] out long sourceLine);
    }
}
