using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Represents a source file.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the <see cref="IDiaEnumSourceFiles.Item"/> or <see cref="IDiaEnumSourceFiles.Next"/>
    /// methods. See the example for details.
    /// </remarks>
    [Guid("A2EF5353-F5A8-4EB3-90D2-CB526ACB3CDD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaSourceFile
    {
        /// <summary>
        /// Retrieves a simple integer key value that is unique for this image.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a simple integer key value that is unique for this image.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Comparing keys rather than strings can accelerate line number processing.
        /// </remarks>
        [PreserveSig]
        HRESULT get_uniqueId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the source file name.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the source file name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_fileName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Retrieves the checksum type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the checksum type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The checksum type is a value that can be mapped to a checksum algorithm. For example, the standard PDB file format
        /// can typically have one of the following values: The CryptoAPI labels are from the ALG_ID enumeration. For more
        /// information on hashing algorithms, consult the CryptoAPI section of the Microsoft Windows SDK. To obtain the actual
        /// checksum bytes for the source file, call the <see cref="get_checksum"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT get_checksumType(
            [Out] out CV_SourceChksum_t pRetVal);

        /// <summary>
        /// Retrieves an enumerator of compilands that have line numbers referencing this file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an <see cref="IDiaEnumSymbols"/> object that contains a list of all compilands that have line numbers referencing this file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_compilands(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols pRetVal);

        /// <summary>
        /// Retrieves the checksum bytes.
        /// </summary>
        /// <param name="cbData">[in] Size of the data buffer, in bytes.</param>
        /// <param name="pcbData">[out] Returns the number of checksum bytes. This parameter cannot be NULL.</param>
        /// <param name="pbData">[in, out] A buffer that is filled with the checksum bytes. If this parameter is NULL, then pcbData returns the number of bytes required.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// To determine the type of checksum algorithm that was used to generate the checksum bytes, call the <see cref="get_checksumType"/>
        /// method. The checksum is typically generated from the image of the source file so changes in the source file are
        /// reflected in changes in the checksum bytes. If the checksum bytes do not match a checksum generated from the loaded
        /// image of the file, then the file should be considered damaged or tampered with. Typical checksums are never more
        /// than 32 bytes in size but do not assume that is the maximum size of a checksum. Set the data parameter to NULL
        /// to get the number of bytes required to retrieve the checksum. Then allocate a buffer of the appropriate size and
        /// call this method once more with the new buffer.
        /// </remarks>
        [PreserveSig]
        HRESULT get_checksum(
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData);
    }
}
