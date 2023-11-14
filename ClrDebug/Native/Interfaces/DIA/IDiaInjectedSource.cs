using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Accesses injected source code stored in the DIA data source.
    /// </summary>
    /// <remarks>
    /// Injected source is text that is injected during compilation. This does not mean the preprocessor #include used
    /// in C++. Obtain this interface by calling the IDiaEnumInjectedSources or IDiaEnumInjectedSources methods. See the
    /// IDiaEnumInjectedSources interface for an example of obtaining the IDiaInjectedSource interface.
    /// </remarks>
    [Guid("AE605CDC-8105-4A23-B710-3259F1E26112")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaInjectedSource
    {
        /// <summary>
        /// Retrieves a cyclic redundancy check (CRC) calculated from the bytes of the source code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the CRC calculated from the bytes of the source code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_crc(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the number of bytes of code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is the length of the source code and is the same value as returned by the IDiaInjectedSource
        /// method.
        /// </remarks>
        [PreserveSig]
        HRESULT get_length(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the file name for the source.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the file name for the source.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_fileName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);

        /// <summary>
        /// Retrieves the object file name to which the source was compiled.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the object file name to which the source was compiled.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_objectFileName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);

        /// <summary>
        /// Retrieves the name given to non-file source code; that is, code that was injected.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name given to injected non-file source code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_virtualFilename(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);

        /// <summary>
        /// Retrieves the indicator of the source compression used.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the indicator of the source compression used. A value of zero indicates that no source compression was used.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is specific to the compiler used. For example, a compiler might use Run-Length
        /// Encoding or Huffman-style compression.
        /// </remarks>
        [PreserveSig]
        HRESULT get_sourceCompression(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the source code bytes.
        /// </summary>
        /// <param name="cbData">[in] The number of bytes that represents the size of the data buffer.</param>
        /// <param name="pcbData">[out] Returns the number of bytes that represents the bytes returned. If data is NULL, then pcbData is the total number of bytes of data available.</param>
        /// <param name="pbData">[out] A buffer that is to be filled in with the source bytes.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_source(
            [In] int cbData,
            [Out] out int pcbData,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData);
    }
}
