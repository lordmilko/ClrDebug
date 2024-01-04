namespace ClrDebug.DbgEng
{
    public class SourceCodeDownloadUrlLinkProvider : ComObject<ISourceCodeDownloadUrlLinkProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceCodeDownloadUrlLinkProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SourceCodeDownloadUrlLinkProvider(ISourceCodeDownloadUrlLinkProvider raw) : base(raw)
        {
        }

        #region ISourceCodeDownloadUrlLinkProvider
        #region ProvideSourceCodeFileUrlList

        public object[] ProvideSourceCodeFileUrlList(ISvcModule pModule, string sourceCodeFileSpec, string algorithmRetrievalName, string algorithmParameters)
        {
            object[] ppUrlList;
            TryProvideSourceCodeFileUrlList(pModule, sourceCodeFileSpec, algorithmRetrievalName, algorithmParameters, out ppUrlList).ThrowDbgEngNotOK();

            return ppUrlList;
        }

        public HRESULT TryProvideSourceCodeFileUrlList(ISvcModule pModule, string sourceCodeFileSpec, string algorithmRetrievalName, string algorithmParameters, out object[] ppUrlList)
        {
            /*HRESULT ProvideSourceCodeFileUrlList(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string sourceCodeFileSpec,
            [In, MarshalAs(UnmanagedType.LPWStr)] string algorithmRetrievalName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string algorithmParameters,
            [SRI.Out, MarshalAs(UnmanagedType.SafeArray)] out object[] ppUrlList);*/
            ppUrlList = null;
            HRESULT hr = Raw.ProvideSourceCodeFileUrlList(pModule, sourceCodeFileSpec, algorithmRetrievalName, algorithmParameters, out ppUrlList);

            return hr;
        }

        #endregion
        #endregion
    }
}
