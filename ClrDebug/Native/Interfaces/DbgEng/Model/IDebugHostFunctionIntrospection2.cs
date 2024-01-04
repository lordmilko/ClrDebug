using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8E1CB118-AA83-409A-AAE9-C7FF78911A5F")]
    [ComImport]
    public interface IDebugHostFunctionIntrospection2 : IDebugHostFunctionIntrospection
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
        HRESULT EnumerateLocalsDetailsEx(
            [In, MarshalAs(UnmanagedType.U1)] bool enumerateInlinedLocals,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetailsEnumerator localsEnum);
    }
}
