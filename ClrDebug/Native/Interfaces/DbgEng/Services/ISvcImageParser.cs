using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// General service for parsing an executable image of some generic format which may be on disk, may be memory mapped (as a file), or may be memory mapped (as a loaded image), or may be in the VA space of the target (as either a flat map or a loaded image).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("27F4290C-41B2-453D-9980-E34B9DAF8E34")]
    [ComImport]
    public interface ISvcImageParser
    {
        /// <summary>
        /// Gets the architecture of the image. If the image is a multi-architecture image (for any definition of such -- whether a "fat binary", a "CHPE image", etc..., this method will return S_FALSE to indicate that it returned the *DEFAULT ARCHITECTURE* but that another "view" of the binary is available.
        /// </summary>
        [PreserveSig]
        HRESULT GetImageArchitecture(
            [Out] out int pImageArch);

        /// <summary>
        /// Maps an alternate view of the image for a secondary architecture. If the image is not a multi-architecture image, this will return E_NOTIMPL.
        /// </summary>
        [PreserveSig]
        HRESULT ReparseForAlternateArchitecture(
            [In] int altArch,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageParser ppAltParser);

        /// <summary>
        /// Gets the load size of the image as determined from the headers of the format.
        /// </summary>
        [PreserveSig]
        HRESULT GetImageLoadSize(
            [Out] out long pImageLoadSize);

        /// <summary>
        /// EnumerateFileViewRegions Enumerates every "file view region" within the file. This often corresponds to what an executable image format would call a section.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateFileViewRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegionEnumerator ppEnum);

        /// <summary>
        /// FindFileViewRegion Locate a "file view region" within the file by its given name (e.g.: ".text", etc...). If there is no such named region, E_BOUNDS is returned.
        /// </summary>
        [PreserveSig]
        HRESULT FindFileViewRegion(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwsRegionName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);

        /// <summary>
        /// FindFileViewRegionByOffset Locate a "file view region" given an offset within the file view.
        /// </summary>
        [PreserveSig]
        HRESULT FindFileViewRegionByOffset(
            [In] long offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);

        /// <summary>
        /// EnumerateMemoryViewRegions Enumerates every "memory view region" within the file. This often corresponds to what an executable image format would call a segment.<para/>
        /// For ELF, this would correspond to program headers with a VA/PA mapping.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateMemoryViewRegions(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegionEnumerator ppEnum);

        /// <summary>
        /// FindMemoryViewRegionByOffset Locate a "memory view region" given an offset within the VA space of the loaded module (what some parlances might call a relative virtual address or RVA).
        /// </summary>
        [PreserveSig]
        HRESULT FindMemoryViewRegionByOffset(
            [In] long offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);

        /// <summary>
        /// Locate a "memory view region" given its id.
        /// </summary>
        [PreserveSig]
        HRESULT FindMemoryViewRegionById(
            [In] long id,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageMemoryViewRegion ppRegion);

        /// <summary>
        /// TranslateFileViewOffsetToMemoryViewOffset Translates an offset into the file view of the image into an offset in the memory view of the image.<para/>
        /// An offset out of bounds of the file view will return E_BOUNDS. An offset which does not map to anything in the memory view (it is only in the file and not put in memory by the loader) will return E_NOT_SET.<para/>
        /// If a mapping is returned, the number of contiguous bytes of the mapping can optionally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateFileViewOffsetToMemoryViewOffset(
            [In] long fileViewOffset,
            [Out] out long pMemoryViewOffset,
            [Out] out long pMappedByteCount);

        /// <summary>
        /// GetMemoryViewOffset For an offset into the **CURRENT VIEW** of the image (depending on how the image was parsed), this will translate that offset into an offset in the memory view of the image.<para/>
        /// This may either be a no-op or may be equivalent to calling TranslateFileViewOffsetToMemoryViewOffset depending on how the image was originally parsed.
        /// </summary>
        [PreserveSig]
        HRESULT GetMemoryViewOffset(
            [In] long currentViewOffset,
            [Out] out long pMemoryViewOffset,
            [Out] out long pMappedByteCount);

        /// <summary>
        /// TranslateMemoryViewOffsetToFileViewOffset Translates an offset into the memory view of the image into an offset in the file view of the image.<para/>
        /// An offset out of bounds of the memory view will return E_BOUNDS. An offset which does not map to anything in the file view (e.g.: it is .bss or other uninitialized data) will return E_NOT_SET.<para/>
        /// If a mapping is returned, the number of contiguous bytes of the mapping can optionally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT TranslateMemoryViewOffsetToFileViewOffset(
            [In] long memoryViewOffset,
            [Out] out long pFileViewOffset,
            [Out] out long pMappedByteCount);

        /// <summary>
        /// GetFileViewOffset For an offset into the **CURRENT VIEW** of the image (depending on how the image was parsed), this will translate that offset into an offset in the file view of the image.<para/>
        /// This may either be a no-op or may be equivalent to calling TranslateMemoryViewOffsetToFileViewOffset depending on how the image was originally parsed.
        /// </summary>
        [PreserveSig]
        HRESULT GetFileViewOffset(
            [In] long currentViewOffset,
            [Out] out long pFileViewOffset,
            [Out] out long pMappedByteCount);
    }
}
