using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("471934B0-B6B6-4259-B16B-0784CE0274A7")]
    [ComImport]
    public interface ISvcImageParseProvider
    {
        [PreserveSig]
        HRESULT ParseLoadedImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pImage,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);
        
        [PreserveSig]
        HRESULT ParseImageFile(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcDebugSourceFile pImageFile,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);
        
        [PreserveSig]
        HRESULT ParseTargetMappedImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext pImageContext,
            [In] long imageOffset,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);
        
        [PreserveSig]
        HRESULT ParseLocalLoadedImage(
            [In] IntPtr pImageMap,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);
        
        [PreserveSig]
        HRESULT ParseLocalMappedImage(
            [In] IntPtr pImageMap,
            [In] long imageSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppImageParser);
    }
}
