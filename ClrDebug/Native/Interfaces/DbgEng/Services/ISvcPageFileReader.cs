using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3603A7EE-E996-46E0-85BA-9CEA48EEF6E1")]
    [ComImport]
    public interface ISvcPageFileReader
    {
        /// <summary>
        /// Indicates whether a page can be read by the page file reader.
        /// </summary>
        [PreserveSig]
        HRESULT IsPageAvailable(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long TranslationEntry,
            [Out, MarshalAs(UnmanagedType.U1)] out bool PageIsAvailable);

        /// <summary>
        /// Reads data from the page file (or another backing store).
        /// </summary>
        [PreserveSig]
        HRESULT ReadPage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long TranslationEntry,
            [In] long ByteCount,
            [Out] IntPtr Buffer);
    }
}
