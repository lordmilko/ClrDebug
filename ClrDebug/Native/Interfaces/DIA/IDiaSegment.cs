using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Maps data from the section number to segments of address space.
    /// </summary>
    /// <remarks>
    /// Because the DIA SDK already performs translations from the section offset to relative virtual addresses, most applications
    /// will not make use of the information in the segment map. Obtain this interface by calling the IDiaEnumSegments
    /// or IDiaEnumSegments methods. See the example for details.
    /// </remarks>
    [Guid("0775B784-C75B-4449-848B-B7BD3159545B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaSegment
    {
        /// <summary>
        /// Retrieves the segment number.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the segment number.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_frame(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the offset, in segments, where the section begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset, in segments, where the section begins.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_offset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes in the segment.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes in the segment.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_length(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the segment can be read.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the segment can be read; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_read(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the segment can be modified.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the segment can be written to; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_write(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the segment is executable.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the segment is marked as executable; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_execute(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// Retrieves the section number that maps to this segment.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section number that maps to this segment.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_addressSection(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the beginning of the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the RVA of the beginning of the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the virtual address (VA) of the beginning of the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the VA of the beginning of the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_virtualAddress(
            [Out] out long pRetVal);
    }
}
