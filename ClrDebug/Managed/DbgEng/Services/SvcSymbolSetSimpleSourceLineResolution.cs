namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetSimpleSourceLineResolution : ComObject<ISvcSymbolSetSimpleSourceLineResolution>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetSimpleSourceLineResolution"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetSimpleSourceLineResolution(ISvcSymbolSetSimpleSourceLineResolution raw) : base(raw)
        {
        }

        #region ISvcSymbolSetSimpleSourceLineResolution
        #region FindOffsetBySourceLine

        public FindOffsetBySourceLineResult FindOffsetBySourceLine(string sourceFileName, long line)
        {
            FindOffsetBySourceLineResult result;
            TryFindOffsetBySourceLine(sourceFileName, line, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryFindOffsetBySourceLine(string sourceFileName, long line, out FindOffsetBySourceLineResult result)
        {
            /*HRESULT FindOffsetBySourceLine(
            [In, MarshalAs(UnmanagedType.LPWStr)] string sourceFileName,
            [In] long line,
            [Out] out long moduleOffset,
            [Out, MarshalAs(UnmanagedType.BStr)] out string actualSourceFileName,
            [Out] out long returnedLine);*/
            long moduleOffset;
            string actualSourceFileName;
            long returnedLine;
            HRESULT hr = Raw.FindOffsetBySourceLine(sourceFileName, line, out moduleOffset, out actualSourceFileName, out returnedLine);

            if (hr == HRESULT.S_OK)
                result = new FindOffsetBySourceLineResult(moduleOffset, actualSourceFileName, returnedLine);
            else
                result = default(FindOffsetBySourceLineResult);

            return hr;
        }

        #endregion
        #region FindSourceLineByOffset

        public FindSourceLineByOffsetResult FindSourceLineByOffset(long moduleOffset)
        {
            FindSourceLineByOffsetResult result;
            TryFindSourceLineByOffset(moduleOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryFindSourceLineByOffset(long moduleOffset, out FindSourceLineByOffsetResult result)
        {
            /*HRESULT FindSourceLineByOffset(
            [In] long moduleOffset,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFileName,
            [Out] out long sourceLine,
            [Out] out long lineDisplacement);*/
            string sourceFileName;
            long sourceLine;
            long lineDisplacement;
            HRESULT hr = Raw.FindSourceLineByOffset(moduleOffset, out sourceFileName, out sourceLine, out lineDisplacement);

            if (hr == HRESULT.S_OK)
                result = new FindSourceLineByOffsetResult(sourceFileName, sourceLine, lineDisplacement);
            else
                result = default(FindSourceLineByOffsetResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
