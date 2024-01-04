namespace ClrDebug.DbgEng
{
    public class SvcSourceFileEnumerator : ComObject<ISvcSourceFileEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSourceFileEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSourceFileEnumerator(ISvcSourceFileEnumerator raw) : base(raw)
        {
        }

        #region ISvcSourceFileEnumerator
        #region Next

        public SvcSourceFile Next
        {
            get
            {
                SvcSourceFile sourceFileResult;
                TryGetNext(out sourceFileResult).ThrowDbgEngNotOK();

                return sourceFileResult;
            }
        }

        public HRESULT TryGetNext(out SvcSourceFile sourceFileResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile sourceFile);*/
            ISvcSourceFile sourceFile;
            HRESULT hr = Raw.GetNext(out sourceFile);

            if (hr == HRESULT.S_OK)
                sourceFileResult = sourceFile == null ? null : new SvcSourceFile(sourceFile);
            else
                sourceFileResult = default(SvcSourceFile);

            return hr;
        }

        #endregion
        #region Reset

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
