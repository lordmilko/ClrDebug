using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various symbols contained in the data source.
    /// </summary>
    /// <remarks>
    /// This interface provides symbols grouped by a specific type of symbol, for example, SymTagUDT (user-defined types)
    /// or SymTagBaseClass. To work with symbols grouped by address, use the IDiaEnumSymbolsByAddr interface. Obtain this
    /// interface by calling the following methods:
    /// </remarks>
    [Guid("CAB72C48-443B-48F5-9B0B-42F0820AB29A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumSymbols
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
        /// Retrieves the number of symbols.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of symbols.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a symbol by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSymbol object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSymbols method.</param>
        /// <param name="symbol">[out] Returns an IDiaSymbol object representing the desired symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol symbol);

        /// <summary>
        /// Retrieves a specified number of symbols in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array that is to be filled in with the IDiaSymbol objects that represent the desired symbols.</param>
        /// <param name="pceltFetched">[out] Returns the number of symbols in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more symbols. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of symbols in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more symbols to skip.</returns>
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
        /// <param name="ppenum">[out] Returns an IDiaEnumSymbols object that contains a duplicate of the enumerator. The symbols are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppenum);
    }
}
