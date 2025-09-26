using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8E1CB118-AA83-409A-AAE9-C7FF78911A5F")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostFunctionIntrospection2 : IDebugHostFunctionIntrospection
    {
#if !GENERATED_MARSHALLING
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
#endif
        
        [PreserveSig]
        HRESULT EnumerateLocalsDetailsEx(
            [In, MarshalAs(UnmanagedType.U1)] bool enumerateInlinedLocals,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetailsEnumerator localsEnum);
    }
}
