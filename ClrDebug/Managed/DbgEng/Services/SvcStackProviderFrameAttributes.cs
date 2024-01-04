namespace ClrDebug.DbgEng
{
    public class SvcStackProviderFrameAttributes : ComObject<ISvcStackProviderFrameAttributes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackProviderFrameAttributes"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackProviderFrameAttributes(ISvcStackProviderFrameAttributes raw) : base(raw)
        {
        }

        #region ISvcStackProviderFrameAttributes
        #region FrameText

        public string FrameText
        {
            get
            {
                string frameText;
                TryGetFrameText(out frameText).ThrowDbgEngNotOK();

                return frameText;
            }
        }

        public HRESULT TryGetFrameText(out string frameText)
        {
            /*HRESULT GetFrameText(
            [Out, MarshalAs(UnmanagedType.BStr)] out string frameText);*/
            return Raw.GetFrameText(out frameText);
        }

        #endregion
        #region SourceAssociation

        public GetSourceAssociationResult SourceAssociation
        {
            get
            {
                GetSourceAssociationResult result;
                TryGetSourceAssociation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetSourceAssociation(out GetSourceAssociationResult result)
        {
            /*HRESULT GetSourceAssociation(
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFile,
            [Out] out long sourceLine,
            [Out] out long sourceColumn);*/
            string sourceFile;
            long sourceLine;
            long sourceColumn;
            HRESULT hr = Raw.GetSourceAssociation(out sourceFile, out sourceLine, out sourceColumn);

            if (hr == HRESULT.S_OK)
                result = new GetSourceAssociationResult(sourceFile, sourceLine, sourceColumn);
            else
                result = default(GetSourceAssociationResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
