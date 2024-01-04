using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7D42C7D1-B9D3-4DDF-B9F9-05694F013B86")]
    [ComImport]
    public interface ISvcMemoryAccess
    {
        [PreserveSig]
        HRESULT ReadMemory(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [Out] IntPtr Buffer,
            [In] long BufferSize,
            [Out] out long BytesRead);
        
        [PreserveSig]
        HRESULT WriteMemory(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long Offset,
            [In] IntPtr Buffer,
            [In] long BufferSize,
            [Out] out long BytesWritten);
    }
}
