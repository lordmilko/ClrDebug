using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various section contributions contained in the data source.
    /// </summary>
    [Guid("1994DEB2-2C82-4B1D-A57F-AFF424D54A68")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaEnumSectionContribs
    {
        /// <summary>
        /// Retrieves the <see cref="IEnumVARIANT"/> version of this enumerator.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the IUnknown interface that represents the <see cref="IEnumVARIANT"/> version of this enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get__NewEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT pRetVal);

        /// <summary>
        /// Retrieves the number of section contributions.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of section contributions.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves section contributions by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSectionContrib object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSectionContribs method.</param>
        /// <param name="section">[out] Returns an IDiaSectionContrib object representing the desired section contribution.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSectionContrib section);

        /// <summary>
        /// Retrieves a specified number of section contributions in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of section contributions in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array that is to be filled with the IDiaSectionContrib objects that represent the desired section contributions.</param>
        /// <param name="pceltFetched">[out] Returns the number of section contributions in the enumerator fetched.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more section contributions. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSectionContrib rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of section contributions in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of section contributions in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more section contributions to skip.</returns>
        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Resets an enumeration sequence to the beginning.
        /// </summary>
        /// <returns>Returns S_OK.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Creates an enumerator that contains the same enumeration state as the current enumerator.
        /// </summary>
        /// <param name="ppenum">[out] Returns an IDiaEnumSectionContribs object that contains a duplicate of the enumerator. The section contributions are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSectionContribs ppenum);
    }
}
