using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1A39F548-ECF8-4FFE-830D-C923F51E752D")]
    [ComImport]
    public interface ISvcAddressContextHardware
    {
        /// <summary>
        /// Gets the directory base for this address context (represented as hardware -- e.g.: a processor) e.g.: For a AMD64 processor, this interface would return the CR3 value.
        /// </summary>
        [PreserveSig]
        HRESULT GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [Out] out long directoryBase);

        /// <summary>
        /// Gets the number of paging levels mode that the hardware is utilizing.
        /// </summary>
        [PreserveSig]
        HRESULT GetPagingLevels(
            [Out] out int pagingLevels);
    }
}
