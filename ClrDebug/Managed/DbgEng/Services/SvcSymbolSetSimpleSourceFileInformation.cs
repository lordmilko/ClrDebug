namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a "simple interface" around the enumeration of source files that contribute to a particular binary and their association to compilation units / compilands.<para/>
    /// This is an optional interface for symbol sets to implement.
    /// </summary>
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

        /// <summary>
        /// Gets a source file by its unique identifier.
        /// </summary>
        public SvcSourceFile GetSourceFileById(long id)
        {
            SvcSourceFile sourceFileResult;
            TryGetSourceFileById(id, out sourceFileResult).ThrowDbgEngNotOK();

            return sourceFileResult;
        }

        /// <summary>
        /// Gets a source file by its unique identifier.
        /// </summary>
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

        /// <summary>
        /// Enumerates all of the source files which contribute to the image.
        /// </summary>
        public SvcSourceFileEnumerator EnumerateSourceFiles(string fileName, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSourceFileEnumerator sourceFileEnumResult;
            TryEnumerateSourceFiles(fileName, pSearchInfo, out sourceFileEnumResult).ThrowDbgEngNotOK();

            return sourceFileEnumResult;
        }

        /// <summary>
        /// Enumerates all of the source files which contribute to the image.
        /// </summary>
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
