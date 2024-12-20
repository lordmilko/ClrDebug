namespace ClrDebug.DbgEng
{
    public class SvcSymbolCompilationUnitSources : ComObject<ISvcSymbolCompilationUnitSources>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolCompilationUnitSources"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolCompilationUnitSources(ISvcSymbolCompilationUnitSources raw) : base(raw)
        {
        }

        #region ISvcSymbolCompilationUnitSources
        #region EnumerateSourceFiles

        /// <summary>
        /// Enumerates all of the source files which contribute to this compilation unit.
        /// </summary>
        public SvcSourceFileEnumerator EnumerateSourceFiles(string fileName, SvcSymbolSearchInfo pSearchInfo)
        {
            SvcSourceFileEnumerator sourceFileEnumResult;
            TryEnumerateSourceFiles(fileName, pSearchInfo, out sourceFileEnumResult).ThrowDbgEngNotOK();

            return sourceFileEnumResult;
        }

        /// <summary>
        /// Enumerates all of the source files which contribute to this compilation unit.
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
