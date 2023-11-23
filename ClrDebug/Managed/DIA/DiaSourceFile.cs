namespace ClrDebug.DIA
{
    /// <summary>
    /// Represents a source file.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the IDiaEnumSourceFiles or IDiaEnumSourceFiles methods. See the example for details.
    /// </remarks>
    public class DiaSourceFile : ComObject<IDiaSourceFile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaSourceFile"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaSourceFile(IDiaSourceFile raw) : base(raw)
        {
        }

        #region IDiaSourceFile
        #region UniqueId

        /// <summary>
        /// Retrieves a simple integer key value that is unique for this image.
        /// </summary>
        public int UniqueId
        {
            get
            {
                int pRetVal;
                TryGetUniqueId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a simple integer key value that is unique for this image.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a simple integer key value that is unique for this image.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Comparing keys rather than strings can accelerate line number processing.
        /// </remarks>
        public HRESULT TryGetUniqueId(out int pRetVal)
        {
            /*HRESULT get_uniqueId(
            [Out] out int pRetVal);*/
            return Raw.get_uniqueId(out pRetVal);
        }

        #endregion
        #region FileName

        /// <summary>
        /// Retrieves the source file name.
        /// </summary>
        public string FileName
        {
            get
            {
                string pRetVal;
                TryGetFileName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the source file name.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the source file name.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetFileName(out string pRetVal)
        {
            /*HRESULT get_fileName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);*/
            return Raw.get_fileName(out pRetVal);
        }

        #endregion
        #region ChecksumType

        /// <summary>
        /// Retrieves the checksum type.
        /// </summary>
        public CV_SourceChksum_t ChecksumType
        {
            get
            {
                CV_SourceChksum_t pRetVal;
                TryGetChecksumType(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the checksum type.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the checksum type.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The checksum type is a value that can be mapped to a checksum algorithm. For example, the standard PDB file format
        /// can typically have one of the following values: The CryptoAPI labels are from the ALG_ID enumeration. For more
        /// information on hashing algorithms, consult the CryptoAPI section of the Microsoft Windows SDK. To obtain the actual
        /// checksum bytes for the source file, call the IDiaSourceFile method.
        /// </remarks>
        public HRESULT TryGetChecksumType(out CV_SourceChksum_t pRetVal)
        {
            /*HRESULT get_checksumType(
            [Out] out CV_SourceChksum_t pRetVal);*/
            return Raw.get_checksumType(out pRetVal);
        }

        #endregion
        #region Compilands

        /// <summary>
        /// Retrieves an enumerator of compilands that have line numbers referencing this file.
        /// </summary>
        public DiaEnumSymbols Compilands
        {
            get
            {
                DiaEnumSymbols pRetValResult;
                TryGetCompilands(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves an enumerator of compilands that have line numbers referencing this file.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaEnumSymbols object that contains a list of all compilands that have line numbers referencing this file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetCompilands(out DiaEnumSymbols pRetValResult)
        {
            /*HRESULT get_compilands(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols pRetVal);*/
            IDiaEnumSymbols pRetVal;
            HRESULT hr = Raw.get_compilands(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaEnumSymbols(pRetVal);
            else
                pRetValResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region Checksum

        /// <summary>
        /// Retrieves the checksum bytes.
        /// </summary>
        public byte[] Checksum
        {
            get
            {
                byte[] pbData;
                TryGetChecksum(out pbData).ThrowOnNotOK();

                return pbData;
            }
        }

        /// <summary>
        /// Retrieves the checksum bytes.
        /// </summary>
        /// <param name="pbData">[in, out] A buffer that is filled with the checksum bytes. If this parameter is NULL, then pcbData returns the number of bytes required.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// To determine the type of checksum algorithm that was used to generate the checksum bytes, call the IDiaSourceFile
        /// method. The checksum is typically generated from the image of the source file so changes in the source file are
        /// reflected in changes in the checksum bytes. If the checksum bytes do not match a checksum generated from the loaded
        /// image of the file, then the file should be considered damaged or tampered with. Typical checksums are never more
        /// than 32 bytes in size but do not assume that is the maximum size of a checksum. Set the data parameter to NULL
        /// to get the number of bytes required to retrieve the checksum. Then allocate a buffer of the appropriate size and
        /// call this method once more with the new buffer.
        /// </remarks>
        public HRESULT TryGetChecksum(out byte[] pbData)
        {
            /*HRESULT get_checksum(
            [In] int cbData,
            [Out] out int pcbData,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData);*/
            int cbData = 0;
            int pcbData;
            pbData = null;
            HRESULT hr = Raw.get_checksum(cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.get_checksum(cbData, out pcbData, pbData);
            fail:
            return hr;
        }

        #endregion
        #endregion
    }
}
