using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An optional QI off an ISvcImageParser. This parses arbitrary image data blobs (structures) and provides pointers to such data.<para/>
    /// Data is identified by GUIDs.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("86669E84-8182-4C54-8938-04B5E5C5B958")]
    [ComImport]
    public interface ISvcImageDataLocationParser
    {
        /// <summary>
        /// Locates an arbitrary data blob identified by GUID and returns both the memory and file offset of the data. If the data has no memory or file offset (but has the opposite), zero is returned in the appropriate field.
        /// </summary>
        [PreserveSig]
        HRESULT LocateDataBlob(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid dataBlob,
            [Out] out long pFileOffset,
            [Out] out long pMemoryOffset,
            [Out] out long pBlobSize);
    }
}
