using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("23ED1044-166C-4C62-91FC-B5656E4A74EF")]
    [ComImport]
    public interface ISvcSymbolProvider
    {
        [PreserveSig]
        HRESULT LocateSymbolsForImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule image,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet);
    }
}
