using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The image parse provider provides an image parser for recognized formats in one of several manners.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("471934B0-B6B6-4259-B16B-0784CE0274A7")]
    [ComImport]
    public interface ISvcImageParseProvider
    {
        /// <summary>
        /// Parses an image which is in the target VA space of the process and is given by an ISvcModule. Not every method will work on an image parsed directly out of target VA space.<para/>
        /// The ELF section table is often not pulled into the loaded image and hence enumerating sections will outright fail.
        /// </summary>
        [PreserveSig]
        HRESULT ParseLoadedImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pImage,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);

        /// <summary>
        /// Parses an image which is from a file on disk.
        /// </summary>
        [PreserveSig]
        HRESULT ParseImageFile(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcDebugSourceFile pImageFile,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);

        /// <summary>
        /// Parses an image which is memory mapped into a target VA space as a flat memory map (and not as a loaded image).
        /// </summary>
        [PreserveSig]
        HRESULT ParseTargetMappedImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext pImageContext,
            [In] long imageOffset,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);

        /// <summary>
        /// Parsea an image which is loaded into the address space of the caller. Not every method will work on an image parsed from a loaded view.<para/>
        /// The ELF section table is often not pulled into the loaded image and hence enumerating sections will outright fail.
        /// </summary>
        [PreserveSig]
        HRESULT ParseLocalLoadedImage(
            [In] IntPtr pImageMap,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);

        /// <summary>
        /// Parses an image which is memory mapped into the address space of the caller as a flat memory map (and not as a loaded image).
        /// </summary>
        [PreserveSig]
        HRESULT ParseLocalMappedImage(
            [In] IntPtr pImageMap,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);
    }
}
