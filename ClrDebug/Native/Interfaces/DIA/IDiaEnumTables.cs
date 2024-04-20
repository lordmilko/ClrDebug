using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various tables contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the IDiaSession method.
    /// </remarks>
    [Guid("C65C2B0A-1150-4D7A-AFCC-E05BF3DEE81E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumTables
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
        /// Retrieves the number of tables.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of tables.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a table by means of an index or name.
        /// </summary>
        /// <param name="index">[in] Index or name of the IDiaTable to be retrieved. If an integer variant is used, it must be in the range 0 to count-1, where count is as returned by the IDiaEnumTables method.</param>
        /// <param name="table">[out] Returns an IDiaTable object representing the desired table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// If a string variant is specified, then the string names a particular table. The name should be one of the table
        /// names as defined in Constants (Debug Interface Access SDK).
        /// </remarks>
        [PreserveSig]
        HRESULT Item(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.Struct)] //Doesn't need custom DIA string marshalling
#else
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            object index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaTable table);

        /// <summary>
        /// Retrieves a specified number of tables in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of tables in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array that is to be filled in with the IDiaTable objects that represent the desired tables.</param>
        /// <param name="pceltFetched">[out] Returns the number of tables in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more tables. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [MarshalAs(UnmanagedType.Interface), Out] out IDiaTable rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of tables in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of tables in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more tables to skip.</returns>
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
        /// <param name="ppenum">[out] Returns an IDiaEnumTables object that contains a duplicate of the enumerator. The tables are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumTables ppenum);
    }
}
