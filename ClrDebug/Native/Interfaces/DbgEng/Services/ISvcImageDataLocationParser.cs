using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("86669E84-8182-4C54-8938-04B5E5C5B958")]
    [ComImport]
    public interface ISvcImageDataLocationParser
    {
        [PreserveSig]
        HRESULT LocateDataBlob(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid dataBlob,
            [Out] out long pFileOffset,
            [Out] out long pMemoryOffset,
            [Out] out long pBlobSize);
    }
}
