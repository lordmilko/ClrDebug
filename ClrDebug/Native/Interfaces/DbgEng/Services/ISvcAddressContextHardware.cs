using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1A39F548-ECF8-4FFE-830D-C923F51E752D")]
    [ComImport]
    public interface ISvcAddressContextHardware
    {
        [PreserveSig]
        HRESULT GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [Out] out long directoryBase);
        
        [PreserveSig]
        HRESULT GetPagingLevels(
            [Out] out int pagingLevels);
    }
}
