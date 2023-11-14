using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerate the various injected sources contained in the data source.
    /// </summary>
    /// <remarks>
    /// This interface is obtained by calling the IDiaSession method with the name of a specific source file or by calling
    /// the IDiaSession method with the GUID of the IDiaEnumInjectedSources interface.
    /// </remarks>
    [Guid("D5612573-6925-4468-8883-98CDEC8C384A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumInjectedSources
    {
        /// <summary>
        /// Retrieves the <see cref="IEnumVARIANT"/> version of this enumerator.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get__NewEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT pRetVal);

        /// <summary>
        /// Retrieves the number of injected sources.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of injected sources.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves an injected source by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaInjectedSource object to be retrieved. The index is the range 0 to count-1, where count is returned by the IDiaEnumInjectedSources method.</param>
        /// <param name="injectedSource">[out] Returns an IDiaInjectedSource object representing the injected source.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInjectedSource injectedSource);

        /// <summary>
        /// Retrieves a specified number of injected sources in the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of injected sources in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] Returns an array of IDiaInjectedSource objects that represents the desired injected sources.</param>
        /// <param name="pceltFetched">[out] Returns the number of injected sources in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more injected sources. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInjectedSource rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Skips a specified number of injected sources in an enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of injected sources in the enumeration sequence to skip.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE if there are no more injected sources to skip.</returns>
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
        /// <param name="ppenum">[out] Returns an IDiaEnumInjectedSources object that contains a duplicate of the enumerator. The injected sources are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInjectedSources ppenum);
    }
}
