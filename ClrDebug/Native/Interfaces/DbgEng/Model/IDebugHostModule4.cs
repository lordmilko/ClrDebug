using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41415136-38A4-474F-8E98-57E2DC64E565")]
    [ComImport]
    public interface IDebugHostModule4 : IDebugHostModule3
    {
        [PreserveSig]
        new HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);
        
        [PreserveSig]
        new HRESULT EnumerateChildren(
            [In] SymbolKind kind,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator ppEnum);
        
        [PreserveSig]
        new HRESULT GetSymbolKind(
            [Out] out SymbolKind kind);
        
        [PreserveSig]
        new HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);
        
        [PreserveSig]
        new HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        new HRESULT GetContainingModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule containingModule);
        
        [PreserveSig]
        new HRESULT GetImageName(
            [In, MarshalAs(UnmanagedType.U1)] bool allowPath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string imageName);
        
        [PreserveSig]
        new HRESULT GetBaseLocation(
            [Out] out Location moduleBaseLocation);
        
        [PreserveSig]
        new HRESULT GetVersion(
            [Out] out long fileVersion,
            [Out] out long productVersion);
        
        [PreserveSig]
        new HRESULT FindTypeByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string typeName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        new HRESULT FindSymbolByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);
        
        [PreserveSig]
        new HRESULT FindSymbolByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string symbolName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);
        
        [PreserveSig]
        new HRESULT FindContainingSymbolByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol,
            [Out] out long offset);
        
        [PreserveSig]
        new HRESULT GetRange(
            [Out] out Location moduleStart,
            [Out] out Location moduleEnd);
        
        [PreserveSig]
        new HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pComparisonSymbol,
            [In] int comparisonFlags,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pMatches);
        
        [PreserveSig]
        HRESULT FindTypeByName2(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pEnclosingSymbol,
            [In, MarshalAs(UnmanagedType.LPWStr)] string typeName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
    }
}
