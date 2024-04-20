using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various frame data elements contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface from the <see cref="IDiaSession.getEnumTables"/> method. See the example for details.
    /// </remarks>
    [Guid("9FC77A4B-3C1C-44ED-A798-6C1DEEA53E1F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumFrameData
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
        /// Retrieves the number of frame data elements.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of frame data elements.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_Count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a frame data element by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaFrameData"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="get_Count"/> method.</param>
        /// <param name="frame">[out] Returns an <see cref="IDiaFrameData"/> object representing the desired frame data element.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData frame);

        /// <summary>
        /// Retrieves a specified number of frame data elements in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of frame data elements in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array of <see cref="IDiaFrameData"/> objects to be filled in with the requested frame data elements.</param>
        /// <param name="pceltFetched">[out] Returns the number of frame data elements in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more records. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of frame data elements in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of frame data elements in the enumeration sequence to skip.</param>
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
        /// <param name="ppenum">[out] Returns an <see cref="IDiaEnumFrameData"/> object that contains a duplicate of the enumerator. The frame data is not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumFrameData ppenum);

        /// <summary>
        /// Returns a frame by relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">[in] RVA of the frame of interest.</param>
        /// <param name="frame">[out] Returns an <see cref="IDiaFrameData"/> object representing the frame that contains the address provided.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if no frame data matches the specified address. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT frameByRVA(
            [In] int relativeVirtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData frame);

        /// <summary>
        /// Returns a frame by virtual address (VA).
        /// </summary>
        /// <param name="virtualAddress">[in] VA of the frame of interest.</param>
        /// <param name="frame">[out] Returns an <see cref="IDiaFrameData"/> object that represents the frame that contains the address provided.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if no frame data matches the specified address. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT frameByVA(
            [In] long virtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData frame);
    }
}
