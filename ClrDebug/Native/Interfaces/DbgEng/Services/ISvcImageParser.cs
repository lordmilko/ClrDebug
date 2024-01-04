using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("27F4290C-41B2-453D-9980-E34B9DAF8E34")]
    [ComImport]
    public interface ISvcImageParser
    {
        [PreserveSig]
        HRESULT GetImageArchitecture(
            [Out] out int pImageArch);
        
        [PreserveSig]
        HRESULT ReparseForAlternateArchitecture(
            [In] int altArch,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppAltParser);
        
        [PreserveSig]
        HRESULT GetImageLoadSize(
            [Out] out long pImageLoadSize);
        
        [PreserveSig]
        HRESULT EnumerateFileViewRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegionEnumerator ppEnum);
        
        [PreserveSig]
        HRESULT FindFileViewRegion(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwsRegionName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);
        
        [PreserveSig]
        HRESULT FindFileViewRegionByOffset(
            [In] long offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);
        
        [PreserveSig]
        HRESULT EnumerateMemoryViewRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegionEnumerator ppEnum);
        
        [PreserveSig]
        HRESULT FindMemoryViewRegionByOffset(
            [In] long offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);
        
        [PreserveSig]
        HRESULT FindMemoryViewRegionById(
            [In] long id,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);
        
        [PreserveSig]
        HRESULT TranslateFileViewOffsetToMemoryViewOffset(
            [In] long fileViewOffset,
            [Out] out long pMemoryViewOffset,
            [Out] out long pMappedByteCount);
        
        [PreserveSig]
        HRESULT GetMemoryViewOffset(
            [In] long currentViewOffset,
            [Out] out long pMemoryViewOffset,
            [Out] out long pMappedByteCount);
        
        [PreserveSig]
        HRESULT TranslateMemoryViewOffsetToFileViewOffset(
            [In] long memoryViewOffset,
            [Out] out long pFileViewOffset,
            [Out] out long pMappedByteCount);
        
        [PreserveSig]
        HRESULT GetFileViewOffset(
            [In] long currentViewOffset,
            [Out] out long pFileViewOffset,
            [Out] out long pMappedByteCount);
    }
}
