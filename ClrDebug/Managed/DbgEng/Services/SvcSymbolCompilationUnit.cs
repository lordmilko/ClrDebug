namespace ClrDebug.DbgEng
{
    public class SvcSymbolCompilationUnit : ComObject<ISvcSymbolCompilationUnit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolCompilationUnit"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolCompilationUnit(ISvcSymbolCompilationUnit raw) : base(raw)
        {
        }

        #region ISvcSymbolCompilationUnit
        #region PrimarySource

        public SvcSourceFile PrimarySource
        {
            get
            {
                SvcSourceFile primarySourceFileResult;
                TryGetPrimarySource(out primarySourceFileResult).ThrowDbgEngNotOK();

                return primarySourceFileResult;
            }
        }

        public HRESULT TryGetPrimarySource(out SvcSourceFile primarySourceFileResult)
        {
            /*HRESULT GetPrimarySource(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile primarySourceFile);*/
            ISvcSourceFile primarySourceFile;
            HRESULT hr = Raw.GetPrimarySource(out primarySourceFile);

            if (hr == HRESULT.S_OK)
                primarySourceFileResult = primarySourceFile == null ? null : new SvcSourceFile(primarySourceFile);
            else
                primarySourceFileResult = default(SvcSourceFile);

            return hr;
        }

        #endregion
        #region Language

        public GetLanguageResult Language
        {
            get
            {
                GetLanguageResult result;
                TryGetLanguage(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetLanguage(out GetLanguageResult result)
        {
            /*HRESULT GetLanguage(
            [Out] out SvcSourceLanguage language,
            [Out] out int version);*/
            SvcSourceLanguage language;
            int version;
            HRESULT hr = Raw.GetLanguage(out language, out version);

            if (hr == HRESULT.S_OK)
                result = new GetLanguageResult(language, version);
            else
                result = default(GetLanguageResult);

            return hr;
        }

        #endregion
        #region Producer

        public string Producer
        {
            get
            {
                string producerString;
                TryGetProducer(out producerString).ThrowDbgEngNotOK();

                return producerString;
            }
        }

        public HRESULT TryGetProducer(out string producerString)
        {
            /*HRESULT GetProducer(
            [Out, MarshalAs(UnmanagedType.BStr)] out string producerString);*/
            return Raw.GetProducer(out producerString);
        }

        #endregion
        #endregion
    }
}
