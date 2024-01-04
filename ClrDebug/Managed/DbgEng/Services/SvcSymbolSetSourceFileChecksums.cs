namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetSourceFileChecksums : ComObject<ISvcSymbolSetSourceFileChecksums>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetSourceFileChecksums"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetSourceFileChecksums(ISvcSymbolSetSourceFileChecksums raw) : base(raw)
        {
        }

        #region ISvcSymbolSetSourceFileChecksums
        #region GetLegacySourceFileChecksumInformation

        public GetLegacySourceFileChecksumInformationResult GetLegacySourceFileChecksumInformation(string fileName)
        {
            GetLegacySourceFileChecksumInformationResult result;
            TryGetLegacySourceFileChecksumInformation(fileName, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetLegacySourceFileChecksumInformation(string fileName, out GetLegacySourceFileChecksumInformationResult result)
        {
            /*HRESULT GetLegacySourceFileChecksumInformation(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [Out] out SvcChecksumKind pChecksumKind,
            [Out] out int pChecksumSize);*/
            SvcChecksumKind pChecksumKind;
            int pChecksumSize;
            HRESULT hr = Raw.GetLegacySourceFileChecksumInformation(fileName, out pChecksumKind, out pChecksumSize);

            if (hr == HRESULT.S_OK)
                result = new GetLegacySourceFileChecksumInformationResult(pChecksumKind, pChecksumSize);
            else
                result = default(GetLegacySourceFileChecksumInformationResult);

            return hr;
        }

        #endregion
        #region GetLegacySourceFileChecksum

        public GetLegacySourceFileChecksumResult GetLegacySourceFileChecksum(string fileName)
        {
            GetLegacySourceFileChecksumResult result;
            TryGetLegacySourceFileChecksum(fileName, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetLegacySourceFileChecksum(string fileName, out GetLegacySourceFileChecksumResult result)
        {
            /*HRESULT GetLegacySourceFileChecksum(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [Out] out SvcChecksumKind pChecksumKind,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pChecksum,
            [In] int checksumSize,
            [Out] out int pActualBytesWritten);*/
            SvcChecksumKind pChecksumKind;
            byte[] pChecksum;
            int checksumSize = 0;
            int pActualBytesWritten;
            HRESULT hr = Raw.GetLegacySourceFileChecksum(fileName, out pChecksumKind, null, checksumSize, out pActualBytesWritten);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            checksumSize = pActualBytesWritten;
            pChecksum = new byte[checksumSize];
            hr = Raw.GetLegacySourceFileChecksum(fileName, out pChecksumKind, pChecksum, checksumSize, out pActualBytesWritten);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLegacySourceFileChecksumResult(pChecksumKind, pChecksum);

                return hr;
            }

            fail:
            result = default(GetLegacySourceFileChecksumResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
