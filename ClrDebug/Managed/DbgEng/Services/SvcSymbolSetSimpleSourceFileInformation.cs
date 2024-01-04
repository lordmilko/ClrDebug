namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetSimpleSourceFileInformation : ComObject<ISvcSymbolSetSimpleSourceFileInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetSimpleSourceFileInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetSimpleSourceFileInformation(ISvcSymbolSetSimpleSourceFileInformation raw) : base(raw)
        {
        }

        #region ISvcSymbolSetSimpleSourceFileInformation
        #region GetSourceFileById

        public SvcSourceFile GetSourceFileById(long id)
        {
            SvcSourceFile sourceFileResult;
            TryGetSourceFileById(id, out sourceFileResult).ThrowDbgEngNotOK();

            return sourceFileResult;
        }

        public HRESULT TryGetSourceFileById(long id, out SvcSourceFile sourceFileResult)
        {
            /*HRESULT GetSourceFileById(
            [In] long id,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile sourceFile);*/
            ISvcSourceFile sourceFile;
            HRESULT hr = Raw.GetSourceFileById(id, out sourceFile);

            if (hr == HRESULT.S_OK)
                sourceFileResult = sourceFile == null ? null : new SvcSourceFile(sourceFile);
            else
                sourceFileResult = default(SvcSourceFile);

            return hr;
        }

        #endregion
        #region EnumerateSourceFiles

        public SvcSourceFileEnumerator EnumerateSourceFiles(string fileName, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSourceFileEnumerator sourceFileEnumResult;
            TryEnumerateSourceFiles(fileName, pSearchInfo, out sourceFileEnumResult).ThrowDbgEngNotOK();

            return sourceFileEnumResult;
        }

        public HRESULT TryEnumerateSourceFiles(string fileName, SvcSymbolSearchInfo pSearchInfo, out SvcSourceFileEnumerator sourceFileEnumResult)
        {
            /*HRESULT EnumerateSourceFiles(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFileEnumerator sourceFileEnum);*/
            ISvcSourceFileEnumerator sourceFileEnum;
            HRESULT hr = Raw.EnumerateSourceFiles(fileName, ref pSearchInfo, out sourceFileEnum);

            if (hr == HRESULT.S_OK)
                sourceFileEnumResult = sourceFileEnum == null ? null : new SvcSourceFileEnumerator(sourceFileEnum);
            else
                sourceFileEnumResult = default(SvcSourceFileEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
