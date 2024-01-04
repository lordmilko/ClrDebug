using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("ED36A63D-AD2B-467E-A0CA-4CA949357625")]
    [ComImport]
    public interface IDebugHostModule5 : IDebugHostModule4
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
        new HRESULT FindTypeByName2(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pEnclosingSymbol,
            [In, MarshalAs(UnmanagedType.LPWStr)] string typeName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);
        
        [PreserveSig]
        new HRESULT CompareAgainst(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pComparisonSymbol,
            [In] int comparisonFlags,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pMatches);
        
        [PreserveSig]
        HRESULT GetPrimaryCompilerInformation(
            [Out] out KnownCompiler pCompilerId,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pPrimaryCompilerString);
    }
}
