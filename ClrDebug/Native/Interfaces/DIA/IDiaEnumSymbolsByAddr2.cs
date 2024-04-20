using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    [Guid("1E45BD02-BE45-4D71-BA32-0E576CFCD59F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumSymbolsByAddr2 : IDiaEnumSymbolsByAddr
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Positions the enumerator by performing a lookup by image section number and offset.
        /// </summary>
        /// <param name="isect">[in] Image section number.</param>
        /// <param name="offset">[in] Offset in section.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the symbol could not be found. Otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT symbolByAddr(
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Positions the enumerator by performing a lookup by relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">[in] Address relative to start of image.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the symbol could not be found. Otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT symbolByRVA(
            [In] int relativeVirtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Positions the enumerator by performing a lookup by virtual address (VA).
        /// </summary>
        /// <param name="virtualAddress">[in] Virtual address.</param>
        /// <param name="ppSymbol">[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the symbol could not be found. Otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT symbolByVA(
            [In] long virtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        /// <summary>
        /// Retrieves the next symbols in order by address.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array that is to be filled in with the <see cref="IDiaSymbol"/> object that represent the desired symbols.</param>
        /// <param name="pceltFetched">[out] Returns the number of symbols in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more symbols. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method updates the enumerator position by the number of elements fetched.
        /// </remarks>
        [PreserveSig]
        new HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Retrieves the previous symbols in order by address.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumerator to be retrieved.</param>
        /// <param name="rgelt">[out] An array that is to be filled in with <see cref="IDiaSymbol"/> objects that represent the desired symbols.</param>
        /// <param name="pceltFetched">[out] Returns the number of symbols in the fetched enumerator.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no previous symbols. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method updates the enumerator position by the number of elements fetched.
        /// </remarks>
        [PreserveSig]
        new HRESULT Prev(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);

        /// <summary>
        /// Makes a copy of an object.
        /// </summary>
        /// <param name="ppenum">[out] Returns an <see cref="IDiaEnumSymbolsByAddr"/> object that contains a duplicate of the enumerator. The symbols are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbolsByAddr ppenum);
#endif

        [PreserveSig]
        HRESULT symbolByAddrEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        [PreserveSig]
        HRESULT symbolByRVAEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int relativeVirtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        [PreserveSig]
        HRESULT symbolByVAEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] long virtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        [PreserveSig]
        HRESULT NextEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);

        [PreserveSig]
        HRESULT PrevEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);
    }
}
