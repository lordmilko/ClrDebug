using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("28D96C86-10A3-4976-B14E-EAEF4790AA1F")]
    [ComImport]
    public interface IDebugHostSymbolEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);
    }
}
