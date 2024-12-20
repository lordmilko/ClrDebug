using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a contiguous region of memory within an address space.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E327A72A-65D9-4545-9304-09F0104BB138")]
    [ComImport]
    public interface ISvcMemoryRegion
    {
        /// <summary>
        /// Gets the bounds of this memory region.
        /// </summary>
        [PreserveSig]
        HRESULT GetRange(
            [Out] out SvcAddressRange Range);

        /// <summary>
        /// Indicates whether this region of memory is readable. If the implementation cannot make a determination of whether the range is readable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);

        /// <summary>
        /// Indicates whether this region of memory is writeable. If the implementation cannot make a determination of whether the range is writeable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);

        /// <summary>
        /// Indicates whether this region of memory is executable. If the implementation cannot make a determination of whether the range is executable or not, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT IsExecutable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsExecutable);
    }
}
