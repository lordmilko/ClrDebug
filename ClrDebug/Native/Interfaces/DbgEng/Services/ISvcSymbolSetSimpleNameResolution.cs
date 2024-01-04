using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("733177E7-9C18-46B7-8D00-3D50A9119FC3")]
    [ComImport]
    public interface ISvcSymbolSetSimpleNameResolution
    {
        [PreserveSig]
        HRESULT FindSymbolByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string symbolName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol);
        
        [PreserveSig]
        HRESULT FindSymbolByOffset(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.U1)] bool exactMatchOnly,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbol,
            [Out] out long symbolOffset);
    }
}
