using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A0E9E780-FE9A-4085-AB4B-8B4CC276266A")]
    [ComImport]
    public interface ISvcDebugSourceFile
    {
        [PreserveSig]
        HRESULT Read(
            [In] long byteOffset,
            [Out] IntPtr buffer,
            [In] long readSize,
            [Out] out long bytesRead);
        
        [PreserveSig]
        HRESULT Write(
            [In] long byteOffset,
            [In] IntPtr buffer,
            [In] long writeSize,
            [Out] out long bytesWritten);
    }
}
