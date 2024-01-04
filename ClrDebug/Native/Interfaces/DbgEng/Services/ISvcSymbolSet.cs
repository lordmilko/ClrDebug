using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6FA683AF-06AA-484D-87CF-137C1EA016BD")]
    [ComImport]
    public interface ISvcSymbolSet
    {
        [PreserveSig]
        HRESULT GetSymbolById(
            [In] long symbolId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppSymbol);
        
        [PreserveSig]
        HRESULT EnumerateAllSymbols(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator ppEnumerator);
    }
}
