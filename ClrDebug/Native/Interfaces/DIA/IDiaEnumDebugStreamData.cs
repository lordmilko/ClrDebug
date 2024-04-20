using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides access to the records in a debug data stream.
    /// </summary>
    /// <remarks>
    /// This interface represents a stream of records in a debug data stream. The size and interpretation of each record
    /// is dependent on the data stream the record comes from. This interface effectively provides access to the raw data
    /// bytes in the symbol file. Call the <see cref="IDiaEnumDebugStreams.Item"/> or <see cref="IDiaEnumDebugStreams.Next"/>
    /// methods to obtain an IDiaEnumDebugStreamData object.
    /// </remarks>
    [Guid("486943E8-D187-4A6B-A3C4-291259FFF60D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumDebugStreamData
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
        /// Retrieves the number records in the debug data stream.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_Count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the name of a debug data stream.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of a debug data stream.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_name(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves the specified record.
        /// </summary>
        /// <param name="index">[in] Index of the record to be retrieved. The index is in the range 0 to count-1, where count is returned by <see cref="get_Count"/>.</param>
        /// <param name="cbData">[in] Size of the data buffer, in bytes.</param>
        /// <param name="pcbData">[out] Returns the number of bytes returned. If data is NULL, then pcbData contains the total number of bytes of data available in the specified record.</param>
        /// <param name="pbData">[out] A buffer that is filled in with the debug stream record data.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. Returns E_INVALIDARG for invalid parameters and if the index parameter is out of bounds.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData);

        /// <summary>
        /// Retrieves a specified number of records in the enumerated sequence.
        /// </summary>
        /// <param name="celt">[in] The number of records to be retrieved.</param>
        /// <param name="cbData">[in] Size of the data buffer, in bytes.</param>
        /// <param name="pcbData">[out] Returns the number of bytes returned. If data is NULL, then pcbData contains the total number of bytes of data available for all requested records.</param>
        /// <param name="pbData">[out] A buffer that is to be filled with the debug stream record data.</param>
        /// <param name="pceltFetched">[in, out] Returns the number of records in data.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more records. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of records in an enumerated sequence.
        /// </summary>
        /// <param name="celt">[in] The number of records to skip in the enumerated sequence.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more records to skip.</returns>
        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Resets to the beginning of an enumerated sequence.
        /// </summary>
        /// <returns>Returns S_OK.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Creates an enumerator that contains the same enumerated sequence as the current enumerator.
        /// </summary>
        /// <param name="ppenum">[out] Returns an <see cref="IDiaEnumDebugStreamData"/> object that contains the duplicated sequence of debug data stream records.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreamData ppenum);
    }
}
