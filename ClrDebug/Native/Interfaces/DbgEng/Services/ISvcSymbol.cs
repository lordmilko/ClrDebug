using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7947495F-383B-49C7-B1C5-1F959DD99D09")]
    [ComImport]
    public interface ISvcSymbol
    {
        [PreserveSig]
        HRESULT GetSymbolKind(
            [Out] out SvcSymbolKind kind);
        
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolName);
        
        [PreserveSig]
        HRESULT GetQualifiedName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string qualifiedName);
        
        [PreserveSig]
        HRESULT GetId(
            [Out] out long value);
        
        [PreserveSig]
        HRESULT GetOffset(
            [Out] out long symbolOffset);
    }
}
