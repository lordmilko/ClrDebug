using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various source files contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the QueryInterface method on an <see cref="IDiaTable"/> object. See the example
    /// for details.
    /// </remarks>
    [Guid("10F3DBD9-664F-4469-B808-9471C7A50538")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumSourceFiles
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
        /// Retrieves the number of source files.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of source files.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_Count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a source file by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaSourceFile"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="get_Count"/> method.</param>
        /// <param name="sourceFile">[out] Returns an <see cref="IDiaSourceFile"/> object representing the desired source file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile sourceFile);

        /// <summary>
        /// Retrieves a specified number of source files in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of source files in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out]An array that is to be filled in with the <see cref="IDiaSourceFile"/> objects that represent the desired source files.</param>
        /// <param name="pceltFetched">[out] Returns the number of source files in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more source files. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of source files in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of source files in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more source files to skip.</returns>
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
        /// <param name="ppenum">[out] Returns an <see cref="IDiaEnumSourceFiles"/> object that contains a duplicate of the enumerator. The source files are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSourceFiles ppenum);
    }
}
