using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various segments contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the QueryInterface method on an <see cref="IDiaTable"/> object. See the example
    /// for details.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E8368CA9-01D1-419D-AC0C-E31235DBDA9F")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumSegments
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
        /// Retrieves the number of segments.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_Count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a segment by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaSegment"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="get_Count"/> method.</param>
        /// <param name="segment">[out] Returns an <see cref="IDiaSegment"/> object representing the desired segment.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSegment segment);

        /// <summary>
        /// Retrieves a specified number of segments in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of segments in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array that is to be filled in with the desired <see cref="IDiaSegment"/> objects that represent the segments.</param>
        /// <param name="pceltFetched">[out] Returns the number of segments in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more segments. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSegment rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of segments in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of segments in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more segments to skip.</returns>
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
        /// <param name="ppenum">[out] Returns an <see cref="IDiaEnumSegments"/> object that contains a duplicate of the enumerator. The segments are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSegments ppenum);
    }
}
