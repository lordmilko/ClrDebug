using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Retrieves data describing a section contribution, that is, a contiguous block of memory contributed to the image by a compiland.
    /// </summary>
    /// <remarks>
    /// This interface is obtained by calling the IDiaEnumSectionContribs and IDiaEnumSectionContribs methods. See the
    /// IDiaEnumSectionContribs interface for an example of obtaining the IDiaSectionContrib interface.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0CF4B60E-35B1-4C6C-BDD8-854B9C8E3857")]
    [ComImport]
    public interface IDiaSectionContrib
    {
        /// <summary>
        /// Retrieves a reference to the compiland symbol that contributed this section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object representing the compiland that contributed this section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_compiland(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves the section part of the contribution's address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the contribution's address.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_addressSection(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the offset part of the contribution's address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the contribution's address.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_addressOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the image relative virtual address (RVA) of the contribution.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the image RVA of the contribution.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the virtual address (VA) of the contribution.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the VA of the contribution.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_virtualAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the number of bytes in a section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes in a section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_length(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section cannot be paged out of memory.
        /// </summary>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_notPaged(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains executable code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section contains executable code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_code(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains initialized data.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section contains initialized data; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_initializedData(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains uninitialized data.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section contains uninitialized data; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_uninitializedData(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section is removed before it is made part of the in-memory image.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section is not to be added to the in-memory image; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_remove(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section is a COMDAT record.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section is a COMDAT record; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// A COMDAT record is a Common Object File Format (COFF) record that makes packaged functions visible to the linker.
        /// </remarks>
        [PreserveSig]
        HRESULT get_comdat(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be discarded.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be discarded from memory as needed; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_discardable(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section cannot be cached.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section cannot be cached; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_notCached(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be shared in memory.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section is shareable in memory; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_share(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section is executable as code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be executed as code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_execute(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be read.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be read; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_read(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be modified.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be written to; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_write(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves the cyclic redundancy check (CRC) of the data in the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the CRC of the data in the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_dataCrc(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the cyclic redundancy check (CRC) of the relocation information for the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the CRC of the relocation information for the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_relocationsCrc(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the compiland identifier for the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the compiland identifier for the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_compilandId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains 16-bit code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the code in the section is 16-bit; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method only indicates if the code is 16-bit. If the code is not 16-bit, it could be anything else, such as
        /// 32-bit or 64-bit code.
        /// </remarks>
        [PreserveSig]
        HRESULT get_code16bit(
            [Out] out bool pRetVal);
    }
}
