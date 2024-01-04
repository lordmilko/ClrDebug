using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("31C1B07E-745A-461C-90C0-8FBC5162AC86")]
    [ComImport]
    public interface ISvcJITSymbolProvider
    {
        [PreserveSig]
        HRESULT LocateSymbolsForJITSegment(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule image);
    }
}
