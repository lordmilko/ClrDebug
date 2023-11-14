using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various debug streams contained in the data source.
    /// </summary>
    /// <remarks>
    /// The content of debug streams is implementation-dependent and the data formats are undocumented. Call the IDiaSession
    /// method to obtain an IDiaEnumDebugStreams object.
    /// </remarks>
    [Guid("08CBB41E-47A6-4F87-92F1-1C9C87CED044")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaEnumDebugStreams
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
        /// Retrieves the number of debug streams.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of debug streams available in this enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a debug stream by means of an index or name.
        /// </summary>
        /// <param name="index">[in] Index or name of the debug stream to be retrieved. If an integer variant is used, it must be in the range 0 to count-1, where count is as returned by the IDiaEnumDebugStreams method.</param>
        /// <param name="stream">[out] Returns an IDiaEnumDebugStreamData object representing the specified debug stream.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [MarshalAs(UnmanagedType.Struct), In] object index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreamData stream);

        /// <summary>
        /// Retrieves a specified number of debug streams in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of debug streams in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] Returns an array of IDiaEnumDebugStreamData objects that represents the debug streams being retrieved.</param>
        /// <param name="pceltFetched">[out] Returns the number of debug streams returned.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more streams. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreamData rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of debug streams in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of debug streams in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more records to skip.</returns>
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
        /// <param name="ppenum">[out] Returns an IDiaEnumDebugStreams object that contains a duplicate of the enumerator. The streams are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreams ppenum);
    }
}
