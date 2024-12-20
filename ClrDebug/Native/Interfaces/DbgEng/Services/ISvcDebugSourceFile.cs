using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A0E9E780-FE9A-4085-AB4B-8B4CC276266A")]
    [ComImport]
    public interface ISvcDebugSourceFile
    {
        /// <summary>
        /// Attempts to read the number of bytes specified by the 'readSize' argument from the file offset supplied by 'byteOffset' into the buffer supplied by the 'buffer' argument.<para/>
        /// Note that a partial read is a successful state of this method. In such a case, the 'bytesRead' argument will be set to the number of bytes actually read and S_FALSE will be returned.
        /// </summary>
        [PreserveSig]
        HRESULT Read(
            [In] long byteOffset,
            [Out] IntPtr buffer,
            [In] long readSize,
            [Out] out long bytesRead);

        /// <summary>
        /// Attempts to write the number of bytes specified by the 'writeSize' argument into the file (or a copy-on-write mapping on top of the file as determined by the implementation) at the offset supplied by the 'byteOffset' argument.<para/>
        /// The contents written are from the buffer supplied by the 'buffer' argument. Note that a partial write is a successful state of this method.<para/>
        /// In such a case, the 'bytesWritten' argument will be set to the number of bytes actually written and S_FALSE will be returned.
        /// </summary>
        [PreserveSig]
        HRESULT Write(
            [In] long byteOffset,
            [In] IntPtr buffer,
            [In] long writeSize,
            [Out] out long bytesWritten);
    }
}
