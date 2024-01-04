using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D49EECE8-8D12-4CE1-AB73-E5B63DF4F9D3")]
    [ComImport]
    public interface IDebugHostSymbolSubstitutionEnumerator : IDebugHostSymbolEnumerator
    {
        [PreserveSig]
        new HRESULT Reset();
        
        [PreserveSig]
        new HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);
        
        [PreserveSig]
        HRESULT GetNextWithSubstitutionText(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol,
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolText);
    }
}
