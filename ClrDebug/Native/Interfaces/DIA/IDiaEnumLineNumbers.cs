using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various line numbers contained in the data source.
    /// </summary>
    /// <remarks>
    /// This interface is obtained by calling one of the following methods in the <see cref="IDiaSession"/> interface:
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FE30E878-54AC-44F1-81BA-39DE940F6052")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumLineNumbers
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
        /// Retrieves the number of line numbers.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of line numbers.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_Count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a line number by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaLineNumber"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="get_Count"/> method.</param>
        /// <param name="lineNumber">[out] Returns an <see cref="IDiaLineNumber"/> object representing the desired line number.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaLineNumber lineNumber);

        /// <summary>
        /// Retrieves a specified number of line numbers in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of line numbers in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] Returns an array of <see cref="IDiaLineNumber"/> objects that represent the desired line numbers.</param>
        /// <param name="pceltFetched">[out] Returns the number of line numbers in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more line numbers. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaLineNumber rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of line numbers in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of line numbers in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more line numbers to skip.</returns>
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
        /// <param name="ppenum">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a duplicate of the enumerator. The line numbers are not duplicated, only the enumerator..</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppenum);
    }
}
