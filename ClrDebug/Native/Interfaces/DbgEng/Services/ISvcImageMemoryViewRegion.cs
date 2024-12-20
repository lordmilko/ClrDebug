using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ISvcImageMemoryRegion Describes a "memory veiw region" of an executable. This might be called a "segment" in some parlances.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0DF8C531-ECA0-48F3-94BB-0964EC6EE3F0")]
    [ComImport]
    public interface ISvcImageMemoryViewRegion
    {
        /// <summary>
        /// Gets the memory offset of the memory region. This corresponds to an offset from the load base of the image (or a "relative virtual address" as some might call it).
        /// </summary>
        [PreserveSig]
        long GetMemoryOffset();

        /// <summary>
        /// Gets the size of the memory region.
        /// </summary>
        [PreserveSig]
        long GetSize();

        /// <summary>
        /// Gets a numeric id for the region. This may correspond to a segment number or may simply be an invented ID by the provider (e.g.: an index into the program header table).
        /// </summary>
        [PreserveSig]
        long GetId();

        /// <summary>
        /// Indicates whether this region of the image is mapped as readable. If the implementation cannot make a determination of whether the range is readable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);

        /// <summary>
        /// Indicates whether this region of the image is mapped as writeable. If the implementation cannot make a determination of whether the range is writeable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);

        /// <summary>
        /// Indicates whether this region of the image is mapped as executable. If the implementation cannot make a determination of whether the range is executable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT IsExecutable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsExecutable);

        /// <summary>
        /// Gets the required alignment for this mapping. If the implementation cannot make a determination of alignment, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetAlignment(
            [Out] out int Alignment);

        /// <summary>
        /// Gets the association of this memory view region to the file view. If this memory section is *NOT* associated with the file view (it is uninitialized data, zero-fill, etc...), S_FALSE is returned with a 0/0 mapping and pExtraByteMapping filled in.<para/>
        /// By default, this will return a singular mapping (of the start of the memory view region).
        /// </summary>
        [PreserveSig]
        HRESULT GetFileViewAssociation(
            [Out] out long pFileViewOffset,
            [Out] out long pFileViewSize,
            [Out] out ServiceImageByteMapping pExtraByteMapping);
    }
}
