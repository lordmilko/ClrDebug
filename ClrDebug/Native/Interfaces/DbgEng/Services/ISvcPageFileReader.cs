using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3603A7EE-E996-46E0-85BA-9CEA48EEF6E1")]
    [ComImport]
    public interface ISvcPageFileReader
    {
        [PreserveSig]
        HRESULT IsPageAvailable(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long TranslationEntry,
            [Out, MarshalAs(UnmanagedType.U1)] out bool PageIsAvailable);
        
        [PreserveSig]
        HRESULT ReadPage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long TranslationEntry,
            [In] long ByteCount,
            [Out] IntPtr Buffer);
    }
}
