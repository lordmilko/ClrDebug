namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Returns certain attributes of the stack. This interface is optional on most frame types. It is mandatory on any generic frame and optional on other types.
    /// </summary>
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

        /// <summary>
        /// Gets the "textual representation" of this stack frame. The meaning of this can vary by stack provider. Conceptually, this is what a debugger would place in a "call stack" window representing this frame.<para/>
        /// Anyone who implements ISvcStackProviderFrameAttributes *MUST* implement GetFrameText.
        /// </summary>
        public string FrameText
        {
            get
            {
                string frameText;
                TryGetFrameText(out frameText).ThrowDbgEngNotOK();

                return frameText;
            }
        }

        /// <summary>
        /// Gets the "textual representation" of this stack frame. The meaning of this can vary by stack provider. Conceptually, this is what a debugger would place in a "call stack" window representing this frame.<para/>
        /// Anyone who implements ISvcStackProviderFrameAttributes *MUST* implement GetFrameText.
        /// </summary>
        public HRESULT TryGetFrameText(out string frameText)
        {
            /*HRESULT GetFrameText(
            [Out, MarshalAs(UnmanagedType.BStr)] out string frameText);*/
            return Raw.GetFrameText(out frameText);
        }

        #endregion
        #region SourceAssociation

        /// <summary>
        /// Gets the "source association" for this stack frame (e.g.: the source file, line number, and column number). This is an optional attribute.<para/>
        /// It is legal for any implementation to E_NOTIMPL this. The line number and column number are optional (albeit a column cannot be provided without a line).<para/>
        /// A client may legally return a value of zero for either of these indicating that it is not available or not relevant (e.g.: compiler generated code which does not necessarily map to a line of code may legally return 0 for the source line).
        /// </summary>
        public GetSourceAssociationResult SourceAssociation
        {
            get
            {
                GetSourceAssociationResult result;
                TryGetSourceAssociation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the "source association" for this stack frame (e.g.: the source file, line number, and column number). This is an optional attribute.<para/>
        /// It is legal for any implementation to E_NOTIMPL this. The line number and column number are optional (albeit a column cannot be provided without a line).<para/>
        /// A client may legally return a value of zero for either of these indicating that it is not available or not relevant (e.g.: compiler generated code which does not necessarily map to a line of code may legally return 0 for the source line).
        /// </summary>
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
