using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("35C2DA2D-1359-44E6-996F-7A44C84B2956")]
    [ComImport]
    public interface IComponentFileSourceInitializer2 : IComponentFileSourceInitializer
    {
        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_FILESOURCE component by opening a file at the given path. This method will fail if no such file exists or it cannot be opened.
        /// </summary>
        [PreserveSig]
        new HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.LPWStr)] string filePath);

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_FILESOURCE component from an already opened file handle. While a file name must be provided, it has no bearing on the utilized file.<para/>
        /// If this method succeeds, ownership of the file handle is *TRANSFERRED* to the file source.
        /// </summary>
        [PreserveSig]
        HRESULT InitializeFromHandle(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] IntPtr fileHandle);
    }
}
