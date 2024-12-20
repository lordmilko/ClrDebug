using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a "file view region" of an executable. This might be called a "section" in some parlances.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E9BF1356-BA52-4B57-887F-2998499D5DCB")]
    [ComImport]
    public interface ISvcImageFileViewRegion
    {
        /// <summary>
        /// Gets the file offset of the file region.
        /// </summary>
        [PreserveSig]
        long GetFileOffset();

        /// <summary>
        /// Gets the size of the file region.
        /// </summary>
        [PreserveSig]
        long GetSize();

        /// <summary>
        /// Gets the name of the region. If the region has no name, E_NOT_SET is returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRegionName);

        /// <summary>
        /// Gets the association of this file view region to the memory view. If this file section is *NOT* associated with the memory view (it is not mapped by a loader), S_FALSE is returned with a 0/0 mapping and pExtraByteMapping filled in.<para/>
        /// By default, this will return a singular mapping (of the start of the file view region).
        /// </summary>
        [PreserveSig]
        HRESULT GetMemoryViewAssociation(
            [Out] out long pMemoryViewOffset,
            [Out] out long pMemoryViewSize,
            [Out] out ServiceImageByteMapping pExtraByteMapping);
    }
}
