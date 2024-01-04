namespace ClrDebug.DbgEng
{
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

        public FindSourceLineByOffsetAndInlineSymbolResult FindSourceLineByOffsetAndInlineSymbol(long moduleOffset, ISvcSymbol inlineSymbol)
        {
            FindSourceLineByOffsetAndInlineSymbolResult result;
            TryFindSourceLineByOffsetAndInlineSymbol(moduleOffset, inlineSymbol, out result).ThrowDbgEngNotOK();

            return result;
        }

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
