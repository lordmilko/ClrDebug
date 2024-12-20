namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a "simple interface" around the mapping of addresses to lines of code within the image for inlined locations.<para/>
    /// This is an optional interface for symbol sets to implement. A symbol set which handles inlined frames should always implement this interface.<para/>
    /// Reverse mappings require the more advanced ISvcSymbolSetLineResolution interface (not as yet defined) as there are nearly always multiple mappings for an inlined method.
    /// </summary>
    public class SvcSymbolSetSimpleInlineSourceLineResolution : ComObject<ISvcSymbolSetSimpleInlineSourceLineResolution>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetSimpleInlineSourceLineResolution"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetSimpleInlineSourceLineResolution(ISvcSymbolSetSimpleInlineSourceLineResolution raw) : base(raw)
        {
        }

        #region ISvcSymbolSetSimpleInlineSourceLineResolution
        #region FindSourceLineByOffsetAndInlineSymbol

        /// <summary>
        /// FindSourceLineByOffsetAndInlineSymbol Works similarly to ISvcSymbolSetSimpleLineResolution::FindSourceLineByOffset excepting that it passes a specific inline frame to indicate which of multiply nested inline functions to return the line of code for.<para/>
        /// If no inline symbol is provided or the outer function symbol is provided, this operates identically to FindSourceLineByOffset.
        /// </summary>
        public FindSourceLineByOffsetAndInlineSymbolResult FindSourceLineByOffsetAndInlineSymbol(long moduleOffset, ISvcSymbol inlineSymbol)
        {
            FindSourceLineByOffsetAndInlineSymbolResult result;
            TryFindSourceLineByOffsetAndInlineSymbol(moduleOffset, inlineSymbol, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// FindSourceLineByOffsetAndInlineSymbol Works similarly to ISvcSymbolSetSimpleLineResolution::FindSourceLineByOffset excepting that it passes a specific inline frame to indicate which of multiply nested inline functions to return the line of code for.<para/>
        /// If no inline symbol is provided or the outer function symbol is provided, this operates identically to FindSourceLineByOffset.
        /// </summary>
        public HRESULT TryFindSourceLineByOffsetAndInlineSymbol(long moduleOffset, ISvcSymbol inlineSymbol, out FindSourceLineByOffsetAndInlineSymbolResult result)
        {
            /*HRESULT FindSourceLineByOffsetAndInlineSymbol(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFileName,
            [Out] out long sourceLine,
            [Out] out long lineDisplacement);*/
            string sourceFileName;
            long sourceLine;
            long lineDisplacement;
            HRESULT hr = Raw.FindSourceLineByOffsetAndInlineSymbol(moduleOffset, inlineSymbol, out sourceFileName, out sourceLine, out lineDisplacement);

            if (hr == HRESULT.S_OK)
                result = new FindSourceLineByOffsetAndInlineSymbolResult(sourceFileName, sourceLine, lineDisplacement);
            else
                result = default(FindSourceLineByOffsetAndInlineSymbolResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
