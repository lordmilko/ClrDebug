using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("949A8DE4-BFF9-4F84-A3EF-79B2F154415A")]
    [ComImport]
    public interface ISvcSymbolInfo
    {
        [PreserveSig]
        HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbolType);
        
        [PreserveSig]
        HRESULT GetLocation(
            [Out] out SvcSymbolLocation pLocation);
        
        [PreserveSig]
        HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pValue);
        
        [PreserveSig]
        HRESULT GetAttribute(
            [In] SvcSymbolAttribute attr,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pAttributeValue);
    }
}
